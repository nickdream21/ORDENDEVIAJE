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
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            form2 = form2Instance;
            NumeroOrdenViaje = numeroOrdenViaje;
            InitializeDataGridView2();
            InitializeDataGridView();
            LoadData();


            // Inicializar el botón Siguiente como deshabilitado
            buttonSiguiente.Enabled = false;
        }
        private void InitializeDataGridView2()
        {
            // Limpiar columnas previas
            dataGridView2.Columns.Clear();

            // Desactivar la opción de agregar filas automáticamente
            dataGridView2.AllowUserToAddRows = false;

            // Quitar encabezado de fila (columna en blanco a la izquierda)
            dataGridView2.RowHeadersVisible = false;

            // Cambiar la fuente para hacer el texto más pequeño
            dataGridView2.Font = new Font("Segoe UI", 9); // Ajusta el tamaño de fuente

            // Centrando el texto en todas las celdas
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Definir la columna "Producto" como un ComboBoxColumn
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.Name = "Producto";
            comboBoxColumn.HeaderText = "Producto";
            comboBoxColumn.DataSource = GetProductList(); // Llamada al método para obtener los productos
            comboBoxColumn.DisplayMember = "nombre"; // Nombre del producto a mostrar
            comboBoxColumn.ValueMember = "nombre"; // Valor que representa el producto
            dataGridView2.Columns.Add(comboBoxColumn);

            // Definir la columna de bolsas
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bolsas", HeaderText = "Cantidad de Bolsas" });

            // Crear las columnas para los botones de añadir y eliminar
            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            btnAdd.HeaderText = "Añadir";
            btnAdd.Name = "btnAñadir";
            btnAdd.Text = "Añadir";
            btnAdd.UseColumnTextForButtonValue = true;  // Asegurarse de que el texto se muestre en los botones

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Eliminar";
            btnDelete.Name = "btnEliminar";
            btnDelete.Text = "Eliminar";
            btnDelete.UseColumnTextForButtonValue = true;  // Asegurarse de que el texto se muestre en los botones

            // Añadir las columnas de botones al DataGridView2
            dataGridView2.Columns.Add(btnAdd);
            dataGridView2.Columns.Add(btnDelete);

            // Ajustar el tamaño de las columnas al tamaño de la tabla
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Centrando el texto en los encabezados de las columnas
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Añadir una fila vacía para que se pueda escribir directamente
            dataGridView2.Rows.Add();

            // Manejar el evento de clic en las celdas del DataGridView
            dataGridView2.CellClick += DataGridView2_CellClick;
        }

        // Método para obtener la lista de productos desde la base de datos
        private DataTable GetProductList()
        {
            DataTable dt = new DataTable();

            // Suponiendo que tienes la conexión a la base de datos lista
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre FROM Producto";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }

            return dt;
        }
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no se está clicando en el encabezado
            {
                // Verifica si el clic fue en la columna "Añadir"
                if (e.ColumnIndex == dataGridView2.Columns["btnAñadir"].Index)
                {
                    // Añadir una nueva fila vacía debajo de la fila actual
                    dataGridView2.Rows.Insert(e.RowIndex + 1, "", ""); // Añade una fila vacía

                    // Opción: Puedes mostrar un mensaje si deseas
                    //MessageBox.Show("Nueva fila añadida.");
                }
                // Verifica si el clic fue en la columna "Eliminar"
                else if (e.ColumnIndex == dataGridView2.Columns["btnEliminar"].Index)
                {
                    // Verificar si hay más de una fila antes de eliminar
                    if (dataGridView2.Rows.Count > 1)
                    {
                        dataGridView2.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("No puedes eliminar la última fila.");
                    }
                }
            }
        }
        private void AddNewProduct(string producto, int bolsas)
        {
            // Añadir una nueva fila al DataGridView con los datos del producto y la cantidad de bolsas
            dataGridView2.Rows.Add(producto, bolsas);
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
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "productosTransportados", HeaderText = "Productos Transportados" }); // Nueva columna para los productos

            // Configurar el DataGridView para que sea de solo lectura y no permita redimensión
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
            dataGridView1.RowHeadersVisible = false; // Ocultar el encabezado de filas

            // Ajustar el tamaño de las columnas al tamaño de la tabla
            dataGridView1.Font = new Font("Segoe UI", 9); // Ajusta el tamaño de fuente
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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

                // Consulta para obtener los datos principales de la guía, uniendo con la tabla Manifiesto
                string query = @"
            SELECT gt.idGuia, gt.numeroGuiaTransportista, gt.numeroGuiaCliente, gt.ruta1, gt.ruta2, m.numeroManifiesto, gt.plantaDescarga 
            FROM GuiasTransportista gt
            LEFT JOIN Manifiesto m ON gt.numeroManifiesto = m.idManifiesto
            WHERE gt.numeroOrdenViaje = @numeroOrdenViaje";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@numeroOrdenViaje", NumeroOrdenViaje);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.Rows.Clear();

                // Para cada guía, obtenemos los productos transportados
                foreach (DataRow row in dataTable.Rows)
                {
                    int idGuia = Convert.ToInt32(row["idGuia"]);
                    string productosTransportados = ObtenerProductosTransportados(idGuia, conexion);

                    dataGridView1.Rows.Add(
                        row["numeroGuiaTransportista"],
                        row["numeroGuiaCliente"],
                        row["ruta1"],
                        row["ruta2"],
                        row["numeroManifiesto"],  // Mostrar el número de manifiesto en lugar del idManifiesto
                        row["plantaDescarga"],
                        productosTransportados  // Productos concatenados
                    );
                }
            }
        }




        // Método para obtener y concatenar los productos transportados para una guía en particular
        private string ObtenerProductosTransportados(int idGuia, SqlConnection conexion)
        {
            // Consulta para obtener los productos y las cantidades de bolsas asociadas con esta guía
            string queryProductos = @"
        SELECT p.nombre, d.cantidadBolsas 
        FROM DetalleOrdenViaje d
        JOIN Producto p ON d.idProducto = p.idProducto
        WHERE d.idGuia = @idGuia";

            using (SqlCommand cmd = new SqlCommand(queryProductos, conexion))
            {
                cmd.Parameters.AddWithValue("@idGuia", idGuia);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> productos = new List<string>();

                    while (reader.Read())
                    {
                        string producto = reader["nombre"].ToString();
                        int bolsas = Convert.ToInt32(reader["cantidadBolsas"]);
                        productos.Add($"{producto} ({bolsas} bolsas)");
                    }

                    // Concatenar todos los productos en un solo string, separados por comas
                    return string.Join(", ", productos);
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
            if (string.IsNullOrWhiteSpace(Ruta1))
            {
                MessageBox.Show("Tiene que elegir una Ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Paso 1: Guardar el manifiesto en la tabla Manifiesto si el campo NumeroManifiesto no está vacío
                int idManifiesto = 0;
                if (!string.IsNullOrWhiteSpace(NumeroManifiesto))
                {
                    string queryManifiesto = "INSERT INTO Manifiesto (numeroManifiesto) VALUES (@numeroManifiesto); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand commandManifiesto = new SqlCommand(queryManifiesto, conexion))
                    {
                        commandManifiesto.Parameters.AddWithValue("@numeroManifiesto", NumeroManifiesto);
                        idManifiesto = Convert.ToInt32(commandManifiesto.ExecuteScalar());
                    }
                }

                // Paso 2: Guardar los datos en la tabla GuiasTransportista, usando el idManifiesto
                string queryOrdenViaje = "INSERT INTO GuiasTransportista (numeroGuiaTransportista, numeroGuiaCliente, ruta1, ruta2, numeroManifiesto, plantaDescarga, numeroOrdenViaje) " +
                                         "VALUES (@numeroGuiaTransportista, @numeroGuiaCliente, @ruta1, @ruta2, @numeroManifiesto, @plantaDescarga, @numeroOrdenViaje); " +
                                         "SELECT SCOPE_IDENTITY();";  // Obtener el ID de la orden recién insertada

                using (SqlCommand command = new SqlCommand(queryOrdenViaje, conexion))
                {
                    command.Parameters.AddWithValue("@numeroGuiaTransportista", numeroGuiaTransportista);
                    command.Parameters.AddWithValue("@numeroGuiaCliente", numeroGuiaCliente);
                    command.Parameters.AddWithValue("@ruta1", Ruta1);
                    command.Parameters.AddWithValue("@ruta2", string.IsNullOrEmpty(Ruta2) ? (object)DBNull.Value : Ruta2);
                    command.Parameters.AddWithValue("@numeroManifiesto", idManifiesto > 0 ? (object)idManifiesto : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@plantaDescarga", string.IsNullOrEmpty(PlantaDescarga) ? (object)DBNull.Value : PlantaDescarga);
                    command.Parameters.AddWithValue("@numeroOrdenViaje", NumeroOrdenViaje);

                    // Ejecutar el comando y obtener el ID de la nueva guía
                    int idGuia = Convert.ToInt32(command.ExecuteScalar());

                    // Verificar si se obtuvo el idGuia
                    if (idGuia > 0)
                    {
                        // Guardar los productos y bolsas en la tabla DetalleOrdenViaje
                        GuardarProductos(idGuia, conexion);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la guía de transporte.");
                        return;
                    }
                }
            }

            // Recargar los datos después de la inserción
            LoadData();
            buttonGuardar.Enabled = false;
            buttonSiguiente.Enabled = true;
        }





        // Método para guardar los productos en la tabla DetalleOrdenViaje
        private void GuardarProductos(int idGuia, SqlConnection conexion)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Producto"].Value != null && row.Cells["Bolsas"].Value != null)
                {
                    int idProducto = ObtenerIdProducto(row.Cells["Producto"].Value.ToString(), conexion);
                    int cantidadBolsas = Convert.ToInt32(row.Cells["Bolsas"].Value);

                    // Verificar si idProducto es válido
                    if (idProducto == 0)
                    {
                        MessageBox.Show("Error: No se pudo obtener el ID del producto.");
                        return;
                    }

                    string queryDetalle = "INSERT INTO DetalleOrdenViaje (idGuia, idProducto, cantidadBolsas) " +
                                          "VALUES (@idGuia, @idProducto, @cantidadBolsas)";

                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion))
                    {
                        cmdDetalle.Parameters.AddWithValue("@idGuia", idGuia);
                        cmdDetalle.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidadBolsas", cantidadBolsas);

                        int result = cmdDetalle.ExecuteNonQuery();
                        if (result <= 0)
                        {
                            MessageBox.Show("Error al insertar el producto en la base de datos.");
                        }
                    }
                }
            }
        }
        // Método para obtener el idProducto a partir del nombre del producto
        private int ObtenerIdProducto(string nombreProducto, SqlConnection conexion)
        {
            string queryProducto = "SELECT idProducto FROM Producto WHERE nombre = @nombreProducto";
            using (SqlCommand cmdProducto = new SqlCommand(queryProducto, conexion))
            {
                cmdProducto.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                return Convert.ToInt32(cmdProducto.ExecuteScalar());
            }
        }



        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(form2);
            form7.Show();
            this.Close();
        }
    }
}
