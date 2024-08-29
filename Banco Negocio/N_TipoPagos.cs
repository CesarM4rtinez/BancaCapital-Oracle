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
    public class N_TipoPagos
    {
        public static DataTable Listado_tipoPago(string cTexto)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Listado_tipoPago(cTexto);
        }
        
        public static DataTable Listado_tipoPagoCaido(string cTexto)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Listado_tipoPagoCaido(cTexto);
        }
    }
}
