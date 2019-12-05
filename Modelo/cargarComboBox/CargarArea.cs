using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.cargarComboBox
{

    public class CargarArea
    {
        public Carga[] Rows { get; set; }
    }

    public class Carga
    {
        public int ID_AREA { get; set; }
        public string NOMBRE_AREA { get; set; }
    }

}
