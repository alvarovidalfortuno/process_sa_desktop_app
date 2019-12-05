using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.cargarComboBox
{

    public class CargarComuna
    {
        public Row[] Rows { get; set; }
    }

    public class Row
    {
        public int ID_COMUNA { get; set; }
        public string NOMBRE_COMUNA { get; set; }
    }

}
