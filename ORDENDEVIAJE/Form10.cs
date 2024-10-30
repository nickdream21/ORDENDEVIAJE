using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            // Deshabilitar la opción de maximizar
            this.MaximizeBox = false;

            // Configurar el borde del formulario para que no pueda redimensionarse
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Posicionar el formulario en el centro de la pantalla al aparecer
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            // Agregar evento para convertir texto a mayúsculas
            textBox1.TextChanged += ConvertirTextoAMayusculas;
            textBox2.TextChanged += ConvertirTextoAMayusculas;
            textBox3.TextChanged += ConvertirTextoAMayusculas;
        }


        private void ConvertirTextoAMayusculas(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int cursorPosition = textBox.SelectionStart;
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = cursorPosition;
            }
        }

        private bool ValidarPlacaCarreta(string placa)
        {
            // Asegurarse de que la placa esté en mayúsculas
            placa = placa.ToUpper();

            // Expresión regular para validar el formato de la placa (tres letras, un guion, tres letras)
            Regex regex = new Regex("^[A-Z]{3}-[A-Z]{3}$");

            return regex.IsMatch(placa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener valores de los TextBox
            string placaCarreta = textBox1.Text.Trim();
            string modelo = textBox2.Text.Trim();
            string marca = textBox3.Text.Trim();

            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(placaCarreta))
            {
                MessageBox.Show("El campo 'N° Placa' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MessageBox.Show("El campo 'Modelo' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("El campo 'Marca' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar formato de la placa
            if (!ValidarPlacaCarreta(placaCarreta))
            {
                MessageBox.Show("La placa de la carreta debe estar en el formato 'AAA-AAA'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Conectar a la base de datos
                using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
                {
                    conexion.Open();

                    // Verificar si la placa ya está registrada
                    string queryCheck = "SELECT COUNT(*) FROM Carreta WHERE placaCarreta = @placaCarreta";
                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, conexion))
                    {
                        commandCheck.Parameters.AddWithValue("@placaCarreta", placaCarreta);

                        int count = (int)commandCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("La placa de la carreta ya está registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar la nueva carreta si la placa es válida y no está registrada
                    string queryInsert = "INSERT INTO Carreta (placaCarreta, modelo, marca) VALUES (@placaCarreta, @modelo, @marca)";
                    using (SqlCommand commandInsert = new SqlCommand(queryInsert, conexion))
                    {
                        commandInsert.Parameters.AddWithValue("@placaCarreta", placaCarreta);
                        commandInsert.Parameters.AddWithValue("@modelo", modelo);
                        commandInsert.Parameters.AddWithValue("@marca", marca);

                        commandInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Carreta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de registrar
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la carreta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }    
}

