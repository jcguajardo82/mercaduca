using Soriana.FWK.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebMvc.Menu.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        [CheckSessionOut]
        public ActionResult Inicio(string urlDestino)
        {
            if (Request.UserHostAddress.ToString().Contains(":"))
            {
                if (Request.UserHostAddress.ToString().Split(':').Length > 3)
                { System.Web.HttpContext.Current.Session["TerminalId"] = Request.UserHostAddress.ToString().Split(':')[3]; }
                else
                { System.Web.HttpContext.Current.Session["TerminalId"] = Request.UserHostAddress.ToString().Split(':')[2]; }
            }
            else
            {
                System.Web.HttpContext.Current.Session["TerminalId"] = Request.UserHostAddress.ToString().Split('.')[3];
            }
    
            List<Soriana.FWK.Common.MenuMovilModels> list = new List<Soriana.FWK.Common.MenuMovilModels>();

            list = Soriana.FWK.Common.Helper.GetMenuTpByUserId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim(), urlDestino);

            ViewBag.listMenu = list;
            Session["MenuId"] = urlDestino;
            Session["srvName"] = ConfigurationManager.AppSettings["NombreSitio"].ToString();

            if (!string.IsNullOrEmpty(urlDestino))
            {
                return Redirect(urlDestino.ToString().Trim());

            }
            else
            { return View(); }
        }

        [CheckSessionOut]
        public ActionResult Inicio_6_1(string urlDestino)
        {
            if (string.IsNullOrEmpty(urlDestino))
            {
                urlDestino = Session["MenuId"].ToString();
            }

            Session["MenuId"] = urlDestino;

            List<Soriana.FWK.Common.MenuMovilModels> list = new List<Soriana.FWK.Common.MenuMovilModels>();

            list = Soriana.FWK.Common.Helper.GetMenuTpByUserId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim(), urlDestino);

            ViewBag.listMenu = list;

            //if (!string.IsNullOrEmpty(urlDestino))
            //{

            //    return Redirect(System.Configuration.ConfigurationManager.AppSettings[urlDestino.ToString().Trim()]);

            //}
            //else
            //{ return View(); }

            return View();
        }

        [CheckSessionOut]
        public ActionResult Inicio_7_1(string urlDestino)
        {
            if (string.IsNullOrEmpty(urlDestino))
            {
                urlDestino = Session["MenuId"].ToString();
            }

            Session["MenuId"] = urlDestino;

            List<Soriana.FWK.Common.MenuMovilModels> list = new List<Soriana.FWK.Common.MenuMovilModels>();

            list = Soriana.FWK.Common.Helper.GetMenuTpByUserId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim(), urlDestino);

            ViewBag.listMenu = list;

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult logOut()
        {
            try
            {
                this.ControllerContext = Helper.LogOutSistema(this.ControllerContext);

                return new RedirectResult(ConfigurationManager.AppSettings["srvrName"].ToString() + ConfigurationManager.AppSettings["Login"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult pagLog()
        {
            try
            {

                this.ControllerContext = Helper.LogOutSistema(this.ControllerContext);

                return new RedirectResult(ConfigurationManager.AppSettings["srvrName"].ToString() + ConfigurationManager.AppSettings["Login"].ToString()+ConfigurationManager.AppSettings["HomeLogin"].ToString());
               // return new RedirectResult(Session["urlLogin"].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}