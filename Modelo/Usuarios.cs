using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuarios
    {
        string id_usuario,correo_usuario,contrasena_usuario;


        public Usuarios()
        {
            this.id_usuario = "";
            this.correo_usuario = "";
            this.contrasena_usuario = "";
        }

        public Usuarios(string id_usuario, string correo_usuario, string contrasena_usuario)
        {
            this.id_usuario = id_usuario;
            this.correo_usuario = correo_usuario;
            this.contrasena_usuario = contrasena_usuario;
        }

        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Correo_usuario { get => correo_usuario; set => correo_usuario = value; }
        public string Contrasena_usuario { get => contrasena_usuario; set => contrasena_usuario = value; }
    }
}
