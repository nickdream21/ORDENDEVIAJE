namespace ORDENDEVIAJE
{
    partial class Form2
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            dateTimePicker3 = new DateTimePicker();
            label5 = new Label();
            dateTimePicker4 = new DateTimePicker();
            label6 = new Label();
            dateTimePicker5 = new DateTimePicker();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 86);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 0;
            label1.Text = "N° PEDIDO:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(193, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 150);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 2;
            label2.Text = "N° ORDEN DE VIAJE:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(193, 143);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 84);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha de Salida:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(464, 81);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(123, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(593, 84);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 7;
            label4.Text = "Hora de Salida:";
            label4.Click += label4_Click;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Location = new Point(710, 81);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(84, 27);
            dateTimePicker3.TabIndex = 9;
            dateTimePicker3.ValueChanged += dateTimePicker3_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(342, 146);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 10;
            label5.Text = "Fecha de Llegada:";
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Format = DateTimePickerFormat.Short;
            dateTimePicker4.Location = new Point(464, 141);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(123, 27);
            dateTimePicker4.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(593, 143);
            label6.Name = "label6";
            label6.Size = new Size(111, 20);
            label6.TabIndex = 12;
            label6.Text = "Hora de Salida:";
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.Format = DateTimePickerFormat.Time;
            dateTimePicker5.Location = new Point(710, 143);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new Size(84, 27);
            dateTimePicker5.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 212);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 14;
            label7.Text = "Cliente:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(102, 209);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(216, 28);
            comboBox1.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 264);
            label8.Name = "label8";
            label8.Size = new Size(92, 20);
            label8.TabIndex = 17;
            label8.Text = "Placa Tracto:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(311, 264);
            label9.Name = "label9";
            label9.Size = new Size(96, 20);
            label9.TabIndex = 19;
            label9.Text = "Placa Carreta";
            label9.Click += this.label9_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(126, 261);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(179, 28);
            comboBox2.TabIndex = 20;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(413, 261);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(179, 28);
            comboBox3.TabIndex = 21;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 450);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(dateTimePicker5);
            Controls.Add(label6);
            Controls.Add(dateTimePicker4);
            Controls.Add(label5);
            Controls.Add(dateTimePicker3);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private MonthCalendar monthCalendar1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private DateTimePicker dateTimePicker3;
        private Label label5;
        private DateTimePicker dateTimePicker4;
        private Label label6;
        private DateTimePicker dateTimePicker5;
        private Label label7;
        private ComboBox comboBox1;
        private Label label8;
        private Label label9;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
    }
}