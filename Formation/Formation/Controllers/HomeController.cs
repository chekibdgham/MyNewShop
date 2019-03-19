using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Formation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string ResultConnection(string username,string password)
        {
            string resultat = "";
            if (username=="chekib" && password=="123")
            {
                resultat = "success";
            }
            else
            {
                resultat = "failed";
            }
            return resultat;
        }
    }
}