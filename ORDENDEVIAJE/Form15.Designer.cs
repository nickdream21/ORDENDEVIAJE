namespace ORDENDEVIAJE
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            panel1 = new Panel();
            btnGuardar = new Button();
            txtImporteTotal = new TextBox();
            label4 = new Label();
            dtpFechaEmision = new DateTimePicker();
            label3 = new Label();
            txtNumeroFactura = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(txtImporteTotal);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtpFechaEmision);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNumeroFactura);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(486, 355);
            panel1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(354, 296);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtImporteTotal
            // 
            txtImporteTotal.Location = new Point(214, 211);
            txtImporteTotal.Name = "txtImporteTotal";
            txtImporteTotal.Size = new Size(178, 27);
            txtImporteTotal.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 211);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 5;
            label4.Text = "Importe Total:";
            // 
            // dtpFechaEmision
            // 
            dtpFechaEmision.Format = DateTimePickerFormat.Short;
            dtpFechaEmision.Location = new Point(214, 148);
            dtpFechaEmision.Name = "dtpFechaEmision";
            dtpFechaEmision.Size = new Size(178, 27);
            dtpFechaEmision.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 155);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 3;
            label3.Text = "Fecha de Emision:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(214, 98);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(178, 27);
            txtNumeroFactura.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 101);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "N° Factura:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 27);
            label1.Name = "label1";
            label1.Size = new Size(265, 31);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE FACTURA";
            // 
            // Form15
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 352);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form15";
            Text = "Form15";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private TextBox txtNumeroFactura;
        private Label label2;
        private Label label1;
        private Button btnGuardar;
        private TextBox txtImporteTotal;
        private Label label4;
        private DateTimePicker dtpFechaEmision;
    }
}