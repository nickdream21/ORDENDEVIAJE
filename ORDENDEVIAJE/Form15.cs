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
    public partial class Form15 : Form
    {
        private string connectionString = @"Data Source=NICK;Initial Catalog=OrdenViajeSGV;Integrated Security=True";
        public Form15()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar el formulario en la pantalla
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Fijar el tamaño del formulario
            this.MaximizeBox = false; // Desactivar el botón de maximizar
            txtNumeroFactura.TextChanged += TxtNumeroFactura_TextChanged; // Evento para validar y formatear el número de factura

        }

        private void TxtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto a mayúsculas y eliminar espacios adicionales en los extremos
            string text = txtNumeroFactura.Text.Trim().ToUpper();

            // Usar expresión regular para capturar las partes necesarias y formatear correctamente
            string pattern = @"^(F\d{3})\s*-\s*(\d{8})$";
            Match match = Regex.Match(text, pattern);

            if (match.Success)
            {
                // Formatear con espacios correctos
                string formattedText = $"{match.Groups[1].Value} - {match.Groups[2].Value}";
                txtNumeroFactura.TextChanged -= TxtNumeroFactura_TextChanged; // Desactivar temporalmente el evento para evitar loops
                txtNumeroFactura.Text = formattedText;
                txtNumeroFactura.SelectionStart = txtNumeroFactura.Text.Length; // Mantener el cursor al final
                txtNumeroFactura.TextChanged += TxtNumeroFactura_TextChanged; // Reasignar el evento
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos()) // Validar los campos antes de guardar
            {
                if (FacturaExiste(txtNumeroFactura.Text))
                {
                    MessageBox.Show("El número de factura ya existe en la base de datos. Por favor, ingresa un número diferente.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GuardarFactura(); // Llamar al método para guardar la factura
                }
            }
        }
        // Método para verificar si la factura ya existe en la base de datos
        private bool FacturaExiste(string numeroFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Factura WHERE numeroFactura = @numeroFactura";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Método para validar que los campos del formulario estén correctos
        private bool ValidarCampos()
        {
            // Patrón correcto del formato 'F### - ########'
            string pattern = @"^F\d{3} - \d{8}$";
            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text) || !Regex.IsMatch(txtNumeroFactura.Text.Trim(), pattern))
            {
                MessageBox.Show("El número de factura debe tener el formato 'F### - ########' (por ejemplo, 'F222 - 00004266').",
                                "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que el valor total sea un número válido
            if (!decimal.TryParse(txtImporteTotal.Text, out decimal valorTotal))
            {
                MessageBox.Show("El importe total debe ser un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que la fecha de emisión no sea una fecha futura
            if (dtpFechaEmision.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de emisión no puede ser una fecha futura.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Si todas las validaciones son correctas
            return true;
        }


        // Método para guardar la factura en la base de datos
        // Método para guardar la factura en la base de datos
        private void GuardarFactura()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Consulta para insertar la factura en la base de datos
                    string query = "INSERT INTO Factura (numeroFactura, valorTotal, fechaEmision) VALUES (@numeroFactura, @valorTotal, @fechaEmision)";

                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@numeroFactura", txtNumeroFactura.Text);
                        command.Parameters.AddWithValue("@valorTotal", decimal.Parse(txtImporteTotal.Text));
                        command.Parameters.AddWithValue("@fechaEmision", dtpFechaEmision.Value);

                        command.ExecuteNonQuery();
                    }

                    // Confirmar la transacción si todo salió bien
                    transaction.Commit();
                    MessageBox.Show("Factura guardada exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close(); // Cerrar el formulario después de guardar
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, deshacer la transacción
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
