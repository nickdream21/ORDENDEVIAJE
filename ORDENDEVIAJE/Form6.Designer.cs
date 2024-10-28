namespace ORDENDEVIAJE
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxNumManifiesto = new TextBox();
            comboBoxPlantaDescarga = new ComboBox();
            buttonGuardar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // textBoxNumManifiesto
            // 
            textBoxNumManifiesto.Location = new Point(279, 108);
            textBoxNumManifiesto.Name = "textBoxNumManifiesto";
            textBoxNumManifiesto.Size = new Size(100, 27);
            textBoxNumManifiesto.TabIndex = 0;
            // 
            // comboBoxPlantaDescarga
            // 
            comboBoxPlantaDescarga.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlantaDescarga.FormattingEnabled = true;
            comboBoxPlantaDescarga.Items.AddRange(new object[] { "Planta 1", "Planta 2", "Planta 3" });
            comboBoxPlantaDescarga.Location = new Point(150, 70);
            comboBoxPlantaDescarga.Name = "comboBoxPlantaDescarga";
            comboBoxPlantaDescarga.Size = new Size(100, 28);
            comboBoxPlantaDescarga.TabIndex = 1;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(113, 236);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 2;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(304, 259);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 23);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // Form6
            // 
            ClientSize = new Size(541, 378);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonGuardar);
            Controls.Add(comboBoxPlantaDescarga);
            Controls.Add(textBoxNumManifiesto);
            Name = "Form6";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxNumManifiesto;
        private System.Windows.Forms.ComboBox comboBoxPlantaDescarga;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}
