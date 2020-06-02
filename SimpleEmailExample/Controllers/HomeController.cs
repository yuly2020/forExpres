using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleEmailExample.Models;


namespace SimpleEmailExample.Controllers
{
    public class HomeController : Controller
    {

        // Aqui realizo la conexión a la BD 
       
        SimpleEmailExample.Models.SimpleEmailDBConnection BD = new Models.SimpleEmailDBConnection();
        public ActionResult Index()
        {
            
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //Muestro el listado de email de la BD retornando una lista
            return View();

        }

         public ActionResult ListadoEmail()
        {
            //Muestro el listado de email de la BD retornando una lista
            var qry = BD.Email;
            return View(qry.ToList());
           
        }
        // EnvioEmail   es un metodo donde recibe 3 para metros de información  para el envio del correo

        [HttpPost]
        public ActionResult EnvioEmail(string TX_Email, string TX_Subject, string TX_Message)

        {
            // Valido si los campos traen su respectiva información porque son campos obligatorios
            if (TX_Email == "") 

                return Content("Debe ingresar el correo");


             if  (TX_Subject == "")

                return Content("Debe ingresar el Subject");

            if (TX_Message == "")

                return Content("Debe ingresar el Message");
            else


            //  realice una clase global llamada enviarCorreo, con el fin de que se pueda implementar desde 
            // cualquier controlador 

            new Emails().enviarCorreo(TX_Email, TX_Subject, TX_Message);

          //guardo  los mensajes los campos en BD tabla Email para tener en cuenta a quien fue enviado

            Email campos = new Email();
            campos.Email1 = TX_Email;
            campos.Subject = TX_Subject;
            campos.Message = TX_Message; 
            BD.Email.Add(campos);
            //BD.SaveChanges();


            // Si el mensaje fue enviado muestro un mensaje por pantalla  de que fue enviado satisfactoriamente


            ViewBag.Mensaje = "Mensaje enviado correctamente";

            // Redirecciona  al listado
            return RedirectToAction("ListadoEmail");

           
        }

    }
}