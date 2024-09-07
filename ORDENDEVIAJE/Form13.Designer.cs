namespace ORDENDEVIAJE
{
    partial class Form13
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
            button2 = new Button();
            textBox3 = new TextBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Ruta = new DataGridViewComboBoxColumn();
            Añadir = new DataGridViewCheckBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 447);
            panel1.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(234, 386);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 13;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(177, 338);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FloralWhite;
            label2.Location = new Point(28, 341);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 11;
            label2.Text = "N° Manifiesto:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "JAVE" });
            comboBox2.Location = new Point(177, 298);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FloralWhite;
            label1.Location = new Point(28, 301);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 9;
            label1.Text = "Planta descarga:";
            // 
            // button1
            // 
            button1.Location = new Point(28, 253);
            button1.Name = "button1";
            button1.Size = new Size(115, 29);
            button1.TabIndex = 8;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ruta, Añadir });
            dataGridView1.Location = new Point(28, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 7;
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
            // Form13
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 450);
            Controls.Add(panel1);
            Name = "Form13";
            Text = "Form13";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private TextBox textBox3;
        private Label label2;
        private ComboBox comboBox2;
        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewComboBoxColumn Ruta;
        private DataGridViewCheckBoxColumn Añadir;
    }
}