namespace ORDENDEVIAJE
{
    partial class Form7
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
            dataGridViewIngresos = new DataGridView();
            dataGridViewGastos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGastos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewIngresos
            // 
            dataGridViewIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngresos.Location = new Point(43, 122);
            dataGridViewIngresos.Name = "dataGridViewIngresos";
            dataGridViewIngresos.RowHeadersVisible = false;
            dataGridViewIngresos.RowHeadersWidth = 51;
            dataGridViewIngresos.Size = new Size(863, 142);
            dataGridViewIngresos.TabIndex = 0;
            // 
            // dataGridViewGastos
            // 
            dataGridViewGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGastos.Location = new Point(43, 358);
            dataGridViewGastos.Name = "dataGridViewGastos";
            dataGridViewGastos.RowHeadersWidth = 51;
            dataGridViewGastos.Size = new Size(863, 188);
            dataGridViewGastos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(317, 2);
            label1.Name = "label1";
            label1.Size = new Size(208, 38);
            label1.TabIndex = 2;
            label1.Text = "LIQUIDACIÓN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 80);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Ingresos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 325);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 4;
            label3.Text = "Gastos:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(43, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(863, 40);
            panel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(912, 517);
            button1.Name = "button1";
            button1.Size = new Size(42, 29);
            button1.TabIndex = 6;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 682);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewGastos);
            Controls.Add(dataGridViewIngresos);
            Name = "Form7";
            Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGastos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewIngresos;
        private DataGridView dataGridViewGastos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Button button1;
    }
}