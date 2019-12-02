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
    public partial class VCrearEmp : Form
    {
        public VCrearEmp()
        {
            InitializeComponent();
            //TODO hacer un bind a dato de usuarios recien creado
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            btnCrearEmpleado();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            btnVolver();

        }
        

        #region Métodos Botones

        private void btnCrearEmpleado() {

            string SNOMBRE_EMPLEADO = txtSnombre_empleado.Text;
            string PAPELLIDO_EMPLEADO= txtPapellido_empleado.Text;
            string SAPELLIDO_EMPLEADO = txtSapeliido_empleado.Text;
            string EDAD_EMPLEADO = txtEdad_empleado.Text;
            string RUN_EMPLEADO =txtRun_empleado.Text;
            string DV_EMPLEADO = txtDv_empleado.Text;
            string DIRECCION = txtDireccion.Text;
            string ID_COMUNA = cbComuna.SelectedIndex.ToString();
            string ID_USUARIO = cbUsuario.SelectedIndex.ToString();
            string ID_AREA = cbArea.SelectedIndex.ToString();
            string ID_CARGO = cbCargo.SelectedIndex.ToString();


            EmpleadosController empc = new EmpleadosController();
            var response = empc.crearEmpleado(
                 SNOMBRE_EMPLEADO,
                 PAPELLIDO_EMPLEADO,
                 SAPELLIDO_EMPLEADO,
                 EDAD_EMPLEADO,
                 RUN_EMPLEADO,
                 DV_EMPLEADO,
                 DIRECCION,
                 ID_COMUNA,
                 ID_USUARIO,
                 ID_AREA,
                 ID_CARGO);

            var evaluar_response = JsonConvert.DeserializeObject<Rootobject>(response);
            //
            if (evaluar_response.ok == true)
            {

                MessageBox.Show("Empleado Creado Correctamente");
                
            }
            else
            {

                MessageBox.Show("No se pudo crear, Por favor revise los datos ingresados");
            }


        }

        private void btnVolver()
        {
            GC.Collect();
            Close();
        }

        #endregion


    }
}
