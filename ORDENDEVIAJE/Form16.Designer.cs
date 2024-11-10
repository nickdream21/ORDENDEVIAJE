namespace ORDENDEVIAJE
{
    partial class Form16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form16));
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox1 = new TextBox();
            btnExportar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            tabPage2 = new TabPage();
            btnExport = new Button();
            dataGridView2 = new DataGridView();
            btnBuscar = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            tabPage3 = new TabPage();
            dataGridView3 = new DataGridView();
            label5 = new Label();
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FloralWhite;
            panel1.Controls.Add(tabControl1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1208, 619);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1205, 619);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FloralWhite;
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(btnExportar);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1197, 586);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Órdenes de Viaje por CPIC";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(37, 452);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(94, 29);
            btnExportar.TabIndex = 4;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 36);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 1;
            label1.Text = "N° CPIC:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1132, 287);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(106, 81);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FloralWhite;
            tabPage2.Controls.Add(btnExport);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(btnBuscar);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(dateTimePicker2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(dateTimePicker1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1197, 586);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Finanzas";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(45, 415);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 8;
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(45, 212);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1101, 188);
            dataGridView2.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(45, 158);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 87);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 5;
            label4.Text = "N° CPIC:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 84);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(129, 27);
            textBox2.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(443, 24);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(132, 27);
            dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(352, 31);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha Final:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 31);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "Fecha de Inicio:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(162, 26);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(129, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FloralWhite;
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(comboBox1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1197, 586);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Conductores";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(37, 145);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(1126, 188);
            dataGridView3.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 35);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 1;
            label5.Text = "Conductor:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(343, 28);
            comboBox1.TabIndex = 0;
            // 
            // Form16
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 523);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form16";
            Text = "Form16";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button btnExportar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label4;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Button btnExport;
        private DataGridView dataGridView2;
        private Button btnBuscar;
        private Label label5;
        private ComboBox comboBox1;
        private DataGridView dataGridView3;
    }
}