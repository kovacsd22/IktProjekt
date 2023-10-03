using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Server.Models
{
    public class Jogosultsag : Record
    {
        [DataMember]
        public int Szint { get; set; } // Szint tulajdonság hozzáadása

        [DataMember]
        public string Nev { get; set; }

        [OperationContract]
        public override string ToString()
        {
            return $"Id: {Id}\nSzint: {Szint}\nNév: {Nev}";
        }
    }
}
