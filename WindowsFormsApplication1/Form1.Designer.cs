namespace WindowsFormsApplication1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CKClave = new System.Windows.Forms.CheckBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.BCancela = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.TClave = new System.Windows.Forms.TextBox();
            this.Web = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.CKClave);
            this.groupBox1.Controls.Add(this.TUsuario);
            this.groupBox1.Controls.Add(this.BCancela);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.BAceptar);
            this.groupBox1.Controls.Add(this.TClave);
            this.groupBox1.Controls.Add(this.Web);
            this.groupBox1.Location = new System.Drawing.Point(5, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 281);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApplication1.Properties.Resources.Clave;
            this.pictureBox3.Location = new System.Drawing.Point(49, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 51);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.Usr;
            this.pictureBox2.Location = new System.Drawing.Point(54, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 47);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // CKClave
            // 
            this.CKClave.AutoSize = true;
            this.CKClave.Checked = true;
            this.CKClave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CKClave.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CKClave.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CKClave.Location = new System.Drawing.Point(106, 114);
            this.CKClave.Name = "CKClave";
            this.CKClave.Size = new System.Drawing.Size(43, 26);
            this.CKClave.TabIndex = 11;
            this.CKClave.Text = "R";
            this.CKClave.UseVisualStyleBackColor = true;
            // 
            // TUsuario
            // 
            this.TUsuario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TUsuario.ForeColor = System.Drawing.Color.Blue;
            this.TUsuario.Location = new System.Drawing.Point(106, 30);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(156, 29);
            this.TUsuario.TabIndex = 4;
            // 
            // BCancela
            // 
            this.BCancela.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.BCancela.Image = global::WindowsFormsApplication1.Properties.Resources.Cancelar;
            this.BCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancela.Location = new System.Drawing.Point(216, 150);
            this.BCancela.Name = "BCancela";
            this.BCancela.Size = new System.Drawing.Size(51, 51);
            this.BCancela.TabIndex = 10;
            this.BCancela.UseVisualStyleBackColor = true;
            this.BCancela.Click += new System.EventHandler(this.BCancela_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.logo_free_autoclick;
            this.pictureBox1.Location = new System.Drawing.Point(129, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // BAceptar
            // 
            this.BAceptar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.BAceptar.Image = global::WindowsFormsApplication1.Properties.Resources.Aceptar;
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.Location = new System.Drawing.Point(92, 150);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(51, 51);
            this.BAceptar.TabIndex = 6;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // TClave
            // 
            this.TClave.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TClave.ForeColor = System.Drawing.Color.Blue;
            this.TClave.Location = new System.Drawing.Point(106, 76);
            this.TClave.Name = "TClave";
            this.TClave.PasswordChar = '$';
            this.TClave.Size = new System.Drawing.Size(156, 29);
            this.TClave.TabIndex = 5;
            this.TClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TClave_KeyPress);
            // 
            // Web
            // 
            this.Web.AutoSize = true;
            this.Web.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Web.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Web.ForeColor = System.Drawing.Color.Blue;
            this.Web.Location = new System.Drawing.Point(262, 203);
            this.Web.Name = "Web";
            this.Web.Size = new System.Drawing.Size(0, 15);
            this.Web.TabIndex = 3;
            this.Web.Click += new System.EventHandler(this.Web_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApplication1.Properties.Resources.fondp1;
            this.pictureBox4.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(366, 288);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.ClientSize = new System.Drawing.Size(353, 280);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BCancela;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.TextBox TClave;
        private System.Windows.Forms.Label Web;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.CheckBox CKClave;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

