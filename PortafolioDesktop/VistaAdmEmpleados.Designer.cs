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
            this.btnCrearEmp = new System.Windows.Forms.Button();
            this.btnActualizarEmp = new System.Windows.Forms.Button();
            this.btnEliminarEmp = new System.Windows.Forms.Button();
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
            // btnCrearEmp
            // 
            this.btnCrearEmp.Location = new System.Drawing.Point(73, 79);
            this.btnCrearEmp.Name = "btnCrearEmp";
            this.btnCrearEmp.Size = new System.Drawing.Size(130, 23);
            this.btnCrearEmp.TabIndex = 2;
            this.btnCrearEmp.Text = "Crear Empleado";
            this.btnCrearEmp.UseVisualStyleBackColor = true;
            this.btnCrearEmp.Click += new System.EventHandler(this.btnCrearEmp_Click);
            // 
            // btnActualizarEmp
            // 
            this.btnActualizarEmp.Location = new System.Drawing.Point(73, 156);
            this.btnActualizarEmp.Name = "btnActualizarEmp";
            this.btnActualizarEmp.Size = new System.Drawing.Size(130, 23);
            this.btnActualizarEmp.TabIndex = 3;
            this.btnActualizarEmp.Text = "Actualizar Empleado";
            this.btnActualizarEmp.UseVisualStyleBackColor = true;
            this.btnActualizarEmp.Click += new System.EventHandler(this.btnActualizarEmp_Click);
            // 
            // btnEliminarEmp
            // 
            this.btnEliminarEmp.Location = new System.Drawing.Point(73, 226);
            this.btnEliminarEmp.Name = "btnEliminarEmp";
            this.btnEliminarEmp.Size = new System.Drawing.Size(130, 23);
            this.btnEliminarEmp.TabIndex = 4;
            this.btnEliminarEmp.Text = "Eliminar Empleado";
            this.btnEliminarEmp.UseVisualStyleBackColor = true;
            this.btnEliminarEmp.Click += new System.EventHandler(this.btnEliminarEmp_Click);
            // 
            // VistaAdmEmpleados
            // 
            this.ClientSize = new System.Drawing.Size(1263, 557);
            this.Controls.Add(this.btnEliminarEmp);
            this.Controls.Add(this.btnActualizarEmp);
            this.Controls.Add(this.btnCrearEmp);
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
        private System.Windows.Forms.Button btnCrearEmp;
        private System.Windows.Forms.Button btnActualizarEmp;
        private System.Windows.Forms.Button btnEliminarEmp;
    }
}