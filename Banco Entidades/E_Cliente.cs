using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Cliente
    {
        public int    ID_PERSONA        { get; set; }
        public int    ID_TP_CLIENTE     { get; set; }
        public int    ID_IDENTIFICACION { get; set; }
        public int    ID_PAIS           { get; set; }
        public int    ID_ESTADO_CIVIL   { get; set; }
        public int    ID_RANGO_INGRESO  { get; set; }
        public int    ID_MONEDA         { get; set; }
        public int    ID_SUCURSAL       { get; set; }


        public string NOMBRE               { get; set; }
        public string APE_PATE             { get; set; }
        public string APE_MATE             { get; set; }
        public DateTime FECHA_NAC            { get; set; }
        public string DIRECCION_RES        { get; set; }
        public string TEL_CEL              { get; set; }
        public string TEL_FIJO             { get; set; }
        public string CORREO_ELECTRONICO   { get; set; }
        public float SEXO                 { get; set; }
        public string NUM_IDENTIFICACION   { get; set; }
        public DateTime FECHA_EXPIRACION_IDE { get; set; }
        public string CARGO_TRABAJO        { get; set; }
    }
}
