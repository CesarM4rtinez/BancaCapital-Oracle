using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;

namespace Banco.Datos
{
    public class D_Empleado
    {
        public DataTable ListadoEmpleadoGeneral(string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                cTexto = "%" + cTexto + "%";
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from V_EMPLEADOS WHERE NOMBRE like '" + cTexto + "' ", SqlCon);
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

        public string GuardarEmpleado(int nOpcion, E_Empleado oCl)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarPersonasEmpleadas", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nOpcion", OracleDbType.Int32).Value               = nOpcion;
                Comando.Parameters.Add("nId_Persona", OracleDbType.Int32).Value           = oCl.ID_PERSONA; // Añade el ID_CLIENTE para la actualización
                Comando.Parameters.Add("nId_Identificacion", OracleDbType.Int32).Value    = oCl.ID_IDENTIFICACION;
                Comando.Parameters.Add("nId_Pais", OracleDbType.Int32).Value              = oCl.ID_PAIS;
                Comando.Parameters.Add("nId_EstadoCivil", OracleDbType.Int32).Value       = oCl.ID_ESTADO_CIVIL;
                Comando.Parameters.Add("nId_RangoIngreso", OracleDbType.Int32).Value      = oCl.ID_RANGO_INGRESO;
                Comando.Parameters.Add("nId_Moneda", OracleDbType.Int32).Value            = oCl.ID_MONEDA;
                Comando.Parameters.Add("nId_Sucursal", OracleDbType.Int32).Value          = oCl.ID_SUCURSAL;
                Comando.Parameters.Add("nId_Depto", OracleDbType.Int32).Value             = oCl.ID_DEPTO;

                Comando.Parameters.Add("cNombre", OracleDbType.Varchar2).Value            = oCl.NOMBRE;
                Comando.Parameters.Add("cApePate", OracleDbType.Varchar2).Value           = oCl.APE_PATE;
                Comando.Parameters.Add("cApeMate", OracleDbType.Varchar2).Value           = oCl.APE_MATE;
                Comando.Parameters.Add("cFechaNac", OracleDbType.Date).Value              = oCl.FECHA_NAC;
                Comando.Parameters.Add("cDireccionRes", OracleDbType.Varchar2).Value      = oCl.DIRECCION_RES;
                Comando.Parameters.Add("cTelCel", OracleDbType.Varchar2).Value            = oCl.TEL_CEL;
                Comando.Parameters.Add("cTelFijo", OracleDbType.Varchar2).Value           = oCl.TEL_FIJO;
                Comando.Parameters.Add("cCorreoElectronico", OracleDbType.Varchar2).Value = oCl.CORREO_ELECTRONICO;
                Comando.Parameters.Add("cSexo", OracleDbType.BinaryFloat).Value           = oCl.SEXO;
                Comando.Parameters.Add("cNumIdentificacion", OracleDbType.Varchar2).Value = oCl.NUM_IDENTIFICACION;
                Comando.Parameters.Add("cFechaExpiracionIDE", OracleDbType.Date).Value    = oCl.FECHA_EXPIRACION_IDE;
                Comando.Parameters.Add("cEmpleado", OracleDbType.BinaryFloat).Value       = 1;

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

        public DataTable Listado_identificacion()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_IDENTIFICACION,NOM_IDENTIFICACION FROM TB_TIPO_IDENTIFICACION", SQLCon);
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

        public DataTable Listado_paises()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_PAIS,NOM_PAIS FROM TB_PAISES", SQLCon);
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

        public DataTable Listado_estadoCiviles()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_ESTADO_CIVIL,NOM_ESTADO_CIVIL FROM TB_ESTADOS_CIVILES", SQLCon);
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

        public DataTable Listado_moneda()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_MONEDA,NOM_MONEDA FROM TB_MONEDAS", SQLCon);
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

        public DataTable Listado_rangoIngreso()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_RANGO_INGRESO,RANGO FROM TB_RANGO_INGRESO", SQLCon);
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
                OracleCommand Comando = new OracleCommand("SELECT ID_SUCURSAL,DIRECCION FROM TB_SUCURSAL", SQLCon);
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

        public DataTable Listado_depto()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT ID_DEPTO,DEPARTAMENTO FROM TB_DEPARTAMENTOS", SQLCon);
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
