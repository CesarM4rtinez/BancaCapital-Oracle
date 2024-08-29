namespace SisBanca
{
    partial class Frm_DetalleEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titulo_form = new System.Windows.Forms.Panel();
            this.lbl_empleados = new System.Windows.Forms.Label();
            this.Btn_salir_cliente = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Tbc_principal = new System.Windows.Forms.TabControl();
            this.Empleados = new System.Windows.Forms.TabPage();
            this.Dgv_principal = new System.Windows.Forms.DataGridView();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MantEmpleados = new System.Windows.Forms.TabPage();
            this.Date_fecha_exp_dni = new System.Windows.Forms.DateTimePicker();
            this.Date_fecha_nac = new System.Windows.Forms.DateTimePicker();
            this.Cmb_sucursal = new System.Windows.Forms.ComboBox();
            this.Cmb_departamento = new System.Windows.Forms.ComboBox();
            this.Cmb_sexo = new System.Windows.Forms.ComboBox();
            this.Cmb_moneda = new System.Windows.Forms.ComboBox();
            this.Cmb_rango_ingreso = new System.Windows.Forms.ComboBox();
            this.Cmb_estado_civil = new System.Windows.Forms.ComboBox();
            this.Cmb_pais = new System.Windows.Forms.ComboBox();
            this.Cmb_identificacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_correo_electronico = new System.Windows.Forms.TextBox();
            this.Txt_tel_fijo_cliente = new System.Windows.Forms.TextBox();
            this.Txt_DNI = new System.Windows.Forms.TextBox();
            this.Txt_ape_mate_cliente = new System.Windows.Forms.TextBox();
            this.Txt_ape_pate_cliente = new System.Windows.Forms.TextBox();
            this.Txt_tel_cel_cliente = new System.Windows.Forms.TextBox();
            this.Txt_direccion_cliente = new System.Windows.Forms.TextBox();
            this.Txt_nom_cliente = new System.Windows.Forms.TextBox();
            this.Btn_retornar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_titulo_form.SuspendLayout();
            this.Tbc_principal.SuspendLayout();
            this.Empleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).BeginInit();
            this.MantEmpleados.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_titulo_form
            // 
            this.pnl_titulo_form.BackColor = System.Drawing.Color.OrangeRed;
            this.pnl_titulo_form.Controls.Add(this.lbl_empleados);
            this.pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo_form.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titulo_form.Name = "pnl_titulo_form";
            this.pnl_titulo_form.Size = new System.Drawing.Size(1780, 44);
            this.pnl_titulo_form.TabIndex = 41;
            // 
            // lbl_empleados
            // 
            this.lbl_empleados.AutoSize = true;
            this.lbl_empleados.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empleados.ForeColor = System.Drawing.Color.White;
            this.lbl_empleados.Location = new System.Drawing.Point(729, 12);
            this.lbl_empleados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_empleados.Name = "lbl_empleados";
            this.lbl_empleados.Size = new System.Drawing.Size(297, 25);
            this.lbl_empleados.TabIndex = 0;
            this.lbl_empleados.Text = "DETALLE DE EMPLEADOS";
            // 
            // Btn_salir_cliente
            // 
            this.Btn_salir_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_salir_cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_salir_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir_cliente.ForeColor = System.Drawing.Color.White;
            this.Btn_salir_cliente.Image = global::SisBanca.Properties.Resources.cerrar_sesion;
            this.Btn_salir_cliente.Location = new System.Drawing.Point(348, 623);
            this.Btn_salir_cliente.Name = "Btn_salir_cliente";
            this.Btn_salir_cliente.Size = new System.Drawing.Size(100, 74);
            this.Btn_salir_cliente.TabIndex = 46;
            this.Btn_salir_cliente.Text = "Salir";
            this.Btn_salir_cliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_salir_cliente.UseVisualStyleBackColor = false;
            this.Btn_salir_cliente.Click += new System.EventHandler(this.Btn_salir_cliente_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_reporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_reporte.Image = global::SisBanca.Properties.Resources.reporte;
            this.Btn_reporte.Location = new System.Drawing.Point(240, 623);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(100, 74);
            this.Btn_reporte.TabIndex = 45;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // Btn_actualizar
            // 
            this.Btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_actualizar.ForeColor = System.Drawing.Color.White;
            this.Btn_actualizar.Image = global::SisBanca.Properties.Resources.actualizar;
            this.Btn_actualizar.Location = new System.Drawing.Point(134, 622);
            this.Btn_actualizar.Name = "Btn_actualizar";
            this.Btn_actualizar.Size = new System.Drawing.Size(100, 74);
            this.Btn_actualizar.TabIndex = 43;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_actualizar.UseVisualStyleBackColor = false;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_nuevo.ForeColor = System.Drawing.Color.White;
            this.Btn_nuevo.Image = global::SisBanca.Properties.Resources.agregar_carpeta;
            this.Btn_nuevo.Location = new System.Drawing.Point(26, 622);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(100, 74);
            this.Btn_nuevo.TabIndex = 42;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Tbc_principal
            // 
            this.Tbc_principal.Controls.Add(this.Empleados);
            this.Tbc_principal.Controls.Add(this.MantEmpleados);
            this.Tbc_principal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tbc_principal.Location = new System.Drawing.Point(13, 74);
            this.Tbc_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Tbc_principal.Name = "Tbc_principal";
            this.Tbc_principal.SelectedIndex = 0;
            this.Tbc_principal.Size = new System.Drawing.Size(1751, 541);
            this.Tbc_principal.TabIndex = 10;
            // 
            // Empleados
            // 
            this.Empleados.Controls.Add(this.Dgv_principal);
            this.Empleados.Controls.Add(this.Txt_buscar);
            this.Empleados.Controls.Add(this.Btn_buscar);
            this.Empleados.Controls.Add(this.label1);
            this.Empleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empleados.Location = new System.Drawing.Point(4, 25);
            this.Empleados.Margin = new System.Windows.Forms.Padding(4);
            this.Empleados.Name = "Empleados";
            this.Empleados.Padding = new System.Windows.Forms.Padding(4);
            this.Empleados.Size = new System.Drawing.Size(1743, 512);
            this.Empleados.TabIndex = 0;
            this.Empleados.Text = "Empleados";
            this.Empleados.UseVisualStyleBackColor = true;
            // 
            // Dgv_principal
            // 
            this.Dgv_principal.AllowUserToAddRows = false;
            this.Dgv_principal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_principal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
            this.Dgv_principal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dgv_principal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_principal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_principal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.Dgv_principal.ColumnHeadersHeight = 35;
            this.Dgv_principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_principal.DefaultCellStyle = dataGridViewCellStyle39;
            this.Dgv_principal.EnableHeadersVisualStyles = false;
            this.Dgv_principal.Location = new System.Drawing.Point(8, 69);
            this.Dgv_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_principal.Name = "Dgv_principal";
            this.Dgv_principal.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.Dgv_principal.RowHeadersWidth = 51;
            this.Dgv_principal.Size = new System.Drawing.Size(1727, 435);
            this.Dgv_principal.TabIndex = 4;
            this.Dgv_principal.DoubleClick += new System.EventHandler(this.Dgv_principal_DoubleClick);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(85, 26);
            this.Txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(327, 22);
            this.Txt_buscar.TabIndex = 1;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_buscar.Location = new System.Drawing.Point(420, 23);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(100, 28);
            this.Btn_buscar.TabIndex = 2;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // MantEmpleados
            // 
            this.MantEmpleados.Controls.Add(this.Date_fecha_exp_dni);
            this.MantEmpleados.Controls.Add(this.Date_fecha_nac);
            this.MantEmpleados.Controls.Add(this.Cmb_sucursal);
            this.MantEmpleados.Controls.Add(this.Cmb_departamento);
            this.MantEmpleados.Controls.Add(this.Cmb_sexo);
            this.MantEmpleados.Controls.Add(this.Cmb_moneda);
            this.MantEmpleados.Controls.Add(this.Cmb_rango_ingreso);
            this.MantEmpleados.Controls.Add(this.Cmb_estado_civil);
            this.MantEmpleados.Controls.Add(this.Cmb_pais);
            this.MantEmpleados.Controls.Add(this.Cmb_identificacion);
            this.MantEmpleados.Controls.Add(this.label6);
            this.MantEmpleados.Controls.Add(this.label7);
            this.MantEmpleados.Controls.Add(this.label19);
            this.MantEmpleados.Controls.Add(this.label23);
            this.MantEmpleados.Controls.Add(this.label8);
            this.MantEmpleados.Controls.Add(this.Txt_correo_electronico);
            this.MantEmpleados.Controls.Add(this.Txt_tel_fijo_cliente);
            this.MantEmpleados.Controls.Add(this.Txt_DNI);
            this.MantEmpleados.Controls.Add(this.Txt_ape_mate_cliente);
            this.MantEmpleados.Controls.Add(this.Txt_ape_pate_cliente);
            this.MantEmpleados.Controls.Add(this.Txt_tel_cel_cliente);
            this.MantEmpleados.Controls.Add(this.Txt_direccion_cliente);
            this.MantEmpleados.Controls.Add(this.Txt_nom_cliente);
            this.MantEmpleados.Controls.Add(this.Btn_retornar);
            this.MantEmpleados.Controls.Add(this.Btn_guardar);
            this.MantEmpleados.Controls.Add(this.Btn_cancelar);
            this.MantEmpleados.Controls.Add(this.label10);
            this.MantEmpleados.Controls.Add(this.label9);
            this.MantEmpleados.Controls.Add(this.label16);
            this.MantEmpleados.Controls.Add(this.label15);
            this.MantEmpleados.Controls.Add(this.label14);
            this.MantEmpleados.Controls.Add(this.label5);
            this.MantEmpleados.Controls.Add(this.label4);
            this.MantEmpleados.Controls.Add(this.label18);
            this.MantEmpleados.Controls.Add(this.label17);
            this.MantEmpleados.Controls.Add(this.label13);
            this.MantEmpleados.Controls.Add(this.label12);
            this.MantEmpleados.Controls.Add(this.label11);
            this.MantEmpleados.Controls.Add(this.label2);
            this.MantEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MantEmpleados.Location = new System.Drawing.Point(4, 25);
            this.MantEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.MantEmpleados.Name = "MantEmpleados";
            this.MantEmpleados.Padding = new System.Windows.Forms.Padding(4);
            this.MantEmpleados.Size = new System.Drawing.Size(1743, 512);
            this.MantEmpleados.TabIndex = 1;
            this.MantEmpleados.Text = "Mantenimiento";
            this.MantEmpleados.UseVisualStyleBackColor = true;
            // 
            // Date_fecha_exp_dni
            // 
            this.Date_fecha_exp_dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_fecha_exp_dni.Location = new System.Drawing.Point(1312, 299);
            this.Date_fecha_exp_dni.Name = "Date_fecha_exp_dni";
            this.Date_fecha_exp_dni.Size = new System.Drawing.Size(335, 27);
            this.Date_fecha_exp_dni.TabIndex = 54;
            // 
            // Date_fecha_nac
            // 
            this.Date_fecha_nac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_fecha_nac.Location = new System.Drawing.Point(1312, 63);
            this.Date_fecha_nac.Name = "Date_fecha_nac";
            this.Date_fecha_nac.Size = new System.Drawing.Size(335, 27);
            this.Date_fecha_nac.TabIndex = 54;
            // 
            // Cmb_sucursal
            // 
            this.Cmb_sucursal.DisplayMember = "CLIENTE";
            this.Cmb_sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_sucursal.FormattingEnabled = true;
            this.Cmb_sucursal.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.Cmb_sucursal.Location = new System.Drawing.Point(216, 41);
            this.Cmb_sucursal.Name = "Cmb_sucursal";
            this.Cmb_sucursal.Size = new System.Drawing.Size(326, 26);
            this.Cmb_sucursal.TabIndex = 53;
            this.Cmb_sucursal.ValueMember = "CLIENTE";
            // 
            // Cmb_departamento
            // 
            this.Cmb_departamento.DisplayMember = "CLIENTE";
            this.Cmb_departamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_departamento.FormattingEnabled = true;
            this.Cmb_departamento.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.Cmb_departamento.Location = new System.Drawing.Point(969, 54);
            this.Cmb_departamento.Name = "Cmb_departamento";
            this.Cmb_departamento.Size = new System.Drawing.Size(276, 26);
            this.Cmb_departamento.TabIndex = 53;
            this.Cmb_departamento.ValueMember = "CLIENTE";
            // 
            // Cmb_sexo
            // 
            this.Cmb_sexo.DisplayMember = "CLIENTE";
            this.Cmb_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_sexo.FormattingEnabled = true;
            this.Cmb_sexo.Items.AddRange(new object[] {
            "Femenino",
            "Masculino"});
            this.Cmb_sexo.Location = new System.Drawing.Point(969, 394);
            this.Cmb_sexo.Name = "Cmb_sexo";
            this.Cmb_sexo.Size = new System.Drawing.Size(276, 26);
            this.Cmb_sexo.TabIndex = 53;
            this.Cmb_sexo.ValueMember = "CLIENTE";
            // 
            // Cmb_moneda
            // 
            this.Cmb_moneda.DisplayMember = "NOM_MONEDA";
            this.Cmb_moneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_moneda.FormattingEnabled = true;
            this.Cmb_moneda.Location = new System.Drawing.Point(216, 390);
            this.Cmb_moneda.Name = "Cmb_moneda";
            this.Cmb_moneda.Size = new System.Drawing.Size(326, 26);
            this.Cmb_moneda.TabIndex = 53;
            this.Cmb_moneda.ValueMember = "NOM_MONEDA";
            // 
            // Cmb_rango_ingreso
            // 
            this.Cmb_rango_ingreso.DisplayMember = "RANGO";
            this.Cmb_rango_ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_rango_ingreso.FormattingEnabled = true;
            this.Cmb_rango_ingreso.Location = new System.Drawing.Point(216, 318);
            this.Cmb_rango_ingreso.Name = "Cmb_rango_ingreso";
            this.Cmb_rango_ingreso.Size = new System.Drawing.Size(326, 26);
            this.Cmb_rango_ingreso.TabIndex = 53;
            this.Cmb_rango_ingreso.ValueMember = "RANGO";
            // 
            // Cmb_estado_civil
            // 
            this.Cmb_estado_civil.DisplayMember = "NOM_ESTADO_CIVIL";
            this.Cmb_estado_civil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_estado_civil.FormattingEnabled = true;
            this.Cmb_estado_civil.Location = new System.Drawing.Point(216, 242);
            this.Cmb_estado_civil.Name = "Cmb_estado_civil";
            this.Cmb_estado_civil.Size = new System.Drawing.Size(326, 26);
            this.Cmb_estado_civil.TabIndex = 53;
            this.Cmb_estado_civil.ValueMember = "NOM_ESTADO_CIVIL";
            // 
            // Cmb_pais
            // 
            this.Cmb_pais.DisplayMember = "NOM_PAIS";
            this.Cmb_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_pais.FormattingEnabled = true;
            this.Cmb_pais.Location = new System.Drawing.Point(216, 173);
            this.Cmb_pais.Name = "Cmb_pais";
            this.Cmb_pais.Size = new System.Drawing.Size(326, 26);
            this.Cmb_pais.TabIndex = 53;
            this.Cmb_pais.ValueMember = "NOM_PAIS";
            // 
            // Cmb_identificacion
            // 
            this.Cmb_identificacion.DisplayMember = "NOM_IDENTIFICACION";
            this.Cmb_identificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_identificacion.FormattingEnabled = true;
            this.Cmb_identificacion.Location = new System.Drawing.Point(216, 108);
            this.Cmb_identificacion.Name = "Cmb_identificacion";
            this.Cmb_identificacion.Size = new System.Drawing.Size(326, 26);
            this.Cmb_identificacion.TabIndex = 53;
            this.Cmb_identificacion.ValueMember = "NOM_IDENTIFICACION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(618, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Apellido Materno: (*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(965, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Departamento: (*)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(82, 43);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 20);
            this.label19.TabIndex = 50;
            this.label19.Text = "Sucursal: (*)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(966, 361);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 20);
            this.label23.TabIndex = 50;
            this.label23.Text = "Sexo: (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(966, 282);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 20);
            this.label8.TabIndex = 49;
            this.label8.Text = "Correo Electrónico: (*)";
            // 
            // Txt_correo_electronico
            // 
            this.Txt_correo_electronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_correo_electronico.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_correo_electronico.Location = new System.Drawing.Point(969, 311);
            this.Txt_correo_electronico.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_correo_electronico.MaxLength = 100;
            this.Txt_correo_electronico.Name = "Txt_correo_electronico";
            this.Txt_correo_electronico.ReadOnly = true;
            this.Txt_correo_electronico.Size = new System.Drawing.Size(276, 24);
            this.Txt_correo_electronico.TabIndex = 47;
            // 
            // Txt_tel_fijo_cliente
            // 
            this.Txt_tel_fijo_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_tel_fijo_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_tel_fijo_cliente.Location = new System.Drawing.Point(969, 225);
            this.Txt_tel_fijo_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_tel_fijo_cliente.MaxLength = 150;
            this.Txt_tel_fijo_cliente.Name = "Txt_tel_fijo_cliente";
            this.Txt_tel_fijo_cliente.ReadOnly = true;
            this.Txt_tel_fijo_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_tel_fijo_cliente.TabIndex = 46;
            // 
            // Txt_DNI
            // 
            this.Txt_DNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DNI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_DNI.Location = new System.Drawing.Point(621, 390);
            this.Txt_DNI.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_DNI.MaxLength = 100;
            this.Txt_DNI.Name = "Txt_DNI";
            this.Txt_DNI.ReadOnly = true;
            this.Txt_DNI.Size = new System.Drawing.Size(276, 24);
            this.Txt_DNI.TabIndex = 4;
            // 
            // Txt_ape_mate_cliente
            // 
            this.Txt_ape_mate_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ape_mate_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_ape_mate_cliente.Location = new System.Drawing.Point(621, 226);
            this.Txt_ape_mate_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_ape_mate_cliente.MaxLength = 100;
            this.Txt_ape_mate_cliente.Name = "Txt_ape_mate_cliente";
            this.Txt_ape_mate_cliente.ReadOnly = true;
            this.Txt_ape_mate_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_ape_mate_cliente.TabIndex = 3;
            // 
            // Txt_ape_pate_cliente
            // 
            this.Txt_ape_pate_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ape_pate_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_ape_pate_cliente.Location = new System.Drawing.Point(621, 139);
            this.Txt_ape_pate_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_ape_pate_cliente.MaxLength = 150;
            this.Txt_ape_pate_cliente.Name = "Txt_ape_pate_cliente";
            this.Txt_ape_pate_cliente.ReadOnly = true;
            this.Txt_ape_pate_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_ape_pate_cliente.TabIndex = 2;
            // 
            // Txt_tel_cel_cliente
            // 
            this.Txt_tel_cel_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_tel_cel_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_tel_cel_cliente.Location = new System.Drawing.Point(969, 139);
            this.Txt_tel_cel_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_tel_cel_cliente.Name = "Txt_tel_cel_cliente";
            this.Txt_tel_cel_cliente.ReadOnly = true;
            this.Txt_tel_cel_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_tel_cel_cliente.TabIndex = 12;
            // 
            // Txt_direccion_cliente
            // 
            this.Txt_direccion_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_direccion_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_direccion_cliente.Location = new System.Drawing.Point(621, 312);
            this.Txt_direccion_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_direccion_cliente.Name = "Txt_direccion_cliente";
            this.Txt_direccion_cliente.ReadOnly = true;
            this.Txt_direccion_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_direccion_cliente.TabIndex = 9;
            // 
            // Txt_nom_cliente
            // 
            this.Txt_nom_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_nom_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_nom_cliente.Location = new System.Drawing.Point(622, 54);
            this.Txt_nom_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_nom_cliente.MaxLength = 20;
            this.Txt_nom_cliente.Name = "Txt_nom_cliente";
            this.Txt_nom_cliente.ReadOnly = true;
            this.Txt_nom_cliente.Size = new System.Drawing.Size(276, 24);
            this.Txt_nom_cliente.TabIndex = 1;
            // 
            // Btn_retornar
            // 
            this.Btn_retornar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_retornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar.ForeColor = System.Drawing.Color.White;
            this.Btn_retornar.Location = new System.Drawing.Point(374, 458);
            this.Btn_retornar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_retornar.Name = "Btn_retornar";
            this.Btn_retornar.Size = new System.Drawing.Size(101, 32);
            this.Btn_retornar.TabIndex = 15;
            this.Btn_retornar.Text = "Retornar";
            this.Btn_retornar.UseVisualStyleBackColor = false;
            this.Btn_retornar.Visible = false;
            this.Btn_retornar.Click += new System.EventHandler(this.Btn_retornar_Click_1);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_guardar.Location = new System.Drawing.Point(259, 457);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(101, 32);
            this.Btn_guardar.TabIndex = 14;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Visible = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click_1);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.LightCoral;
            this.Btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_cancelar.Location = new System.Drawing.Point(144, 457);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(101, 32);
            this.Btn_cancelar.TabIndex = 13;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Visible = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1308, 261);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "Fecha de expiración de indentifiación: (*)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1308, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Fecha de nacimiento: (*)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(966, 108);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "Teléfono Móvil: (*)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(618, 282);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(214, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Dirección de residencia: (*)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(618, 110);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "Apellido Paterno: (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(618, 361);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Número de Indentificación: (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(966, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Teléfono Fijo: (*)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(89, 393);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 20);
            this.label18.TabIndex = 5;
            this.label18.Text = "Moneda: (*)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 320);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(177, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "Rango de Ingresos: (*)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(59, 244);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Estado Civil: (*)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(115, 175);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "País: (*)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(50, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Identificacion: (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(618, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre de Cliente: (*)";
            // 
            // Frm_DetalleEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 709);
            this.Controls.Add(this.Tbc_principal);
            this.Controls.Add(this.pnl_titulo_form);
            this.Controls.Add(this.Btn_salir_cliente);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_nuevo);
            this.Name = "Frm_DetalleEmpleados";
            this.Load += new System.EventHandler(this.Frm_DetalleEmpleados_Load);
            this.pnl_titulo_form.ResumeLayout(false);
            this.pnl_titulo_form.PerformLayout();
            this.Tbc_principal.ResumeLayout(false);
            this.Empleados.ResumeLayout(false);
            this.Empleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).EndInit();
            this.MantEmpleados.ResumeLayout(false);
            this.MantEmpleados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo_form;
        private System.Windows.Forms.Label lbl_empleados;
        private System.Windows.Forms.Button Btn_salir_cliente;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Button Btn_actualizar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage Empleados;
        private System.Windows.Forms.DataGridView Dgv_principal;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage MantEmpleados;
        private System.Windows.Forms.DateTimePicker Date_fecha_exp_dni;
        private System.Windows.Forms.DateTimePicker Date_fecha_nac;
        private System.Windows.Forms.ComboBox Cmb_sucursal;
        private System.Windows.Forms.ComboBox Cmb_sexo;
        private System.Windows.Forms.ComboBox Cmb_moneda;
        private System.Windows.Forms.ComboBox Cmb_rango_ingreso;
        private System.Windows.Forms.ComboBox Cmb_estado_civil;
        private System.Windows.Forms.ComboBox Cmb_pais;
        private System.Windows.Forms.ComboBox Cmb_identificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_correo_electronico;
        private System.Windows.Forms.TextBox Txt_tel_fijo_cliente;
        private System.Windows.Forms.TextBox Txt_DNI;
        private System.Windows.Forms.TextBox Txt_ape_mate_cliente;
        private System.Windows.Forms.TextBox Txt_ape_pate_cliente;
        private System.Windows.Forms.TextBox Txt_tel_cel_cliente;
        private System.Windows.Forms.TextBox Txt_direccion_cliente;
        private System.Windows.Forms.TextBox Txt_nom_cliente;
        private System.Windows.Forms.Button Btn_retornar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_departamento;
        private System.Windows.Forms.Label label7;
    }
}