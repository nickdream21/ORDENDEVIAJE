namespace ORDENDEVIAJE
{
    partial class Form4
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            textBoxGuiaTransportista = new TextBox();
            label3 = new Label();
            textBoxGuiaCliente = new TextBox();
            label4 = new Label();
            label6 = new Label();
            textBoxDescripcionProducto = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(646, 24);
            label1.TabIndex = 0;
            label1.Text = "GUIAS DE TRANSPORTISTA ASIGNADAS A LA ORDEN DE VIAJE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 70);
            label2.Name = "label2";
            label2.Size = new Size(152, 20);
            label2.TabIndex = 1;
            label2.Text = "N° Guia Transportista:";
            // 
            // textBoxGuiaTransportista
            // 
            textBoxGuiaTransportista.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxGuiaTransportista.Location = new Point(203, 63);
            textBoxGuiaTransportista.Margin = new Padding(3, 2, 3, 2);
            textBoxGuiaTransportista.Name = "textBoxGuiaTransportista";
            textBoxGuiaTransportista.Size = new Size(228, 27);
            textBoxGuiaTransportista.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(647, 70);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 3;
            label3.Text = "N° Guia Cliente:";
            // 
            // textBoxGuiaCliente
            // 
            textBoxGuiaCliente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxGuiaCliente.Location = new Point(766, 63);
            textBoxGuiaCliente.Margin = new Padding(3, 2, 3, 2);
            textBoxGuiaCliente.Name = "textBoxGuiaCliente";
            textBoxGuiaCliente.Size = new Size(228, 27);
            textBoxGuiaCliente.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 110);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 5;
            label4.Text = "Ruta:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 153);
            label6.Name = "label6";
            label6.Size = new Size(175, 20);
            label6.TabIndex = 9;
            label6.Text = "Descripcion de Producto:";
            // 
            // textBoxDescripcionProducto
            // 
            textBoxDescripcionProducto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDescripcionProducto.Location = new Point(203, 147);
            textBoxDescripcionProducto.Multiline = true;
            textBoxDescripcionProducto.Name = "textBoxDescripcionProducto";
            textBoxDescripcionProducto.Size = new Size(228, 34);
            textBoxDescripcionProducto.TabIndex = 10;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(203, 106);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 11;
            button1.Text = "Elegir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 267);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1062, 169);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(18, 217);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 13;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(980, 460);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 14;
            button3.Text = "Siguiente";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 501);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBoxDescripcionProducto);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBoxGuiaCliente);
            Controls.Add(label3);
            Controls.Add(textBoxGuiaTransportista);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxGuiaTransportista;
        private Label label3;
        private TextBox textBoxGuiaCliente;
        private Label label4;
        private Label label6;
        private TextBox textBoxDescripcionProducto;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private DataGridViewTextBoxColumn guiaTransportista;
        private DataGridViewTextBoxColumn guiaCliente;
        private DataGridViewTextBoxColumn ruta1;
        private DataGridViewTextBoxColumn ruta2;
        private DataGridViewTextBoxColumn numManifiesto;
        private DataGridViewTextBoxColumn plantaDescarga;
        private DataGridViewTextBoxColumn descProducto;
        private Button button3;
    }
}