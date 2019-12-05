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
using Modelo.Empleados;
using Newtonsoft.Json;

namespace PortafolioDesktop
{
    public partial class VActualizarEmp : Form
    {
        public VActualizarEmp()
        {
            InitializeComponent();
            disable();
        }


        private void btnActualizarEmp_Click(object sender, EventArgs e)
        {
            btnActualizarEmpleado();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            btnVolver();
        }

        private void btnBuscarEmp_Click(object sender, EventArgs e)
        {
            btnBuscarEmpleado();
        }

        private void btnActualizarEmp_Click_1(object sender, EventArgs e)
        {
            btnActualizarEmpleado();
        }

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

        private void disable() {

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
        //TODO agregar método al terminar correctamente de actualizar
        private void clean() {

            txtSnombre_empleado.Text = string.Empty;
            txtPapellido_empleado.Text = string.Empty;
            txtSapeliido_empleado.Text = string.Empty;
            txtEdad_empleado.Text = string.Empty;
            txtRun_empleado.Text = string.Empty;
            txtDv_empleado.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            cbComuna.Enabled = false;
            cbUsuario.Enabled = false;
            cbArea.SelectedValue =false;
            cbCargo.SelectedValue = false;



        }

        private void loadComboUsuario() {

            string uri = "http://localhost:8000/empleadoList";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {

                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var data_table = JsonConvert.DeserializeObject<Empleados>(s);

               // dgwEmpleados.DataSource = data_table.Rows;
            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }


        }


        #endregion

       
    }
}
