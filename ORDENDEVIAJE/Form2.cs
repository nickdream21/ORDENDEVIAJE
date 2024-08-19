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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox; // Añade esto para evitar la ambigüedad

namespace ORDENDEVIAJE
{
    public partial class Form2 : Form
    {
        private string connectionString = "server=NICK;database=SGV;integrated security=true";
        private bool isUpdating = false;
        private DataTable tractosDataTable; // Declarar tractosDataTable aquí
        private DataTable carretasDataTable; // Declarar carretasDataTable aquí
        private DataTable conductoresDataTable; // Declarar conductoresDataTable aquí
        private DataTable clientesDataTable;

        public Form2()
        {
            InitializeComponent();
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker2.ShowUpDown = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            buttonContinuar.Enabled = false;

            LoadClientes();
            LoadConductores();
            LoadTractos();
            LoadCarretas();

            // Desactivar el autocompletado del ComboBox y habilitar la búsqueda manual

            ConfigureComboBox(comboBox1);
            ConfigureComboBox(comboBox2);
            ConfigureComboBox(comboBox3);
            ConfigureComboBox(comboBox4);

        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.AutoCompleteSource = AutoCompleteSource.None;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Cambiar a DropDownList
            comboBox.MaxDropDownItems = 10;
            if (comboBox == comboBox1)
                comboBox.TextUpdate += ComboBox1_TextUpdate;
            else if (comboBox == comboBox2)
                comboBox.TextUpdate += ComboBox2_TextUpdate;
            else if (comboBox == comboBox3)
                comboBox.TextUpdate += ComboBox3_TextUpdate;
            else if (comboBox == comboBox4)
                comboBox.TextUpdate += ComboBox4_TextUpdate;
        }

        private void LoadClientes()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT idCliente, nombre FROM Cliente", conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "idCliente";
            }
        }

        private void LoadConductores()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                // Concatenar los nombres y apellidos directamente en la consulta SQL
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT idConductor, RTRIM(apPaterno) + ' ' + RTRIM(apMaterno) + ' ' + RTRIM(nombre) AS NombreCompleto FROM Conductor", conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                comboBox4.DataSource = dataTable;
                comboBox4.DisplayMember = "NombreCompleto";
                comboBox4.ValueMember = "idConductor";
            }
        }

        private void LoadTractos()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT idTracto, placaTracto FROM Tracto", conexion);
                tractosDataTable = new DataTable(); // Inicializar tractosDataTable
                dataAdapter.Fill(tractosDataTable);
                comboBox2.DataSource = tractosDataTable;
                comboBox2.DisplayMember = "placaTracto";
                comboBox2.ValueMember = "idTracto";
            }
        }

        /*private void ComboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (tractosDataTable == null)
                return;

            ComboBox comboBox = (ComboBox)sender;
            string searchText = comboBox.Text;

            // Filtrar los elementos según el texto ingresado
            var filteredItems = tractosDataTable.AsEnumerable()
                .Where(row => row.Field<string>("placaTracto").StartsWith(searchText, StringComparison.OrdinalIgnoreCase));

            if (filteredItems.Any())
            {
                DataTable filteredDataTable = filteredItems.CopyToDataTable();

                // Desactivar temporalmente el DataSource
                comboBox.DataSource = null;

                // Añadir los elementos filtrados
                comboBox.Items.Clear();
                foreach (DataRow row in filteredDataTable.Rows)
                {
                    comboBox.Items.Add(row["placaTracto"].ToString());
                }

                // Restaurar el texto original
                comboBox.Text = searchText;

                // Establecer la posición del cursor
                comboBox.SelectionStart = searchText.Length;
                comboBox.SelectionLength = 0;

                // Mostrar la lista desplegable si hay elementos filtrados
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                comboBox.DroppedDown = false;
            }
        }*/


        private void ComboBox1_TextUpdate(object sender, EventArgs e)
        {
            FiltrarComboBox(comboBox1, clientesDataTable, "nombre");
        }
        // Método para filtrar y mostrar datos en comboBox2
        private void ComboBox2_TextUpdate(object sender, EventArgs e)
        {
            FiltrarComboBox(comboBox2, tractosDataTable, "placaTracto");
        }

        private void ComboBox3_TextUpdate(object sender, EventArgs e)
        {
            FiltrarComboBox(comboBox3, carretasDataTable, "placaCarreta");
        }

        private void ComboBox4_TextUpdate(object sender, EventArgs e)
        {
            FiltrarComboBox(comboBox4, conductoresDataTable, "NombreCompleto");
        }

        private void FiltrarComboBox(ComboBox comboBox, DataTable dataTable, string columnName)
        {
            if (dataTable == null)
                return;

            string searchText = comboBox.Text;

            var filteredItems = dataTable.AsEnumerable()
                .Where(row => row.Field<string>(columnName).StartsWith(searchText, StringComparison.OrdinalIgnoreCase));

            if (filteredItems.Any())
            {
                DataTable filteredDataTable = filteredItems.CopyToDataTable();
                comboBox.DataSource = null;
                comboBox.Items.Clear();
                foreach (DataRow row in filteredDataTable.Rows)
                {
                    comboBox.Items.Add(row[columnName].ToString());
                }
                comboBox.Text = searchText;
                comboBox.SelectionStart = searchText.Length;
                comboBox.SelectionLength = 0;
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                comboBox.DroppedDown = false;
            }
        }

        private void LoadCarretas()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT idCarreta, placaCarreta FROM Carreta", conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                comboBox3.DataSource = dataTable;
                comboBox3.DisplayMember = "placaCarreta";
                comboBox3.ValueMember = "idCarreta";
            }
        }

        public int OrderId
        {
            get
            {
                int orderId;
                if (int.TryParse(textBox5.Text, out orderId))
                {
                    return orderId;
                }
                else
                {
                    throw new InvalidOperationException("El ID de la orden de viaje no es válido.");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            // Verificar que el campo N° Orden Viaje no esté vacío
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("El campo N° Orden Viaje debe estar lleno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recuperar el número de orden de viaje
            string numeroOrdenViaje = textBox5.Text;

            // Pasar el numeroOrdenViaje al constructor de Form4
            Form4 form4 = new Form4(this, numeroOrdenViaje);
            form4.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            // Verificar que los campos obligatorios no estén vacíos
            StringBuilder mensajeError = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                mensajeError.AppendLine("El campo N° Orden Viaje debe estar lleno.");
            }
            if (comboBox1.SelectedIndex == -1)
            {
                mensajeError.AppendLine("Debe seleccionar un Cliente.");
            }
            if (comboBox2.SelectedIndex == -1)
            {
                mensajeError.AppendLine("Debe seleccionar una Placa de Tracto.");
            }
            if (comboBox3.SelectedIndex == -1)
            {
                mensajeError.AppendLine("Debe seleccionar una Placa de Carreta.");
            }
            if (comboBox4.SelectedIndex == -1)
            {
                mensajeError.AppendLine("Debe seleccionar un Conductor.");
            }

            if (mensajeError.Length > 0)
            {
                MessageBox.Show(mensajeError.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recuperar los datos del formulario
            string numeroOrdenViaje = textBox5.Text;
            string fechaSalida = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string horaSalida = dateTimePicker3.Value.ToString("HH:mm:ss");
            string fechaLlegada = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string horaLlegada = dateTimePicker4.Value.ToString("HH:mm:ss");
            int? cliente = comboBox1.SelectedValue as int?;
            int? placaTracto = comboBox2.SelectedValue as int?;
            int? placaCarreta = comboBox3.SelectedValue as int?;
            int? conductor = comboBox4.SelectedValue as int?;
            string observaciones = textBox4.Text;

            // Guardar los datos en la base de datos
            string query = @"INSERT INTO OrdenViaje (numeroOrdenViaje, fechaSalida, horaSalida, fechaLlegada, horaLlegada, idCliente, idTracto, idCarreta, idConductor, observaciones) 
                     OUTPUT INSERTED.idOrdenViaje 
                     VALUES (@numeroOrdenViaje, @fechaSalida, @horaSalida, @fechaLlegada, @horaLlegada, @idCliente, @idTracto, @idCarreta, @idConductor, @observaciones)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@numeroOrdenViaje", numeroOrdenViaje);
                    command.Parameters.AddWithValue("@fechaSalida", fechaSalida);
                    command.Parameters.AddWithValue("@horaSalida", horaSalida);
                    command.Parameters.AddWithValue("@fechaLlegada", fechaLlegada);
                    command.Parameters.AddWithValue("@horaLlegada", horaLlegada);
                    command.Parameters.AddWithValue("@idCliente", cliente ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@idTracto", placaTracto ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@idCarreta", placaCarreta ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@idConductor", conductor ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@observaciones", observaciones);

                    try
                    {
                        conexion.Open();

                        // Obtener el idOrdenViaje generado
                        int idOrdenViaje = (int)command.ExecuteScalar();

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Datos del viaje guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        buttonContinuar.Enabled = true;

                        // Deshabilitar el botón "Guardar"
                        buttonGuardar.Enabled = false;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Número de error para violación de clave única
                        {
                            MessageBox.Show("El número de orden de viaje ya existe. Por favor, ingrese un número de orden diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
