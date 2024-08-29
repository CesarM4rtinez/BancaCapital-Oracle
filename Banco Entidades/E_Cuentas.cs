using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Cuentas
    {
        public int     ID_CUENTA          { get; set; }
        public int     ID_TIPO_APLICACION { get; set; }
        public int     ID_PERSONA         { get; set; }
        public int     ID_SUCURSAL        { get; set; }
        public decimal SALDO_CUENTA       { get; set; }
    }
}
