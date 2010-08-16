using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace DersDemo_Ajax_Second
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PersonelGiris : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            File.AppendAllText(
                context.Server.MapPath("~/log/personel.txt"),
                string.Format(
                    "Personel Kodu : {0}, \t Giriş Saati : {1} \r\n\r\n"
                    , context.Request["pk"],
                    DateTime.Now));
            context.Response.ContentType = "text/plain";
            context.Response.Write("ok");
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
