﻿using System.Collections.Generic;
using System.ServiceModel;
using Pacagroup.Comercial.Creditos.Dominio;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace Pacagroup.Comercial.Creditos.Contrato
{
    [ServiceContract]
    public interface ICreditoService
    {
        [OperationContract]
        [Description("Servicio REST que lista toda la información de los créditos.")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Credito> ListarCredito();

        [OperationContract]
        [Description("Servicio REST que obtiene la información de un crédito en especifico.")]
        [WebGet(UriTemplate = "/ObtenerCredito/{idCredito}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Credito ObtenerCredito(string idCredito);

        [OperationContract]
        [Description("Servicio REST que permite registrar créditos")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/RegistrarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito RegistrarCredito(Credito credito);

        [OperationContract]
        [Description("Servicio REST que permite actualizar créditos")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito ActualizarCredito(Credito credito);

        [OperationContract]
        [Description("Servicio REST que permite eliminar créditos")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarCredito/{idCredito}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarCredito(string idCredito);
    }
}
