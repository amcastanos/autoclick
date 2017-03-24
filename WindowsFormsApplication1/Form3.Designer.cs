namespace WindowsFormsApplication1
{
    partial class Plan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plan));
            this.TR = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TR
            // 
            this.TR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TR.ForeColor = System.Drawing.Color.Blue;
            this.TR.Location = new System.Drawing.Point(5, 3);
            this.TR.Name = "TR";
            this.TR.ReadOnly = true;
            this.TR.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TR.Size = new System.Drawing.Size(311, 278);
            this.TR.TabIndex = 0;
            this.TR.Text = "";
            // 
            // Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(101)))));
            this.ClientSize = new System.Drawing.Size(322, 284);
            this.ControlBox = false;
            this.Controls.Add(this.TR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plan";
            this.Shown += new System.EventHandler(this.Plan_Shown);
            this.LocationChanged += new System.EventHandler(this.Plan_LocationChanged);
            this.VisibleChanged += new System.EventHandler(this.Plan_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TR;
    }
}