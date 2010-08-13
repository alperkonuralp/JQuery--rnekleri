using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Net.Mail;

namespace DersDemo_JQ_Ajax
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SendMail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            try
            {
                var mm = new MailMessage("alperkonuralp@gmail.com", "alperkonuralp@gmail.com");
                mm.Subject = "İletişim Formu - " + context.Request["tbKonu"];
                mm.Body = context.Request["tbMesaj"];
                mm.IsBodyHtml = false;

                SmtpClient sc = new SmtpClient();
                sc.EnableSsl = true;

                sc.Send(mm);


                context.Response.Write("ok");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
