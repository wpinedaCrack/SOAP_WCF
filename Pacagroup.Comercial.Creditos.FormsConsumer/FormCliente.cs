using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Pacagroup.Comercial.Creditos.FormsConsumer
{
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Soap();
            //Rest();
        }

        private void Soap()
        {
            //using (ProxyCliente.ClienteServiceClient proxyClient = new ProxyCliente.ClienteServiceClient())
            //{
            //    var cliente = proxyClient.ObtenerCliente(txtNumeroDocumento.Text);
            //    txtNombre.Text = cliente.Nombre;
            //    txtApellidoPaterno.Text = cliente.ApellidoPaterno;
            //    txtApellidoMaterno.Text = cliente.ApellidoMaterno;
            //}               
        }

        private void Rest()
        {
            WebClient proxy = new WebClient();
            string serviceURL = "http://localhost/WcfServiceCliente/ClienteService.svc/rest/ObtenerCliente/" + txtNumeroDocumento.Text;
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Cliente));

            Cliente cliente = obj.ReadObject(stream) as Cliente;

            txtNombre.Text = cliente.Nombre;
            txtApellidoPaterno.Text = cliente.ApellidoPaterno;
            txtApellidoMaterno.Text = cliente.ApellidoMaterno;
        }


    }
}
