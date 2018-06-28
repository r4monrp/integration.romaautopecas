using integration.romaautopecas.core.httptransfermodel.aicbrasil;
using integration.romaautopecas.core.httptransfermodel.authenticate;
using integration.romaautopecas.core.httptransfermodel.brand;
using integration.romaautopecas.core.httptransfermodel.order;
using integration.romaautopecas.core.httptransfermodel.product;
using integration.romaautopecas.core.models.aicbrasil.customer;
using integration.romaautopecas.core.models.aicbrasil.order;
using integration.romaautopecas.core.models.aicbrasil.product;
using integration.romaautopecas.core.models.idealeware.authenticate;
using integration.romaautopecas.core.models.idealeware.brand;
using integration.romaautopecas.core.models.idealeware.order;
using integration.romaautopecas.core.models.idealeware.product;
using integration.romaautopecas.core.models.integration;
using integration.romaautopecas.core.providers.aicbrasil;
using integration.romaautopecas.core.providers.idealeware;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.managers
{
    public class IntegrationManager : IIntegrationManager
    {
        #region Objetos
        private readonly IHttpTransferAuthenticate _HttpTransferAutenthicateApi;
        private readonly IHttpTransferBrand _HttpTransferBrandApi;
        private readonly IHttpTransferOrder _HttpTransferOrder;
        private readonly IHttpTransferProduct _HttpTransferProductModel;
        private readonly IHttpTransferAicBrasil _HttpTransferAicBrasilApi;
        private readonly ILogger _logger;
        private JsonDateTimeModel _jsonDateTimeModel;
        #endregion

        #region Construtor
        public IntegrationManager(IHttpTransferAuthenticate httpTransferAuthenticateModel, IHttpTransferBrand httpTransferBrandModel,
            IHttpTransferOrder httpTransferOrder, IHttpTransferProduct httpTransferProductModel, IHttpTransferAicBrasil httpTransferAicBrasil, ILoggerFactory logger)
        {
            this._HttpTransferAutenthicateApi = httpTransferAuthenticateModel;
            this._HttpTransferBrandApi = httpTransferBrandModel;
            this._HttpTransferOrder = httpTransferOrder;
            this._HttpTransferProductModel = httpTransferProductModel;
            this._HttpTransferAicBrasilApi = httpTransferAicBrasil;
            _jsonDateTimeModel = ReadJsonFile();
            this._logger = logger.CreateLogger("IntegrationManager");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - IntegrationManager em execução.");
        }
        #endregion

        #region Autenticação no ERP conforme code
        /// <summary>
        /// Autentica no erp conforme code
        /// </summary>
        /// <param name="code">code</param>
        public void RunIntegrationAuthenticateERP(string code)
        {
            var tokenAic = _HttpTransferAicBrasilApi.AicAuthenticate(code);

            if (tokenAic == null)
                return;

            var runCreate = RunIntegrationCreateProductsAndBrands(tokenAic.access_token);
            var runUpdate = RunIntegrationUpdateProductsAndBrands(tokenAic.access_token);
            RunIntegrationOrder(tokenAic.access_token);
        }
        #endregion

        #region Integração de Pedidos
        /// <summary>
        /// Iniciar a integração do serviço - Pedidos
        /// </summary>
        public void RunIntegrationOrder(string tokenAicBrasil)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationOrder em execução.");

            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands- Token AIC : {tokenAicBrasil}");

            if (string.IsNullOrWhiteSpace(tokenAicBrasil))
                return;

            /* autenticação na idealeWare*/
            var token = _HttpTransferAutenthicateApi.Login(AppSettings.GetUserIdealeware());
            if (token == null)
                return;

            //Busca os pedidos nao integrados do ecommerce
            var ordersNotIntegrated = _HttpTransferOrder.GetOrdersNotIntegrated(token.AccessToken);
            if (ordersNotIntegrated == null)
                return;

            //Loop nos pedidos
            foreach (var order in ordersNotIntegrated)
            {
                try
                {
                    //Verifico se o cliente existe 
                    var customersAicBrasil = _HttpTransferAicBrasilApi.GetCustomersByCpfAsync(tokenAicBrasil, order.Customer.Cpf_Cnpj);

                    if (!customersAicBrasil.customers.Any())
                    {
                        var resultInsertCustumer = _HttpTransferAicBrasilApi.InsertCustomerAsync(tokenAicBrasil, new CustomerInsertAicBrasil
                        {
                            customers = new List<CustomerCreateAicBrasil> {
                                new CustomerCreateAicBrasil
                            {
                                code = order.Customer.Id.ToString(),
                                cpfcnpj = order.Customer.Cpf_Cnpj,
                                email = order.Customer.Email,
                                firstname = order.Customer.Firstname_Companyname,
                                lastname = order.Customer.Lastname_Tradingname,
                                ie = order.Customer.Rg_Ie,
                                phone = order.Customer.Phone,
                                billingaddress = new BillingAddressAicBrasil
                                {
                                    address1 = order.BillingAddress.AddressLine1,
                                    address2 = order.BillingAddress.AddressLine2,
                                    city = order.BillingAddress.City,
                                    country = "BR",
                                    district = order.BillingAddress.District,
                                    number = Convert.ToInt32(order.BillingAddress.Number),
                                    state = order.BillingAddress.State,
                                    zipCode = order.BillingAddress.ZipCode
                                },
                                shippingaddress = new ShippingAddressAicBrasil
                                {
                                    address1 = order.DeliveryAddress.AddressLine1,
                                    address2 = order.DeliveryAddress.AddressLine2,
                                    city = order.DeliveryAddress.City,
                                    country = "BR",
                                    district = order.DeliveryAddress.District,
                                    number = Convert.ToInt32(order.DeliveryAddress.Number),
                                    state = order.DeliveryAddress.State,
                                    zipcode = order.DeliveryAddress.ZipCode
                                }
                            }
                         }
                        });

                        order.Customer.Id = resultInsertCustumer.customers.FirstOrDefault().code;
                    }
                    else
                    {
                        order.Customer.Id = customersAicBrasil.customers?.FirstOrDefault()?.code ?? order.Customer.Id;
                    }

                    _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} -Number {order.OrderNumber} - Iniciando integração do pedido.");

                    //Preenche informaçoes basicas do pedido
                    var orderAic = new AicOrderModel()
                    {
                        orderTotal = order.OrderPrice,
                        orderDiscount = order.TotalDiscountPrice,
                        destinationtype = "VendaUsuarioFinal",
                        shippingtype = "PorContaDoDestinatarioRemetente",
                        customercode = order.Customer.Id.ToString(),
                    };


                    switch (order.Payment.PaymentMethods.FirstOrDefault().Type)
                    {
                        case enPaymentMethodType.CreditCard:
                            orderAic.billingtype = "CreditCard";
                            orderAic.installments = order.Payment.PaymentMethods.FirstOrDefault().CreditCardInstallmentCount;
                            break;
                        case enPaymentMethodType.BankSlip:
                            orderAic.billingtype = "Boleto";
                            orderAic.installments = 1;
                            break;
                        case enPaymentMethodType.Money:
                            orderAic.billingtype = "Money";
                            orderAic.installments = 1;
                            break;
                        case enPaymentMethodType.Other:
                            orderAic.billingtype = "Money";
                            orderAic.installments = 1;
                            break;
                    }

                    //Loop nos produtos do pedido
                    orderAic.orderitens = new List<AicItemOrderModel>();
                    foreach (var item in order.Products)
                    {
                        orderAic.orderitens.Add(new AicItemOrderModel()
                        {
                            code = item.Sku.Code,
                        });
                    }

                    var orderInsert = new AicOrderInsertModel { orders = new List<AicOrderModel> { orderAic } };

                    //Inserir o pedido no ERP
                    var orderAicIntegrated = _HttpTransferAicBrasilApi.InsertOrderAsync(tokenAicBrasil, orderInsert);
                    if (orderAicIntegrated == null)
                        continue;

                    //Atualiza o pedido para integrado no ecommerce
                    var orderIntregrated = _HttpTransferOrder.UpdateOrderIntegrated(token.AccessToken, order.Id.ToString());
                    if (orderIntregrated == null)
                        continue;

                    _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} -Pedido {order.OrderNumber} - Finalizado Integração com sucesso");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} -Pedido {order.OrderNumber} - RunIntegrationOrder ERRO  {ex.Message}.");
                    continue;
                }
            }


        }
        #endregion

        #region Integração de Produtos e Marcas
        /// <summary>
        /// Iniciar a integração do serviço - Produtos/Marcas - Criaçao
        /// </summary>
        public bool RunIntegrationCreateProductsAndBrands(string tokenAicBrasil)
        {

            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands em execução.");

            var productsAicBrasil = new List<ProductDetailAicBrasil>();
            int CountProductsAicBrasil = 0;
            decimal maxPages = 0;
            try
            {
                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands em execução.");

                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands- Token AIC : {tokenAicBrasil}");

                if (string.IsNullOrWhiteSpace(tokenAicBrasil))
                    return false;

                /* listagem de produtos aicBrasil */
                var alterDate = _jsonDateTimeModel.LastDateExecutionCreate;

                var maxDate = DateTime.Now;

                var resultCount = _HttpTransferAicBrasilApi.GetCountCreateProductsAsync(tokenAicBrasil, alterDate.ToUniversalTime(), maxDate.ToUniversalTime());
                CountProductsAicBrasil = resultCount.Count;

                if (CountProductsAicBrasil > 0)
                {
                    maxPages = Math.Ceiling((decimal)CountProductsAicBrasil / 50);
                    for (int i = 1; i <= maxPages; i++)
                    {
                        var resultProductsAicBrasil = _HttpTransferAicBrasilApi.GetCreateProductsAsync(tokenAicBrasil, alterDate.ToUniversalTime(), maxDate.ToUniversalTime(), 1, 50);
                        if (resultProductsAicBrasil == null || !resultProductsAicBrasil.Any())
                            continue;
                        else
                            productsAicBrasil.AddRange(resultProductsAicBrasil);
                    }
                }

                /* Verifica se possui produto para atualizar */
                if (productsAicBrasil != null && productsAicBrasil.Any())
                {

                    _jsonDateTimeModel.LastDateExecutionCreate = DateTime.Now;

                    /* autenticação na idealeWare*/
                    var token = _HttpTransferAutenthicateApi.Login(AppSettings.GetUserIdealeware());
                    if (token == null)
                        return false;

                    /* listagem de produtos idealeWare*/
                    var productsIdealeware = _HttpTransferProductModel.GetProductsComplete(token.AccessToken);

                    #region Salva as Marcas
                    _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create - (Criação de Marca )- Iniciando integração de marcas.");

                    /* listagem de marcas da idealeWare */
                    var brandsCreate = _HttpTransferBrandApi.GetBrandComplete(token.AccessToken);

                    var brandNotImplemented = productsAicBrasil.Where(p => !brandsCreate.Select(b => b.Code).Contains(p.BrandCode)).ToList();

                    var brandNotImplementedGroupbyCode = brandNotImplemented.GroupBy(b => b.BrandCode);

                    foreach (var brand in brandNotImplementedGroupbyCode)
                    {
                        _HttpTransferBrandApi.CreateBrand(token.AccessToken,
                           new BrandCreate
                           {
                               Code = brand.Key,
                               Name = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                               Status = true,
                               MetaTagDescription = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                               MetaTagTitle = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                           });
                    }

                    #endregion

                    /* listagem de marcas da idealeWare */
                    var brandsUpdate = _HttpTransferBrandApi.GetBrandComplete(token.AccessToken);

                    /*Salva e altera os Produtos*/
                    foreach (var productAicBrasil in productsAicBrasil)
                    {

                        var brand = brandsUpdate.FirstOrDefault(b => b.Code.Equals(productAicBrasil.BrandCode));

                        #region Altera uma marca
                        /*verifica se a marca foi alterada*/
                        if (brand.Name != productAicBrasil.BrandName)
                        {
                            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Update " +
                                $" - (Atualização da Marca - {brand.Name} )- Iniciando integração de marcas.");

                            brand = _HttpTransferBrandApi.UpdateBrand(token.AccessToken,
                            new BrandUpdate
                            {
                                Code = productAicBrasil.BrandCode,
                                Name = productAicBrasil.BrandName,
                                Status = true,
                                Position = brand.Position,
                                MetaTagDescription = brand.MetaTagDescription,
                                MetaTagTitle = brand.MetaTagTitle,
                                Picture = brand.Picture
                            }, brand.Id);
                        }
                        #endregion

                        if (productsIdealeware != null && !productsIdealeware.Any(p => p.Skus.FirstOrDefault().Code == productAicBrasil.Code))

                        {
                            if (productAicBrasil.PartTypeName.ToLower() == "venda")
                            {
                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create -" +
                                    $" (Criação das informações do produto: {productAicBrasil.Name} )- Iniciando integração de criação produto.");

                                var product = _HttpTransferProductModel.CreateProductInformation(token.AccessToken, new ProductInformationCreate
                                {
                                    Brand = new BrandReference { Id = brand.Id, Name = brand.Name },
                                    Name = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear}",
                                    Status = true,
                                    BriefDescription = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}",
                                    Description = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName} "
                                });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create -" +
                                    $" (Criação do sku do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                                _HttpTransferProductModel.CreateProductSKU(token.AccessToken, product.Id, new SkuCreate
                                {
                                    Available = productAicBrasil.Price == 0 ? false : true,
                                    AwaitedProductNotification = true,
                                    Code = productAicBrasil.Code.Trim(),
                                    Ean = "",
                                    Height = productAicBrasil.Height,
                                    Length = productAicBrasil.Length,
                                    Weight = productAicBrasil.Weight,
                                    Width = productAicBrasil.Width,
                                    Price = productAicBrasil.Price == 0 ? 0.01m : productAicBrasil.Price,
                                    Status = true,
                                    Stock = 1,
                                    Variations = new List<VariationReference>
                        {
                           AppSettings.GetDefaultVariation()
                        }
                                });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Criaçao- Update -" +
                                    $" (Atualização da categoria do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                                _HttpTransferProductModel.UpdateProductCategories(token.AccessToken, product.Id, new List<CategoryReference>() { AppSettings.GetDefaultCategory() });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Criaçao- Update -" +
                                   $" (Atualização do SEO do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");
                                var seo = new ProductSeoUpdate()
                                {
                                    MetaTagTitle = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}",
                                    MetaTagDescription = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}"
                                };
                                seo.MetaTagTitle = (seo.MetaTagTitle.Length > 59 ? seo.MetaTagTitle.Substring(0, 59) : seo.MetaTagTitle);
                                _HttpTransferProductModel.UpdateProductSEO(token.AccessToken, product.Id, seo);
                            }
                        }
                    }
                    WriteStoreJsonFile();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} " +
                    $"-Erro na integração de criação produtos e marcas - RunIntegrationCreateProductsAndBrands. ERRO: {ex.Message}.");
                return false;
            }
        }

        /// <summary>
        /// Iniciar a integração do serviço - Produtos/Marcas - Alterados
        /// </summary>
        public bool RunIntegrationUpdateProductsAndBrands(string tokenAicBrasil)
        {

            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands em execução.");

            var productsAicBrasil = new List<ProductDetailAicBrasil>();
            int CountProductsAicBrasil = 0;
            decimal maxPages = 0;
            try
            {
                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands em execução.");

                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - RunIntegrationProductsAndBrands- Token AIC : {tokenAicBrasil}");

                if (string.IsNullOrWhiteSpace(tokenAicBrasil))
                    return false;

                /* listagem de produtos aicBrasil */
                var alterDate = _jsonDateTimeModel.LastDateExecutionUpdate;

                var maxDate = DateTime.Now;

                var resultCount = _HttpTransferAicBrasilApi.GetCountUpdateProductsAsync(tokenAicBrasil, alterDate.ToUniversalTime(), maxDate.ToUniversalTime());
                CountProductsAicBrasil = resultCount.Count;

                if (CountProductsAicBrasil > 0)
                {
                    maxPages = Math.Ceiling((decimal)CountProductsAicBrasil / 50);
                    for (int i = 1; i <= maxPages; i++)
                    {
                        var resultProductsAicBrasil = _HttpTransferAicBrasilApi.GetUpdateProductsAsync(tokenAicBrasil, alterDate.ToUniversalTime(), maxDate.ToUniversalTime(), 1, 50);
                        if (resultProductsAicBrasil == null || !resultProductsAicBrasil.Any())
                            continue;
                        else
                            productsAicBrasil.AddRange(resultProductsAicBrasil);
                    }
                }

                /* Verifica se possui produto para atualizar */
                if (productsAicBrasil != null && productsAicBrasil.Any())
                {

                    _jsonDateTimeModel.LastDateExecutionUpdate = DateTime.Now;

                    /* autenticação na idealeWare*/
                    var token = _HttpTransferAutenthicateApi.Login(AppSettings.GetUserIdealeware());
                    if (token == null)
                        return false;

                    /* listagem de produtos idealeWare*/
                    var productsIdealeware = _HttpTransferProductModel.GetProductsComplete(token.AccessToken);

                    #region Salva as Marcas
                    _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create - (Criação de Marca )- Iniciando integração de marcas.");

                    /* listagem de marcas da idealeWare */
                    var brandsCreate = _HttpTransferBrandApi.GetBrandComplete(token.AccessToken);

                    var brandNotImplemented = productsAicBrasil.Where(p => !brandsCreate.Select(b => b.Code).Contains(p.BrandCode)).ToList();

                    var brandNotImplementedGroupbyCode = brandNotImplemented.GroupBy(b => b.BrandCode);

                    foreach (var brand in brandNotImplementedGroupbyCode)
                    {
                        _HttpTransferBrandApi.CreateBrand(token.AccessToken,
                           new BrandCreate
                           {
                               Code = brand.Key,
                               Name = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                               Status = true,
                               MetaTagDescription = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                               MetaTagTitle = brandNotImplemented.FirstOrDefault(b => b.BrandCode.Equals(brand.Key)).BrandName,
                           });
                    }

                    #endregion

                    /* listagem de marcas da idealeWare */
                    var brandsUpdate = _HttpTransferBrandApi.GetBrandComplete(token.AccessToken);

                    /*Salva e altera os Produtos*/
                    foreach (var productAicBrasil in productsAicBrasil)
                    {

                        var brand = brandsUpdate.FirstOrDefault(b => b.Code.Equals(productAicBrasil.BrandCode));

                        #region Altera uma marca
                        /*verifica se a marca foi alterada*/
                        if (brand.Name != productAicBrasil.BrandName)
                        {
                            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Update " +
                                $" - (Atualização da Marca - {brand.Name} )- Iniciando integração de marcas.");

                            brand = _HttpTransferBrandApi.UpdateBrand(token.AccessToken,
                            new BrandUpdate
                            {
                                Code = productAicBrasil.BrandCode,
                                Name = productAicBrasil.BrandName,
                                Status = true,
                                Position = brand.Position,
                                MetaTagDescription = brand.MetaTagDescription,
                                MetaTagTitle = brand.MetaTagTitle,
                                Picture = brand.Picture
                            }, brand.Id);
                        }
                        #endregion

                        var product = productsIdealeware.FirstOrDefault(p => p.Skus.Any(s => s.Code == productAicBrasil.Code));

                        if (product != null)
                        {

                            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Update -" +
                              $" (Atualização das informações do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                            _HttpTransferProductModel.UpdateProductInformation(token.AccessToken, product.Id, new ProductInformationUpdate
                            {
                                Brand = new BrandReference { Id = brand.Id, Name = brand.Name },
                                Name = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear}",
                                BriefDescription = product.BriefDescription,
                                Description = product.Description,
                                Status = productAicBrasil.Price == 0 ? false : productAicBrasil.PartTypeName?.ToLower() == "venda" ? true : false
                            });

                            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Update -" +
                              $" (Atualização do sku do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                            _HttpTransferProductModel.UpdateProductSKU(token.AccessToken, product.Id, product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).Id, new SkuUpdate
                            {
                                Available = productAicBrasil.Price == 0 ? false : productAicBrasil.PartTypeName?.ToLower() == "venda" ? true : false,
                                AwaitedProductNotification = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).AwaitedProductNotification,
                                Code = productAicBrasil.Code.Trim(),
                                Ean = product.Skus.FirstOrDefault().Ean,
                                Height = productAicBrasil.Height,
                                Length = productAicBrasil.Length,
                                Weight = productAicBrasil.Weight,
                                Width = productAicBrasil.Width,
                                Price = productAicBrasil.Price == 0 ? 0.01m : productAicBrasil.Price,
                                Status = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).Status,
                                Stock = (productAicBrasil.PartTypeName?.ToLower() == "venda" ? 1 : 0),
                                CostPrice = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).CostPrice,
                                DeadlineProductStranded = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).DeadlineProductStranded,
                                MinimumStock = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).MinimumStock,
                                PromotionalPrice = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).PromotionalPrice,
                                PromotionalDateEnd = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).PromotionalDateEnd,
                                PromotionalDateStart = product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).PromotionalDateStart
                            });

                            _HttpTransferProductModel.UpdateProductSKUFreight(token.AccessToken, product.Id, product.Skus.FirstOrDefault(s => s.Code == productAicBrasil.Code).Id, new SkuUpdate
                            {
                                Height = productAicBrasil.Height,
                                Length = productAicBrasil.Length,
                                Weight = productAicBrasil.Weight,
                                Width = productAicBrasil.Width
                            });
                        }
                        else
                        {
                            if (productAicBrasil.PartTypeName.ToLower() == "venda")
                            {
                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create -" +
                                    $" (Criação das informações do produto: {productAicBrasil.Name} )- Iniciando integração de criação produto.");

                                var newProduct = _HttpTransferProductModel.CreateProductInformation(token.AccessToken, new ProductInformationCreate
                                {
                                    Brand = new BrandReference { Id = brand.Id, Name = brand.Name },
                                    Name = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear}",
                                    Status = true,
                                    BriefDescription = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}",
                                    Description = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName} "
                                });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Create -" +
                                    $" (Criação do sku do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                                _HttpTransferProductModel.CreateProductSKU(token.AccessToken, newProduct.Id, new SkuCreate
                                {
                                    Available = productAicBrasil.Price == 0 ? false : true,
                                    AwaitedProductNotification = true,
                                    Code = productAicBrasil.Code.Trim(),
                                    Ean = "",
                                    Height = productAicBrasil.Height,
                                    Length = productAicBrasil.Length,
                                    Weight = productAicBrasil.Weight,
                                    Width = productAicBrasil.Width,
                                    Price = productAicBrasil.Price == 0 ? 0.01m : productAicBrasil.Price,
                                    Status = true,
                                    Stock = 1,
                                    Variations = new List<VariationReference>
                        {
                           AppSettings.GetDefaultVariation()
                        }
                                });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Criaçao- Update -" +
                                    $" (Atualização da categoria do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");

                                _HttpTransferProductModel.UpdateProductCategories(token.AccessToken, newProduct.Id, new List<CategoryReference>() { AppSettings.GetDefaultCategory() });

                                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} Criaçao- Update -" +
                                   $" (Atualização do SEO do produto: {productAicBrasil.Name} )- Iniciando integração de produto.");
                                var seo = new ProductSeoUpdate()
                                {
                                    MetaTagTitle = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}",
                                    MetaTagDescription = $"{productAicBrasil.Name} - {productAicBrasil.VehicleModel} - {productAicBrasil.VehicleYear} - {productAicBrasil.BrandName}"
                                };
                                seo.MetaTagTitle = (seo.MetaTagTitle.Length > 59 ? seo.MetaTagTitle.Substring(0, 59) : seo.MetaTagTitle);
                                _HttpTransferProductModel.UpdateProductSEO(token.AccessToken, newProduct.Id, seo);
                            }

                        }
                    }
                    WriteStoreJsonFile();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} " +
                    $"-Erro na integração de produtos e marcas alterados - RunIntegrationProductsAndBrands. ERRO: {ex.Message}.");
                return false;
            }
        }
        #endregion

        #region Métodos Auxiliares
        public JsonDateTimeModel ReadJsonFile()
        {
            try
            {
                string resourceName = Path.Combine("C:/Static", "Integration.json");
                using (StreamReader sr = File.OpenText(resourceName))
                {
                    string json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<JsonDateTimeModel>(json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ERRO: {ex.Message}.");
                throw;
            }
        }

        public void WriteStoreJsonFile()
        {
            try
            {
                string resourceName = Path.Combine("C:/Static", "Integration.json");
                string json = JsonConvert.SerializeObject(_jsonDateTimeModel, Formatting.Indented);
                File.WriteAllText(resourceName, json);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ERRO: {ex.Message}.");
                throw;
            }
        }
        #endregion
    }
}

