using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.Menu;

namespace WebMvc.MciaPorCaducar.Controllers
{
    public class MciaPorCaducarController : Controller
    {
        NGMciaPorCaducarSorianaTienda.NGTerminalPortatil.NGTerminalPortatil ng = new NGMciaPorCaducarSorianaTienda.NGTerminalPortatil.NGTerminalPortatil();

        // GET: MciaPorCaducar
        public ActionResult Index()
        {
            return View();
        }

        #region Captura de Mercancia
        [CheckSessionOut]
        public ActionResult CapturaMcia()
        {
            try
            {
                Session["flagOpcion"] = string.Empty;

                System.Data.DataSet fol = ng.CaducaEntrada();
                /*********************
                 * Fol_MciaCaduca
                   --------------
                   324
                 *********************/

                if (fol != null)
                {
                    if (fol.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowfol in fol.Tables[0].Rows)
                        {
                            Session["FolMcia"] = rowfol[0].ToString().Trim();
                        }
                        Session["flagOpcion"] = "Principal";
                        Session["TituloPagina"] = "2.-Captura Mcía Caduc";
                        Session["flagField"] = "inArt";
                    }
                }
                else
                {
                    Session["flagOpcion"] = "Error";
                    Session["lblResult"] = "ERROR: NO EXISTE".ToLower();
                }

                return View();
            }
            catch (Exception ex)
            {
                Session["flagOpcion"] = "Error";
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    Session["lblResult"] = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    Session["lblResult"] = "NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    Session["lblResult"] = ex.Message.ToLower();
                }

                if (Session["flagOpcion"].ToString() == "" || Session["flagOpcion"].ToString() == "Error")
                {
                    return RedirectToAction("Inicio", "Menu");
                }

                return View();
            }
        }

        [CheckSessionOut]
        public ActionResult mCapturaMcia()
        {
            try
            {
                Session["flagOpcion"] = string.Empty;

                System.Data.DataSet fol = ng.CaducaEntrada();
                /*********************
                 * Fol_MciaCaduca
                   --------------
                   324
                 *********************/

                if (fol != null)
                {
                    if (fol.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowfol in fol.Tables[0].Rows)
                        {
                            Session["FolMcia"] = rowfol[0].ToString().Trim();
                        }
                        Session["flagOpcion"] = "Principal";
                        Session["TituloPagina"] = "2.-Captura Mcía Caduc";
                        Session["flagField"] = "inArt";
                    }
                }
                else
                {
                    Session["flagOpcion"] = "Error";
                    Session["lblResult"] = "ERROR: NO EXISTE".ToLower();
                }

                return View();
            }
            catch (Exception ex)
            {
                Session["flagOpcion"] = "Error";
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    Session["lblResult"] = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    Session["lblResult"] = "NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    Session["lblResult"] = ex.Message.ToLower();
                }

                if (Session["flagOpcion"].ToString() == "" || Session["flagOpcion"].ToString() == "Error")
                {
                    return RedirectToAction("Index", "Menu");
                }

                return View();
            }
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult CaducaArticulo(string inArt)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet cadArt = ng.CaducaArticulo(Session["FolMcia"].ToString(), inArt);

                if (cadArt != null)
                {
                    if (cadArt.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowcadArt in cadArt.Tables[0].Rows)
                        {
                            Session["NumSKU"] = rowcadArt[0].ToString().Trim();
                            temp = "Continuar~" + rowcadArt[1].ToString().Trim().ToLower();
                        }
                        //Pantalla 2 
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult CaducaLote(string inLot)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet cadLot = ng.CaducaLote(Session["FolMcia"].ToString(), Session["NumSKU"].ToString(), inLot);

                if (cadLot != null)
                {
                    if (cadLot.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowcadLot in cadLot.Tables[0].Rows)
                        {
                            temp = "Continuar~" + rowcadLot[2].ToString().Trim() + ";";
                            //BitExisteLote
                            if (rowcadLot[0].ToString().Trim() == "0")
                            {
                                //Pantalla 4
                                temp += "FecCad";
                            }
                            else
                            {
                                //Pantalla 3
                                temp += "LoteReg;" + rowcadLot[1].ToString().Trim();
                            }
                        }
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult CaducaFecCaducidad(string inLot, string inFec)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet fecCad = ng.CaducaFecCaducidad(Session["FolMcia"].ToString(), Session["NumSKU"].ToString(), inLot, inFec);

                if (fecCad != null)
                {
                    if (fecCad.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowfecCad in fecCad.Tables[0].Rows)
                        {
                            Session["BitFechaDif"] = rowfecCad[1].ToString().Trim();

                            //BitFechaPasada
                            if (rowfecCad[0].ToString().Trim() == "1")
                            {
                                //Pantalla 5  
                                temp = "Continuar~ConservaFec";
                            }
                            //BitFechaDif 
                            else if (rowfecCad[1].ToString().Trim() == "1")
                            {
                                //Pantalla 6
                                temp = "Continuar~CoincideFec";
                            }
                            else
                            {
                                //Pantalla 7
                                temp = "Continuar~CapturaCant";
                            }
                        }
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }

            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult ValPantalla()
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                if (Session["BitFechaDif"].ToString() == "1")
                {
                    //Pantalla 6
                    temp = "Continuar~CoincideFec";
                }
                else
                {
                    //Pantalla 7
                    temp = "Continuar~CapturaCant";
                }

            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult CaducaCantidad(string inCan, string inLot, string inFec)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                string cadCant = ng.CaducaCantidad(Session["FolMcia"].ToString(), Session["NumSKU"].ToString(), inLot, inFec, inCan);

                string caduca = ng.Caduca(Session["FolMcia"].ToString(), Session["NumSKU"].ToString(), inLot, inFec, inCan);

                Session["FolMcia"] = 0;
                Session.Remove("NumSKU");
                Session.Remove("BitFechaDif");
                temp = "Continuar~CapturaMcia";
                // return RedirectToAction("CapturaMcia", "MciaPorCaducar");

            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult CaducaSalir(string op4)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                if (op4 == "1")
                {
                    string cadSalir = ng.CaducaSalir("S", Session["FolMcia"].ToString());

                    Session["FolMcia"] = 0;
                    Session.Remove("NumSKU");
                    Session.Remove("BitFechaDif");
                    //return RedirectToAction("Inicio", "Menu");
                    temp = "Continuar~Inicio";
                }
                else
                {
                    string cadSalir = ng.CaducaSalir("N", Session["FolMcia"].ToString());

                    Session["FolMcia"] = 0;
                    Session.Remove("NumSKU");
                    Session.Remove("BitFechaDif");
                    //return RedirectToAction("Inicio", "Menu");
                    temp = "Continuar~Inicio";
                }

            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Autoriza Merma
        [CheckSessionOut]
        public ActionResult AutorizaMerma()
        {
            try
            {
                Session["flagOpcion"] = string.Empty;

                string autMer = ng.AutMermaEntrada();

                var ddlJefe = new SelectList(ng.ComboAutMermaMostrarJD(null), "Id", "Descripcion");
                Session["cmb_JEFE"] = ddlJefe;

                Session["flagOpcion"] = "Principal";
                Session["flagField"] = "cmb_JEFE";
                Session["TituloPagina"] = "1.-Autorizar Merma";

                return View();
            }
            catch (Exception ex)
            {
                Session["flagOpcion"] = "Error";
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    Session["lblResult"] = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    Session["lblResult"] = "NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    Session["lblResult"] = ex.Message.ToLower();
                }

                if (Session["flagOpcion"].ToString() == "" || Session["flagOpcion"].ToString() == "Error")
                {
                    return RedirectToAction("Inicio", "Menu");
                }

                return View();
            }
        }

        [CheckSessionOut]
        public ActionResult mAutorizaMerma()
        {
            try
            {
                Session["flagOpcion"] = string.Empty;

                string autMer = ng.AutMermaEntrada();

                var ddlJefe = new SelectList(ng.ComboAutMermaMostrarJD(null), "Id", "Descripcion");
                Session["cmb_JEFE"] = ddlJefe;

                Session["flagOpcion"] = "Principal";
                Session["flagField"] = "cmb_JEFE";
                Session["TituloPagina"] = "1.-Autorizar Merma";

                return View();
            }
            catch (Exception ex)
            {
                Session["flagOpcion"] = "Error";
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    Session["lblResult"] = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    Session["lblResult"] = "NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    Session["lblResult"] = ex.Message.ToLower();
                }

                if (Session["flagOpcion"].ToString() == "" || Session["flagOpcion"].ToString() == "Error")
                {
                    return RedirectToAction("Index", "Menu");
                }

                return View();
            }
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult AutMermaValidaCodigos()
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet valCod = ng.AutMermaValidaCodigos();

                if (valCod != null)
                {
                    if (valCod.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowvalCod in valCod.Tables[0].Rows)
                        {

                            //BitCodigosAutz
                            if (rowvalCod[0].ToString().Trim() == "1")
                            {
                                //Pantalla 5
                                temp = "Continuar~GenActa";
                            }
                            else
                            {
                                //salir 
                                // return RedirectToAction("Inicio", "Menu");
                                temp = "Continuar~Inicio";
                            }
                        }
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult AutMermaMostrarJD(string cmb_JEFE)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet merMos = ng.AutMermaMostrarJD(cmb_JEFE);

                if (merMos != null)
                {
                    if (merMos.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowmerMos in merMos.Tables[0].Rows)
                        {
                            temp = "Continuar~CapArt;" + rowmerMos[1].ToString().Trim().ToLower();
                        }
                        //Pantalla 2 
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult AutMermaArticulo(string cmb_JEFE, string inArt)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet artMer = ng.AutMermaArticulo(cmb_JEFE, inArt);

                if (artMer != null)
                {
                    if (artMer.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowartMer in artMer.Tables[0].Rows)
                        {
                            Session["BitExisteLote"] = rowartMer[5].ToString().Trim();
                            Session["NumSKU"] = rowartMer[0].ToString().Trim();

                            temp = "Continuar~" + rowartMer[1].ToString().Trim().ToLower() + ";" + rowartMer[2].ToString().Trim() + ";" + rowartMer[3].ToString().Trim() + ";" + rowartMer[4].ToString().Trim() + ";";

                            //BitExisteLote
                            if (rowartMer[5].ToString().Trim() == "1")
                            {
                                //Pantalla 3
                                temp += "ModCant;" + rowartMer[6].ToString().Trim();
                            }
                            else
                            {
                                //Pantalla 4
                                temp += "CapCantMerma";
                            }
                        }
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult AutMermaCantidad(string Existe, string inCan, string inArt)
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                string capCant = ng.AutMermaCantidad(Session["NumSKU"].ToString(), Existe, inCan, inArt, Session["BitExisteLote"].ToString());

                //Pantalla 2
                temp = "Continuar~CapArt";
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult AutMermaSalir()
        {
            string temp = Request.QueryString["userName"] + "Controller";

            try
            {
                System.Data.DataSet autSal = ng.AutMermaSalir();

                if (autSal != null)
                {
                    if (autSal.Tables.Count > 0)
                    {
                        foreach (System.Data.DataRow rowautSal in autSal.Tables[0].Rows)
                        {
                            //BitActaDestruccion
                            if (rowautSal[0].ToString().Trim() == "1")
                            {
                                temp = "Continuar~FolGen;" + rowautSal[1].ToString().Trim() + ";" + rowautSal[2].ToString().Trim();
                                //Pantalla 6
                            }
                            else
                            {
                                temp = "Continuar~NoGen";
                                //Pantalla 7
                            }
                        }
                    }
                }
                else
                {
                    temp = "Error~" + "ERROR: NO EXISTE".ToLower();
                }
            }
            catch (Exception ex)
            {
                string msjError;
                if (ex.Message.Contains("Int32") || ex.Message.Contains("Error converting data type to decimal"))
                {
                    msjError = "NO EXISTE, DATO INVALIDO".ToLower();
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    msjError = "ERROR: NO SE PUDO REALIZAR LA ACCION".ToLower();
                }
                else
                {
                    msjError = ex.Message.ToLower();
                }

                temp = "Error~" + msjError;
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}