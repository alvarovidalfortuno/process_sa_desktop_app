using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Modelo.Empleados;

using Newtonsoft.Json;

namespace Controlador
{
   public class EmpleadosController
    {
       

        public string crearEmpleado
            (
            string SNOMBRE_EMPLEADO,
            string PAPELLIDO_EMPLEADO,
            string SAPELLIDO_EMPLEADO, 
            string EDAD_EMPLEADO,
            string RUN_EMPLEADO, 
            string DV_EMPLEADO, 
            string DIRECCION,
            string ID_COMUNA, 
            string ID_USUARIO, 
            string ID_AREA, 
            string ID_CARGO
            )
        {
            var response = "";
            // Creando Json para método POST crear
            Rootobject emp = new Rootobject();
            emp.SNOMBRE_EMPLEADO = SNOMBRE_EMPLEADO;
            emp.PAPELLIDO_EMPLEADO = PAPELLIDO_EMPLEADO;
            emp.SAPELLIDO_EMPLEADO = SAPELLIDO_EMPLEADO;
            emp.EDAD_EMPLEADO = EDAD_EMPLEADO;
            emp.RUN_EMPLEADO = RUN_EMPLEADO;
            emp.DV_EMPLEADO = DV_EMPLEADO;
            emp.DIRECCION = DIRECCION;
            emp.ID_COMUNA = ID_COMUNA;
            emp.ID_USUARIO = ID_USUARIO;
            emp.ID_AREA = ID_AREA;
            emp.ID_CARGO = ID_CARGO;

            var empJson = JsonConvert.SerializeObject(emp);

            const string url = "http://localhost:8000/usuarioCreate";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            //Stream newStream = request.GetRequestStream();
            //var response = (HttpWebResponse)request.GetResponse();

            using (var stream_writer = new StreamWriter(request.GetRequestStream()))
            {

                stream_writer.Write(empJson);
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


        //TODO Agregar ID Empleado al servicio y aca para completar la acción

        public string actualizarEmpleado(
            string ID_EMPLEADO,
            string SNOMBRE_EMPLEADO,
            string PAPELLIDO_EMPLEADO,
            string SAPELLIDO_EMPLEADO,
            string EDAD_EMPLEADO,
            string RUN_EMPLEADO,
            string DV_EMPLEADO,
            string DIRECCION,
            string ID_COMUNA,
            string ID_USUARIO,
            string ID_AREA,
            string ID_CARGO
            )
        {
            string response = "";

            // Creando Json para método POST Actualizar

            Rootobject emp = new Rootobject();
            emp.SNOMBRE_EMPLEADO = SNOMBRE_EMPLEADO;
            emp.PAPELLIDO_EMPLEADO = PAPELLIDO_EMPLEADO;
            emp.SAPELLIDO_EMPLEADO = SAPELLIDO_EMPLEADO;
            emp.EDAD_EMPLEADO = EDAD_EMPLEADO;
            emp.RUN_EMPLEADO = RUN_EMPLEADO;
            emp.DV_EMPLEADO = DV_EMPLEADO;
            emp.DIRECCION = DIRECCION;
            emp.ID_COMUNA = ID_COMUNA;
            emp.ID_USUARIO = ID_USUARIO;
            emp.ID_AREA = ID_AREA;
            emp.ID_CARGO = ID_CARGO;

            var empJson = JsonConvert.SerializeObject(emp);

            string url = "http://localhost:8000/usuarioUpdate"+ ID_EMPLEADO;
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            //Stream newStream = request.GetRequestStream();
            //var response = (HttpWebResponse)request.GetResponse();

            using (var stream_writer = new StreamWriter(request.GetRequestStream()))
            {

                stream_writer.Write(empJson);
                stream_writer.Flush();
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var stream_reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response_text = stream_reader.ReadToEnd();
                response = response_text;
            }



            return response;
        }



        public Rootobject buscarEmpleado(string ID_EMPLEADO) {


            {
                string uri = "http://localhost:8000/empleadoBuscar?id_empleado=" + ID_EMPLEADO;
                Console.WriteLine(uri);
                //Agregar nuevo método con parametro en la uri
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = WebRequestMethods.Http.Get;
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {

                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var response = JsonConvert.DeserializeObject<Rootobject>(s);

                    return response;
                    
                }
                else
                {
                    Rootobject responseDummy = new Rootobject();
                    return responseDummy;
                }
            }






        }


        public string eliminarEmpleado(string ID_EMPLEADO) {

            var response = "";

            string url = "http://localhost:8000/usuarioUpdate" + ID_EMPLEADO; //TODO Actualizar URL
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Put;

            using (var stream_writer = new StreamWriter(request.GetRequestStream())) 
            {
            
                //<????>
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var stream_reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response_text = stream_reader.ReadToEnd();
                response = response_text;
            }



            return response;
        
        
        
        }

    }
}
