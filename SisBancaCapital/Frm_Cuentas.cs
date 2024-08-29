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
    public partial class Frm_Cuentas : Form
    {
        public Frm_Cuentas()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_CUENTA = 0;
        int ID_TIPO_APLICACION = 0;
        int ID_PERSONA = 0;
        int ID_SUCURSAL = 0;
        int Estadoguarda = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_saldo.ReadOnly = !lestado;
        }

        private void Limpiar_texto()
        {
            Txt_saldo.Text    = "";
            cmb_sucursal.Text = "";
            cmb_producto.Text = "";
            cmb_cliente.Text  = "";
        }

        private void Listado_catalogos()
        {
            D_Cuentas Datos = new D_Cuentas();
            cmb_producto.DataSource = Datos.Listado_producto();
            cmb_producto.ValueMember = "ID_TIPO_APLICACION";
            cmb_producto.DisplayMember = "NOM_PRODUCTO";

            cmb_cliente.DataSource = Datos.Listado_personas();
            cmb_cliente.ValueMember = "ID_PERSONA";
            cmb_cliente.DisplayMember = "NOMBRE";

            cmb_sucursal.DataSource = Datos.Listado_sucursal();
            cmb_sucursal.ValueMember = "ID_SUCURSAL";
            cmb_sucursal.DisplayMember = "DIRECCION";
        }

        private void Formato_cuentasGeneral()
        {
            Dgv_principal.Columns[0].Visible    = false;
            Dgv_principal.Columns[1].Visible    = false;
            Dgv_principal.Columns[2].Visible    = false;
            Dgv_principal.Columns[3].Visible    = false;

            Dgv_principal.Columns[4].Width      = 90;
            Dgv_principal.Columns[5].Width      = 100;
            Dgv_principal.Columns[6].Width      = 80;
            Dgv_principal.Columns[7].Width      = 80;
            
            Dgv_principal.Columns[8].Width      = 100;
            Dgv_principal.Columns[9].Width      = 100;
            Dgv_principal.Columns[10].Width     = 100;
            Dgv_principal.Columns[11].Width     = 90;
            Dgv_principal.Columns[12].Width     = 90;
            Dgv_principal.Columns[13].Width     = 100;
            Dgv_principal.Columns[14].Width     = 80;
            Dgv_principal.Columns[15].Width     = 80;
        }

        private void Listado_cuentasGeneral(string cTexto)
        {
            try
            {
                D_Cuentas Datos = new D_Cuentas();
                Dgv_principal.DataSource = Datos.Listado_cuenta(cTexto);
                this.Formato_cuentasGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled         = lEstado;
            this.Btn_actualizar.Enabled    = lEstado;
            this.Btn_reporte.Enabled       = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
            this.btn_cerrarCuenta.Enabled  = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CUENTA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_TIPO_APLICACION = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TIPO_APLICACION"].Value);
                this.ID_PERSONA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value);
                this.ID_SUCURSAL = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);

                string nomCliente     = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOMBRE"].Value);
                string apePateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);
                Txt_saldo.Text      = Convert.ToString(Dgv_principal.CurrentRow.Cells["SALDO_ACTUAL"].Value);
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
            Txt_saldo.Text = "0.00";
            Txt_saldo.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_saldo.Focus();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_saldo.Text    == String.Empty ||
                cmb_cliente.Text  == String.Empty ||
                cmb_producto.Text == String.Empty ||
                cmb_sucursal.Text == String.Empty
                )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                E_Cuentas oCl = new E_Cuentas();
                string Rpta = "";

                oCl.ID_CUENTA          = this.ID_CUENTA;
                oCl.ID_TIPO_APLICACION = Convert.ToInt32(cmb_producto.SelectedValue);
                oCl.ID_PERSONA         = Convert.ToInt32(cmb_cliente.SelectedValue);
                oCl.ID_SUCURSAL        = Convert.ToInt32(cmb_sucursal.SelectedValue);
                oCl.SALDO_CUENTA       = Convert.ToDecimal(Txt_saldo.Text);
                
                D_Cuentas Datos        = new D_Cuentas();
                Rpta = Datos.Guardar_cuenta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_cuentasGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_CUENTA = 0;
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

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_CUENTA = 0;
            this.ID_TIPO_APLICACION = 0;
            this.ID_PERSONA = 0;
            this.ID_SUCURSAL = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpiar_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_cuentasGeneral(Txt_buscar.Text.Trim());
        }

        private void Frm_Cuentas_Load(object sender, EventArgs e)
        {
            this.Limpiar_texto();
            Listado_cuentasGeneral(Txt_buscar.Text.Trim());
            this.Listado_catalogos();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaCuentas.ToString();
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
                filas += "<td>" + row.Cells["NOM_CUENTA"].Value.ToString()   + "</td>";
                filas += "<td>" + row.Cells["NOM_CLIENTE"].Value.ToString()  + " " +
                         row.Cells["APE_PATE_CLIENTE"].Value.ToString()      + " " +
                         row.Cells["APE_MATE_CLIENTE"].Value.ToString()      + "</td>";
                filas += "<td>" + row.Cells["SALDO_ACTUAL"].Value.ToString() + "</td>";
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

        private void btn_cerrarCuenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.ID_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                    D_Cuentas Datos = new D_Cuentas();
                    Rpta = Datos.Eliminar_cuenta(this.ID_CUENTA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_cuentasGeneral("%");
                        this.ID_CUENTA = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
