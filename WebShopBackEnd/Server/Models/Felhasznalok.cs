using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Server.Models
{
    [DataContract]

    public class Felhasznalo : Record
    {
        [DataMember]

        public string LoginNev { get; set; }

        [DataMember]

        public string HASH { get; set; }

        [DataMember]

        public string SALT { get; set; }

        [DataMember]

        public string Nev { get; set; }

        [DataMember]

        public byte Jog { get; set; }

        [DataMember]

        public bool Aktiv { get; set; }

        [DataMember]

        public string Email { get; set; }

        [DataMember]

        public string ProfilKep { get; set; }

        [OperationContract]

        public override string ToString()
        {
            return $"Id: {Id}\nLogin név: {LoginNev}\nHASH: {HASH}\nSALT: {SALT}\nNév: {Nev}\nJog: {Jog}\nAktív: {(Aktiv ? "Igen" : "Nem")}\nE-mail: {Email}\nProfilkép utvonala: {ProfilKep}";
        }

    }
}