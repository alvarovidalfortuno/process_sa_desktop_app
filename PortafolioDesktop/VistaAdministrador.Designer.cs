namespace PortafolioDesktop
{
    partial class VistaAdministrador
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
            this.btnTerminarSesion = new System.Windows.Forms.Button();
            this.btnAdminEmp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTerminarSesion
            // 
            this.btnTerminarSesion.Location = new System.Drawing.Point(52, 226);
            this.btnTerminarSesion.Name = "btnTerminarSesion";
            this.btnTerminarSesion.Size = new System.Drawing.Size(135, 23);
            this.btnTerminarSesion.TabIndex = 0;
            this.btnTerminarSesion.Text = "Terminar Sesión";
            this.btnTerminarSesion.UseVisualStyleBackColor = true;
            this.btnTerminarSesion.Click += new System.EventHandler(this.btnTerminarSesion_Click);
            // 
            // btnAdminEmp
            // 
            this.btnAdminEmp.Location = new System.Drawing.Point(52, 73);
            this.btnAdminEmp.Name = "btnAdminEmp";
            this.btnAdminEmp.Size = new System.Drawing.Size(130, 23);
            this.btnAdminEmp.TabIndex = 2;
            this.btnAdminEmp.Text = "Administrar Empleados";
            this.btnAdminEmp.UseVisualStyleBackColor = true;
            this.btnAdminEmp.Click += new System.EventHandler(this.btnAdminEmp_Click);
            // 
            // VistaAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 285);
            this.Controls.Add(this.btnAdminEmp);
            this.Controls.Add(this.btnTerminarSesion);
            this.Name = "VistaAdministrador";
            this.Text = "VistaAdministrador";
            this.Load += new System.EventHandler(this.VistaAdministrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTerminarSesion;
       
        private System.Windows.Forms.Button btnAdminEmp;
    }
}