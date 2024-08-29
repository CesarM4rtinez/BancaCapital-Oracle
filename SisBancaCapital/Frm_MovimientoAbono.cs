using Banco.Entidades;
using Banco.Datos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Font = System.Drawing.Font;

namespace SisBanca
{
    public partial class Frm_MovimientoAbono : Form
    {
        public Frm_MovimientoAbono()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_MV_ABONO    = 0;
        int ID_CUENTA      = 0;
        int ID_SUCURSAL    = 0;
        int ID_PRESTAMO    = 0;
        int ID_PERSONA     = 0;
        int ID_TRANSACCION = 0;
        int Estadoguarda   = 0;

        private void Estado_texto(bool lestado)
        {
            txt_descripcion.ReadOnly = !lestado;
            txt_totalPagado.ReadOnly = !lestado;
        }

        private void Formato_abonoGeneral()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Visible = false;
            Dgv_principal.Columns[2].Visible = false;
            Dgv_principal.Columns[3].Visible = false;
            Dgv_principal.Columns[4].Visible = false;
            Dgv_principal.Columns[5].Visible = false;

            Dgv_principal.Columns[6].Width = 90;
            Dgv_principal.Columns[7].Width = 90;
            Dgv_principal.Columns[8].Width = 100;
            Dgv_principal.Columns[9].Width = 160;
            Dgv_principal.Columns[10].Width = 110;
            Dgv_principal.Columns[11].Width = 110;
            Dgv_principal.Columns[12].Width = 110;
            Dgv_principal.Columns[13].Width = 120;
            Dgv_principal.Columns[14].Width = 120;
            Dgv_principal.Columns[15].Width = 100;
            Dgv_principal.Columns[16].Width = 90;
            Dgv_principal.Columns[17].Width = 170;
            Dgv_principal.Columns[18].Width = 170;
            Dgv_principal.Columns[19].Width = 100;
            Dgv_principal.Columns[20].Width = 100;
            Dgv_principal.Columns[21].Width = 100;
            Dgv_principal.Columns[22].Width = 100;
        }

        private void Listado_abonoGeneral(string cTexto)
        {
            try
            {
                D_MovimientoAbono Datos = new D_MovimientoAbono();
                Dgv_principal.DataSource = Datos.ListadoMV_abonoGenerales(cTexto);
                this.Formato_abonoGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_catalogos()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();

            cmb_persona.DataSource    = Datos.Listado_persona();
            cmb_persona.ValueMember   = "ID_PERSONA";
            cmb_persona.DisplayMember = "NOMBRE";

            cmb_prestamo.DataSource    = Datos.Listado_prestamo();
            cmb_prestamo.ValueMember   = "ID_PRESTAMO";
            cmb_prestamo.DisplayMember = "CODIGO_PRESTAMO";

            cmb_sucursal.DataSource    = Datos.Listado_sucursal();
            cmb_sucursal.ValueMember   = "ID_SUCURSAL";
            cmb_sucursal.DisplayMember = "DIRECCION";

            cmb_cuenta.DataSource    = Datos.Listado_cuenta();
            cmb_cuenta.ValueMember   = "ID_CUENTA";
            cmb_cuenta.DisplayMember = "NOMBRE_CLIENTE";

            cmb_tipoTransaccion.DataSource    = Datos.Listado_transaccion();
            cmb_tipoTransaccion.ValueMember   = "ID_TRANSACCION";
            cmb_tipoTransaccion.DisplayMember = "TIPO_TRANSACCION";
        }


        private void Limpiar_texto()
        {
            txt_totalPagado.Text     = "";
            txt_descripcion.Text     = "";

            cmb_tipoTransaccion.Text = "";
            cmb_persona.Text         = "";
            cmb_prestamo.Text        = "";
            cmb_cuenta.Text          = "";
            cmb_sucursal.Text        = "";
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_MV_ABONO    = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value);
                this.ID_CUENTA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_PERSONA     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value);
                this.ID_TRANSACCION = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TRANSACCION"].Value);
                this.ID_SUCURSAL    = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);
                this.ID_PRESTAMO    = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value);

                txt_descripcion.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DESCRIPCION"].Value);
                txt_totalPagado.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["TOTAL_PAGADO"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
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
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            txt_descripcion.Focus();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_abonoGeneral(Txt_buscar.Text.Trim());
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                txt_descripcion.Text     == String.Empty ||
                txt_totalPagado.Text     == String.Empty ||

                cmb_prestamo.Text        == String.Empty ||
                cmb_persona.Text         == String.Empty ||
                cmb_cuenta.Text          == String.Empty ||
                cmb_sucursal.Text        == String.Empty ||
                cmb_tipoTransaccion.Text == String.Empty
                )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else // Se procedería a registrar la información
            {
                string Rpta = "";
                E_MovimientoAbono oCl = new E_MovimientoAbono();

                oCl.ID_MV_ABONO    = this.ID_MV_ABONO;
                oCl.ID_CUENTA      = Convert.ToInt32(cmb_cuenta.SelectedValue);
                oCl.ID_PRESTAMO    = Convert.ToInt32(cmb_prestamo.SelectedValue);
                oCl.ID_PERSONA     = Convert.ToInt32(cmb_persona.SelectedValue);
                oCl.ID_SUCURSAL    = Convert.ToInt32(cmb_sucursal.SelectedValue);
                oCl.ID_TRANSACCION = Convert.ToInt32(cmb_tipoTransaccion.SelectedValue);
                oCl.DESCRIPCION    = txt_descripcion.Text.Trim();
                oCl.TOTAL_PAGADO   = Convert.ToDecimal(txt_totalPagado.Text);

                D_MovimientoAbono Datos = new D_MovimientoAbono();
                Rpta = Datos.GuardarMV_abono(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_abonoGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_MV_ABONO = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_MV_ABONO = 0;
            this.ID_CUENTA = 0;
            this.ID_PRESTAMO = 0;
            this.ID_PERSONA = 0;
            this.ID_TRANSACCION = 0;
            this.ID_SUCURSAL = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpiar_texto();
            this.Estado_Botonesprincipales(true);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Frm_DetalleMovimiento_Load(object sender, EventArgs e)
        {
            Listado_abonoGeneral(Txt_buscar.Text.Trim());
            this.Listado_catalogos();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaMovimientoAbono.ToString();

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
                filas += "<td>" + row.Cells["MONTO_PRESTADO"].Value.ToString() + "</td>";
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

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            Tbc_principal.SelectedIndex = 1;
            txt_descripcion.Focus();
        }

        private void btn_ticket_click(object sender, EventArgs e)
        {
            // Abre el diálogo de impresión
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1; // Asocia el PrintDialog con el PrintDocument

            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print(); // Imprime usando el PrintDocument
            }

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define el tamaño personalizado para el PDF (en puntos, 1 pulgada = 72 puntos)
            float width = 400; // Ancho de la página en puntos
            float height = 600; // Altura de la página en puntos

            // Establece el tamaño de la página
            e.PageSettings.PaperSize = new PaperSize("Custom", (int)width, (int)height);

            // Ahora puedes dibujar el contenido en el PDF usando las coordenadas y medidas ajustadas.
            // Ten en cuenta que las posiciones y tamaños de fuente deben ajustarse para el nuevo tamaño de página.

            // Ejemplo de dibujo de texto en el nuevo tamaño de página
            e.Graphics.DrawString("Transacción de Abono", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            // Otros elementos del ticket...

            // Asegúrate de ajustar las coordenadas y tamaños según el nuevo tamaño de página.
        }


        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            // Asigna el documento de impresión al control PrintPreviewDialog
            printPreviewDialog1.Document = printDocument1;

            // Manejador de evento para el dibujo del ticket en el documento de impresión
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // Muestra el preview al cargar el formulario
            printPreviewDialog1.ShowDialog();
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}