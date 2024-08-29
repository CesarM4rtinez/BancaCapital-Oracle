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
    public class D_Cuentas
    {
        public DataTable Listado_cuenta(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                cTexto = "%" + cTexto + "%";
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_CUENTAS WHERE NOMBRE like '" + cTexto + "' ", SQLCon);
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

        public string Guardar_cuenta(int nOpcion, E_Cuentas oCl)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarCuenta", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nOpcion", OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("nId_Cuenta", OracleDbType.Int32).Value = oCl.ID_CUENTA; // Añade el ID_CLIENTE para la actualización
                Comando.Parameters.Add("nId_TipoAplicacion", OracleDbType.Int32).Value = oCl.ID_TIPO_APLICACION;
                Comando.Parameters.Add("nId_Persona", OracleDbType.Int32).Value = oCl.ID_PERSONA;
                Comando.Parameters.Add("nId_Sucursal", OracleDbType.Int32).Value = oCl.ID_SUCURSAL;
                Comando.Parameters.Add("cSaldoCuenta", OracleDbType.Decimal).Value = oCl.SALDO_CUENTA;

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

        public string Eliminar_cuenta(int ID_CUENTA)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_EliminarCuenta", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nId_Cuenta", OracleDbType.Int32).Value = ID_CUENTA;
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

        public DataTable Listado_producto()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();
            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_TIPO_APLICACION, NOM_PRODUCTO FROM TB_PRODUCTO_APLICACION WHERE ESTADO = 1 ORDER BY NOM_PRODUCTO ASC", SQLCon);
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

        public DataTable Listado_personas()
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
    }
}
