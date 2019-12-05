using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Modelo.ServiceResponse;
using Newtonsoft.Json;

namespace PortafolioDesktop
{
    public partial class VCrearUsu : Form
    {
        public VCrearUsu()
        {
            InitializeComponent();
            setupPasswordTxt();
        }

        

        private void btnCrearUsu_Click(object sender, EventArgs e)
        {
            ejecutarCrearEmp();
        }


        #region Métodos UI

        private void setupPasswordTxt()
        {
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 30;
        }

        private bool validarCampos() {

            bool isValid;
            Regex remail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");


            if (!(txtUsuario.Text.Length > 0)) {

                MessageBox.Show("Usuario debe contener un valor");
                isValid = false;
                return isValid;
            }

            if (!(remail.IsMatch(txtUsuario.Text))) {

                MessageBox.Show("El usuario debe ser un email");
                isValid = false;
                return isValid;
            
            }

            if (!(txtPassword.Text.Length > 0)) {

                MessageBox.Show("Password debe contener un valor");
                isValid = false;
                return isValid;
            }

            isValid = true;
            return isValid;
        }
        private void ejecutarCrearEmp()
        {
            var isOK = validarCampos();
            if (isOK)
            {

                btnCrearUsuario();
            }
        }
        #endregion


        #region Métodos Botones
        private void btnCrearUsuario()
        {
            
            {
                var correo_usuario = txtUsuario.Text;
                var password = txtPassword.Text;

                UsuariosController uc = new UsuariosController();
                var response = uc.crearUsuario(correo_usuario, password);
                var evaluar_response = JsonConvert.DeserializeObject<Rootobject>(response);
                //
                if (evaluar_response.ok == true)
                {

                    MessageBox.Show("Usuario Creado Correctamente");
                    MessageBox.Show("Procediendo a agregar datos Empleado...");
                    GC.Collect();
                    Close();
                    var vcrearemp = new VCrearEmp();
                    vcrearemp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo crear, Por favor revise los datos ingresados");
                }
            }

        }
        #endregion

    }
}
