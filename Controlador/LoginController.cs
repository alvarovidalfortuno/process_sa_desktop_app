using System;
using System.IO;
using System.Net;
using Modelo.PasswordResponse;
using Modelo.Encrypter;
using Newtonsoft.Json;

namespace Controlador
{
    public class LoginController
    {

        public Boolean Login(string usuario, string password)
        {


            const string url = "http://localhost:8000/login";
            string password_response;
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            //Stream newStream = request.GetRequestStream();
            //var response = (HttpWebResponse)request.GetResponse();

            using (var stream_writer = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"usuario\": \"" + usuario + "\"" +
                    "}";

                stream_writer.Write(json);
                stream_writer.Flush();
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var stream_reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response_text = stream_reader.ReadToEnd();
                password_response = response_text;
            }

            //INICIA PROCESO DE VALIDACION
            var password_encriptado = Encrypter.Encrypt(password); //Encritando password insgresado
            var deserializedJson = JsonConvert.DeserializeObject<RootObject>(password_response);

            //Limpiando password proveniente del Response
            var password_IN = deserializedJson.json;
            var auxString1 = password_IN.Replace("[{\"CONTRASE�A_USUARIO\":", "");
            var auxString2 = auxString1.Replace("}]", "");
            var auxString3 = auxString2.Replace("\"","");
            var password_IN_cleaned = auxString3;


            if (password_encriptado == password_IN_cleaned) {

                return true;
                
            }

            return false;
        }
    }
}
