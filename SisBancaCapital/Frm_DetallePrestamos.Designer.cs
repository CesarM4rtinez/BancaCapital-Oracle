namespace SisBanca
{
    partial class Frm_DetallePrestamos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titulo_form = new System.Windows.Forms.Panel();
            this.lbl_prestamos = new System.Windows.Forms.Label();
            this.Btn_salir_cliente = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Tbc_principal = new System.Windows.Forms.TabControl();
            this.Prestamos = new System.Windows.Forms.TabPage();
            this.Dgv_principal = new System.Windows.Forms.DataGridView();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Mantenimiento = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_plazo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tasaInteres = new System.Windows.Forms.TextBox();
            this.cmb_producto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_cuenta = new System.Windows.Forms.ComboBox();
            this.cmb_cliente = new System.Windows.Forms.ComboBox();
            this.Btn_retornar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_montoPrestado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlanPago = new System.Windows.Forms.TabPage();
            this.dgv_planpago = new System.Windows.Forms.DataGridView();
            this.btn_buscarplanpago = new System.Windows.Forms.Button();
            this.txt_planpago = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_titulo_form.SuspendLayout();
            this.Tbc_principal.SuspendLayout();
            this.Prestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).BeginInit();
            this.Mantenimiento.SuspendLayout();
            this.PlanPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_planpago)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titulo_form
            // 
            this.pnl_titulo_form.BackColor = System.Drawing.Color.OrangeRed;
            this.pnl_titulo_form.Controls.Add(this.lbl_prestamos);
            this.pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo_form.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titulo_form.Name = "pnl_titulo_form";
            this.pnl_titulo_form.Size = new System.Drawing.Size(1780, 44);
            this.pnl_titulo_form.TabIndex = 41;
            // 
            // lbl_prestamos
            // 
            this.lbl_prestamos.AutoSize = true;
            this.lbl_prestamos.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prestamos.ForeColor = System.Drawing.Color.White;
            this.lbl_prestamos.Location = new System.Drawing.Point(713, 11);
            this.lbl_prestamos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_prestamos.Name = "lbl_prestamos";
            this.lbl_prestamos.Size = new System.Drawing.Size(267, 25);
            this.lbl_prestamos.TabIndex = 0;
            this.lbl_prestamos.Text = "CAPITAL E INTERESES";
            // 
            // Btn_salir_cliente
            // 
            this.Btn_salir_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_salir_cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_salir_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir_cliente.ForeColor = System.Drawing.Color.White;
            this.Btn_salir_cliente.Image = global::SisBanca.Properties.Resources.cerrar_sesion;
            this.Btn_salir_cliente.Location = new System.Drawing.Point(347, 623);
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
            this.Btn_reporte.Location = new System.Drawing.Point(239, 623);
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
            this.Btn_actualizar.Location = new System.Drawing.Point(133, 622);
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
            this.Btn_nuevo.Location = new System.Drawing.Point(25, 622);
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
            this.Tbc_principal.Controls.Add(this.Prestamos);
            this.Tbc_principal.Controls.Add(this.Mantenimiento);
            this.Tbc_principal.Controls.Add(this.PlanPago);
            this.Tbc_principal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tbc_principal.Location = new System.Drawing.Point(16, 74);
            this.Tbc_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Tbc_principal.Name = "Tbc_principal";
            this.Tbc_principal.SelectedIndex = 0;
            this.Tbc_principal.Size = new System.Drawing.Size(1751, 541);
            this.Tbc_principal.TabIndex = 40;
            // 
            // Prestamos
            // 
            this.Prestamos.Controls.Add(this.Dgv_principal);
            this.Prestamos.Controls.Add(this.Btn_buscar);
            this.Prestamos.Controls.Add(this.Txt_buscar);
            this.Prestamos.Controls.Add(this.label1);
            this.Prestamos.Location = new System.Drawing.Point(4, 25);
            this.Prestamos.Margin = new System.Windows.Forms.Padding(4);
            this.Prestamos.Name = "Prestamos";
            this.Prestamos.Padding = new System.Windows.Forms.Padding(4);
            this.Prestamos.Size = new System.Drawing.Size(1743, 512);
            this.Prestamos.TabIndex = 0;
            this.Prestamos.Text = "Prestamos";
            this.Prestamos.UseVisualStyleBackColor = true;
            // 
            // Dgv_principal
            // 
            this.Dgv_principal.AllowUserToAddRows = false;
            this.Dgv_principal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_principal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_principal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dgv_principal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_principal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_principal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_principal.ColumnHeadersHeight = 35;
            this.Dgv_principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_principal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_principal.EnableHeadersVisualStyles = false;
            this.Dgv_principal.Location = new System.Drawing.Point(8, 61);
            this.Dgv_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_principal.Name = "Dgv_principal";
            this.Dgv_principal.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_principal.RowHeadersWidth = 51;
            this.Dgv_principal.Size = new System.Drawing.Size(1727, 444);
            this.Dgv_principal.TabIndex = 5;
            this.Dgv_principal.DoubleClick += new System.EventHandler(this.Dgv_principal_DoubleClick);
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_buscar.Location = new System.Drawing.Point(422, 25);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(100, 28);
            this.Btn_buscar.TabIndex = 2;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = false;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(87, 27);
            this.Txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(327, 22);
            this.Txt_buscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // Mantenimiento
            // 
            this.Mantenimiento.Controls.Add(this.label6);
            this.Mantenimiento.Controls.Add(this.txt_plazo);
            this.Mantenimiento.Controls.Add(this.label5);
            this.Mantenimiento.Controls.Add(this.txt_tasaInteres);
            this.Mantenimiento.Controls.Add(this.cmb_producto);
            this.Mantenimiento.Controls.Add(this.label4);
            this.Mantenimiento.Controls.Add(this.cmb_cuenta);
            this.Mantenimiento.Controls.Add(this.cmb_cliente);
            this.Mantenimiento.Controls.Add(this.Btn_retornar);
            this.Mantenimiento.Controls.Add(this.Btn_guardar);
            this.Mantenimiento.Controls.Add(this.Btn_cancelar);
            this.Mantenimiento.Controls.Add(this.label16);
            this.Mantenimiento.Controls.Add(this.txt_montoPrestado);
            this.Mantenimiento.Controls.Add(this.label3);
            this.Mantenimiento.Controls.Add(this.label2);
            this.Mantenimiento.Location = new System.Drawing.Point(4, 25);
            this.Mantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.Mantenimiento.Name = "Mantenimiento";
            this.Mantenimiento.Padding = new System.Windows.Forms.Padding(4);
            this.Mantenimiento.Size = new System.Drawing.Size(1743, 512);
            this.Mantenimiento.TabIndex = 1;
            this.Mantenimiento.Text = "Mantenimiento";
            this.Mantenimiento.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1174, 226);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Plazo: (*)";
            // 
            // txt_plazo
            // 
            this.txt_plazo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_plazo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_plazo.Location = new System.Drawing.Point(1178, 264);
            this.txt_plazo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_plazo.Name = "txt_plazo";
            this.txt_plazo.ReadOnly = true;
            this.txt_plazo.Size = new System.Drawing.Size(386, 24);
            this.txt_plazo.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(656, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = "Tasa de Interes: (*)";
            // 
            // txt_tasaInteres
            // 
            this.txt_tasaInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tasaInteres.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_tasaInteres.Location = new System.Drawing.Point(660, 264);
            this.txt_tasaInteres.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tasaInteres.Name = "txt_tasaInteres";
            this.txt_tasaInteres.ReadOnly = true;
            this.txt_tasaInteres.Size = new System.Drawing.Size(386, 24);
            this.txt_tasaInteres.TabIndex = 59;
            // 
            // cmb_producto
            // 
            this.cmb_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_producto.FormattingEnabled = true;
            this.cmb_producto.Location = new System.Drawing.Point(1178, 73);
            this.cmb_producto.Name = "cmb_producto";
            this.cmb_producto.Size = new System.Drawing.Size(387, 26);
            this.cmb_producto.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1174, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Producto bancario: (*)";
            // 
            // cmb_cuenta
            // 
            this.cmb_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cuenta.FormattingEnabled = true;
            this.cmb_cuenta.Location = new System.Drawing.Point(660, 73);
            this.cmb_cuenta.Name = "cmb_cuenta";
            this.cmb_cuenta.Size = new System.Drawing.Size(387, 26);
            this.cmb_cuenta.TabIndex = 56;
            // 
            // cmb_cliente
            // 
            this.cmb_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cliente.FormattingEnabled = true;
            this.cmb_cliente.Location = new System.Drawing.Point(126, 73);
            this.cmb_cliente.Name = "cmb_cliente";
            this.cmb_cliente.Size = new System.Drawing.Size(387, 26);
            this.cmb_cliente.TabIndex = 55;
            // 
            // Btn_retornar
            // 
            this.Btn_retornar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_retornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar.ForeColor = System.Drawing.Color.White;
            this.Btn_retornar.Location = new System.Drawing.Point(356, 451);
            this.Btn_retornar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_retornar.Name = "Btn_retornar";
            this.Btn_retornar.Size = new System.Drawing.Size(101, 32);
            this.Btn_retornar.TabIndex = 15;
            this.Btn_retornar.Text = "Retornar";
            this.Btn_retornar.UseVisualStyleBackColor = false;
            this.Btn_retornar.Visible = false;
            this.Btn_retornar.Click += new System.EventHandler(this.Btn_retornar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_guardar.Location = new System.Drawing.Point(240, 450);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(101, 32);
            this.Btn_guardar.TabIndex = 14;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Visible = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.LightCoral;
            this.Btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_cancelar.Location = new System.Drawing.Point(126, 450);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(101, 32);
            this.Btn_cancelar.TabIndex = 13;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Visible = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(122, 226);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "Monto otorgado: (*)";
            // 
            // txt_montoPrestado
            // 
            this.txt_montoPrestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montoPrestado.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_montoPrestado.Location = new System.Drawing.Point(126, 264);
            this.txt_montoPrestado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_montoPrestado.Name = "txt_montoPrestado";
            this.txt_montoPrestado.ReadOnly = true;
            this.txt_montoPrestado.Size = new System.Drawing.Size(386, 24);
            this.txt_montoPrestado.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Persona Titular del préstamo: (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(656, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cargado a la cuenta bancaria: (*)";
            // 
            // PlanPago
            // 
            this.PlanPago.Controls.Add(this.dgv_planpago);
            this.PlanPago.Controls.Add(this.btn_buscarplanpago);
            this.PlanPago.Controls.Add(this.txt_planpago);
            this.PlanPago.Controls.Add(this.label7);
            this.PlanPago.Location = new System.Drawing.Point(4, 25);
            this.PlanPago.Name = "PlanPago";
            this.PlanPago.Size = new System.Drawing.Size(1743, 512);
            this.PlanPago.TabIndex = 2;
            this.PlanPago.Text = "Planes de pago";
            this.PlanPago.UseVisualStyleBackColor = true;
            // 
            // dgv_planpago
            // 
            this.dgv_planpago.AllowUserToAddRows = false;
            this.dgv_planpago.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Menu;
            this.dgv_planpago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_planpago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_planpago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_planpago.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_planpago.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_planpago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_planpago.ColumnHeadersHeight = 35;
            this.dgv_planpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_planpago.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_planpago.EnableHeadersVisualStyles = false;
            this.dgv_planpago.Location = new System.Drawing.Point(8, 61);
            this.dgv_planpago.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_planpago.Name = "dgv_planpago";
            this.dgv_planpago.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_planpago.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_planpago.RowHeadersWidth = 51;
            this.dgv_planpago.Size = new System.Drawing.Size(1727, 444);
            this.dgv_planpago.TabIndex = 9;
            // 
            // btn_buscarplanpago
            // 
            this.btn_buscarplanpago.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_buscarplanpago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscarplanpago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscarplanpago.ForeColor = System.Drawing.Color.White;
            this.btn_buscarplanpago.Location = new System.Drawing.Point(422, 25);
            this.btn_buscarplanpago.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscarplanpago.Name = "btn_buscarplanpago";
            this.btn_buscarplanpago.Size = new System.Drawing.Size(100, 28);
            this.btn_buscarplanpago.TabIndex = 8;
            this.btn_buscarplanpago.Text = "Buscar";
            this.btn_buscarplanpago.UseVisualStyleBackColor = false;
            this.btn_buscarplanpago.Click += new System.EventHandler(this.btn_buscarplanpago_Click);
            // 
            // txt_planpago
            // 
            this.txt_planpago.Location = new System.Drawing.Point(87, 27);
            this.txt_planpago.Margin = new System.Windows.Forms.Padding(4);
            this.txt_planpago.Name = "txt_planpago";
            this.txt_planpago.Size = new System.Drawing.Size(327, 22);
            this.txt_planpago.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Buscar:";
            // 
            // Frm_DetallePrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 709);
            this.Controls.Add(this.pnl_titulo_form);
            this.Controls.Add(this.Btn_salir_cliente);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Tbc_principal);
            this.Name = "Frm_DetallePrestamos";
            this.Load += new System.EventHandler(this.Frm_DetallePrestamos_Load);
            this.pnl_titulo_form.ResumeLayout(false);
            this.pnl_titulo_form.PerformLayout();
            this.Tbc_principal.ResumeLayout(false);
            this.Prestamos.ResumeLayout(false);
            this.Prestamos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).EndInit();
            this.Mantenimiento.ResumeLayout(false);
            this.Mantenimiento.PerformLayout();
            this.PlanPago.ResumeLayout(false);
            this.PlanPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_planpago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo_form;
        private System.Windows.Forms.Label lbl_prestamos;
        private System.Windows.Forms.Button Btn_salir_cliente;
        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage Prestamos;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Mantenimiento;
        private System.Windows.Forms.Button Btn_retornar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_montoPrestado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button Btn_reporte;
        public System.Windows.Forms.Button Btn_actualizar;
        public System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.TabPage PlanPago;
        private System.Windows.Forms.DataGridView Dgv_principal;
        private System.Windows.Forms.ComboBox cmb_cliente;
        private System.Windows.Forms.ComboBox cmb_cuenta;
        private System.Windows.Forms.ComboBox cmb_producto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_plazo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tasaInteres;
        private System.Windows.Forms.DataGridView dgv_planpago;
        private System.Windows.Forms.Button btn_buscarplanpago;
        private System.Windows.Forms.TextBox txt_planpago;
        private System.Windows.Forms.Label label7;
    }
}