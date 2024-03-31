using Pacagroup.Comercial.Creditos.ConsoleConsumer.ProxyCredito;
using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;

namespace Pacagroup.Comercial.Creditos.ConsoleConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rest();
            //Program m = new Program();
            //m.Soap2();
            Soap();
        }

        private static void Rest()
        {
            WebClient proxy = new WebClient();

            //Servicio Expuesto en el IISS
            string serviceURL = "http://192.168.0.38/WCFSoap2/CreditoService.svc/rest/ListarCredito";
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(IEnumerable<Credito>));

            IEnumerable<Credito> credito = obj.ReadObject(stream) as IEnumerable<Credito>;

            if (credito != null)
                foreach (var item in credito)
                {
                    Console.WriteLine("IdCredito : " + item.IdCredito + " Fecha : " + item.Fecha + " Monto : " + item.Monto);
                }

            Console.ReadLine();
        }

        private static void Soap()
        {
            ProxyCredito.CreditoServiceClient proxy = new CreditoServiceClient();
            IEnumerable<Credito> colleccion = proxy.ListarCredito();

            if (colleccion != null)
                foreach (var item in colleccion)
                {
                    Console.WriteLine("IdCredito : " + item.IdCredito +
                                      " Fecha : " + item.Fecha +
                                      " Monto : " + item.Monto);
                }

            if (proxy.State == CommunicationState.Opened)
                proxy.Close();

            Console.ReadLine();
        }
        //private void Soap2()
        //{
        //    CreditoServiceClient proxy = new CreditoServiceClient();
        //    IEnumerable<Credito> colleccion = proxy.ListarCredito();

        //    if (colleccion != null)
        //        foreach (var item in colleccion)
        //        {
        //            Console.WriteLine("IdCredito : " + item.IdCredito +
        //                              " Fecha : " + item.Fecha +
        //                              " Monto : " + item.Monto);
        //        }

        //    if (proxy.State == CommunicationState.Opened)
        //        proxy.Close();

        //    Console.ReadLine();
        //}
    }
}
