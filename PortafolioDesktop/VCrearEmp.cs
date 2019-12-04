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

        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        private bool validarCampos() {

            bool isValid;
            //Validar campo Snombre
            if (!(txtSnombre_empleado.Text.Length>0)) 
            {
                MessageBox.Show("Ingrese Nombre");
                isValid = false;
                return isValid;
            
            }
            if (!(txtPapellido_empleado.Text.Length > 0)) {

                MessageBox.Show("Ingrese Apellido Paterno");

                isValid = false;
                return isValid;
            }
            if (!(txtSapeliido_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Apellido Materno");

                isValid = false;
                return isValid;
            }
            if (!(txtEdad_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Edad");

                isValid = false;
                return isValid;
            }
            if (!(txtRun_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Rut");

                isValid = false;
                return isValid;
            }
            else {


               // validarRut();
            
            
            
            }
            if (!(txtDv_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Dígito Verificador");

                isValid = false;
                return isValid;
            }
            if (!(txtDireccion.Text.Length > 0))
            {

                MessageBox.Show("Ingrese Dirección");

                isValid = false;
                return isValid;
            }
            if (cbComuna.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Comuna");

                isValid = false;
                return isValid;

            }
            if (cbUsuario.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Usuario");

                isValid = false;
                return isValid;
            }
            if (cbArea.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Área");

                isValid = false;
                return isValid;

            }
            if (cbCargo.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Cargo");

                isValid = false;
                return isValid;
            }

          


            isValid = true;

            return isValid;
        
        }

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
