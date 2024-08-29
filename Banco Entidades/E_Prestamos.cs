using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Prestamos
    {
        public int     ID_PRESTAMO        { get; set; }
        public int     IP_PERSONA         { get; set; }
        public int     ID_CUENTA          { get; set; }
        public int     ID_TIPO_APLICACION { get; set; }
        public decimal MONTO_OTORGADO     { get; set; }
        public decimal TASA_INTERES       { get; set; }
        public int     PLAZO              { get; set; }
    }
}
