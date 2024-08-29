using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_MovimientoTarjeta
    {
        public int ID_MV_TARJETA    { get; set; }
        public int ID_TARJETA       { get; set; }
        public int ID_PERSONA       { get; set; }
        public int ID_SUCURSAL      { get; set; }
        public int ID_PRESTAMO      { get; set; }
        public int ID_TRANSACCION   { get; set; }
        public int ID_USER          { get; set; }
        public string  DESCRIPCION  { get; set; }
        public decimal  MONTO        { get; set; }
    }
}
