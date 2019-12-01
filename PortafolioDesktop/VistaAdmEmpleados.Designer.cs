using System;

namespace PortafolioDesktop
{
    partial class VistaAdmEmpleados
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgwEmpleados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(1134, 503);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgwEmpleados
            // 
            this.dgwEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEmpleados.Location = new System.Drawing.Point(499, 49);
            this.dgwEmpleados.Name = "dgwEmpleados";
            this.dgwEmpleados.Size = new System.Drawing.Size(739, 421);
            this.dgwEmpleados.TabIndex = 1;
            // 
            // VistaAdmEmpleados
            // 
            this.ClientSize = new System.Drawing.Size(1263, 557);
            this.Controls.Add(this.dgwEmpleados);
            this.Controls.Add(this.btnVolver);
            this.Name = "VistaAdmEmpleados";
            this.Load += new System.EventHandler(this.VistaAdmEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEmpleados)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgwEmpleados;
    }
}