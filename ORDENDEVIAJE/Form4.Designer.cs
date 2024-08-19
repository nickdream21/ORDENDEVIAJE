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
            buttonElegir = new Button();
            buttonGuardar = new Button();
            buttonSiguiente = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FloralWhite;
            label1.Location = new Point(199, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(646, 24);
            label1.TabIndex = 0;
            label1.Text = "GUIAS DE TRANSPORTISTA ASIGNADAS A LA ORDEN DE VIAJE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FloralWhite;
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
            label3.BackColor = Color.FloralWhite;
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
            label4.BackColor = Color.FloralWhite;
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
            label6.BackColor = Color.FloralWhite;
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
            // buttonElegir
            // 
            buttonElegir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonElegir.Location = new Point(203, 106);
            buttonElegir.Name = "buttonElegir";
            buttonElegir.Size = new Size(94, 29);
            buttonElegir.TabIndex = 11;
            buttonElegir.Text = "Elegir";
            buttonElegir.UseVisualStyleBackColor = true;
            buttonElegir.Click += buttonElegir_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonGuardar.Location = new Point(18, 217);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(94, 29);
            buttonGuardar.TabIndex = 13;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonSiguiente
            // 
            buttonSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSiguiente.Location = new Point(980, 460);
            buttonSiguiente.Name = "buttonSiguiente";
            buttonSiguiente.Size = new Size(94, 29);
            buttonSiguiente.TabIndex = 14;
            buttonSiguiente.Text = "Siguiente";
            buttonSiguiente.UseVisualStyleBackColor = true;
            buttonSiguiente.Click += buttonSiguiente_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(18, 273);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1039, 126);
            dataGridView1.TabIndex = 15;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1091, 506);
            panel1.TabIndex = 16;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 501);
            Controls.Add(dataGridView1);
            Controls.Add(buttonSiguiente);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonElegir);
            Controls.Add(textBoxDescripcionProducto);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBoxGuiaCliente);
            Controls.Add(label3);
            Controls.Add(textBoxGuiaTransportista);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
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
        private Button buttonElegir;
        private Button buttonGuardar;
        private DataGridViewTextBoxColumn guiaTransportista;
        private DataGridViewTextBoxColumn guiaCliente;
        private DataGridViewTextBoxColumn ruta1;
        private DataGridViewTextBoxColumn ruta2;
        private DataGridViewTextBoxColumn numManifiesto;
        private DataGridViewTextBoxColumn plantaDescarga;
        private DataGridViewTextBoxColumn descProducto;
        private Button buttonSiguiente;
        private DataGridView dataGridView1;
        private Panel panel1;
    }
}