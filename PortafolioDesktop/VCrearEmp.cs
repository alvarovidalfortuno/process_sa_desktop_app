using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Controlador;
using Modelo.cargarComboBox;
using Modelo.ServiceResponse;
using Newtonsoft.Json;

namespace PortafolioDesktop
{
    public partial class VCrearEmp : Form
    {
        public VCrearEmp()
        {
            InitializeComponent();
            cargarComunas();
            cargarUsuarios();
            cargarCargos();
            cargarAreas();
        }

        

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            ejecutarCrearEmp();
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            btnVolver();

        }

        #region Métodos UI
        private void ejecutarCrearEmp()
        {
            var isOK = validarCampos();
            if (isOK)
            {

                btnCrearEmpleado();

            }
        }

        private void cargarComunas()
        {
           
                string uri = "http://localhost:8000/comboComuna";
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                   

                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var data_table = JsonConvert.DeserializeObject<CargarComuna>(s);

                cbComuna.DataSource = data_table.Rows;
                cbComuna.DisplayMember = "NOMBRE_COMUNA";
                cbComuna.ValueMember = "ID_COMUNA";

                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            

        }//OK

        private void cargarAreas()
        {
            string uri = "http://localhost:8000/comboArea";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {


                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var data_table = JsonConvert.DeserializeObject<CargarArea>(s);

                cbArea.DataSource = data_table.Rows;
                cbArea.DisplayMember = "NOMBRE_AREA";
                cbArea.ValueMember = "ID_AREA";

            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }
        }//OK

        private void cargarCargos()
        {
            string uri = "http://localhost:8000/comboCargo";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {


                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var data_table = JsonConvert.DeserializeObject<CargarCargo>(s);

                cbCargo.DataSource = data_table.Rows;
                cbCargo.DisplayMember = "NOMBRE_CARGO";
                cbCargo.ValueMember = "ID_CARGO";

            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }

        }//OK

        private void cargarUsuarios()
        {
            string uri = "http://localhost:8000/comboUsuario";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {


                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var data_table = JsonConvert.DeserializeObject<CargarUsuario>(s);

                cbUsuario.DataSource = data_table.Rows;
                cbUsuario.DisplayMember = "CORREO_USUARIO";
                cbUsuario.ValueMember = "ID_USUARIO";

            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }
        }//OK

        #endregion

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
            else
            {

                if (!(int.TryParse(txtEdad_empleado.Text, out int resultado)))
                {

                    MessageBox.Show("Ingrese sólo numeros en edad");
                    isValid = false;
                    return isValid;
                }
                else
                {
                    if (!(int.Parse(txtEdad_empleado.Text) > 17) || !(int.Parse(txtEdad_empleado.Text) < 100))
                    {
                        MessageBox.Show("Ingrese una edad entre 18 y 99 años");
                        isValid = false;
                        return isValid;


                    }
                }

            }
            if (!(txtRun_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Rut");

                isValid = false;
                return isValid;
            }
           
            if (!(txtDv_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Dígito Verificador");

                isValid = false;
                return isValid;
            }
            else
            {
                var rut = txtRun_empleado.Text + txtDv_empleado.Text;

                var isRutValid = validarRut(rut);
                if (!isRutValid) {

                    MessageBox.Show("El rut ingresado no es válido");


                }


            }
            if (!(txtDireccion.Text.Length > 0))
            {

                MessageBox.Show("Ingrese Dirección");

                isValid = false;
                return isValid;
            }
           /* if (cbComuna.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Comuna");

                isValid = false;
                return isValid;

            }*/
            /*if (cbUsuario.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Usuario");

                isValid = false;
                return isValid;
            }*/
            /*if (cbArea.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Área");

                isValid = false;
                return isValid;

            }*/
           /* if (cbCargo.SelectedIndex == 0) {

                MessageBox.Show("Seleccione Cargo");

                isValid = false;
                return isValid;
            }*/

          


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
            string ID_COMUNA = cbComuna.SelectedValue.ToString();
            string ID_USUARIO = cbUsuario.SelectedValue.ToString();
            string ID_AREA = cbArea.SelectedValue.ToString();
            string ID_CARGO = cbCargo.SelectedValue.ToString();
            

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
                GC.Collect();
                Close();
                
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
