using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pacagroup.Comercial.Creditos.WebConsumer.Models.Cliente;
using Pacagroup.Comercial.Creditos.WebConsumer.Models.Credito;

namespace Pacagroup.Comercial.Creditos.WebConsumer.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public async Task<ActionResult> Index(string apellidoPaterno)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (string.IsNullOrEmpty(apellidoPaterno))
                    apellidoPaterno = string.Empty;

                var cliente = new ClienteViewModel { ApellidoPaterno = apellidoPaterno };

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ClienteViewModel));
                MemoryStream men = new MemoryStream();
                ser.WriteObject(men, cliente);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res =
                    await
                        client.PostAsync("WcfServiceCliente/ClienteService.svc/rest/BuscarCliente",
                            new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<ClienteViewModel>));
                    List<ClienteViewModel> response = obj.ReadObject(result) as List<ClienteViewModel>;
                    return View(response);
                }
                else
                    return View();
            }
        }
    }
}