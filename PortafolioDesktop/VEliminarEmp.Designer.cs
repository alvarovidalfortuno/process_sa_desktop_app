namespace PortafolioDesktop
{
    partial class VEliminarEmp
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarEmp = new System.Windows.Forms.Button();
            this.txtEliminarEmp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eliminar Empleados";
            // 
            // btnEliminarEmp
            // 
            this.btnEliminarEmp.Location = new System.Drawing.Point(68, 131);
            this.btnEliminarEmp.Name = "btnEliminarEmp";
            this.btnEliminarEmp.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEmp.TabIndex = 1;
            this.btnEliminarEmp.Text = "Eliminar";
            this.btnEliminarEmp.UseVisualStyleBackColor = true;
            // 
            // txtEliminarEmp
            // 
            this.txtEliminarEmp.Location = new System.Drawing.Point(125, 81);
            this.txtEliminarEmp.Name = "txtEliminarEmp";
            this.txtEliminarEmp.Size = new System.Drawing.Size(54, 20);
            this.txtEliminarEmp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Empleado";
            // 
            // VEliminarEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEliminarEmp);
            this.Controls.Add(this.btnEliminarEmp);
            this.Controls.Add(this.label1);
            this.Name = "VEliminarEmp";
            this.Text = "VEliminarEmp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarEmp;
        private System.Windows.Forms.TextBox txtEliminarEmp;
        private System.Windows.Forms.Label label2;
    }
}