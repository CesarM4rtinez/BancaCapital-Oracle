using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Banco.Datos
{
    public class D_Prestamos
    {
        public DataTable ListadoPrestamosGenerales(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                cTexto = "%" + cTexto + "%";
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_PRESTAMOS WHERE NOMBRE like '" + cTexto + "' ", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public DataTable Listado_planpago(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                cTexto = "%" + cTexto + "%";
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_PLANPAGO WHERE CODIGO_PRESTAMO like '" + cTexto + "' ", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string GuardarPrestamos(int nOpcion, E_Prestamos oCl)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarPrestamo", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nOpcion",             OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("cId_Prestamo",        OracleDbType.Int32).Value = oCl.ID_PRESTAMO;
                Comando.Parameters.Add("cMontoOtorgado",      OracleDbType.Decimal).Value = oCl.MONTO_OTORGADO;
                Comando.Parameters.Add("cTasaInteres",        OracleDbType.Decimal).Value = oCl.TASA_INTERES;
                Comando.Parameters.Add("cPlazo",              OracleDbType.Int32).Value = oCl.PLAZO;
                Comando.Parameters.Add("cId_Persona",         OracleDbType.Int32).Value = oCl.IP_PERSONA;
                Comando.Parameters.Add("cId_Cuenta",          OracleDbType.Int32).Value = oCl.ID_CUENTA;
                Comando.Parameters.Add("cId_TipoAplicacion",  OracleDbType.Int32).Value = oCl.ID_TIPO_APLICACION;
                

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public DataTable Listado_cliente()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT\r\n    A.ID_PERSONA,\r\n    CAST(A.NOMBRE || ' ' || A.APE_PATE || ' ' || A.APE_MATE AS VARCHAR2(100)) AS NOMBRE_CLIENTE\r\n    FROM\r\n    TB_PERSONAS A\r\nINNER JOIN\r\n    TB_CUENTA B\r\nON  A.ID_PERSONA = B.ID_PERSONA\r\nWHERE\r\n    B.ESTADO = 1 AND A.EMPLEADO = 0\r\nORDER BY\r\n    NOMBRE_CLIENTE\r\nASC", SQLCon);
                Comando.CommandType = CommandType.Text;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public DataTable Listado_cuenta()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT\r\n    CAST(A.NOMBRE || ' ' || A.APE_PATE || ' ' || A.APE_MATE AS VARCHAR2(100)) AS NOMBRE_CLIENTE,\r\n    B.ID_CUENTA AS CUENTA_PERSONA\r\nFROM\r\n    TB_PERSONAS A\r\nINNER JOIN\r\n    TB_CUENTA B\r\nON  A.ID_PERSONA = B.ID_PERSONA\r\nWHERE\r\n    B.ESTADO = 1 AND A.EMPLEADO = 0\r\nORDER BY\r\n    NOMBRE_CLIENTE\r\nASC", SQLCon);
                Comando.CommandType = CommandType.Text;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public DataTable Listado_producto()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT\r\n    ID_TIPO_APLICACION,\r\n    NOM_PRODUCTO\r\nFROM\r\n    TB_PRODUCTO_APLICACION\r\nWHERE ESTADO = 1\r\nORDER BY NOM_PRODUCTO ASC", SQLCon);
                Comando.CommandType = CommandType.Text;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }
    }
}
