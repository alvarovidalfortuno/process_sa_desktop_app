using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void btnCrearUsu_Click(object sender, EventArgs e)
        { 
            
            btnCrearUsuario();
        }



        #region Métodos Botones
        private void btnCrearUsuario()
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
            else {

                MessageBox.Show("No se pudo crear, Por favor revise los datos ingresados");
            }


        }
        #endregion

    }
}
