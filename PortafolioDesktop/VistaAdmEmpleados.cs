using Modelo.Empleados;
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
using Newtonsoft.Json;

namespace PortafolioDesktop
{
    public partial class VistaAdmEmpleados: Form
    {
        public VistaAdmEmpleados()
        {
            InitializeComponent();

        }

        private void VistaAdmEmpleados_Load(object sender, EventArgs e)
        {
           
            try
            {
                ListarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            btnVolverAdmEmpleados();
           
        }


        private void btnCrearEmp_Click(object sender, EventArgs e)
        {
            btnCrearEmpleados();
            
        }

        private void btnActualizarEmp_Click(object sender, EventArgs e)
        {

            btnActualizarEmpleados();
        }

        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {

            btnEliminarEmpleados();
            
        }

        private void btnCrearUsu_Click(object sender, EventArgs e)
        {
            btnCrearUsuario();
        }

        #region Métodos Empleados
        private void ListarEmpleados()
        {
            string uri = "http://localhost:8000/empleadoList";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {
                dgwEmpleados.AutoGenerateColumns = true;

                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var data_table = JsonConvert.DeserializeObject<Empleados>(s);

                dgwEmpleados.DataSource = data_table.Rows;
            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }
        }

        #endregion

        #region Métodos Botones
        private void btnCrearEmpleados()
        {
            var vcrearusu = new VCrearUsu();
            vcrearusu.ShowDialog();
            GC.Collect();
            Close();
        }
        private void btnActualizarEmpleados()
        {
            var vactualizaremp = new VActualizarEmp();
            vactualizaremp.ShowDialog();
            GC.Collect();
            Close();
        }
        private void btnEliminarEmpleados()
        {
            var veliminaremp = new VEliminarEmp();
            veliminaremp.ShowDialog();
            GC.Collect();
            Close();
        }

        private void btnCrearUsuario() {
           // var vcrearusuario = new VCrearUsuario();
            //vcrearusuario.ShowDialog();
            GC.Collect();
            Close();


        }
        private void btnVolverAdmEmpleados()
        {
            GC.Collect();
            Close();
        }
        #endregion

       
    }
}
