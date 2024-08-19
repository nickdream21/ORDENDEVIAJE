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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();

            // Deshabilitar la opción de maximizar
            this.MaximizeBox = false;

            // Configurar el borde del formulario para que no pueda redimensionarse
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Posicionar el formulario en el centro de la pantalla al aparecer
            this.StartPosition = FormStartPosition.CenterScreen;

            textBox1.TextChanged += ConvertirTextoAMayusculas;
            textBox2.TextChanged += ConvertirTextoAMayusculas;
            textBox3.TextChanged += ConvertirTextoAMayusculas;


        }


        private bool ValidarPlacaTracto(string placa)
        {
            // Asegurarse de que la placa esté en mayúsculas
            placa = placa.ToUpper();

            // Expresión regular para validar el formato de la placa (tres letras, un guion, tres letras)
            Regex regex = new Regex("^[A-Z]{3}-[A-Z]{3}$");

            return regex.IsMatch(placa);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, completa todos los campos antes de registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string placaTracto = textBox1.Text.Trim();

            // Validar formato de la placa
            if (!ValidarPlacaTracto(placaTracto))
            {
                MessageBox.Show("La placa del tracto debe estar en el formato 'AAA-AAA'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Conectar a la base de datos
                using (SqlConnection conexion = new SqlConnection("server=NICK;database=SGV;integrated security=true"))
                {
                    conexion.Open();

                    // Verificar si la placa ya está registrada
                    string queryCheck = "SELECT COUNT(*) FROM Tracto WHERE placaTracto = @placaTracto";
                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, conexion))
                    {
                        commandCheck.Parameters.AddWithValue("@placaTracto", placaTracto);

                        int count = (int)commandCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("La placa del tracto ya está registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar el nuevo tracto si la placa es válida y no está registrada
                    string queryInsert = "INSERT INTO Tracto (placaTracto, modelo, marca) VALUES (@placaTracto, @modelo, @marca)";
                    using (SqlCommand commandInsert = new SqlCommand(queryInsert, conexion))
                    {
                        commandInsert.Parameters.AddWithValue("@placaTracto", placaTracto);
                        commandInsert.Parameters.AddWithValue("@modelo", textBox2.Text.Trim().ToUpper());
                        commandInsert.Parameters.AddWithValue("@marca", textBox3.Text.Trim().ToUpper());

                        commandInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tracto registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de registrar
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el tracto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

    }
}

