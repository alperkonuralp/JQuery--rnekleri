using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace DersDemo_Ajax_Second
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MuhtarlikVeriKayit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Stopwatch sc = new Stopwatch();
            sc.Start();
            var name = context.Server.MapPath(string.Format("~/datas/Data_{0:yyyy}{0:MM}{0:dd}{0:hh}{0:mm}{0:ss}.txt", DateTime.Now));
            StringBuilder sb = new StringBuilder("Muhtarlık Veri Girişi : ");
            sb.AppendLine();
            sb.AppendFormat("Zaman : {0:D} {0:T}", DateTime.Now);
            sb.AppendLine();

            sb.AppendLine("Query String(Get):");
            foreach (DictionaryEntry a in context.Request.QueryString)
            {
                sb.AppendFormat("{0} = {1}\r\n", a.Key, a.Value);
            }

            sb.AppendLine();

            sb.AppendLine("Form(Post):");
            foreach (DictionaryEntry a in context.Request.Form)
            {
                sb.AppendFormat("{0} = {1}\r\n", a.Key, a.Value);
            }

            sb.AppendLine();

            sb.AppendLine("Cookies:");
            foreach (HttpCookie a in context.Request.Cookies)
            {
                sb.AppendFormat("{0} = {1}\r\n", a.Name, a.Value);
            }

            sb.AppendLine();

            sb.AppendLine("Server Variables:");
            foreach (DictionaryEntry a in context.Request.ServerVariables)
            {
                sb.AppendFormat("{0} = {1}\r\n", a.Key, a.Value);
            }
            sb.AppendLine();

            File.AppendAllText(name, sb.ToString());
            sc.Stop();

            File.AppendAllText(name, "\r\nİşlem için geçen süre : " + sc.Elapsed + "\r\n");


            context.Response.ContentType = "text/plain";
            context.Response.Write("ok - " + name);
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
