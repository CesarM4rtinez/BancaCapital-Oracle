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
    public class D_Tarjetas
    {
        public DataTable Listado_tarjeta(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                cTexto = "%" + cTexto + "%";
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_TARJETAS WHERE NOMBRE like '" + cTexto + "' ", SQLCon);
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
        
        public string Guardar_tarjeta(int nOpcion, E_Tarjetas oCl)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarTarjeta", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nOpcion",     OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("nId_Tarjeta", OracleDbType.Int32).Value = oCl.ID_TARJETA; // Añade el ID_CLIENTE para la actualización
                Comando.Parameters.Add("nId_Persona", OracleDbType.Int32).Value = oCl.ID_PERSONA;
                Comando.Parameters.Add("nId_Cuenta",  OracleDbType.Int32).Value = oCl.ID_CUENTA;
                Comando.Parameters.Add("nId_TipoTarjeta", OracleDbType.Int32).Value = oCl.ID_TP_TARJETA;
                Comando.Parameters.Add("cSaldo",          OracleDbType.Decimal).Value = oCl.SALDO;
                Comando.Parameters.Add("cLimite", OracleDbType.Decimal).Value = oCl.LIMITE;

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
                OracleCommand Comando = new OracleCommand("SELECT \r\n    A.ID_PERSONA AS PERSONA_CLIENTE,\r\n    CAST(A.NOMBRE || ' ' || A.APE_PATE || ' ' || A.APE_MATE AS VARCHAR2(100)) AS NOMBRE_CLIENTE\r\nFROM \r\n    TB_PERSONAS A\r\nINNER JOIN\r\n    TB_CUENTA B\r\nON\r\n    B.ID_PERSONA = A.ID_PERSONA\r\nWHERE \r\n    A.ESTADO = 1 AND A.EMPLEADO = 0 \r\nORDER BY \r\n    NOMBRE_CLIENTE ASC", SQLCon);
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
                OracleCommand Comando = new OracleCommand("SELECT \r\n    A.ID_CUENTA AS CUENTA_PERSONA,\r\n    CAST(B.NOMBRE || ' ' || B.APE_PATE || ' ' || B.APE_MATE AS VARCHAR2(100)) AS NOMBRE_CLIENTE\r\nFROM \r\n    TB_CUENTA A\r\nINNER JOIN\r\n    TB_PERSONAS B\r\nON\r\n    A.ID_PERSONA = B.ID_PERSONA\r\nWHERE \r\n    A.ESTADO = 1 AND B.EMPLEADO = 0 \r\nORDER BY \r\n    NOMBRE_CLIENTE ASC", SQLCon);
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

        public DataTable Listado_tipoTarjeta()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_TIPO_TARJETA,NOM_TARJETA FROM TB_TIPO_TARJETA WHERE ESTADO = 1 ORDER BY NOM_TARJETA ASC", SQLCon);
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
