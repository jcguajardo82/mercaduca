using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soriana.FWK.Datos.SQL;
using System.Configuration;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System.Data;
using System.Data.SqlClient;

namespace DTMciaPorCaducarSorianaTienda.DTTerminalPortatil
{
    public class DTTerminalPortatil
    {
        public DTTerminalPortatil()
        {
            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
        }

        #region DTCapturaMcia
        public DataSet CaducaEntrada()
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcCapMciaCaducaEntrada_pUp", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message);
                throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet CaducaArticulo(string FolMcia, string CodBarra)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));
                parameters.Add("@CodBarra", CodBarra);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcCapMciaCaducaArticulo_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet CaducaLote(string FolMcia,string NumSKU, string CveLote)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));
                parameters.Add("@Id_Num_SKU", Convert.ToInt32(NumSKU));
                parameters.Add("@Id_Cve_Lote", CveLote);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcCapMciaCaducaLote_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet CaducaFecCaducidad(string FolMcia, string NumSKU, string CveLote,string FecCad)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));
                parameters.Add("@Id_Num_SKU", Convert.ToInt32(NumSKU));
                parameters.Add("@Id_Cve_Lote", CveLote);
                parameters.Add("@Fec_Caducidad", FecCad);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcCapMciaCaducaFecCaducidad_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public string CaducaCantidad(string FolMcia, string NumSKU, string CveLote, string FecCad, string Cantidad)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));
                parameters.Add("@Id_Num_SKU", Convert.ToInt32(NumSKU));
                parameters.Add("@Id_Cve_Lote", CveLote);
                parameters.Add("@Fec_Caducidad", FecCad);
                parameters.Add("@Cantidad", Convert.ToInt32(Cantidad));

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "rmpcCapMciaCaducaCantidad_sUp", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }


        public string Caduca(string FolMcia, string NumSKU, string CveLote, string FecCad, string Cantidad)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));
                parameters.Add("@Id_Num_SKU", Convert.ToInt32(NumSKU));
                parameters.Add("@Id_Cve_Lote", CveLote);
                parameters.Add("@Fec_Caducidad", FecCad);
                parameters.Add("@Cantidad", Convert.ToInt32(Cantidad));

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "rmpcCapMciaCaduca_pUp", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public string CaducaSalir(string CveOperacion, string FolMcia)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@CveOperacion", CveOperacion);
                parameters.Add("@Id_Fol_MciaCaduca", Convert.ToInt32(FolMcia));

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "rmpcCapMciaCaducaSalir_pUp", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }
        #endregion

        #region DTAutorizaMerma
        public string AutMermaEntrada()
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "rmpAutorizacionMermaEntrada_pUp", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet AutMermaValidaCodigos()
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpAutorizacionMermaValidaCodigos_pUp ", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet AutMermaMostrarJD(string JefeDepto)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_JefeDepto", JefeDepto);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcAutorizacionMermaMostrarJD_sUp ", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet AutMermaSalir()
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcAutorizacionMermaSalir_pUp ", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public DataSet AutMermaArticulo(string Usuario,string CodBarra)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Usuario", Convert.ToInt32(Usuario));
                parameters.Add("@CodBarra", CodBarra);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcAutorizacionMermaArticulo_sUp ", false, parameters);

                return ds;
            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }

        public string AutMermaCantidad(string NumSKU, string Existencia, string Cantidad,string CodBarra, string BitExisteLote)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Num_SKU", Convert.ToInt32(NumSKU));
                parameters.Add("@Existencia", Existencia);
                parameters.Add("@Cantidad", Convert.ToInt32(Cantidad));
                parameters.Add("@CodBarra", CodBarra);
                parameters.Add("@BitExisteLote", BitExisteLote);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "rmpcAutorizacionMermaCantidad_sUp", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
            catch (Exception ex)
            { Soriana.FWK.Log.clsLogManagerFWK.WriteMessage_Bitacora("Error - " + ex.Message); throw ex; }
        }
        #endregion
    }
}


