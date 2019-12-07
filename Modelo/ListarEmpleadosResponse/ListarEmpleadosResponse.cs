using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ListarEmpleadosResponse
{

    public class ListarEmpleadosResponse
    {
        public Row[] Rows { get; set; }
    }

    public class Row
    {
        public string ID_EMPLEADO { get; set; }
        public string SNOMBRE_EMPLEADO { get; set; }
        public string PAPELLIDO_EMPLEADO { get; set; }
        public string SAPELLIDO_EMPLEADO { get; set; }
        public int EDAD_EMPLEADO { get; set; }
        public int RUN_EMPLEADO { get; set; }
        public string DV_EMPLEADO { get; set; }
        public string DIRECCION { get; set; }
        public string NOMBRE_COMUNA { get; set; }
        public string CORREO_USUARIO { get; set; }
        public string NOMBRE_AREA { get; set; }
        public string NOMBRE_CARGO { get; set; }
    }

}
