using Banco.Entidades;
using Banco.Datos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_TarjetasCredito : Form
    {
        public Frm_TarjetasCredito()
        {
            InitializeComponent();
        }

        int ID_TARJETA = 0;
        int ID_PERSONA = 0;
        int ID_CUENTA = 0;
        int ID_TP_TARJETA = 0;
        int Estadoguarda = 0; //Sin ninguna acción


        private void Limpiar_texto()
        {
            Txt_saldo.Text = "";
            Txt_limite.Text = "";
            cmb_cuenta.Text = "";
            cmb_cliente.Text = "";
            cmb_tarjeta.Text = "";
        }
        // ----------------------------------------- BLOQUE 1


        private void Listado_catalogos()
        {
            D_Tarjetas Datos = new D_Tarjetas();
            cmb_cliente.DataSource = Datos.Listado_cliente();
            cmb_cliente.ValueMember = "PERSONA_CLIENTE";
            cmb_cliente.DisplayMember = "NOMBRE_CLIENTE";

            cmb_cuenta.DataSource = Datos.Listado_cuenta();
            cmb_cuenta.ValueMember = "CUENTA_PERSONA";
            cmb_cuenta.DisplayMember = "NOMBRE_CLIENTE";

            cmb_tarjeta.DataSource = Datos.Listado_tipoTarjeta();
            cmb_tarjeta.ValueMember = "ID_TIPO_TARJETA";
            cmb_tarjeta.DisplayMember = "NOM_TARJETA";
        }

        private void Formato_TARJETA()
        {
            Dgv_principal.Columns[0].Visible     = false;
            Dgv_principal.Columns[1].Visible     = false;
            Dgv_principal.Columns[2].Visible     = false;
            Dgv_principal.Columns[3].Visible     = false;
            Dgv_principal.Columns[4].Width       = 100;
            Dgv_principal.Columns[5].Width       = 90;
            Dgv_principal.Columns[6].Width       = 60;
            Dgv_principal.Columns[7].Width       = 60;
            Dgv_principal.Columns[8].Width       = 80;
            Dgv_principal.Columns[9].Width       = 60;
            Dgv_principal.Columns[10].Width      = 60;
            Dgv_principal.Columns[11].Width      = 100;
            Dgv_principal.Columns[12].Width      = 170;
        }

        private void Listado_tarjeta(string cTexto)
        {
            try
            {
                D_Tarjetas Datos = new D_Tarjetas();
                Dgv_principal.DataSource = Datos.Listado_tarjeta(cTexto);
                this.Formato_TARJETA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_texto(bool lestado)
        {
            Txt_limite.ReadOnly = !lestado;
            Txt_saldo.ReadOnly  = !lestado;
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TARJETA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ID_TARJETA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA"].Value);
                ID_PERSONA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value);
                ID_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                ID_TP_TARJETA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TIPO_TARJETA"].Value);

                cmb_tarjeta.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_TARJETA"].Value);
                
                string nomCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOMBRE"].Value);
                string apePateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);

                cmb_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;
                cmb_cuenta.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;

                Txt_saldo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["SALDO"].Value);
                Txt_limite.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["LIMITE"].Value);
            }
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
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
            this.Estado_texto(true);
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Limpiar_texto();
            Tbc_principal.SelectedIndex = 1;
            Txt_saldo.Focus();
        }

        // ----------------------------------------- BLOQUE 4

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_TARJETA         = 0;
            this.ID_PERSONA         = 0;
            this.ID_CUENTA          = 0;
            this.ID_TP_TARJETA      = 0;
            this.Estadoguarda       = 0;

            this.Limpiar_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        // ----------------------------------------- BLOQUE 5

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_saldo.Text   == String.Empty ||
                Txt_limite.Text  == String.Empty ||
                cmb_cliente.Text == String.Empty ||
                cmb_cuenta.Text  == String.Empty ||
                cmb_tarjeta.Text == String.Empty 
                )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                E_Tarjetas oCl = new E_Tarjetas();
                string Rpta = "";

                oCl.ID_TARJETA         = this.ID_TARJETA;
                oCl.ID_TP_TARJETA      = Convert.ToInt32(cmb_tarjeta.SelectedValue);
                oCl.ID_PERSONA         = Convert.ToInt32(cmb_cliente.SelectedValue);
                oCl.ID_CUENTA          = Convert.ToInt32(cmb_cuenta.SelectedValue);
                oCl.SALDO              = Convert.ToDecimal(Txt_saldo.Text);
                oCl.LIMITE             = Convert.ToDecimal(Txt_limite.Text);

                D_Tarjetas Datos = new D_Tarjetas();
                Rpta = Datos.Guardar_tarjeta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tarjeta("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_TARJETA    = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        // ----------------------------------------- BLOQUE 6

        private void Frm_TarjetasCredito_Load(object sender, EventArgs e)
        {
            Listado_tarjeta(Txt_buscar.Text.Trim());
            this.Listado_catalogos();
            this.Limpiar_texto();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tarjeta(Txt_buscar.Text.Trim());
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaTarjetasCredito.ToString();
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
                filas += "<td>" + row.Cells["NOM_TARJETA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_PATE_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_MATE_CLIENTE"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SALDO_DISPONIBLE"].Value.ToString() + "</td>";
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

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}
