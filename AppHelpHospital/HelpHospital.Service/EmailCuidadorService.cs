using HelpHospital.Service.Contracts;
using System;
using System.Net;
using System.Net.Mail;

namespace HelpHospital.Service
{
    public class EmailCuidadorService : IEmailService
    {
        private string from = "guilhermehugonoahalmeidag@gmail.com";
        private string passaword = "Y5gtU276Fas";
        private string title = "Comunicado - Hospital Sírio-Libanês";

        public void Enviar( string to, string body)
        {

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(from);

            mailMessage.CC.Add(to);
            mailMessage.Subject = title;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<p>Olá!</p>" +
                "<p>Somos do Hospital Sírio-Libanês,informamos a ocorrência " +
                "da entrada de um familiar em nossas estruturas.</p>" + body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(from, passaword);

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
