using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortafolioDesktop
{
    public partial class VistaAdministrador : Form
    {
        public VistaAdministrador()
        {
            InitializeComponent();
        }

        private void VistaAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void btnTerminarSesion_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void btnAdminEmp_Click(object sender, EventArgs e)
        {
            var vistaAdmEmpleados = new VistaAdmEmpleados();
            vistaAdmEmpleados.ShowDialog();
        }

        private void btnAdminRoles_Click(object sender, EventArgs e)
        {
            var vistaAdmRoles = new VistaAdmRoles();
            vistaAdmRoles.ShowDialog();
        }
    }
}
