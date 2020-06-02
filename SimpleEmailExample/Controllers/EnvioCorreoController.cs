using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using System.Net.Mail;
using System.Text;


namespace SimpleEmailExample.Controllers
{
    public class EnvioCorreoController : Controller
    {
        // GET: EnvioCorreo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnvioEmail(string TX_Email, string TX_Subject, string TX_Message)

        {
            new Emails().enviarCorreo(TX_Email, TX_Subject, TX_Message);
            ViewBag.Mensaje = "Mensaje enviado correctamente";
            return View("~/Home/Contact");
        }

      
    }
}