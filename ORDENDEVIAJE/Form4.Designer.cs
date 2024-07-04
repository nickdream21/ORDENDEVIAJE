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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            guiaTransportista = new DataGridViewTextBoxColumn();
            guiaCliente = new DataGridViewTextBoxColumn();
            ruta1 = new DataGridViewTextBoxColumn();
            ruta2 = new DataGridViewTextBoxColumn();
            numManifiesto = new DataGridViewTextBoxColumn();
            plantaDescarga = new DataGridViewTextBoxColumn();
            descProducto = new DataGridViewTextBoxColumn();
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
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 63);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 32);
            textBox1.TabIndex = 2;
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
            label3.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(766, 63);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(228, 32);
            textBox2.TabIndex = 4;
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
            // textBox3
            // 
            textBox3.Location = new Point(203, 147);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(228, 34);
            textBox3.TabIndex = 10;
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { guiaTransportista, guiaCliente, ruta1, ruta2, numManifiesto, plantaDescarga, descProducto });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 267);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1062, 169);
            dataGridView1.TabIndex = 12;
            // 
            // guiaTransportista
            // 
            guiaTransportista.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            guiaTransportista.HeaderText = "N° Guia Transportista";
            guiaTransportista.MinimumWidth = 6;
            guiaTransportista.Name = "guiaTransportista";
            guiaTransportista.Resizable = DataGridViewTriState.False;
            // 
            // guiaCliente
            // 
            guiaCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            guiaCliente.HeaderText = "N° Guia Cliente";
            guiaCliente.MinimumWidth = 6;
            guiaCliente.Name = "guiaCliente";
            guiaCliente.Resizable = DataGridViewTriState.False;
            // 
            // ruta1
            // 
            ruta1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ruta1.HeaderText = "Ruta 1";
            ruta1.MinimumWidth = 6;
            ruta1.Name = "ruta1";
            ruta1.Resizable = DataGridViewTriState.False;
            // 
            // ruta2
            // 
            ruta2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ruta2.HeaderText = "Ruta 2";
            ruta2.MinimumWidth = 6;
            ruta2.Name = "ruta2";
            ruta2.Resizable = DataGridViewTriState.False;
            // 
            // numManifiesto
            // 
            numManifiesto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            numManifiesto.HeaderText = "N° Manifiesto";
            numManifiesto.MinimumWidth = 6;
            numManifiesto.Name = "numManifiesto";
            numManifiesto.Resizable = DataGridViewTriState.False;
            // 
            // plantaDescarga
            // 
            plantaDescarga.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            plantaDescarga.HeaderText = "Planta de Descarga";
            plantaDescarga.MinimumWidth = 6;
            plantaDescarga.Name = "plantaDescarga";
            plantaDescarga.Resizable = DataGridViewTriState.False;
            // 
            // descProducto
            // 
            descProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descProducto.HeaderText = "Descripcion de Producto";
            descProducto.MinimumWidth = 6;
            descProducto.Name = "descProducto";
            descProducto.Resizable = DataGridViewTriState.False;
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
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Label label6;
        private TextBox textBox3;
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