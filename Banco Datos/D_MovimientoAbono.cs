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
    public class D_MovimientoAbono
    {
        public DataTable ListadoMV_abonoGenerales(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                cTexto = "%" + cTexto + "%";
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_MOVIMIENTO_ABONO WHERE NOMBRE like '" + cTexto + "' ", SqlCon);
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

        public string GuardarMV_abono(int nOpcion, E_MovimientoAbono oCl)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarMovimientoAbono", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nOpcion",         OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("nId_MV_Abono",    OracleDbType.Int32).Value = oCl.ID_MV_ABONO;
                Comando.Parameters.Add("nId_Cuenta",      OracleDbType.Int32).Value = oCl.ID_CUENTA;
                Comando.Parameters.Add("nId_Prestamo",    OracleDbType.Int32).Value = oCl.ID_PRESTAMO;
                Comando.Parameters.Add("nId_Persona",     OracleDbType.Int32).Value = oCl.ID_PERSONA;
                Comando.Parameters.Add("nId_Sucursal",    OracleDbType.Int32).Value = oCl.ID_SUCURSAL;
                Comando.Parameters.Add("nId_Transaccion", OracleDbType.Int32).Value = oCl.ID_TRANSACCION;
                Comando.Parameters.Add("cDescripcion",    OracleDbType.Varchar2).Value = oCl.DESCRIPCION;
                Comando.Parameters.Add("cTotalPagado",    OracleDbType.Decimal).Value = oCl.TOTAL_PAGADO;

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

        public DataTable Listado_persona()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();
            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_PERSONA,CAST(NOMBRE || ' ' || APE_PATE || ' ' || APE_MATE AS VARCHAR2(100)) AS NOMBRE FROM TB_PERSONAS WHERE ESTADO = 1 AND EMPLEADO = 0 ORDER BY NOMBRE ASC", SQLCon);
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

        public DataTable Listado_prestamo()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();
            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_PRESTAMO,CODIGO_PRESTAMO FROM TB_PRESTAMO WHERE ESTADO = 1", SQLCon);
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

        public DataTable Listado_sucursal()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_SUCURSAL,DIRECCION FROM TB_SUCURSAL WHERE ESTADO = 1 ORDER BY DIRECCION ASC", SQLCon);
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
                OracleCommand Comando = new OracleCommand("SELECT \r\n    A.ID_CUENTA,\r\n    CAST(B.NOMBRE || ' ' || B.APE_PATE || ' ' || B.APE_MATE AS VARCHAR2(100)) AS NOMBRE_CLIENTE\r\nFROM \r\n    TB_CUENTA A\r\nINNER JOIN\r\n    TB_PERSONAS B\r\nON\r\n    A.ID_PERSONA = B.ID_PERSONA\r\nWHERE \r\n    A.ESTADO = 1 AND B.EMPLEADO = 0 \r\nORDER BY \r\n    NOMBRE_CLIENTE ASC", SQLCon);
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

        public DataTable Listado_transaccion()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();
            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_TRANSACCION,TIPO_TRANSACCION FROM TB_TRANSACCION WHERE ESTADO = 1", SQLCon);
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