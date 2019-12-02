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
            btnEliminarEmpleados();
        }

        #region Métodos Botones

        private void btnEliminarEmpleados()
        {

            var id_empleado = txtEliminarEmp.Text;

            EmpleadosController ec = new EmpleadosController();
            var response = ec.eliminarEmpleado(id_empleado);

            txtEliminarEmp.Text = string.Empty;

            MessageBox.Show(response);

        }


        #endregion

    }
}
