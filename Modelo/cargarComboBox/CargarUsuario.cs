using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.cargarComboBox
{

    public class CargarUsuario
    {
        public Usuario[] Rows { get; set; }
    }

    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public string CORREO_USUARIO { get; set; }
    }

}
