using Banco.Datos;
using Banco.Entidades;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_MovimientoTarjeta : Form
    {
        public Frm_MovimientoTarjeta()
        {
            InitializeComponent();
        }

        int ID_MV_TARJETA  = 0;
        int ID_TARJETA     = 0;
        int ID_PRESTAMO    = 0;
        int ID_SUCURSAL    = 0;
        int ID_PERSONA     = 0;
        int ID_TRANSACCION = 0;
        int Estadoguarda   = 0;

        private void Estado_texto(bool lestado)
        {
            txt_descripcion.ReadOnly   = !lestado;
            txt_totalPagado.ReadOnly   = !lestado;
        }

        private void Formato_tarjetaGeneral()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Visible = false;
            Dgv_principal.Columns[2].Visible = false;
            Dgv_principal.Columns[3].Visible = false;
            Dgv_principal.Columns[4].Visible = false;            
            Dgv_principal.Columns[5].Visible = false;

            Dgv_principal.Columns[6].Width  = 140;
            Dgv_principal.Columns[7].Width  = 140;
            Dgv_principal.Columns[8].Width  = 100;
            Dgv_principal.Columns[9].Width  = 120;
            Dgv_principal.Columns[10].Width = 160;
            Dgv_principal.Columns[11].Width = 120;
            Dgv_principal.Columns[12].Width = 80;
            Dgv_principal.Columns[13].Width = 80;
            Dgv_principal.Columns[14].Width = 120;
            Dgv_principal.Columns[15].Width = 170;
            Dgv_principal.Columns[16].Width = 110;
            Dgv_principal.Columns[17].Width = 90;
            Dgv_principal.Columns[18].Width = 90;
        }

        private void Listado_tarjetaGeneral(string cTexto)
        {
            try
            {
                D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
                Dgv_principal.DataSource = Datos.ListadoMV_tarjetaGenerales(cTexto);
                this.Formato_tarjetaGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_catalogos()
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();

            cmb_persona.DataSource    = Datos.Listado_persona();
            cmb_persona.ValueMember   = "ID_PERSONA";
            cmb_persona.DisplayMember = "NOMBRE";

            cmb_prestamo.DataSource    = Datos.Listado_prestamo();
            cmb_prestamo.ValueMember   = "ID_PRESTAMO";
            cmb_prestamo.DisplayMember = "CODIGO_PRESTAMO";

            cmb_sucursal.DataSource    = Datos.Listado_sucursal();
            cmb_sucursal.ValueMember   = "ID_SUCURSAL";
            cmb_sucursal.DisplayMember = "DIRECCION";

            cmb_tarjeta.DataSource    = Datos.Listado_tarjeta();
            cmb_tarjeta.ValueMember   = "ID_TARJETA";
            cmb_tarjeta.DisplayMember = "NOMBRE_CLIENTE";

            cmb_tipoTransaccion.DataSource = Datos.Listado_transaccion();
            cmb_tipoTransaccion.ValueMember = "ID_TRANSACCION";
            cmb_tipoTransaccion.DisplayMember = "TIPO_TRANSACCION";
        }

        private void Limpiar_texto()
        {
            txt_totalPagado.Text     = "";
            txt_descripcion.Text     = "";
            cmb_tipoTransaccion.Text = "";
            cmb_persona.Text         = "";
            cmb_tarjeta.Text         = "";
            cmb_prestamo.Text        = "";
            cmb_sucursal.Text        = "";
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled         = lEstado;
            this.Btn_actualizar.Enabled    = lEstado;
            this.Btn_reporte.Enabled       = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_MV_TARJETA   = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value);
                this.ID_TARJETA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA"].Value);
                this.ID_PERSONA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value);
                this.ID_PRESTAMO     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value);
                this.ID_SUCURSAL     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);
                this.ID_TRANSACCION  = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TRANSACCION"].Value);

                txt_descripcion.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DESCRIPCION"].Value);
                txt_totalPagado.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["MONTO"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible  = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Limpiar_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            txt_descripcion.Focus();
            txt_totalPagado.Text = "00.00";
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            txt_descripcion.Focus();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tarjetaGeneral(Txt_buscar.Text.Trim());
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            txt_descripcion.Focus();
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_MV_TARJETA = 0;
            this.ID_SUCURSAL = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpiar_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                txt_totalPagado.Text == String.Empty ||
                txt_descripcion.Text == String.Empty ||
                cmb_persona.Text     == String.Empty ||
                cmb_tarjeta.Text     == String.Empty ||
                cmb_prestamo.Text    == String.Empty ||
                cmb_sucursal.Text    == String.Empty ||
                cmb_tipoTransaccion.Text  == String.Empty
                )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else // Se procedería a registrar la información
            {
                string Rpta = "";
                E_MovimientoTarjeta oCl = new E_MovimientoTarjeta();
                //Frm_Login User = new Frm_Login();

                //oCl.ID_MV_TARJETA  = this.ID_MV_TARJETA;
                
                oCl.ID_TARJETA     = Convert.ToInt32(cmb_tarjeta.SelectedValue);
                oCl.ID_PRESTAMO    = Convert.ToInt32(cmb_prestamo.SelectedValue);
                oCl.ID_PERSONA     = Convert.ToInt32(cmb_persona.SelectedValue);
                oCl.ID_TARJETA     = Convert.ToInt32(cmb_tarjeta.SelectedValue);
                oCl.ID_TRANSACCION = Convert.ToInt32(cmb_tipoTransaccion.SelectedValue);
                oCl.ID_SUCURSAL    = Convert.ToInt32(cmb_sucursal.SelectedValue);
                //oCl.ID_USER        = Convert.ToInt32(User.txtUsuario.Text);
                oCl.DESCRIPCION    = txt_descripcion.Text.Trim();
                oCl.MONTO          = Convert.ToDecimal(txt_totalPagado.Text);

                D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
                Rpta = Datos.GuardarMV_tarjeta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tarjetaGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_MV_TARJETA = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Frm_MovimientoTarjeta_Load(object sender, EventArgs e)
        {
            Listado_tarjetaGeneral(Txt_buscar.Text.Trim());
            this.Listado_catalogos();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaMovimientoTarjeta.ToString();
            // Generar valores aleatorios para el RUC y el Nro
            Random random = new Random();
            string ruc = random.Next(100000000, 999999999).ToString(); // RUC de 10 dígitos
            string nro = random.Next(100000, 999999).ToString(); // Nro de 6 dígitos

            // Reemplazar los marcadores de posición en el HTML
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@RUC", ruc);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NRO", nro);

            string filas = string.Empty;

            foreach (DataGridViewRow row in Dgv_principal.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["SUCURSAL"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_PATE_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_MATE_CLIENTE"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["MONTO_SALIDA"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    // Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.visa_256, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    // -----------------------------------------------------------------------
                    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.BannerYT, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img2.ScaleToFit(140, 60);
                    img2.Alignment = iTextSharp.text.Image.UNDERLYING;

                    // Ajusta el valor en el eje X para mover la imagen más a la derecha
                    float offsetX = 203; // Puedes ajustar este valor según tus necesidades
                    img2.SetAbsolutePosition(pdfDoc.LeftMargin + offsetX, pdfDoc.Top - 84);
                    pdfDoc.Add(img2);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();

                    // Mostrar mensaje de validación
                    MessageBox.Show("El Reporte se ha generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_ticket_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}
