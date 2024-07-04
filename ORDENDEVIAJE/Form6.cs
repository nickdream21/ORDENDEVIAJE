using System;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form6 : Form
    {
        public string NumeroManifiesto { get; private set; }
        public string PlantaDescarga { get; private set; }

        public Form6()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //NumeroManifiesto = textBox1.Text;
            //PlantaDescarga = comboBox1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
