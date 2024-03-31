using System;
using System.ComponentModel.DataAnnotations;

namespace Pacagroup.Comercial.Creditos.WebConsumer.Models.Cliente
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Sexo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string EstadoCivil { get; set; }
    }
}