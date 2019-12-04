using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.BuscarEmpleadoResponse2
{

   

        public class BuscarEmpleadoResponse2
        {
            public Response[] response { get; set; }
        }

        public class Response
        {
            public int ID_EMPLEADO { get; set; }
            public string SNOMBRE_EMPLEADO { get; set; }
            public string PAPELLIDO_EMPLEADO { get; set; }
            public string SAPELLIDO_EMPLEADO { get; set; }
            public int EDAD_EMPLEADO { get; set; }
            public int RUN_EMPLEADO { get; set; }
            public string DV_EMPLEADO { get; set; }
            public string DIRECCION { get; set; }
            public int ID_COMUNA { get; set; }
            public int ID_USUARIO { get; set; }
            public int ID_AREA { get; set; }
            public object ID_CARGO { get; set; }
        }
    }


