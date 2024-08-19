using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            // Deshabilitar la opción de maximizar
            this.MaximizeBox = false;

            // Configurar el borde del formulario para que no pueda redimensionarse
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Posicionar el formulario en el centro de la pantalla al aparecer
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroOrdenViaje = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numeroOrdenViaje))
            {
                MessageBox.Show("Por favor, ingrese un número de orden de viaje.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("server=NICK;database=SGV;integrated security=true"))
                {
                    conexion.Open();

                    // Consulta para verificar si la orden de viaje existe
                    string query = "SELECT COUNT(*) FROM OrdenViaje WHERE numeroOrdenViaje = @numeroOrdenViaje";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@numeroOrdenViaje", numeroOrdenViaje);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // La orden existe, abrir el nuevo formulario
                            Form12 form12 = new Form12(numeroOrdenViaje);
                            form12.Show();
                        }
                        else
                        {
                            // La orden no existe, mostrar mensaje
                            MessageBox.Show("La orden de viaje no existe o no está registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la orden de viaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

