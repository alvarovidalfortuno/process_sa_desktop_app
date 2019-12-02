using Modelo.Usuarios;
using Modelo.Encrypter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class UsuariosController
    {

        public string crearUsuario(string correo_usuario,string password) {

            //Recibiendo datos, construyendo clase Usuario y convirtiendola a Json
            var response = "";
                Rootobject usuarioJson = new Rootobject();
                usuarioJson.correo_usuario = correo_usuario;
                usuarioJson.password = password;

            var json_send = JsonConvert.SerializeObject(usuarioJson);

            
                const string url = "http://localhost:8000/usuarioCreate";
                var request = WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                request.Method = WebRequestMethods.Http.Post;
                //Stream newStream = request.GetRequestStream();
                //var response = (HttpWebResponse)request.GetResponse();

                using (var stream_writer = new StreamWriter(request.GetRequestStream()))
                {

                    stream_writer.Write(json_send);
                    stream_writer.Flush();
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var stream_reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response_text = stream_reader.ReadToEnd();
                    response = response_text;
                }

            //Response Return
            return response;
        }

        public string updateUsuario(string correo_usuario, string password) {

            //Recibiendo datos, construyendo clase Usuario y convirtiendola a Json
            var response = "";
            Rootobject usuarioJson = new Rootobject();
            usuarioJson.correo_usuario = correo_usuario;
            usuarioJson.password = password;

            var json_send = JsonConvert.SerializeObject(usuarioJson);


            const string url = "http://localhost:8000/usuarioUpdate";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            //Stream newStream = request.GetRequestStream();
            //var response = (HttpWebResponse)request.GetResponse();

            using (var stream_writer = new StreamWriter(request.GetRequestStream()))
            {

                stream_writer.Write(json_send);
                stream_writer.Flush();
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var stream_reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response_text = stream_reader.ReadToEnd();
                response = response_text;
            }

            //Response Return
            return response;





        }



    }
}
