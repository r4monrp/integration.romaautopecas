using integration.romaautopecas.start.Integration;
using System;
using System.Threading;

namespace integration.romaautopecas.start
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} - Iniciando serviço de autenticação");

            while (true)
            {
                try
                {
                    //Inicia a Autenticação e Integração
                    new IntegrationStart();


                    //Aguarda 10 min para iniciar novamente
                    Thread.Sleep(TimeSpan.FromMinutes(10));

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{DateTime.Now} - Foi encontrado um problema : {ex.Message}.");
                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }
            }
        }
    }
}
