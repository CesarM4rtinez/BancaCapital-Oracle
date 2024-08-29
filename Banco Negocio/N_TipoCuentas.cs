using Banco.Datos;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class N_TipoCuentas
    {
        public static DataTable Listado_tipoCuenta(string cTexto)
        {
            D_TipoCuentas Datos = new D_TipoCuentas();
            return Datos.Listado_tipoCuenta(cTexto);
        }
        
        public static DataTable Listado_tipoCuentasCaidas(string cTexto)
        {
            D_TipoCuentas Datos = new D_TipoCuentas();
            return Datos.Listado_tipoCuentasCaidas(cTexto);
        }
    }
}
