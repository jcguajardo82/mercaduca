using Soriana.FWK.Common;
using SqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Menu.Controllers
{
    public class MenuController : Controller
    {
        // GET: User
        [AuthorizationPrivilegeFilter]
        public ActionResult Index(string Navegador)
        {
            Session["srvName"] = ConfigurationManager.AppSettings["NombreSitio"].ToString();

            #region TerminalId

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
            #endregion

            #region menu
            var list = GetMenuTpBySystemId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim());

            ViewBag.listMenu = list;
            #endregion

            return View();
        }

        #region menuAndroid
        public static List<MenuModels> GetMenuTpBySystemId(string usuario, string sistemaId)
        {
            SqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
            Hashtable hashtables = new Hashtable()
            {
                { "@usuario", usuario },
                { "@Id_Sistema", sistemaId }
            };
            DataSet dataSet = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_fmk_GetMenuByUser_TP", false, hashtables);
            List<MenuModels> menuModels = new List<MenuModels>();
            MenuModels menuModel = new MenuModels();
            Hashtable hashtables1 = new Hashtable();
            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            if (row["Id_Parent"].ToString().Trim().Equals("803"))
                            {
                                if (!hashtables1.ContainsKey(row["Id_Menu"].ToString()))
                                {
                                    hashtables1.Add(row["Id_Menu"].ToString(), "ok");
                                }
                            }
                        }
                        List<string> strs = new List<string>();
                        foreach (object key in hashtables1.Keys)
                        {
                            strs.Add(key.ToString());
                        }
                        strs.Sort();
                        foreach (string str in strs)
                        {
                            menuModel = new MenuModels();
                            DataRow[] dataRowArray = dataSet.Tables[0].Select(string.Concat("Id_Menu = '", str.ToString().Trim(), "'"));
                            for (int i = 0; i < (int)dataRowArray.Length; i++)
                            {
                                DataRow dataRow = dataRowArray[i];
                                menuModel.Usuario = dataRow["Usuario"].ToString();
                                menuModel.Id_Sistema = dataRow["Id_Sistema"].ToString();
                                menuModel.Id_Usuario = dataRow["Id_Usuario"].ToString();
                                menuModel.Id_Perfil = dataRow["Id_Perfil"].ToString();
                                menuModel.Nombre = dataRow["Nombre"].ToString().ToLower();
                                menuModel.Id_Parent = dataRow["Id_Parent"].ToString();
                                menuModel.Id_Recurso = dataRow["Id_Recurso"].ToString();
                                menuModel.Id_Menu = dataRow["Id_Menu"].ToString();
                                menuModel.URL = dataRow["URL"].ToString();
                                menuModel.Posicion = dataRow["Posicion"].ToString();
                                string[] strArrays = menuModel.URL.Split(new char[] { '/' });
                                if ((int)strArrays.Length < 3)
                                {
                                    menuModel.controlador = string.Empty;
                                    menuModel.accion = string.Empty;
                                }
                                else
                                {
                                    menuModel.controlador = strArrays[1].ToString();
                                    menuModel.accion = strArrays[2].ToString();
                                }
                            }
                            menuModel.subM = new Dictionary<int, List<MenuModels>>();
                            int num = 1;
                            int num1 = 1;
                            List<MenuModels> menuModels1 = new List<MenuModels>();
                            DataRow[] dataRowArray1 = dataSet.Tables[0].Select(string.Concat("Id_Parent = '", str.ToString().Trim(), "'"));
                            for (int j = 0; j < (int)dataRowArray1.Length; j++)
                            {
                                DataRow dataRow1 = dataRowArray1[j];
                                MenuModels empty = new MenuModels()
                                {
                                    Usuario = dataRow1["Usuario"].ToString(),
                                    Id_Sistema = dataRow1["Id_Sistema"].ToString(),
                                    Id_Usuario = dataRow1["Id_Usuario"].ToString(),
                                    Id_Perfil = dataRow1["Id_Perfil"].ToString(),
                                    Nombre = dataRow1["Nombre"].ToString().ToLower(),
                                    Id_Parent = dataRow1["Id_Parent"].ToString(),
                                    Id_Recurso = dataRow1["Id_Recurso"].ToString(),
                                    Id_Menu = dataRow1["Id_Menu"].ToString(),
                                    URL = dataRow1["URL"].ToString(),
                                    Posicion = dataRow1["Posicion"].ToString()
                                };
                                string[] strArrays1 = empty.URL.Split(new char[] { '/' });
                                if ((int)strArrays1.Length < 3)
                                {
                                    empty.controlador = string.Empty;
                                    empty.accion = string.Empty;
                                }
                                else
                                {
                                    empty.controlador = strArrays1[1].ToString();
                                    empty.accion = "m" + strArrays1[2].ToString();
                                }
                                menuModels1.Add(empty);
                                if (num % 4 == 0)
                                {
                                    menuModel.subM.Add(num1, menuModels1);
                                    menuModels1 = new List<MenuModels>();
                                    num1++;
                                }
                                num++;
                            }
                            if (menuModels1.Count > 0)
                            {
                                menuModel.subM.Add(num1, menuModels1);
                            }
                            menuModels.Add(menuModel);
                        }
                    }
                }
            }
            return menuModels;
        }
        #endregion

        [CheckSessionOut]
        public ActionResult Inicio(string Navegador, string urlDestino)
        {
            //Session["Navegador"] = "Others";
            Session["srvName"] = ConfigurationManager.AppSettings["NombreSitio"].ToString();
            Session["flagOpcion"] = string.Empty;
            Session["lblResult"] = string.Empty;

            #region TerminalId
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
            #endregion

            if (Session["Navegador"] != null)
            {
                if (Session["Navegador"].ToString().Trim().Equals("Opera"))
                {
                    Session["UserId"] = System.Web.HttpContext.Current.Session["SystemUserId"];

                    List<Soriana.FWK.Common.MenuMovilModels> list = new List<Soriana.FWK.Common.MenuMovilModels>();

                    list = Soriana.FWK.Common.Helper.GetMenuTpByUserId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim(), urlDestino);

                    ViewBag.listMenu = list;
                    Session["MenuId"] = urlDestino;

                    if (!string.IsNullOrEmpty(urlDestino))
                    {
                        return Redirect(urlDestino.ToString().Trim());

                    }
                    else
                    { return View(); }
                }
                else
                {
                    return RedirectToAction("Index", "Menu");
                }
            }
            else
            {
                Session["UserId"] = System.Web.HttpContext.Current.Session["SystemUserId"];

                List<Soriana.FWK.Common.MenuMovilModels> list = new List<Soriana.FWK.Common.MenuMovilModels>();

                list = Soriana.FWK.Common.Helper.GetMenuTpByUserId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim(), urlDestino);

                ViewBag.listMenu = list;
                Session["MenuId"] = urlDestino;

                if (!string.IsNullOrEmpty(urlDestino))
                {
                    return Redirect(urlDestino.ToString().Trim());

                }
                else
                { return View(); }
            }
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


                return new RedirectResult(ConfigurationManager.AppSettings["srvrName"].ToString() + ConfigurationManager.AppSettings["Login"].ToString() + ConfigurationManager.AppSettings["HomeLogin"].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Busqueda(string origen, string paramBusqueda, string valorBusqueda)
        {
            switch (origen)
            {
                //Busqueda Apartado
                case "1":
                    TempData["@srchApartadoParam"] = paramBusqueda;
                    TempData["@srchApartadoVal"] = valorBusqueda;

                    break;
                case "2":
                    TempData["@opBusquedaCliente"] = paramBusqueda;
                    TempData["@busquedaCliente"] = valorBusqueda;

                    break;

                case "3":
                    TempData["@srchUbicacionParamalm"] = paramBusqueda;
                    TempData["@srchUbicacionValalm"] = valorBusqueda;
                    break;
                default:
                    break;
            }
            //ACTION NAME , NOMBRE CARPETA
            return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PruebaCatch(string origen, string paramBusqueda, string valorBusqueda)
        {
            try
            {
                throw new Exception();
                //return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.errMesagge = "NG002-Error en la capa de datos no existe el SKU";
                return new HttpStatusCodeResult(500, "NG001-Error en la capa de datos no existe el SKU");
                //return Json(new { status = ex.Message }, JsonRequestBehavior.AllowGet); 
            }

        }

        public ActionResult UrlNavegation(string menuOption)
        {
            switch (menuOption)
            {
                case "1":
                    return RedirectToAction("AltaMain", "AltayMantenimientoUbicaciones");
                case "2":
                    return RedirectToAction("GeneracionMain", "AltayMantenimientoUbicaciones");
                case "3":
                    return RedirectToAction("ImpresionMain", "AltayMantenimientoUbicaciones");

            }

            return View();
        }
    }
}