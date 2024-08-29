using Banco.Entidades;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Windows.Forms;
using Banco.Datos;

namespace SisBanca
{
    public partial class Frm_DetalleEmpleados : Form
    {
        public Frm_DetalleEmpleados()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_PERSONA        = 0;
        int ID_DEPTO          = 0;
        int ID_IDENTIFICACION = 0;
        int ID_PAIS           = 0;
        int ID_ESTADO_CIVIL   = 0;
        int ID_RANGO_INGRESO  = 0;
        int ID_MONEDA         = 0;
        int ID_SUCURSAL       = 0;

        int SEXO = 0;
        int EMPLEADO = 0;
        int Estadoguarda = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_nom_cliente.ReadOnly        = !lestado;
            Txt_nom_cliente.ReadOnly        = !lestado;
            Txt_ape_pate_cliente.ReadOnly   = !lestado;
            Txt_ape_mate_cliente.ReadOnly   = !lestado;
            Txt_direccion_cliente.ReadOnly  = !lestado;
            Txt_tel_cel_cliente.ReadOnly    = !lestado;
            Txt_tel_fijo_cliente.ReadOnly   = !lestado;
            Txt_DNI.ReadOnly                = !lestado;
            Txt_correo_electronico.ReadOnly = !lestado;
        }

        private void Formato_empleadoGeneral()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Visible = false;
            Dgv_principal.Columns[2].Visible = false;
            Dgv_principal.Columns[3].Visible = false;
            Dgv_principal.Columns[4].Visible = false;
            Dgv_principal.Columns[5].Visible = false;
            Dgv_principal.Columns[6].Visible = false;
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;

            Dgv_principal.Columns[9].Width = 90;
            Dgv_principal.Columns[10].Width = 90;
            Dgv_principal.Columns[11].Width = 90;
            Dgv_principal.Columns[12].Width = 60;
            Dgv_principal.Columns[13].Width = 90;

            Dgv_principal.Columns[14].Width = 120;
            Dgv_principal.Columns[15].Width = 90;

            Dgv_principal.Columns[16].Width = 150;
            Dgv_principal.Columns[17].Width = 90;

            Dgv_principal.Columns[18].Width = 90;
            Dgv_principal.Columns[19].Width = 160;

            Dgv_principal.Columns[20].Width = 90;
            Dgv_principal.Columns[21].Width = 90;

            Dgv_principal.Columns[22].Width = 90;
            Dgv_principal.Columns[23].Width = 90;

            Dgv_principal.Columns[24].Width = 90;
            Dgv_principal.Columns[25].Width = 90;
            
            Dgv_principal.Columns[26].Width = 90;
            Dgv_principal.Columns[27].Width = 90;
            Dgv_principal.Columns[28].Width = 160;
            Dgv_principal.Columns[29].Width = 140;
            Dgv_principal.Columns[30].Visible = false;
        }

        private void Listado_empleadoGeneral(string cTexto)
        {
            try
            {
                D_Empleado Datos = new D_Empleado();
                Dgv_principal.DataSource = Datos.ListadoEmpleadoGeneral(cTexto);
                this.Formato_empleadoGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpiar_texto()
        {
            Txt_nom_cliente.Text = "";
            Txt_ape_pate_cliente.Text = "";
            Txt_ape_mate_cliente.Text = "";
            Txt_direccion_cliente.Text = "";
            Txt_tel_cel_cliente.Text = "";
            Txt_tel_fijo_cliente.Text = "";
            Txt_DNI.Text = "";
            Txt_correo_electronico.Text = "";

            Cmb_pais.Text = "";
            Cmb_moneda.Text = "";
            Cmb_estado_civil.Text = "";
            Cmb_identificacion.Text = "";
            Cmb_rango_ingreso.Text = "";
            Cmb_sexo.Text = "";
            Cmb_sucursal.Text = "";
            Cmb_departamento.Text = "";
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void Listado_catalogos()
        {
            D_Empleado Datos = new D_Empleado();
            Cmb_identificacion.DataSource = Datos.Listado_identificacion();
            Cmb_identificacion.ValueMember = "ID_IDENTIFICACION";
            Cmb_identificacion.DisplayMember = "NOM_IDENTIFICACION";

            Cmb_estado_civil.DataSource = Datos.Listado_estadoCiviles();
            Cmb_estado_civil.ValueMember = "ID_ESTADO_CIVIL";
            Cmb_estado_civil.DisplayMember = "NOM_ESTADO_CIVIL";

            Cmb_pais.DataSource = Datos.Listado_paises();
            Cmb_pais.ValueMember = "ID_PAIS";
            Cmb_pais.DisplayMember = "NOM_PAIS";

            Cmb_rango_ingreso.DataSource = Datos.Listado_rangoIngreso();
            Cmb_rango_ingreso.ValueMember = "ID_RANGO_INGRESO";
            Cmb_rango_ingreso.DisplayMember = "RANGO";

            Cmb_moneda.DataSource = Datos.Listado_moneda();
            Cmb_moneda.ValueMember = "ID_MONEDA";
            Cmb_moneda.DisplayMember = "NOM_MONEDA";

            Cmb_sucursal.DataSource = Datos.Listado_sucursal();
            Cmb_sucursal.ValueMember = "ID_SUCURSAL";
            Cmb_sucursal.DisplayMember = "DIRECCION";

            Cmb_departamento.DataSource = Datos.Listado_depto();
            Cmb_departamento.ValueMember = "ID_DEPTO";
            Cmb_departamento.DisplayMember = "DEPARTAMENTO";
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_PERSONA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PERSONA"].Value);
                Cmb_departamento.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_DEPTO"].Value);
                Cmb_identificacion.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_IDENTIFICACION"].Value);
                Cmb_pais.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PAIS"].Value);
                Cmb_estado_civil.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_ESTADO_CIVIL"].Value);
                Cmb_rango_ingreso.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_RANGO_INGRESO"].Value);
                Cmb_moneda.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MONEDA"].Value);
                Cmb_sucursal.SelectedValue = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);
                Cmb_sexo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["SEXO"].Value);

                Txt_nom_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOMBRE"].Value);
                Txt_ape_pate_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                Txt_ape_mate_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);
                Txt_direccion_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DIRECCION_RES"].Value);
                Txt_tel_cel_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["TEL_CEL"].Value);
                Txt_correo_electronico.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["CORREO_ELECTRONICO"].Value);
                Txt_tel_fijo_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["TEL_FIJO"].Value);
                Txt_DNI.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NUM_IDENTIFICACION"].Value);
                Date_fecha_nac.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["FECHA_NAC"].Value);
                Date_fecha_exp_dni.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["FECHA_EXPIRACION_IDE"].Value);
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
            Txt_nom_cliente.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_nom_cliente.Focus();
        }

        private void Frm_DetalleEmpleados_Load(object sender, EventArgs e)
        {
            Listado_empleadoGeneral(Txt_buscar.Text.Trim());
            this.Listado_catalogos();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaEmpleados.ToString();
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
                filas += "<td>" + row.Cells["DNI_EM"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_EMPLEADO"].Value.ToString() + " " +
                         row.Cells["APE_PATE"].Value.ToString() + " " +
                         row.Cells["APE_MATE"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CARGO"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SUELDO"].Value.ToString() + "</td>";
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

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (Txt_nom_cliente.Text        == String.Empty ||
                Txt_ape_pate_cliente.Text   == String.Empty ||
                Txt_ape_mate_cliente.Text   == String.Empty ||
                Txt_direccion_cliente.Text  == String.Empty ||
                Txt_tel_cel_cliente.Text    == String.Empty ||
                Txt_tel_fijo_cliente.Text   == String.Empty ||
                Txt_DNI.Text                == String.Empty ||
                Txt_correo_electronico.Text == String.Empty ||

                Cmb_departamento.Text       == String.Empty ||
                Cmb_sucursal.Text           == String.Empty ||
                Cmb_rango_ingreso.Text      == String.Empty ||
                Cmb_pais.Text               == String.Empty ||
                Cmb_moneda.Text             == String.Empty ||
                Cmb_identificacion.Text     == String.Empty ||
                Cmb_estado_civil.Text       == String.Empty

                )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Empleado oCl = new E_Empleado();

                oCl.ID_PERSONA           = this.ID_PERSONA;
                oCl.ID_DEPTO             = Convert.ToInt32(Cmb_departamento.SelectedValue);
                oCl.ID_IDENTIFICACION    = Convert.ToInt32(Cmb_identificacion.SelectedValue);
                oCl.ID_PAIS              = Convert.ToInt32(Cmb_pais.SelectedValue);
                oCl.ID_ESTADO_CIVIL      = Convert.ToInt32(Cmb_estado_civil.SelectedValue);
                oCl.ID_RANGO_INGRESO     = Convert.ToInt32(Cmb_rango_ingreso.SelectedValue);
                oCl.ID_MONEDA            = Convert.ToInt32(Cmb_moneda.SelectedValue);
                oCl.ID_SUCURSAL          = Convert.ToInt32(Cmb_sucursal.SelectedValue);

                oCl.NOMBRE               = Txt_nom_cliente.Text.Trim();
                oCl.APE_PATE             = Txt_ape_pate_cliente.Text.Trim();
                oCl.APE_MATE             = Txt_ape_mate_cliente.Text.Trim();
                oCl.FECHA_NAC            = Date_fecha_nac.Value.Date;
                oCl.DIRECCION_RES        = Txt_direccion_cliente.Text.Trim();
                oCl.TEL_CEL              = Txt_tel_cel_cliente.Text.Trim();
                oCl.TEL_FIJO             = Txt_tel_fijo_cliente.Text.Trim();
                oCl.CORREO_ELECTRONICO   = Txt_correo_electronico.Text.Trim();
                oCl.NUM_IDENTIFICACION   = Txt_DNI.Text.Trim();
                oCl.FECHA_EXPIRACION_IDE = Date_fecha_exp_dni.Value.Date;

                // Obtener el valor seleccionado en el ComboBox Cmb_sexo
                if (Cmb_sexo.SelectedItem.ToString() == "Femenino")
                {
                    oCl.SEXO = 0; // Si es mujer, se asigna "0"
                }
                else if (Cmb_sexo.SelectedItem.ToString() == "Masculino")
                {
                    oCl.SEXO = 1; // Si es hombre, se asigna "1"
                }

                D_Empleado Datos = new D_Empleado();
                Rpta = Datos.GuardarEmpleado(Estadoguarda, oCl);

                if (Rpta.Equals("OK"))
                {
                    this.Listado_empleadoGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_PERSONA = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.ID_PERSONA = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpiar_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_retornar_Click_1(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}
