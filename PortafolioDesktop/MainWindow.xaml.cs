using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
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
using Controlador;


namespace PortafolioDesktop
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
        }
        


        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            var usuario = txt_usuario.Text;
            //var password = txt_password.Text;
            var password = passwordBox_usuario.Password;
            try {
                LoginController lc = new LoginController();
               var result=lc.Login(usuario,password);
                if (result) {

                    var vistaAdministrador = new VistaAdministrador();
                    vistaAdministrador.ShowDialog();
                }

                
            } catch(WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_salir_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Close();
        }
    }
}




