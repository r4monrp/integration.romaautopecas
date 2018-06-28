using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using integration.romaautopecas.core.managers;
using integration.romaautopecas.core.httptransfermodel.authenticate;
using integration.romaautopecas.core.httptransfermodel.brand;
using integration.romaautopecas.core.httptransfermodel.order;
using integration.romaautopecas.core.httptransfermodel.product;
using integration.romaautopecas.core.httptransfermodel.aicbrasil;
using Microsoft.Extensions.Logging;
using integration.romaautopecas.core.httptransfermodel.aicbrasil.product;
using integration.romaautopecas.aicbrasilapis;
using integration.romaautopecas.core.providers.aicbrasil;
using integration.romaautopecas.core.providers.idealeware;
using integration.romaautopecas.idealewareapis;

namespace integration.romaautopecas
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            #region Dependências
            services.AddTransient<IAuthenticateApi, AuthenticateApi>();
            services.AddTransient<IBrandApi, BrandApi>();
            services.AddTransient<IOrderApi, OrderApi>();
            services.AddTransient<IProductApi, ProductApi>();
            services.AddTransient<IAicBrasilApi, AicBrasilApi>();
            services.AddTransient<IIntegrationManager, IntegrationManager>();
            services.AddTransient<IHttpTransferAuthenticate, HttpTransferAuthenticate>();
            services.AddTransient<IHttpTransferBrand, HttpTransferBrand>();
            services.AddTransient<IHttpTransferOrder, HttpTransferOrder>();
            services.AddTransient<IHttpTransferProduct, HttpTransferProduct>();
            services.AddTransient<IHttpTransferAicBrasil, HttpTransferProductAicBrasil>();
            services.AddTransient<ILoggerFactory, LoggerFactory>();
            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API de Integração",
                    Description = "API para integração de dados.",
                    TermsOfService = "None"
                });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "integration.romaautopecas.xml");
                c.IncludeXmlComments(filePath);
                c.DescribeAllEnumsAsStrings();
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.RoutePrefix = "docs";
            });
        }
    }
}
