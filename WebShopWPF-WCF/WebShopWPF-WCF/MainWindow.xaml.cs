using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceReference1;

namespace WebShopWPF_WCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Service1Client client = new Service1Client();
        public MainWindow()
        {
            try
            {   
                InitializeComponent();
                kecske();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

         
        }
        public void kecske()
        {
            List<Felhasznalo> felhasznalos = client.FelhasznaloLista_CS().ToList();
            Felhasznalo_adatok.ItemsSource = felhasznalos;
        }
        private void Felhasznalo_kivalaszt(object sender, EventArgs e)
        {
            if (Felhasznalo_adatok.SelectedItems.Count > 0)
            {
                Felhasznalo felhasznalo = Felhasznalo_adatok.SelectedItems[0] as Felhasznalo;

                // Now you can safely access the selected item's properties
                Txb_LoginNev.Text = felhasznalo.LoginNev;
                Txb_HASH.Text = felhasznalo.HASH;
                Txb_SALT.Text = felhasznalo.SALT;
                Txb_Nev.Text = felhasznalo.Nev;
                Txb_Jog.Text = felhasznalo.Jog.ToString();
                Chb_Aktiv.IsChecked = felhasznalo.Aktiv ? true : false;
                Txb_Email.Text = felhasznalo.Email;
                Txb_ProfilKep.Text = felhasznalo.ProfilKep;
            }
            else
            {
                
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = Felhasznalo_adatok.SelectedItem as Felhasznalo;
            client.FelhasznaloTorol_CS(Convert.ToInt32(felhasznalo.Id));
            kecske();
        }

        private void HozzaadasButton_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo UjFelhasznalo = new Felhasznalo
            {
                LoginNev = Txb_LoginNev.Text,
                HASH = Txb_HASH.Text,
                SALT = Txb_SALT.Text,
                Nev = Txb_Nev.Text,
                Jog = Convert.ToByte(Txb_Jog.Text),
                Email = Txb_Email.Text,
                ProfilKep = Txb_ProfilKep.Text

            };

            client.FelhasznaloHozzaAd_CS(UjFelhasznalo);

        }

        private void ModositButton_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = Felhasznalo_adatok.SelectedItem as Felhasznalo;

            
            if (felhasznalo == null)
            {
                MessageBox.Show("Nincs kiválasztott rekord a módosításhoz.");
                return;
            }

            
            felhasznalo.LoginNev = Txb_LoginNev.Text;
            felhasznalo.HASH = Txb_HASH.Text;
            felhasznalo.SALT = Txb_SALT.Text;
            felhasznalo.Nev = Txb_Nev.Text;
            felhasznalo.Jog = Convert.ToByte(Txb_Jog.Text);
            felhasznalo.Aktiv = Chb_Aktiv.IsChecked ?? false; 
            felhasznalo.Email = Txb_Email.Text;
            felhasznalo.ProfilKep = Txb_ProfilKep.Text;

           
            client.FelhasznaloModosit_CS(felhasznalo);
            kecske();
        }
    }
}
