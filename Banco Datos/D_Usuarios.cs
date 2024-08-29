using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Entidades;
using Oracle.ManagedDataAccess.Client;

namespace Banco.Datos
{
    public class D_Usuarios
    {
        public string Guardar_us(int nOpcion, E_Usuarios oUs)
        {
            string Rpta = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GuardarUsuarios", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion",     SqlDbType.Int).Value     = nOpcion;
                Comando.Parameters.Add("@cID_USER",    SqlDbType.Int).Value     = oUs.ID_USER;
                Comando.Parameters.Add("@cUSUARIO",    SqlDbType.VarChar).Value = oUs.USUARIO;
                Comando.Parameters.Add("@cCONTRASEÑA", SqlDbType.VarChar).Value = oUs.CONTRASEÑA;
                Comando.Parameters.Add("@cADMIN",      SqlDbType.Bit).Value     = oUs.ADMINISTRADOR;
                Comando.Parameters.Add("@cPRESTAMOS",  SqlDbType.Bit).Value     = oUs.PRESTAMOS;
                Comando.Parameters.Add("@cCUENTAS",    SqlDbType.Bit).Value     = oUs.CUENTAS;
                Comando.Parameters.Add("@cTARJETAS",   SqlDbType.Bit).Value     = oUs.TARJETAS;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar los datos";
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

        public DataTable Login_us(string USUARIO, string CONTRASEÑA)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SQLCon = new OracleConnection();
            
            {
                try
                {
                    SQLCon = Conexion.getInstancia().CrearConexion();
                    OracleCommand Comando = new OracleCommand("SELECT*FROM V_LOGIN WHERE USUARIO = :nUsuario AND CONTRASEÑA = :nContraseña AND ESTADO=1", SQLCon);
                    Comando.Parameters.Add(new OracleParameter(":nUsuario", OracleDbType.Varchar2)).Value = USUARIO;
                    Comando.Parameters.Add(new OracleParameter(":nContraseña", OracleDbType.Varchar2)).Value = CONTRASEÑA; // Debes aplicar hash a la contraseña antes de pasarla como parámetro.
                    SQLCon.Open();
                    Resultado = Comando.ExecuteReader();
                    Tabla.Load(Resultado);
                    return Tabla;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
                }
            }
        }
    }
}