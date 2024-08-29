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
    public class N_TipoTarjetas
    {
        public static DataTable Listado_tp_tj(string cTexto)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Listado_tp_tj(cTexto);
        }
        
        public static DataTable Listado_tipoTarjetaCaida(string cTexto)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Listado_tipoTarjetaCaida(cTexto);
        }
    }
}
