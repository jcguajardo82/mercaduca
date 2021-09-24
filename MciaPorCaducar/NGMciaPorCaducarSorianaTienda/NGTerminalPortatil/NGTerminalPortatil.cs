using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDMciaPorCaducarSorianaTienda.EDShared;
using System.Data.SqlClient;

namespace NGMciaPorCaducarSorianaTienda.NGTerminalPortatil
{
    public class NGTerminalPortatil
    {
        DTMciaPorCaducarSorianaTienda.DTTerminalPortatil.DTTerminalPortatil dt = new DTMciaPorCaducarSorianaTienda.DTTerminalPortatil.DTTerminalPortatil();

        #region NGCapturaMcia
        public DataSet CaducaEntrada()
        {
            try
            {
                DataSet ds = dt.CaducaEntrada();

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            {
                throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet CaducaArticulo(string FolMcia, string CodBarra)
        {
            try
            {
                DataSet ds = dt.CaducaArticulo( FolMcia,  CodBarra);

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet CaducaLote(string FolMcia, string NumSKU, string CveLote)
        {
            try
            {
                DataSet ds = dt.CaducaLote( FolMcia,  NumSKU,  CveLote);

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet CaducaFecCaducidad(string FolMcia, string NumSKU, string CveLote, string FecCad)
        {
            try
            {
                DataSet ds = dt.CaducaFecCaducidad( FolMcia,  NumSKU,  CveLote,  FecCad);

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public string CaducaCantidad(string FolMcia, string NumSKU, string CveLote, string FecCad, string Cantidad)
        {
            try
            {
                string resultado = dt.CaducaCantidad( FolMcia,  NumSKU,  CveLote,  FecCad,  Cantidad);

                return resultado;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public string Caduca(string FolMcia, string NumSKU, string CveLote, string FecCad, string Cantidad)
        {
            try
            {
                string resultado = dt.Caduca(FolMcia, NumSKU, CveLote, FecCad, Cantidad);

                return resultado;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public string CaducaSalir(string CveOperacion, string FolMcia)
        {
            try
            {
                string resultado = dt.CaducaSalir( CveOperacion,  FolMcia);

                return resultado;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region NGAutorizaMerma
        public string AutMermaEntrada()
        {
            try
            {
                string res = dt.AutMermaEntrada();

                return res;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Combo> ComboAutMermaMostrarJD(string JefeDepto)
        {
            try
            {
                DataSet ds = dt.AutMermaMostrarJD( JefeDepto);
                List<Combo> lista = new List<Combo>();

                Combo cmbIn = new Combo();
                cmbIn.Id = null;
                cmbIn.Descripcion = "Seleccione";
                lista.Add(cmbIn);

                Combo cmbSalir = new Combo();
                cmbSalir.Id = "Salir";
                cmbSalir.Descripcion = "Salir";
                lista.Add(cmbSalir);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Combo cmb = new Combo();

                    cmb.Id = row[0].ToString();
                    cmb.Descripcion = row[1].ToString();

                    lista.Add(cmb);
                }

                return lista;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet AutMermaMostrarJD(string JefeDepto)
        {
            try
            {
                DataSet ds = dt.AutMermaMostrarJD(JefeDepto);

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet AutMermaValidaCodigos()
        {
            try
            {
                DataSet ds = dt.AutMermaValidaCodigos();

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet AutMermaSalir()
        {
            try
            {
                DataSet ds = dt.AutMermaSalir();

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public DataSet AutMermaArticulo(string Usuario, string CodBarra)
        {
            try
            {
                DataSet ds = dt.AutMermaArticulo( Usuario,  CodBarra);

                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public string AutMermaCantidad(string NumSKU, string Existencia, string Cantidad,string CodBarra,string BitExisteLote)
        {
            try
            {
                string resultado = dt.AutMermaCantidad( NumSKU,  Existencia,  Cantidad, CodBarra, BitExisteLote);

                return resultado;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
