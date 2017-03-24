namespace SignalTrade
{
    partial class PPal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PPal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Botones = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripSeparator();
            this.Hora = new System.Windows.Forms.ToolStripLabel();
            this.BCalendar = new System.Windows.Forms.ToolStripButton();
            this.TR = new System.Windows.Forms.RichTextBox();
            this.TW = new System.Windows.Forms.RichTextBox();
            this.LUsuarios = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirEnNuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BEnviar = new System.Windows.Forms.Button();
            this.Tim = new System.Windows.Forms.Timer(this.components);
            this.BDesactiva = new System.Windows.Forms.Button();
            this.LCantidad = new System.Windows.Forms.Label();
            this.BPlan = new System.Windows.Forms.Button();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.TNoticia = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DGNot = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.BDespedida = new System.Windows.Forms.Button();
            this.B1Min = new System.Windows.Forms.Button();
            this.B3Min = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Compra = new System.Windows.Forms.Button();
            this.B4 = new System.Windows.Forms.Button();
            this.B3 = new System.Windows.Forms.Button();
            this.B2 = new System.Windows.Forms.Button();
            this.B1 = new System.Windows.Forms.Button();
            this.BNoTrade = new System.Windows.Forms.Button();
            this.Venta = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.THora = new System.Windows.Forms.TextBox();
            this.TMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TNotP = new System.Windows.Forms.ToolStripLabel();
            this.Botones.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGNot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // Botones
            // 
            this.Botones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.Botones.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.Botones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.Hora,
            this.BCalendar,
            this.TNotP});
            this.Botones.Location = new System.Drawing.Point(0, 0);
            this.Botones.Name = "Botones";
            this.Botones.Size = new System.Drawing.Size(490, 47);
            this.Botones.TabIndex = 0;
            this.Botones.Text = "toolStrip1";
            this.Botones.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Botones_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton1.Text = "Usuarios";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton2.Text = "Acerca De...";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(6, 47);
            // 
            // Hora
            // 
            this.Hora.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hora.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Hora.Name = "Hora";
            this.Hora.Size = new System.Drawing.Size(0, 44);
            // 
            // BCalendar
            // 
            this.BCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCalendar.Image = ((System.Drawing.Image)(resources.GetObject("BCalendar.Image")));
            this.BCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCalendar.Name = "BCalendar";
            this.BCalendar.Size = new System.Drawing.Size(44, 44);
            this.BCalendar.Text = "Calendario";
            this.BCalendar.Click += new System.EventHandler(this.BCalendar_Click);
            // 
            // TR
            // 
            this.TR.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TR.Location = new System.Drawing.Point(111, 53);
            this.TR.Name = "TR";
            this.TR.ReadOnly = true;
            this.TR.Size = new System.Drawing.Size(34, 33);
            this.TR.TabIndex = 1;
            this.TR.Text = "";
            this.TR.TextChanged += new System.EventHandler(this.TR_TextChanged);
            // 
            // TW
            // 
            this.TW.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TW.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TW.Location = new System.Drawing.Point(155, 52);
            this.TW.Name = "TW";
            this.TW.Size = new System.Drawing.Size(329, 275);
            this.TW.TabIndex = 2;
            this.TW.Text = "";
            this.TW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TW_KeyDown);
            this.TW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TW_KeyPress);
            // 
            // LUsuarios
            // 
            this.LUsuarios.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LUsuarios.ContextMenuStrip = this.contextMenuStrip1;
            this.LUsuarios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuarios.ForeColor = System.Drawing.Color.Blue;
            this.LUsuarios.FormattingEnabled = true;
            this.LUsuarios.ItemHeight = 15;
            this.LUsuarios.Location = new System.Drawing.Point(12, 53);
            this.LUsuarios.Name = "LUsuarios";
            this.LUsuarios.Size = new System.Drawing.Size(137, 274);
            this.LUsuarios.TabIndex = 3;
            this.LUsuarios.ValueMemberChanged += new System.EventHandler(this.LUsuarios_ValueMemberChanged);
            this.LUsuarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LUsuarios_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirEnNuevaVentanaToolStripMenuItem,
            this.desconectarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 48);
            // 
            // abrirEnNuevaVentanaToolStripMenuItem
            // 
            this.abrirEnNuevaVentanaToolStripMenuItem.Name = "abrirEnNuevaVentanaToolStripMenuItem";
            this.abrirEnNuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.abrirEnNuevaVentanaToolStripMenuItem.Text = "Abrir en nueva ventana";
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.desconectarToolStripMenuItem.Text = "Desconectar";
            // 
            // BEnviar
            // 
            this.BEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.BEnviar.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEnviar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BEnviar.Location = new System.Drawing.Point(227, 334);
            this.BEnviar.Name = "BEnviar";
            this.BEnviar.Size = new System.Drawing.Size(96, 45);
            this.BEnviar.TabIndex = 4;
            this.BEnviar.Text = "Enviar";
            this.BEnviar.UseVisualStyleBackColor = false;
            this.BEnviar.Click += new System.EventHandler(this.BEnviar_Click);
            // 
            // Tim
            // 
            this.Tim.Enabled = true;
            this.Tim.Interval = 400;
            this.Tim.Tick += new System.EventHandler(this.Tim_Tick);
            // 
            // BDesactiva
            // 
            this.BDesactiva.BackColor = System.Drawing.SystemColors.Control;
            this.BDesactiva.Location = new System.Drawing.Point(269, 231);
            this.BDesactiva.Name = "BDesactiva";
            this.BDesactiva.Size = new System.Drawing.Size(33, 29);
            this.BDesactiva.TabIndex = 15;
            this.BDesactiva.Text = "Desactiva Chat";
            this.BDesactiva.UseVisualStyleBackColor = false;
            this.BDesactiva.Click += new System.EventHandler(this.BDesactiva_Click);
            // 
            // LCantidad
            // 
            this.LCantidad.AutoSize = true;
            this.LCantidad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LCantidad.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantidad.Location = new System.Drawing.Point(450, 346);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(30, 32);
            this.LCantidad.TabIndex = 16;
            this.LCantidad.Text = "0";
            // 
            // BPlan
            // 
            this.BPlan.BackColor = System.Drawing.SystemColors.Control;
            this.BPlan.Location = new System.Drawing.Point(227, 385);
            this.BPlan.Name = "BPlan";
            this.BPlan.Size = new System.Drawing.Size(96, 45);
            this.BPlan.TabIndex = 17;
            this.BPlan.Text = "Plan";
            this.BPlan.UseVisualStyleBackColor = false;
            this.BPlan.Click += new System.EventHandler(this.BPlan_Click);
            // 
            // DTFecha
            // 
            this.DTFecha.Location = new System.Drawing.Point(509, 163);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(200, 20);
            this.DTFecha.TabIndex = 23;
            // 
            // TNoticia
            // 
            this.TNoticia.Location = new System.Drawing.Point(509, 100);
            this.TNoticia.Name = "TNoticia";
            this.TNoticia.Size = new System.Drawing.Size(316, 28);
            this.TNoticia.TabIndex = 24;
            this.TNoticia.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(505, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Noticia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(505, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Fecha:";
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(548, 211);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(82, 28);
            this.BGuardar.TabIndex = 27;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 28;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGNot
            // 
            this.DGNot.AllowUserToAddRows = false;
            this.DGNot.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGNot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGNot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGNot.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGNot.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGNot.Location = new System.Drawing.Point(498, 248);
            this.DGNot.MultiSelect = false;
            this.DGNot.Name = "DGNot";
            this.DGNot.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGNot.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGNot.RowHeadersVisible = false;
            this.DGNot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGNot.Size = new System.Drawing.Size(331, 198);
            this.DGNot.TabIndex = 29;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(765, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 35);
            this.button2.TabIndex = 30;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BDespedida
            // 
            this.BDespedida.BackColor = System.Drawing.SystemColors.Control;
            this.BDespedida.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDespedida.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BDespedida.Image = global::SignalTrade.Properties.Resources.Adios;
            this.BDespedida.Location = new System.Drawing.Point(112, 377);
            this.BDespedida.Name = "BDespedida";
            this.BDespedida.Size = new System.Drawing.Size(43, 38);
            this.BDespedida.TabIndex = 31;
            this.BDespedida.UseVisualStyleBackColor = false;
            this.BDespedida.Click += new System.EventHandler(this.BDespedida_Click);
            // 
            // B1Min
            // 
            this.B1Min.BackColor = System.Drawing.SystemColors.Control;
            this.B1Min.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B1Min.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B1Min.Image = global::SignalTrade.Properties.Resources._1min;
            this.B1Min.Location = new System.Drawing.Point(63, 377);
            this.B1Min.Name = "B1Min";
            this.B1Min.Size = new System.Drawing.Size(43, 38);
            this.B1Min.TabIndex = 22;
            this.B1Min.UseVisualStyleBackColor = false;
            this.B1Min.Click += new System.EventHandler(this.B1Min_Click);
            // 
            // B3Min
            // 
            this.B3Min.BackColor = System.Drawing.SystemColors.Control;
            this.B3Min.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3Min.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B3Min.Image = global::SignalTrade.Properties.Resources._3min;
            this.B3Min.Location = new System.Drawing.Point(12, 377);
            this.B3Min.Name = "B3Min";
            this.B3Min.Size = new System.Drawing.Size(43, 38);
            this.B3Min.TabIndex = 21;
            this.B3Min.UseVisualStyleBackColor = false;
            this.B3Min.Click += new System.EventHandler(this.B3Min_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SignalTrade.Properties.Resources.Usr;
            this.pictureBox4.Location = new System.Drawing.Point(394, 333);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 57);
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SignalTrade.Properties.Resources.logo_free_autoclick;
            this.pictureBox3.Location = new System.Drawing.Point(329, 396);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(163, 59);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // Compra
            // 
            this.Compra.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Compra.Image = global::SignalTrade.Properties.Resources.buy_websites;
            this.Compra.Location = new System.Drawing.Point(392, 5);
            this.Compra.Name = "Compra";
            this.Compra.Size = new System.Drawing.Size(43, 38);
            this.Compra.TabIndex = 8;
            this.Compra.UseVisualStyleBackColor = false;
            this.Compra.Click += new System.EventHandler(this.Compra_Click);
            // 
            // B4
            // 
            this.B4.BackColor = System.Drawing.SystemColors.Control;
            this.B4.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B4.Image = global::SignalTrade.Properties.Resources.Toda;
            this.B4.Location = new System.Drawing.Point(160, 333);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(42, 38);
            this.B4.TabIndex = 14;
            this.B4.UseVisualStyleBackColor = false;
            this.B4.Click += new System.EventHandler(this.B4_Click);
            // 
            // B3
            // 
            this.B3.BackColor = System.Drawing.SystemColors.Control;
            this.B3.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B3.Image = global::SignalTrade.Properties.Resources.Media;
            this.B3.Location = new System.Drawing.Point(111, 333);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(43, 38);
            this.B3.TabIndex = 13;
            this.B3.UseVisualStyleBackColor = false;
            this.B3.Click += new System.EventHandler(this.B3_Click);
            // 
            // B2
            // 
            this.B2.BackColor = System.Drawing.SystemColors.Control;
            this.B2.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B2.Image = global::SignalTrade.Properties.Resources.Cuarto;
            this.B2.Location = new System.Drawing.Point(61, 333);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(43, 38);
            this.B2.TabIndex = 12;
            this.B2.UseVisualStyleBackColor = false;
            this.B2.Click += new System.EventHandler(this.B2_Click);
            // 
            // B1
            // 
            this.B1.BackColor = System.Drawing.SystemColors.Control;
            this.B1.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B1.Image = global::SignalTrade.Properties.Resources.Stop;
            this.B1.Location = new System.Drawing.Point(12, 333);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(43, 38);
            this.B1.TabIndex = 11;
            this.B1.UseVisualStyleBackColor = false;
            this.B1.Click += new System.EventHandler(this.B1_Click);
            // 
            // BNoTrade
            // 
            this.BNoTrade.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BNoTrade.Image = global::SignalTrade.Properties.Resources.NT1;
            this.BNoTrade.Location = new System.Drawing.Point(343, 5);
            this.BNoTrade.Name = "BNoTrade";
            this.BNoTrade.Size = new System.Drawing.Size(43, 38);
            this.BNoTrade.TabIndex = 9;
            this.BNoTrade.UseVisualStyleBackColor = false;
            this.BNoTrade.Click += new System.EventHandler(this.BNoTrade_Click);
            // 
            // Venta
            // 
            this.Venta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Venta.Image = global::SignalTrade.Properties.Resources.Sell1;
            this.Venta.Location = new System.Drawing.Point(442, 5);
            this.Venta.Name = "Venta";
            this.Venta.Size = new System.Drawing.Size(43, 38);
            this.Venta.TabIndex = 10;
            this.Venta.UseVisualStyleBackColor = false;
            this.Venta.Click += new System.EventHandler(this.Venta_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SignalTrade.Properties.Resources.Speaker_32;
            this.pictureBox2.Location = new System.Drawing.Point(353, 346);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 32);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SignalTrade.Properties.Resources.speaker_mute_32;
            this.pictureBox1.Location = new System.Drawing.Point(353, 348);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SignalTrade.Properties.Resources.fondp1;
            this.pictureBox5.Location = new System.Drawing.Point(0, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(492, 450);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // THora
            // 
            this.THora.Location = new System.Drawing.Point(729, 163);
            this.THora.Name = "THora";
            this.THora.Size = new System.Drawing.Size(36, 20);
            this.THora.TabIndex = 32;
            this.THora.Text = "00";
            // 
            // TMin
            // 
            this.TMin.Location = new System.Drawing.Point(777, 163);
            this.TMin.Name = "TMin";
            this.TMin.Size = new System.Drawing.Size(36, 20);
            this.TMin.TabIndex = 33;
            this.TMin.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(725, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Hora Minuto:";
            // 
            // TNotP
            // 
            this.TNotP.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNotP.ForeColor = System.Drawing.Color.White;
            this.TNotP.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TNotP.Name = "TNotP";
            this.TNotP.Size = new System.Drawing.Size(69, 44);
            this.TNotP.Text = "No hay Noticia";
            // 
            // PPal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.ClientSize = new System.Drawing.Size(490, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TMin);
            this.Controls.Add(this.THora);
            this.Controls.Add(this.BDespedida);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DGNot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TNoticia);
            this.Controls.Add(this.DTFecha);
            this.Controls.Add(this.B1Min);
            this.Controls.Add(this.B3Min);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BPlan);
            this.Controls.Add(this.LCantidad);
            this.Controls.Add(this.Compra);
            this.Controls.Add(this.B4);
            this.Controls.Add(this.B3);
            this.Controls.Add(this.B2);
            this.Controls.Add(this.B1);
            this.Controls.Add(this.BNoTrade);
            this.Controls.Add(this.Venta);
            this.Controls.Add(this.LUsuarios);
            this.Controls.Add(this.Botones);
            this.Controls.Add(this.TW);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TR);
            this.Controls.Add(this.BDesactiva);
            this.Controls.Add(this.BEnviar);
            this.Controls.Add(this.pictureBox5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PPal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autoclick News Institucional";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PPal_FormClosed);
            this.Load += new System.EventHandler(this.PPal_Load);
            this.Shown += new System.EventHandler(this.PPal_Shown);
            this.Botones.ResumeLayout(false);
            this.Botones.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGNot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Botones;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton3;
        private System.Windows.Forms.RichTextBox TR;
        private System.Windows.Forms.RichTextBox TW;
        private System.Windows.Forms.ListBox LUsuarios;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirEnNuevaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarToolStripMenuItem;
        private System.Windows.Forms.Button BEnviar;
        private System.Windows.Forms.ToolStripSeparator toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripLabel Hora;
        private System.Windows.Forms.Timer Tim;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Compra;
        private System.Windows.Forms.Button BNoTrade;
        private System.Windows.Forms.Button Venta;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Button B4;
        private System.Windows.Forms.Button BDesactiva;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Button BPlan;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ToolStripButton BCalendar;
        private System.Windows.Forms.Button B3Min;
        private System.Windows.Forms.Button B1Min;
        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.RichTextBox TNoticia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGNot;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BDespedida;
        private System.Windows.Forms.TextBox THora;
        private System.Windows.Forms.TextBox TMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripLabel TNotP;
    }
}