using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Empleados
{

    public class Empleados
    {
        public Row[] Rows { get; set; }
        public string ID_EMPLEADO { get; set; }
        public string SNOMBRE_EMPLEADO { get; set; }
        public string PAPELLIDO_EMPLEADO { get; set; }
        public string SAPELLIDO_EMPLEADO { get; set; }
        public string EDAD_EMPLEADO { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public string DV_EMPLEADO { get; set; }
        public string DIRECCION { get; set; }
        public string ID_COMUNA { get; set; }
        public string ID_USUARIO { get; set; }
        public string ID_AREA { get; set; }
        public string ID_CARGO { get; set; }
    }

    public class Row
    {
        public string ID_EMPLEADO { get; set; }
        public string SNOMBRE_EMPLEADO { get; set; }
        public string PAPELLIDO_EMPLEADO { get; set; }
        public string SAPELLIDO_EMPLEADO { get; set; }
        public string EDAD_EMPLEADO { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public string DV_EMPLEADO { get; set; }
        public string DIRECCION { get; set; }
        public string ID_COMUNA { get; set; }
        public string ID_USUARIO { get; set; }
        public string ID_AREA { get; set; }
        public string ID_CARGO { get; set; }
    }








}



