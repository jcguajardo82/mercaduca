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

        [CheckSessionOut]
        public ActionResult CapturaMcia(string op4, string inCan, string op2, string inFec, string inArt, string inLot)
        {
            try
            {
                if (!string.IsNullOrEmpty(op4))
                {
                    if (op4 == "1")
                    {
                        string cadSalir = ng.CaducaSalir("S", TempData["FolMcia"].ToString());

                        TempData.Clear();
                        return RedirectToAction("Inicio", "Menu");
                    }
                    else
                    {
                        string cadSalir = ng.CaducaSalir("N", TempData["FolMcia"].ToString());

                        TempData.Clear();
                        return RedirectToAction("Inicio", "Menu");
                    }
                }
                else if (!string.IsNullOrEmpty(inCan))
                {
                    string cadCant = ng.CaducaCantidad(TempData["FolMcia"].ToString(), TempData["NumSKU"].ToString(), TempData["Lote"].ToString(), TempData["FecCad"].ToString(), inCan);

                    string caduca = ng.Caduca(TempData["FolMcia"].ToString(), TempData["NumSKU"].ToString(), TempData["Lote"].ToString(), TempData["FecCad"].ToString(), inCan);

                    TempData.Clear();
                    return RedirectToAction("CapturaMcia", "MciaPorCaducar");
                }
                else if (!string.IsNullOrEmpty(op2))
                {
                    if (TempData["BitFechaDif"].ToString() == "1")
                    {
                        //Pantalla 6
                        TempData["flagOpcion"] = "CoincideFec";
                        TempData["flagField"] = "op3";
                    }
                    else
                    {
                        //Pantalla 7
                        TempData["flagOpcion"] = "CapturaCant";
                        TempData["flagField"] = "inCan";
                    }
                }
                else if (!string.IsNullOrEmpty(inFec))
                {
                    System.Data.DataSet fecCad = ng.CaducaFecCaducidad(TempData["FolMcia"].ToString(), TempData["NumSKU"].ToString(), TempData["Lote"].ToString(), inFec);

                    if (fecCad != null)
                    {
                        if (fecCad.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow rowfecCad in fecCad.Tables[0].Rows)
                            {
                                TempData["FecCad"] = inFec;
                                TempData["BitFechaDif"] = rowfecCad[1].ToString().Trim();

                                //BitFechaPasada
                                if (rowfecCad[0].ToString().Trim() == "1")
                                {
                                    //Pantalla 5  
                                    TempData["flagOpcion"] = "ConservaFec";
                                    TempData["flagField"] = "op2";
                                }
                                //BitFechaDif 
                                else if (rowfecCad[1].ToString().Trim() == "1")
                                {
                                    //Pantalla 6
                                    TempData["flagOpcion"] = "CoincideFec";
                                    TempData["flagField"] = "op3";
                                }
                                else
                                {
                                    //Pantalla 7
                                    TempData["flagOpcion"] = "CapturaCant";
                                    TempData["flagField"] = "inCan";
                                }
                            }
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else if (!string.IsNullOrEmpty(inLot))
                {
                    System.Data.DataSet cadLot = ng.CaducaLote(TempData["FolMcia"].ToString(), TempData["NumSKU"].ToString(), inLot);

                    if (cadLot != null)
                    {
                        if (cadLot.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow rowcadLot in cadLot.Tables[0].Rows)
                            {
                                TempData["Lote"] = inLot;
                                TempData["FecCad"] = rowcadLot[2].ToString().Trim();
                                //BitExisteLote
                                if (rowcadLot[0].ToString().Trim() == "0")
                                {
                                    //Pantalla 4
                                    TempData["flagOpcion"] = "FecCad";
                                    TempData["flagField"] = "inFec";
                                }
                                else
                                {
                                    TempData["CanCap"] = rowcadLot[1].ToString().Trim();
                                    //Pantalla 3
                                    TempData["flagOpcion"] = "LoteReg";
                                    TempData["flagField"] = "op";
                                }
                            }
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else if (!string.IsNullOrEmpty(inArt))
                {
                    System.Data.DataSet cadArt = ng.CaducaArticulo(TempData["FolMcia"].ToString(), inArt);

                    if (cadArt != null)
                    {
                        if (cadArt.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow rowcadArt in cadArt.Tables[0].Rows)
                            {
                                TempData["NumSKU"] = rowcadArt[0].ToString().Trim();
                                TempData["DescCod"] = rowcadArt[1].ToString().Trim().ToLower();
                            }
                            //Pantalla 2 
                            TempData["flagOpcion"] = "Lote";
                            TempData["flagField"] = "inLot";
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else
                {
                    TempData.Clear();

                    TempData["flagOpcion"] = string.Empty;

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
                                TempData["FolMcia"] = rowfol[0].ToString().Trim();
                            }
                            TempData["flagOpcion"] = "Principal";
                            Session["TituloPagina"] = "2.-Captura Mcía Caduc";
                            TempData["flagField"] = "inArt";
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }

                TempData.Keep();
                return View();
            }
            catch (Exception ex)
            {
                TempData.Keep();

                TempData["flagError"] = "Error";
                if (ex.Message.Contains("Int32"))
                {
                    TempData["lblResult"] = "NO EXISTE";
                }
                else if (ex.Message.Contains("Error converting data type to decimal"))
                {
                    TempData["lblResult"] = "DATO INVALIDO";
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    TempData["lblResult"] = "NO SE PUDO REALIZAR LA ACCION";
                }
                else
                {
                    TempData["lblResult"] = ex.Message.ToLower();
                }

                if (TempData["flagOpcion"].ToString() == "")
                {
                    return RedirectToAction("Inicio", "Menu");
                }

                return View();
            }
        }

        [CheckSessionOut]
        public ActionResult AutorizaMerma(string op2, string flagEsc, string inCan, string inArt, string cmb_JEFE)
        {
            try
            {
                if (!string.IsNullOrEmpty(op2))
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
                                    TempData["NumActaDestruccion"] = rowautSal[1].ToString().Trim();
                                    TempData["FechaSKU"] = rowautSal[2].ToString().Trim();
                                    //Pantalla 6
                                    TempData["flagOpcion"] = "FolGen";
                                    TempData["flagField"] = "op3";
                                }
                                else
                                {
                                    //Pantalla 7
                                    TempData["flagOpcion"] = "NoGen";
                                    TempData["flagField"] = "op4";
                                }
                            }
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else if (!string.IsNullOrEmpty(flagEsc))
                {
                    if (flagEsc == "Esc")
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
                                        TempData["flagOpcion"] = "GenActa";
                                        TempData["flagField"] = "op2";
                                    }
                                    else
                                    {
                                        //salir 
                                        return RedirectToAction("Inicio", "Menu");
                                    }
                                }
                            }
                        }
                        else
                        {
                            TempData["flagError"] = "Error";
                            TempData["lblResult"] = "ERROR: NO EXISTE";
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(inCan))
                {
                    string capCant = ng.AutMermaCantidad(TempData["NumSKU"].ToString(), TempData["Existe"].ToString(), inCan, TempData["CodBarra"].ToString(), TempData["BitExisteLote"].ToString());

                    //Pantalla 2
                    TempData["flagOpcion"] = "CapArt";
                    TempData["flagField"] = "inArt";
                }
                else if (!string.IsNullOrEmpty(inArt))
                {
                    System.Data.DataSet artMer = ng.AutMermaArticulo(TempData["IdJefe"].ToString(), inArt);

                    if (artMer != null)
                    {
                        if (artMer.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow rowartMer in artMer.Tables[0].Rows)
                            {
                                TempData["CodBarra"] = inArt;
                                TempData["NumSKU"] = rowartMer[0].ToString().Trim();
                                TempData["DesArt"] = rowartMer[1].ToString().Trim().ToLower();
                                TempData["Lote"] = rowartMer[2].ToString().Trim();
                                TempData["Fecha"] = rowartMer[3].ToString().Trim();
                                TempData["Existe"] = rowartMer[4].ToString().Trim();
                                TempData["BitExisteLote"] = rowartMer[5].ToString().Trim();

                                //BitExisteLote
                                if (rowartMer[5].ToString().Trim() == "1")
                                {
                                    //Pantalla 3
                                    TempData["flagOpcion"] = "ModCant";
                                    TempData["flagField"] = "op";
                                    TempData["CantArt"] = rowartMer[6].ToString().Trim();
                                }
                                else
                                {
                                    //Pantalla 4
                                    TempData["flagOpcion"] = "CapCantMerma";
                                    TempData["flagField"] = "inCan";
                                }
                            }
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else if (!string.IsNullOrEmpty(cmb_JEFE))
                {
                    System.Data.DataSet merMos = ng.AutMermaMostrarJD(cmb_JEFE);

                    if (merMos != null)
                    {
                        if (merMos.Tables.Count > 0)
                        {
                            foreach (System.Data.DataRow rowmerMos in merMos.Tables[0].Rows)
                            {
                                TempData["NomJefe"] = rowmerMos[1].ToString().Trim().ToLower();
                            }
                            TempData["IdJefe"] = cmb_JEFE;
                            //Pantalla 2 
                            TempData["flagOpcion"] = "CapArt";
                            TempData["flagField"] = "inArt";
                        }
                    }
                    else
                    {
                        TempData["flagError"] = "Error";
                        TempData["lblResult"] = "ERROR: NO EXISTE";
                    }
                }
                else
                {
                    TempData.Clear();

                    TempData["flagOpcion"] = string.Empty;

                    string autMer = ng.AutMermaEntrada();

                    var ddlJefe = new SelectList(ng.ComboAutMermaMostrarJD(null), "Id", "Descripcion");
                    ViewData["cmb_JEFE"] = ddlJefe;

                    TempData["flagOpcion"] = "Principal";
                    TempData["flagField"] = "cmb_JEFE";
                    Session["TituloPagina"] = "1.-Autorizar Merma";
                }

                TempData.Keep();
                return View();
            }
            catch (Exception ex)
            {
                TempData.Keep();

                TempData["flagError"] = "Error";
                if (ex.Message.Contains("Int32"))
                {
                    TempData["lblResult"] = "NO EXISTE";
                }
                else if (ex.Message.Contains("Error converting data type to decimal"))
                {
                    TempData["lblResult"] = "DATO INVALIDO";
                }
                else if (ex.Message.Contains("Object reference not set to an instance") || ex.Message.Contains("Referencia a objeto no establecida"))
                {
                    TempData["lblResult"] = "NO SE PUDO REALIZAR LA ACCION";
                }
                else
                {
                    TempData["lblResult"] = ex.Message.ToLower();
                }

                if (TempData["flagOpcion"].ToString() == "")
                {
                    return RedirectToAction("Inicio", "Menu");
                }

                return View();
            }
        }
    }
}