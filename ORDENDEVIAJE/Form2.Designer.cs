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
            label7 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            comboBox2 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label12 = new Label();
            textBox4 = new TextBox();
            buttonGuardar = new Button();
            buttonContinuar = new Button();
            comboBox4 = new ComboBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            comboBox3 = new ComboBox();
            label16 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "N° Pedido:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(235, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 112);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "N° CPI:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(127, 109);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 198);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha de Salida:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(169, 193);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(123, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 198);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 7;
            label4.Text = "Hora de Salida:";
            label4.Click += label4_Click;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Location = new Point(508, 198);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(84, 27);
            dateTimePicker3.TabIndex = 9;
            dateTimePicker3.ValueChanged += dateTimePicker3_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 238);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 10;
            label5.Text = "Fecha de Llegada:";
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Format = DateTimePickerFormat.Short;
            dateTimePicker4.Location = new Point(169, 233);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(123, 27);
            dateTimePicker4.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(368, 238);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 12;
            label6.Text = "Hora de Llegada:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 276);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 14;
            label7.Text = "Cliente:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "VITAPRO" });
            comboBox1.Location = new Point(169, 273);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 28);
            comboBox1.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 315);
            label8.Name = "label8";
            label8.Size = new Size(92, 20);
            label8.TabIndex = 17;
            label8.Text = "Placa Tracto:";
            // 
            // label9
            // 
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 22;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(169, 312);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(171, 28);
            comboBox2.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(368, 315);
            label10.Name = "label10";
            label10.Size = new Size(99, 20);
            label10.TabIndex = 23;
            label10.Text = "Placa Carreta:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(28, 367);
            label11.Name = "label11";
            label11.Size = new Size(81, 20);
            label11.TabIndex = 24;
            label11.Text = "Conductor:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(508, 238);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(84, 27);
            dateTimePicker2.TabIndex = 27;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(28, 404);
            label12.Name = "label12";
            label12.Size = new Size(108, 20);
            label12.TabIndex = 28;
            label12.Text = "Observaciones:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(28, 441);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(743, 54);
            textBox4.TabIndex = 29;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(577, 516);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(94, 29);
            buttonGuardar.TabIndex = 30;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonContinuar
            // 
            buttonContinuar.Location = new Point(677, 516);
            buttonContinuar.Name = "buttonContinuar";
            buttonContinuar.Size = new Size(94, 29);
            buttonContinuar.TabIndex = 31;
            buttonContinuar.Text = "Continuar";
            buttonContinuar.UseVisualStyleBackColor = true;
            buttonContinuar.Click += buttonContinuar_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(169, 364);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(171, 28);
            comboBox4.TabIndex = 32;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Trebuchet MS", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(301, 9);
            label13.Name = "label13";
            label13.Size = new Size(214, 32);
            label13.TabIndex = 33;
            label13.Text = "DATOS DEL VIAJE";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(368, 72);
            label14.Name = "label14";
            label14.Size = new Size(80, 20);
            label14.TabIndex = 34;
            label14.Text = "N° Factura:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(368, 112);
            label15.Name = "label15";
            label15.Size = new Size(111, 20);
            label15.TabIndex = 35;
            label15.Text = "N° Orden Viaje:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(508, 68);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 27);
            textBox3.TabIndex = 36;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(508, 109);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(225, 27);
            textBox5.TabIndex = 37;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(508, 312);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(171, 28);
            comboBox3.TabIndex = 38;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(28, 75);
            label16.Name = "label16";
            label16.Size = new Size(79, 20);
            label16.TabIndex = 39;
            label16.Text = "N° Pedido:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 559);
            Controls.Add(label16);
            Controls.Add(comboBox3);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(comboBox4);
            Controls.Add(buttonContinuar);
            Controls.Add(buttonGuardar);
            Controls.Add(textBox4);
            Controls.Add(label12);
            Controls.Add(dateTimePicker2);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(label7);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
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
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox textBox4;
        private Button buttonGuardar;
        private Button buttonContinuar;
        private ComboBox comboBox4;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox textBox3;
        public TextBox textBox5;
        private ComboBox comboBox3;
        private Label label16;
    }
}