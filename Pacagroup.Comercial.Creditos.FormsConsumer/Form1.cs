using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Windows.Forms;

namespace Pacagroup.Comercial.Creditos.FormsConsumer
{
    public partial class frmListadoCreditos : Form
    {
        public frmListadoCreditos()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            //Rest();
            Soap();
        }


        private void Rest()
        {
            WebClient proxy = new WebClient();
            string serviceURL = "http://192.168.0.38/WCFSoap2/CreditoService.svc/rest/ListarCredito";
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(IEnumerable<Credito>));

            IEnumerable<Credito> coleccionCreditos = obj.ReadObject(stream) as IEnumerable<Credito>;

            gridCreditos.DataSource = coleccionCreditos;
        }

        private void Soap()
        {
            var proxyClient = new ProxyCredito.CreditoServiceClient();
            if (proxyClient.ClientCredentials != null)
            {
                proxyClient.ClientCredentials.UserName.UserName = "aespejo";
                proxyClient.ClientCredentials.UserName.Password = "123456";
            }
            gridCreditos.DataSource = proxyClient.ListarCredito();

            if (proxyClient.State == CommunicationState.Opened)
                proxyClient.Close();
        }
    }
}
