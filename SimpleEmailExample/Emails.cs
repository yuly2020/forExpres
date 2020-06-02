using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace SimpleEmailExample
{
    public class Emails
    {

        // Funcion donde se especifica el From, To , Subject  , Body
        MailMessage m = new MailMessage();
        // SmtpClient permite configurar el envio del correo, como el puerto de salida, host, credenciales
        SmtpClient smtp = new SmtpClient();



        public bool enviarCorreo(string TX_Email, string TX_Subject, string TX_Message)
        {
            try 
        {
                m.From = new MailAddress("yulym20009@gmail.com", "Mi Aplicacion");
             //   m.From = new MailAddress(TX_Email);
                m.To.Add ( new MailAddress(TX_Email));
                m.Subject = TX_Subject;
                m.Body = TX_Message;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Send(m);
        return true;
        }

        catch(Exception e)
            
       {
            return false;
        }

        }


        ////En el caso que quiera conectarse a plataforma Gmail para enviar correo.
        ////var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");

        //var m = new System.Net.Mail.MailMessage();
        //string userFrom = "yulym20009@gmail.com"; //Mi cuenta de Gmail u Office 365.
        //m.From = new MailAddress(userFrom, "Mi Aplicacion");

        //m.To.Add( new MailAddress(TX_Email));
        //        m.Subject = TX_Subject;
        //        m.Body = TX_Message;
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
               
        //        smtp.Send(m);
    }
}