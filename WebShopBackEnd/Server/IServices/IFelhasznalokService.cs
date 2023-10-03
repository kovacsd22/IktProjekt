﻿using Google.Protobuf.WellKnownTypes;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace Server.IServices
{
    [ServiceContract]
    public interface IFelhasznalokService
    {
        [OperationContract]

        List<Felhasznalo> FelhasznaloLista_CS();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloLista/")]

        List<Felhasznalo> FelhasznaloLista_Web();

        [OperationContract]

        string FelhasznaloHozzaAd_CS(Felhasznalo felhasznalo);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloHozzaAd/")]

        string FelhasznaloHozzaAd_Web(Felhasznalo felhasznalo);

        [OperationContract]

        string FelhasznaloModosit_CS(Felhasznalo felhasznalo);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloModosit/")]

        string FelhasznaloModosit_Web(Felhasznalo felhasznalo);

        [OperationContract]

        string FelhasznaloTorol_CS(int id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloTorol?id={id}")]

        string FelhasznaloTorol_Web(int id);



        [OperationContract]
        List<Jogosultsag> JogosultsagLista_Web();

        [OperationContract]
        List<Jogosultsag> JogosultsagLista_CS();

        
        [OperationContract]
        string JogosultsagHozzaAd_Web(Jogosultsag jogosultsag);

        [OperationContract]
        string JogosultsagHozzaAd_CS(Jogosultsag jogosultsag);
    }
}
