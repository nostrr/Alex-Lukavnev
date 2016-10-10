using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string time = DateTime.Now.ToString();
            string Method = Request.HttpMethod.ToString();
            string URL = Request.Url.ToString();
            string IP = Request.UserHostAddress.ToString();
            string path = HttpContext.Server.MapPath("~/App_Data");
            using (var stream = new FileStream(path + @"\Log.dat", FileMode.Append, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream, Encoding.GetEncoding(1251)))
                {
                    writer.WriteLine("Время : {0} \nМетод : {1} \nПолный URL : {2} \nIP : {3}\n", time, Method, URL, IP);
                }
            }
            return View();
        }
    }
}