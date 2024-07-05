using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ORDENDEVIAJE
{
    public partial class Form4 : Form
    {
        public string Ruta1 { get; set; }
        public string Ruta2 { get; set; }
        public string NumeroManifiesto { get; set; }
        public string PlantaDescarga { get; set; }

        private string connectionString = @"Data Source=NICK;Initial Catalog=SGV;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Definir las columnas del DataGridView
            dataGridView1.Columns.Add("numeroGuiaTransportista", "N° Guia Transportista");
            dataGridView1.Columns.Add("numeroGuiaCliente", "N° Guia Cliente");
            dataGridView1.Columns.Add("ruta1", "Ruta 1");
            dataGridView1.Columns.Add("ruta2", "Ruta 2");
            dataGridView1.Columns.Add("numeroManifiesto", "N° Manifiesto");
            dataGridView1.Columns.Add("plantaDescarga", "Planta de Descarga");
            dataGridView1.Columns.Add("descripcionProducto", "Descripcion de Producto");

            // Ajustar el tamaño de las columnas al tamaño del DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void LoadData()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM GuiasTransportista", conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Reasignar los encabezados de columna después de llenar el DataTable
                dataGridView1.Columns["numeroGuiaTransportista"].HeaderText = "N° Guia Transportista";
                dataGridView1.Columns["numeroGuiaCliente"].HeaderText = "N° Guia Cliente";
                dataGridView1.Columns["ruta1"].HeaderText = "Ruta 1";
                dataGridView1.Columns["ruta2"].HeaderText = "Ruta 2";
                dataGridView1.Columns["numeroManifiesto"].HeaderText = "N° Manifiesto";
                dataGridView1.Columns["plantaDescarga"].HeaderText = "Planta de Descarga";
                dataGridView1.Columns["descripcionProducto"].HeaderText = "Descripcion de Producto";

                // Ocultar columnas no deseadas
                dataGridView1.Columns["idGuia"].Visible = false;
                dataGridView1.Columns["idOrdenViaje"].Visible = false;

                // Ajustar el tamaño de las columnas al tamaño del DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadCurrentData(string numeroGuiaTransportista, string numeroGuiaCliente, string ruta1, string ruta2, string numeroManifiesto, string plantaDescarga, string descripcionProducto)
        {

            // Limpiar el DataGridView
            dataGridView1.Rows.Clear();

            // Agregar la nueva fila al DataGridView
            dataGridView1.Rows.Add(
                string.IsNullOrWhiteSpace(numeroGuiaTransportista) ? "-" : numeroGuiaTransportista,
                string.IsNullOrWhiteSpace(numeroGuiaCliente) ? "-" : numeroGuiaCliente,
                string.IsNullOrWhiteSpace(ruta1) ? "-" : ruta1,
                string.IsNullOrWhiteSpace(ruta2) ? "-" : ruta2,
                string.IsNullOrWhiteSpace(numeroManifiesto) ? "-" : numeroManifiesto,
                string.IsNullOrWhiteSpace(plantaDescarga) ? "-" : plantaDescarga,
                descripcionProducto
            );

        }





        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData(); // Cargar los datos cuando el formulario se carga
        }



        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        // Propiedades para recibir los datos de Form3


        /*private void Form4_Load(object sender, EventArgs e)
        {
            // Cambia estos valores según tus necesidades
            string connectionString = "server=NICK;database=SGV;integrated security=true";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }*/

 

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Owner = this; // Asegúrate de establecer el propietario
            form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Recuperar los datos ingresados
            string numeroGuiaTransportista = textBoxGuiaTransportista.Text;
            string numeroGuiaCliente = textBoxGuiaCliente.Text;
            string descripcionProducto = textBoxDescripcionProducto.Text;

            // Verifica que los campos obligatorios no estén vacíos
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

            // Inserción en la base de datos
            string connectionString = "server=NICK;database=SGV;integrated security=true";
            string query = "INSERT INTO GuiasTransportista (numeroGuiaTransportista, numeroGuiaCliente, ruta1, ruta2, numeroManifiesto, plantaDescarga, descripcionProducto) " +
                           "VALUES (@numeroGuiaTransportista, @numeroGuiaCliente, @ruta1, @ruta2, @numeroManifiesto, @plantaDescarga, @descripcionProducto)";

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

                    conexion.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Mostrar solo la nueva fila en el DataGridView
            LoadCurrentData(numeroGuiaTransportista, numeroGuiaCliente, Ruta1, Ruta2, NumeroManifiesto, PlantaDescarga, descripcionProducto);

            // Limpiar los TextBox
            //textBoxGuiaTransportista.Clear();
            //textBoxGuiaCliente.Clear();
            //textBoxDescripcionProducto.Clear();

            // Reiniciar rutas y otros datos
            Ruta1 = string.Empty;
            Ruta2 = string.Empty;
            NumeroManifiesto = string.Empty;
            PlantaDescarga = string.Empty;
        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
