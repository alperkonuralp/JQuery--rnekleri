using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace DersDemo_Ajax_First
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class IlIlce : IHttpHandler
    {
        private HttpContext _context;
        private HttpRequest _req;
        private HttpResponse _res;

        private XDocument xd;

        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            _req = context.Request;
            _res = context.Response;
            xd = XDocument.Load(_context.Server.MapPath("~/IlIlce.xml"));

            if (_req.QueryString.Count == 0)
            {
                context.Response.ContentType = "text/javascript";

                _res.Write("[");
                var a = false;
                foreach (var item in xd.Descendants("Il"))
                {
                    if (a)
                    {
                        _res.Write(",\n");
                    }
                    else
                    {
                        a = !a;
                    }
                    _res.Write(
                        string.Format(
                            "{{ \"PlakaKodu\":{0}, \"IlAdi\":\"{1}\" }}",
                        item.Attribute("PlakaKodu").Value,
                        item.Attribute("Adi").Value));
                }
                _res.Write("]");
            }
            else
            {
                context.Response.ContentType = "text/javascript";
                var pk = _req.QueryString["pk"];

                _res.Write("[");
                var a = false;
                var il = xd.Descendants("Il").FirstOrDefault(x => x.Attribute("PlakaKodu").Value == pk);
                foreach (var item in il.Descendants("Ilce"))
                {
                    if (a)
                    {
                        _res.Write(",\n");
                    }
                    else
                    {
                        a = !a;
                    }
                    _res.Write(
                        string.Format(
                            "{{ \"IlceAdi\":\"{0}\" }}",
                        item.Attribute("Adi").Value));
                }
                _res.Write("]");
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
