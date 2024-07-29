using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form4 : Form
    {
        public string Ruta1 { get; set; }
        public string Ruta2 { get; set; }
        public string NumeroManifiesto { get; set; }
        public string PlantaDescarga { get; set; }
        public string NumeroOrdenViaje { get; set; }

        private string connectionString = @"Data Source=NICK;Initial Catalog=SGV;Integrated Security=True";
        private Form2 form2;

        public Form4(Form2 form2Instance, string numeroOrdenViaje)
        {
            InitializeComponent();
            form2 = form2Instance;
            NumeroOrdenViaje = numeroOrdenViaje;

            InitializeDataGridView();
            LoadData();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            // Definir las columnas del DataGridView manualmente
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "numeroGuiaTransportista", HeaderText = "N° Guia Transportista" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "numeroGuiaCliente", HeaderText = "N° Guia Cliente" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ruta1", HeaderText = "Ruta 1" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ruta2", HeaderText = "Ruta 2" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "numeroManifiesto", HeaderText = "N° Manifiesto" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "plantaDescarga", HeaderText = "Planta de Descarga" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "descripcionProducto", HeaderText = "Descripcion de Producto" });

            // Configurar el DataGridView para que sea de solo lectura y no permita redimensión
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
            dataGridView1.RowHeadersVisible = false; // Ocultar el encabezado de filas

            // Ajustar el tamaño de las columnas al tamaño de la tabla
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Añadir el evento KeyDown para interceptar la tecla Enter
            dataGridView1.KeyDown += dataGridView1_KeyDown;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Cancela el evento de tecla para evitar la creación de nuevas filas
            }
        }
        private void DataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
        private void LoadData()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT numeroGuiaTransportista, numeroGuiaCliente, ruta1, ruta2, numeroManifiesto, plantaDescarga, descripcionProducto FROM GuiasTransportista WHERE numeroOrdenViaje = @numeroOrdenViaje", conexion);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@numeroOrdenViaje", NumeroOrdenViaje);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Asignar manualmente los valores de las columnas del DataTable a las columnas del DataGridView
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["numeroGuiaTransportista"],
                        row["numeroGuiaCliente"],
                        row["ruta1"],
                        row["ruta2"],
                        row["numeroManifiesto"],
                        row["plantaDescarga"],
                        row["descripcionProducto"]
                    );
                }
            }
        }

        private void buttonElegir_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Owner = this;
            form3.ShowDialog();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string numeroGuiaTransportista = textBoxGuiaTransportista.Text;
            string numeroGuiaCliente = textBoxGuiaCliente.Text;
            string descripcionProducto = textBoxDescripcionProducto.Text;

            if (string.IsNullOrWhiteSpace(numeroGuiaTransportista))
            {
                MessageBox.Show("El campo N° Guia Transportista debe estar lleno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(numeroGuiaCliente))
            {
                MessageBox.Show("El campo N° Guia Cliente debe estar lleno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(descripcionProducto))
            {
                MessageBox.Show("El campo Descripcion de Producto debe estar lleno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Ruta1))
            {
                MessageBox.Show("Tiene que elegir una Ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO GuiasTransportista (numeroGuiaTransportista, numeroGuiaCliente, ruta1, ruta2, numeroManifiesto, plantaDescarga, descripcionProducto, numeroOrdenViaje) " +
                           "VALUES (@numeroGuiaTransportista, @numeroGuiaCliente, @ruta1, @ruta2, @numeroManifiesto, @plantaDescarga, @descripcionProducto, @numeroOrdenViaje)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@numeroGuiaTransportista", numeroGuiaTransportista);
                    command.Parameters.AddWithValue("@numeroGuiaCliente", numeroGuiaCliente);
                    command.Parameters.AddWithValue("@ruta1", Ruta1);
                    command.Parameters.AddWithValue("@ruta2", string.IsNullOrEmpty(Ruta2) ? (object)DBNull.Value : Ruta2);
                    command.Parameters.AddWithValue("@numeroManifiesto", string.IsNullOrEmpty(NumeroManifiesto) ? (object)DBNull.Value : NumeroManifiesto);
                    command.Parameters.AddWithValue("@plantaDescarga", string.IsNullOrEmpty(PlantaDescarga) ? (object)DBNull.Value : PlantaDescarga);
                    command.Parameters.AddWithValue("@descripcionProducto", descripcionProducto);
                    command.Parameters.AddWithValue("@numeroOrdenViaje", NumeroOrdenViaje);

                    conexion.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Recargar los datos después de la inserción
            LoadData();
            buttonGuardar.Enabled = false;
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(form2);
            form7.ShowDialog();
            this.Close();
        }
    }
}
