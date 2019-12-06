using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Modelo.BorrarEmpleadoResponse;
using Modelo.BuscarEmpleadoResponse;
using Modelo.BuscarEmpleadoResponse2;
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
            Empleados emp = new Empleados();
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

            const string url = "http://localhost:8000/empleadoCreate";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            //Stream newStream = request.GetRequestStream();
            //var response = (HttpWebResponse)request.GetResponse();

            using (var stream_writer = new StreamWriter(request.GetRequestStream()))
            {
                Console.WriteLine("empJson: "+empJson);
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

            Empleados emp = new Empleados();
            emp.ID_EMPLEADO = ID_EMPLEADO;
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

            string url = "http://localhost:8000/empleadoUpdate";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Put;
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



        public Empleados buscarEmpleado(string ID_EMPLEADO) {


            {
                string uri = "http://localhost:8000/empleadoBuscar?id_empleado=" + ID_EMPLEADO;
                Console.WriteLine(uri);
                //Agregar nuevo método con parametro en la uri
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = WebRequestMethods.Http.Get;
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    Empleados response = new Empleados();
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var responseArray = JsonConvert.DeserializeObject<BuscarEmpleadoResponse2>(s);

                    for (int i = 0; i < responseArray.response.Length; i++)
                    {
                        response.ID_EMPLEADO = responseArray.response[i].ID_EMPLEADO.ToString();
                        response.SNOMBRE_EMPLEADO = responseArray.response[i].SNOMBRE_EMPLEADO;
                        response.PAPELLIDO_EMPLEADO = responseArray.response[i].PAPELLIDO_EMPLEADO;
                        response.SAPELLIDO_EMPLEADO = responseArray.response[i].SAPELLIDO_EMPLEADO;
                        response.EDAD_EMPLEADO = responseArray.response[i].EDAD_EMPLEADO.ToString();
                        response.RUN_EMPLEADO = responseArray.response[i].RUN_EMPLEADO.ToString();
                        response.DV_EMPLEADO = responseArray.response[i].DV_EMPLEADO;
                        response.DIRECCION = responseArray.response[i].DIRECCION;
                        response.ID_COMUNA = responseArray.response[i].ID_COMUNA.ToString();
                        response.ID_USUARIO = responseArray.response[i].ID_USUARIO.ToString();
                        response.ID_AREA = responseArray.response[i].ID_AREA.ToString();
                        response.ID_CARGO = responseArray.response[i].ID_CARGO.ToString();

                    }




                    return response;
                    
                }
                else
                {
                    Empleados responseDummy = new Empleados();
                    return responseDummy;
                }
            }






        }//OK


        public string eliminarEmpleado(string ID_EMPLEADO) {

            var response = "";

            BorrarEmpleadoResponse bemp = new BorrarEmpleadoResponse();
            bemp.id_empleado = ID_EMPLEADO;

            var idempJson = JsonConvert.SerializeObject(bemp);

            string url = "http://localhost:8000/empleadoDelete"; //TODO Actualizar URL
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Put;

            using (var stream_writer = new StreamWriter(request.GetRequestStream())) 
            {
                stream_writer.Write(idempJson);
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

    }
}
