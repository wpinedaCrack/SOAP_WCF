﻿using System;
using System.Collections.Generic;
using Pacagroup.Comercial.Creditos.Dominio;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Pacagroup.Comercial.Creditos.Contrato
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerCliente/{numeroDocumento}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Cliente ObtenerCliente(string numeroDocumento);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarCliente", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Cliente> ListarCliente();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BuscarCliente", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Cliente> BuscarCliente(Cliente cliente);
    }
}
