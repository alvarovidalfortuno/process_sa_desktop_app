using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.cargarComboBox
{

    public class CargarCargo
    {
        public Cargo[] Rows { get; set; }
    }

    public class Cargo
    {
        public int ID_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
    }

}
