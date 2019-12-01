using Modelo;
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
            string uri = "http://localhost:8000/empleadoList";
            try
            {
                /*
                //Preparing DGV Columns
                dgwEmpleados.ColumnCount = 12;
                dgwEmpleados.Columns[0].Name = "ID_EMPLEADO";
                dgwEmpleados.Columns[1].Name = "SNOMBRE_EMPLEADO";
                dgwEmpleados.Columns[2].Name = "PAPELLIDO_EMPLEADO";
                dgwEmpleados.Columns[3].Name = "SAPELLIDO_EMPLEADO";
                dgwEmpleados.Columns[4].Name = "EDAD_EMPLEADO";
                dgwEmpleados.Columns[5].Name = "RUN_EMPLEADO";
                dgwEmpleados.Columns[6].Name = "DV_EMPLEADO";
                dgwEmpleados.Columns[7].Name = "DIRECCION";
                dgwEmpleados.Columns[8].Name = "ID_COMUNA";
                dgwEmpleados.Columns[9].Name = "ID_USUARIO";
                dgwEmpleados.Columns[10].Name = "ID_AREA";
                dgwEmpleados.Columns[11].Name = "ID_CARGO";

    */
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    dgwEmpleados.AutoGenerateColumns = true;

                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var data_table = JsonConvert.DeserializeObject<Rootobject>(s);

                    dgwEmpleados.DataSource = data_table.Rows;
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }
    }
}
