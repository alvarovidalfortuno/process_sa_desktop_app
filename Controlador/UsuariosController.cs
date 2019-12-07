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
using Modelo.Usuarios;
using Modelo.BuscarUsuarioResponse;

namespace Controlador
{
    public class UsuariosController
    {

        public string crearUsuario(string correo_usuario,string password) {

            //Recibiendo datos, construyendo clase Usuario y convirtiendola a Json
            //Encriptando constraseña

            var passwordEncriptado = Encrypter.Encrypt(password);

            var response = "";
            Usuarios usuarioJson = new Usuarios();
                usuarioJson.correo_usuario = correo_usuario;
                usuarioJson.contrasea_usuario = passwordEncriptado;

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
            Usuarios usuarioJson = new Usuarios();
            usuarioJson.correo_usuario = correo_usuario;
            usuarioJson.contrasea_usuario = password;

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

        public Usuarios buscarUsuario(string correo_usuario) {

                
                    string uri = "http://localhost:8000/buscarUsuario?correo_usuario=" + correo_usuario;
                    Console.WriteLine(uri);
                    //Agregar nuevo método con parametro en la uri
                    var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                    webRequest.Method = WebRequestMethods.Http.Get;
                    var webResponse = (HttpWebResponse)webRequest.GetResponse();
                    if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                    {
                    Usuarios response = new Usuarios();
                        var reader = new StreamReader(webResponse.GetResponseStream());
                        string s = reader.ReadToEnd();
                        var responseArray = JsonConvert.DeserializeObject<BuscarUsuarioResponse>(s);

                        for (int i = 0; i < responseArray.Rows.Length; i++)
                        {
                            response.id_usuario = responseArray.Rows[i].ID_USUARIO.ToString();
                            response.correo_usuario = responseArray.Rows[i].CORREO_USUARIO;
                            response.contrasea_usuario = responseArray.Rows[i].CONTRASEA_USUARIO;
                            

                        }
                        
                        return response;

                    }
                    else
                    {
                        Usuarios responseDummy = new Usuarios();
                        return responseDummy;
                    }
                

        }

    }
}
