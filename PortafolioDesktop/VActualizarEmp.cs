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
using System.Windows.Forms;
using Controlador;
using Modelo.BuscarEmpleadoResponse2;
using Modelo.cargarComboBox;
using Modelo.Empleados;
using Newtonsoft.Json;

namespace PortafolioDesktop
{
    public partial class VActualizarEmp : Form
    {
        public VActualizarEmp()
        {
            InitializeComponent();
            cargarComunas();
            cargarUsuarios();
            cargarCargos();
            cargarAreas();
            disable();
        }

        #region Botones
        private void btnActualizarEmp_Click(object sender, EventArgs e)
        {
            //REVISAR
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            //REVISAR
        }
        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            btnVolver();
        }
        private void btnBuscarEmp_Click(object sender, EventArgs e)
        {
            ejecutarBuscarEmp();
        }

        private void btnActualizarEmp_Click_1(object sender, EventArgs e)
        {
            ejecutarActualizarEmp();
        }
        #endregion

        #region Métodos Botones

        private void btnBuscarEmpleado()
        {
            enable();

            var id_empleado = txtIdEmpleado.Text;
            EmpleadosController ec = new EmpleadosController();
            Empleados emp = ec.buscarEmpleado(id_empleado);

             txtSnombre_empleado.Text = emp.SNOMBRE_EMPLEADO;
             txtPapellido_empleado.Text = emp.PAPELLIDO_EMPLEADO;
             txtSapeliido_empleado.Text = emp.SAPELLIDO_EMPLEADO;
             txtEdad_empleado.Text = emp.EDAD_EMPLEADO;
             txtRun_empleado.Text = emp.RUN_EMPLEADO;
             txtDv_empleado.Text = emp.DV_EMPLEADO;
             txtDireccion.Text = emp.DIRECCION;
             cbUsuario.Text = emp.ID_USUARIO;
             cbComuna.Text = emp.ID_COMUNA;
             cbArea.Text = emp.ID_AREA;
             cbCargo.Text = emp.ID_CARGO; //TODO Check other options like Text Item etc


             if (emp.ID_EMPLEADO==null) {

                 MessageBox.Show("El empleado no existe");
             
        }

        }

        private void btnActualizarEmpleado() {

            string ID_EMPLEADO = txtIdEmpleado.Text;
            string SNOMBRE_EMPLEADO = txtSnombre_empleado.Text;
            string PAPELLIDO_EMPLEADO = txtPapellido_empleado.Text;
            string SAPELLIDO_EMPLEADO = txtSapeliido_empleado.Text;
            string EDAD_EMPLEADO = txtEdad_empleado.Text;
            string RUN_EMPLEADO = txtRun_empleado.Text;
            string DV_EMPLEADO = txtDv_empleado.Text;
            string DIRECCION = txtDireccion.Text;
            string ID_COMUNA = cbComuna.SelectedValue.ToString();
            string ID_USUARIO = cbUsuario.SelectedValue.ToString();
            string ID_AREA = cbArea.SelectedValue.ToString();
            string ID_CARGO = cbCargo.SelectedValue.ToString();

            EmpleadosController ec = new EmpleadosController();
            var response =ec.actualizarEmpleado(
                                                ID_EMPLEADO, 
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
                                                ID_CARGO
                                                );
            

                MessageBox.Show(response);
            
            
        }

        private void btnVolver() {
            GC.Collect();
            Close();
        }


        #endregion

        #region Métodos UI

        private void ejecutarBuscarEmp() {
            var isOK = validarIDEmpleado();
            if (isOK)
            {

                btnBuscarEmpleado();

            }
        }

        private void ejecutarActualizarEmp()
        {
            var isOK = validarCampos();
            if (isOK)
            {

                btnActualizarEmpleado();

            }
        }

        public bool validarIDEmpleado() {
            bool isValid;
            int result;
            if (!(txtIdEmpleado.Text.Length > 0)) {
                MessageBox.Show("El campo ID Empleado debe tener un valor");
                isValid = false;
                return isValid;
            
            }
            if (!(int.TryParse(txtIdEmpleado.Text,out result))) {

                MessageBox.Show("El valor ingresado como ID empleado debe ser numérico");
                isValid = false;
                return isValid;

            }

            isValid = true;

            return isValid;
        }
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

        private bool validarCampos()
        {

            bool isValid;
            //Validar campo Snombre
            if (!(txtSnombre_empleado.Text.Length > 0))
            {
                MessageBox.Show("Ingrese Nombre");
                isValid = false;
                return isValid;

            }
            if (!(txtPapellido_empleado.Text.Length > 0))
            {

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
                if (!isRutValid)
                {

                    MessageBox.Show("El rut ingresado no es válido");


                }


            }
            if (!(txtDireccion.Text.Length > 0))
            {

                MessageBox.Show("Ingrese Dirección");

                isValid = false;
                return isValid;
            }
            if (cbComuna.SelectedIndex == 0)
            {

                MessageBox.Show("Seleccione Comuna");

                isValid = false;
                return isValid;

            }
            if (cbUsuario.SelectedIndex == 0)
            {

                MessageBox.Show("Seleccione Usuario");

                isValid = false;
                return isValid;
            }
            if (cbArea.SelectedIndex == 0)
            {

                MessageBox.Show("Seleccione Área");

                isValid = false;
                return isValid;

            }
            if (cbCargo.SelectedIndex == 0)
            {

                MessageBox.Show("Seleccione Cargo");

                isValid = false;
                return isValid;
            }




            isValid = true;

            return isValid;

        }

        private void disable()
        {

            txtSnombre_empleado.Enabled = false;
            txtPapellido_empleado.Enabled = false;
            txtSapeliido_empleado.Enabled = false;
            txtEdad_empleado.Enabled = false;
            txtRun_empleado.Enabled = false;
            txtDv_empleado.Enabled = false;
            txtDireccion.Enabled = false;
            cbUsuario.Enabled = false;
            cbComuna.Enabled = false;
            cbCargo.Enabled = false;
            cbArea.Enabled = false;


        }

        private void enable()
        {

            txtSnombre_empleado.Enabled = true;
            txtPapellido_empleado.Enabled = true;
            txtSapeliido_empleado.Enabled = true;
            txtEdad_empleado.Enabled = true;
            txtRun_empleado.Enabled = true;
            txtDv_empleado.Enabled = true;
            txtDireccion.Enabled = true;
            cbUsuario.Enabled = true;
            cbComuna.Enabled = true;
            cbCargo.Enabled = true;
            cbArea.Enabled = true;


        }

        private void clean()
        {

            txtSnombre_empleado.Text = string.Empty;
            txtPapellido_empleado.Text = string.Empty;
            txtSapeliido_empleado.Text = string.Empty;
            txtEdad_empleado.Text = string.Empty;
            txtRun_empleado.Text = string.Empty;
            txtDv_empleado.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            cbComuna.Enabled = false;
            cbUsuario.Enabled = false;
            cbArea.SelectedValue = false;
            cbCargo.SelectedValue = false;



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

      
    }
}
