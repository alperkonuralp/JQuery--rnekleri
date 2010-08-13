using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DersDemo_Ajax_First.NorthwindDataSetTableAdapters;
using System.Text;

namespace DersDemo_Ajax_First
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Data : IHttpHandler
    {
        private HttpContext _context;
        private HttpRequest _req;
        private HttpResponse _res;
        private CategoriesTableAdapter cata;
        private ProductsTableAdapter prta;

        public void ProcessRequest(HttpContext context)
        {


            _context = context;
            _req = context.Request;
            _res = context.Response;

            if (!string.IsNullOrEmpty(_req.QueryString["t"]))
            {
                switch (_req.QueryString["t"].ToLower())
                {
                    case "categories":
                        if (!string.IsNullOrEmpty(_req.QueryString["id"]))
                        {
                            cata = new CategoriesTableAdapter();
                            var ds = new NorthwindDataSet();
                            cata.FillByCategoryID(ds.Categories, int.Parse(_req.QueryString["id"]));
                            foreach (var item in ds.Categories)
                            {
                                item.Picture = null;
                            }
                            _res.ContentType = "text/xml";
                            _res.ContentEncoding = Encoding.UTF8;
                            _res.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                            ds.WriteXml(_res.OutputStream);

                        }
                        else
                        {
                            cata = new CategoriesTableAdapter();
                            var ds = new NorthwindDataSet();
                            cata.Fill(ds.Categories);
                            foreach (var item in ds.Categories)
                            {
                                item.Picture = null;
                            }
                            _res.ContentType = "text/xml";
                            _res.ContentEncoding = Encoding.UTF8;
                            _res.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                            ds.WriteXml(_res.OutputStream);

                        }
                        return;

                    case "products":
                        if (!string.IsNullOrEmpty(_req.QueryString["id"]))
                        {
                            prta = new ProductsTableAdapter();
                            var ds = new NorthwindDataSet();
                            prta.FillByProductID(ds.Products, int.Parse(_req.QueryString["id"]));
                            _res.ContentType = "text/xml";
                            _res.ContentEncoding = Encoding.UTF8;
                            _res.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                            ds.WriteXml(_res.OutputStream);

                        }
                        else if (!string.IsNullOrEmpty(_req.QueryString["cid"]))
                        {
                            prta = new ProductsTableAdapter();
                            var ds = new NorthwindDataSet();
                            prta.FillByCategoryID(ds.Products, int.Parse(_req.QueryString["cid"]));
                            _res.ContentType = "text/xml";
                            _res.ContentEncoding = Encoding.UTF8;
                            _res.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                            ds.WriteXml(_res.OutputStream);

                        }
                        else
                        {
                            prta = new ProductsTableAdapter();
                            var ds = new NorthwindDataSet();
                            prta.Fill(ds.Products);
                            _res.ContentType = "text/xml";
                            _res.ContentEncoding = Encoding.UTF8;
                            _res.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                            ds.WriteXml(_res.OutputStream);

                        }
                        return;
                    default:
                        break;
                }
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
