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
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            btnLogin();
        }


        #region Métodos Botones

        private void Btn_salir_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void btnLogin() {


            var isValid = validarCampos();

            if (isValid) {

                var usuario = txt_usuario.Text;
                //var password = txt_password.Text;
                var password = passwordBox_usuario.Password;
                try
                {
                    LoginController lc = new LoginController();
                    var result = lc.Login(usuario, password);
                    if (result)
                    {
                        var vistaAdministrador = new VistaAdministrador();
                        vistaAdministrador.ShowDialog();
                    }
                    else {

                        System.Windows.Forms.MessageBox.Show("Credenciales Inválidas","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }


                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool validarCampos()
        {

            bool isValid;
            Regex remail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (!(txt_usuario.Text.Length > 0) || !(passwordBox_usuario.Password.Length > 0))
            {

                System.Windows.Forms.MessageBox.Show("Por favor llene los campos");
                isValid = false;
                return isValid;
            }
            else
            {

                if (!remail.IsMatch(txt_usuario.Text))
                {

                    System.Windows.Forms.MessageBox.Show("El usuario debe ser un Email válido", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValid = false;
                    return isValid;
                }
                else
                {

                    isValid = true;
                    return isValid;

                }


            }




        }

        #endregion
    }
}




