using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Tarjetas
    {
        public int       ID_TARJETA         { get; set; }
        public int       ID_PERSONA         { get; set; }
        public int       ID_CUENTA          { get; set; }
        public int       ID_TP_TARJETA      { get; set; }
        public decimal    SALDO              { get; set; }
        public decimal    LIMITE             { get; set; }
    }
}