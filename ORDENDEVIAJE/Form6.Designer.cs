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
            this.textBoxNumManifiesto = new System.Windows.Forms.TextBox();
            this.comboBoxPlantaDescarga = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNumManifiesto
            // 
            this.textBoxNumManifiesto.Location = new System.Drawing.Point(150, 30);
            this.textBoxNumManifiesto.Name = "textBoxNumManifiesto";
            this.textBoxNumManifiesto.Size = new System.Drawing.Size(100, 22);
            this.textBoxNumManifiesto.TabIndex = 0;
            // 
            // comboBoxPlantaDescarga
            // 
            this.comboBoxPlantaDescarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlantaDescarga.FormattingEnabled = true;
            this.comboBoxPlantaDescarga.Items.AddRange(new object[] {
            "Planta 1",
            "Planta 2",
            "Planta 3"});
            this.comboBoxPlantaDescarga.Location = new System.Drawing.Point(150, 70);
            this.comboBoxPlantaDescarga.Name = "comboBoxPlantaDescarga";
            this.comboBoxPlantaDescarga.Size = new System.Drawing.Size(100, 24);
            this.comboBoxPlantaDescarga.TabIndex = 1;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(50, 120);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 2;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(175, 120);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(300, 180);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.comboBoxPlantaDescarga);
            this.Controls.Add(this.textBoxNumManifiesto);
            this.Name = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxNumManifiesto;
        private System.Windows.Forms.ComboBox comboBoxPlantaDescarga;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}
