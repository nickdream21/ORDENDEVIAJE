namespace ORDENDEVIAJE
{
    partial class Form14
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
            panel1 = new Panel();
            btnGuardar = new Button();
            dataGridView1 = new DataGridView();
            dtpFechaEmision = new DateTimePicker();
            label5 = new Label();
            txtValorFlete = new TextBox();
            label4 = new Label();
            txtNumeroFactura = new TextBox();
            label3 = new Label();
            txtNumeroCPIC = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(dtpFechaEmision);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtValorFlete);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtNumeroFactura);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNumeroCPIC);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(968, 520);
            panel1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(820, 405);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 215);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(889, 149);
            dataGridView1.TabIndex = 9;
           // dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dtpFechaEmision
            // 
            dtpFechaEmision.Format = DateTimePickerFormat.Short;
            dtpFechaEmision.Location = new Point(680, 90);
            dtpFechaEmision.Name = "dtpFechaEmision";
            dtpFechaEmision.Size = new Size(125, 27);
            dtpFechaEmision.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(523, 92);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 7;
            label5.Text = "Fecha de emisión:";
            // 
            // txtValorFlete
            // 
            txtValorFlete.Location = new Point(680, 148);
            txtValorFlete.Name = "txtValorFlete";
            txtValorFlete.Size = new Size(125, 27);
            txtValorFlete.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(526, 151);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 5;
            label4.Text = "Valor total de Flete:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(111, 146);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(125, 27);
            txtNumeroFactura.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 153);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 3;
            label3.Text = "N° Factura:";
            // 
            // txtNumeroCPIC
            // 
            txtNumeroCPIC.Location = new Point(111, 89);
            txtNumeroCPIC.Name = "txtNumeroCPIC";
            txtNumeroCPIC.Size = new Size(125, 27);
            txtNumeroCPIC.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 96);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "N° CPIC: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            label1.Location = new Point(341, 25);
            label1.Name = "label1";
            label1.Size = new Size(230, 32);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE CPIC";
            // 
            // Form14
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 468);
            Controls.Add(panel1);
            Name = "Form14";
            Text = "Form14";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtNumeroFactura;
        private Label label3;
        private TextBox txtNumeroCPIC;
        private Label label2;
        private Label label1;
        private TextBox txtValorFlete;
        private Label label4;
        private DateTimePicker dtpFechaEmision;
        private Label label5;
        private DataGridView dataGridView1;
        private Button btnGuardar;
    }
}