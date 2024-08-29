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
    public class N_TipoPrestamo
    {
        public static DataTable Listado_tipoPrestamo(string cTexto)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Listado_tipoPrestamo(cTexto);
        }
        
        public static DataTable Listado_tipoPrestamoCaido(string cTexto)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Listado_tipoPrestamoCaido(cTexto);
        }
    }
}
