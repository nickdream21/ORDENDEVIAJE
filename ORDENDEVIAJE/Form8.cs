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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            // Deshabilitar la opción de maximizar
            this.MaximizeBox = false;

            // Configurar el borde del formulario para que no pueda redimensionarse
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Posicionar el formulario en el centro de la pantalla al aparecer
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // Asignar el evento TextChanged para convertir a mayúsculas
            textBox1.TextChanged += ConvertirTextoAMayusculas;
            textBox2.TextChanged += ConvertirTextoAMayusculas;
            textBox3.TextChanged += ConvertirTextoAMayusculas;
            textBox4.TextChanged += ConvertirTextoAMayusculas;
            textBox5.TextChanged += ConvertirTextoAMayusculas;
            textBox6.TextChanged += ConvertirTextoAMayusculas;
            textBox7.TextChanged += ConvertirTextoAMayusculas;
            textBox8.TextChanged += ConvertirTextoAMayusculas;


            // Configura el ComboBox para que no permita escritura
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // Puedes inicializar el ComboBox con un valor por defecto si es necesario
            comboBox1.SelectedIndex = 0; // Ninguna opción seleccionada inicialmente
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "DNI")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox2.Text = string.Empty;
            }
            else if (comboBox1.SelectedItem.ToString() == "Carnet Extranjería")
            {
                textBox1.Enabled = false;
                textBox1.Text = string.Empty;
                textBox2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tipoDocumento = comboBox1.SelectedItem.ToString();
            string dni = textBox1.Text.Trim();
            string carnetExtranjeria = textBox2.Text.Trim();
            string nombre = textBox3.Text.Trim().ToUpper();
            string apPaterno = textBox4.Text.Trim().ToUpper();
            string apMaterno = textBox5.Text.Trim().ToUpper();
            string telefono = textBox6.Text.Trim();
            string direccion = textBox7.Text.Trim().ToUpper();
            string correo = textBox8.Text.Trim().ToUpper();
            DateTime fechaNacimiento = dateTimePicker1.Value.Date;  // Agregar fecha de nacimiento

            if ((tipoDocumento == "DNI" && string.IsNullOrWhiteSpace(dni)) ||
                (tipoDocumento == "Carnet Extranjería" && string.IsNullOrWhiteSpace(carnetExtranjeria)))
            {
                MessageBox.Show("Debe ingresar un DNI o Carnet de Extranjería válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("server=NICK;database=SGV;integrated security=true"))
                {
                    conexion.Open();

                    // Verificar que no haya duplicados
                    string queryCheck = "SELECT COUNT(*) FROM Conductor WHERE (DNI = @DNI AND @DNI IS NOT NULL) OR (carnetExtranjeria = @CarnetExtranjeria AND @CarnetExtranjeria IS NOT NULL)";
                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, conexion))
                    {
                        commandCheck.Parameters.AddWithValue("@DNI", string.IsNullOrWhiteSpace(dni) ? (object)DBNull.Value : dni);
                        commandCheck.Parameters.AddWithValue("@CarnetExtranjeria", string.IsNullOrWhiteSpace(carnetExtranjeria) ? (object)DBNull.Value : carnetExtranjeria);

                        int count = (int)commandCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("El DNI o Carnet de Extranjería ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar el nuevo conductor
                    string query = "INSERT INTO Conductor (DNI, nombre, apPaterno, apMaterno, fechaNacimiento, direccion, telefono, correo, carnetExtranjeria) " +
                                   "VALUES (@DNI, @Nombre, @ApPaterno, @ApMaterno, @FechaNacimiento, @Direccion, @Telefono, @Correo, @CarnetExtranjeria)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@DNI", string.IsNullOrWhiteSpace(dni) ? (object)DBNull.Value : dni);
                        command.Parameters.AddWithValue("@CarnetExtranjeria", string.IsNullOrWhiteSpace(carnetExtranjeria) ? (object)DBNull.Value : carnetExtranjeria);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@ApPaterno", apPaterno);
                        command.Parameters.AddWithValue("@ApMaterno", apMaterno);
                        command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);  // Agregar fecha de nacimiento
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Correo", correo);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Conductor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Limpiar los TextBox y resetear el ComboBox después del registro exitoso
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();

                // Reiniciar el ComboBox a la opción por defecto
                comboBox1.SelectedIndex = 0;

                // Reiniciar el DateTimePicker a la fecha de hoy
                dateTimePicker1.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el conductor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
