using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_MovimientoCuenta
    {
        public int     ID_MV_CUENTA   { get; set; }
        public int     ID_CUENTA      { get; set; }
        public int     ID_PERSONA     { get; set; }
        public int     ID_SUCURSAL    { get; set; }
        public int     ID_TRANSACCION { get; set; }
        public string  DESCRIPCION    { get; set; }
        public decimal  MONTO          { get; set; }
    } 
}
