using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnjQuery.DAL;
using LearnjQuery.Models;

namespace LearnjQuery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string ChekConnection(string username,string password)
        {
            string securedInfo = "";
            LearnjQueryContext context = new LearnjQueryContext();

            Connexion resultat = context.Connexions.Where(p => p.UserName == username && p.PassWord==password).FirstOrDefault();
            if (resultat==null)
            {
                securedInfo = "Failed";
            }
            else
            {
                securedInfo = "Success";
            }
            return securedInfo;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}