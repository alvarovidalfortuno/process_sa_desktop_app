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
    public partial class VEliminarEmp : Form
    {
        public VEliminarEmp()
        {
            InitializeComponent();
        }

        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {
            ejecutarEliminarEmp();
        }

        #region Métodos Botones

        private void btnEliminarEmpleados()
        {

            var id_empleado = txtEliminarEmp.Text;

            EmpleadosController ec = new EmpleadosController();
            var jsonResponse = ec.eliminarEmpleado(id_empleado);

            txtEliminarEmp.Text = string.Empty;

            var response = JsonConvert.DeserializeObject<Rootobject>(jsonResponse);

            if (response.ok == true)
            {
                MessageBox.Show("El Empleado " + id_empleado + " ha sido eliminado");
                GC.Collect();
                Close();

            }
            else {

                MessageBox.Show("El Empleado " + id_empleado + " No existe");

            }
            
        }


        #endregion

        #region Métodos UI

        private void ejecutarEliminarEmp()
        {
            var isOK = validarIDEmpleado();
            if (isOK)
            {

                btnEliminarEmpleados();

            }
        }

        public bool validarIDEmpleado()
        {
            bool isValid;
            int result;
            if (!(txtEliminarEmp.Text.Length > 0))
            {
                MessageBox.Show("El campo ID Empleado debe tener un valor");
                isValid = false;
                return isValid;

            }
            if (!(int.TryParse(txtEliminarEmp.Text, out result)))
            {

                MessageBox.Show("El valor ingresado como ID empleado debe ser numérico");
                isValid = false;
                return isValid;

            }

            isValid = true;

            return isValid;
        }

        #endregion

    }
}
