using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.BuscarUsuarioResponse
{

    public class BuscarUsuarioResponse
    {
        public Row[] Rows { get; set; }
    }

    public class Row
    {
        public int ID_USUARIO { get; set; }
        public string CORREO_USUARIO { get; set; }
        public string CONTRASEA_USUARIO { get; set; }
    }

}
