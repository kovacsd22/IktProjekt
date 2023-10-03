using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopConsoleClient.ServiceReference1;

namespace WebShopConsoleClient
{
    internal class Program
    {
        public static ServiceReference1.Service1Client client;
        static void Main(string[] args)
        {
            try
            {
                client = new ServiceReference1.Service1Client();
                List<Felhasznalo> felhasznalok = client.FelhasznaloLista_CS().ToList();
                Felhasznalo ujFelhasznalo = new Felhasznalo();
                ujFelhasznalo.Id = 0;
                ujFelhasznalo.LoginNev = "CS client test";
                ujFelhasznalo.SALT = "Salt client";
                ujFelhasznalo.HASH = "Hash client";
                ujFelhasznalo.Nev = "Név client";
                ujFelhasznalo.Jog = 1;
                ujFelhasznalo.Aktiv = false;
                ujFelhasznalo.Email = "Client email";
                ujFelhasznalo.ProfilKep = "sdds client";

                string responsUj = client.FelhasznaloHozzaAd_CS(ujFelhasznalo);
                Console.WriteLine(responsUj);

                ujFelhasznalo.Id = 9;
                ujFelhasznalo.LoginNev = "Modosított login név";
                string responseModosit = client.FelhasznaloModosit_CS(ujFelhasznalo);
                Console.WriteLine(responseModosit);
                string responseTorol = client.FelhasznaloTorol_CS(9);
                Console.WriteLine(responseTorol);
                Console.ReadKey();
            }
            catch (Exception ex)
            { 
                Console.WriteLine (ex.Message);
                Console.ReadKey();
            }
            
           
        }
    }
}
