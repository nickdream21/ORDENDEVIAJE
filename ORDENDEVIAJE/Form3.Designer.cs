namespace ORDENDEVIAJE
{
    partial class Form3
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
            dataGridView1 = new DataGridView();
            Ruta = new DataGridViewComboBoxColumn();
            Añadir = new DataGridViewCheckBoxColumn();
            button1 = new Button();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            textBox3 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ruta, Añadir });
            dataGridView1.Location = new Point(32, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Ruta
            // 
            Ruta.HeaderText = "Ruta";
            Ruta.Items.AddRange(new object[] { "Sullana-Trujillo-Sullana", "Sullana-Guayaquil-Sullana" });
            Ruta.MinimumWidth = 6;
            Ruta.Name = "Ruta";
            Ruta.Width = 125;
            // 
            // Añadir
            // 
            Añadir.HeaderText = "Añadir";
            Añadir.MinimumWidth = 6;
            Añadir.Name = "Añadir";
            Añadir.Resizable = DataGridViewTriState.True;
            Añadir.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(32, 276);
            button1.Name = "button1";
            button1.Size = new Size(115, 29);
            button1.TabIndex = 1;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 324);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 2;
            label1.Text = "Planta descarga:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "JAVE" });
            comboBox2.Location = new Point(181, 321);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 364);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 4;
            label2.Text = "N° Manifiesto:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(181, 361);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(238, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 450);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private TextBox textBox3;
        private Button button2;
        private DataGridViewComboBoxColumn Ruta;
        private DataGridViewCheckBoxColumn Añadir;
    }
}