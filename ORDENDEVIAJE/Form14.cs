using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form14 : Form
    {
        private string connectionString = @"Data Source=NICK;Initial Catalog=SGV;Integrated Security=True";

        public Form14()
        {
            InitializeComponent();
            InitializeDataGridView1();
            // Asegura que el formulario se centre en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            // Conectar el evento CellValueChanged al método
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            // Conectar el evento TextChanged de txtNumeroFactura al método
            txtNumeroFactura.TextChanged += TxtNumeroFactura_TextChanged;
        }

        private void InitializeDataGridView1()
        {
            // Limpiar columnas previas
            dataGridView1.Columns.Clear();

            // Desactivar la opción de agregar filas automáticamente
            dataGridView1.AllowUserToAddRows = false;

            // Quitar encabezado de fila (columna en blanco a la izquierda)
            dataGridView1.RowHeadersVisible = false;

            // Cambiar la fuente para hacer el texto más pequeño
            dataGridView1.Font = new Font("Segoe UI", 9); // Ajusta el tamaño de fuente

            // Centrando el texto en todas las celdas
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Definir la columna "Producto" como un ComboBoxColumn
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.Name = "Producto";
            comboBoxColumn.HeaderText = "Producto";
            comboBoxColumn.DataSource = GetProductList(); // Llamada al método para obtener los productos
            comboBoxColumn.DisplayMember = "nombre"; // Nombre del producto a mostrar
            comboBoxColumn.ValueMember = "nombre"; // Valor que representa el producto
            dataGridView1.Columns.Add(comboBoxColumn);

            // Definir la columna de bolsas
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bolsas", HeaderText = "Cantidad de Bolsas" });

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

            // Añadir las columnas de botones al DataGridView1
            dataGridView1.Columns.Add(btnAdd);
            dataGridView1.Columns.Add(btnDelete);

            // Centrando el texto en los encabezados de las columnas
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar el color de fondo del DataGridView para que coincida con el formulario
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.DefaultCellStyle.BackColor = this.BackColor;

            // Añadir una fila vacía para que se pueda escribir directamente
            dataGridView1.Rows.Add();

            // Ajustar el modo de tamaño automático de las columnas para que llenen el espacio del DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajustar el ancho de la columna de productos para ocupar espacio proporcional
            dataGridView1.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Bolsas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["btnAñadir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["btnEliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Manejar el evento de clic en las celdas del DataGridView1
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        // Método para ajustar el ancho de la columna "Producto"
        private void AjustarAnchoColumnaProducto(DataGridViewComboBoxColumn comboBoxColumn)
        {
            dataGridView1.AutoResizeColumn(dataGridView1.Columns["Producto"].Index, DataGridViewAutoSizeColumnMode.AllCells);
        }

        // Ajustar la altura del DataGridView según las filas visibles
        private void AjustarAlturaDataGridView()
        {
            // Calcular la altura en función de la cantidad de filas y su altura
            int totalRowHeight = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
            int columnHeaderHeight = dataGridView1.ColumnHeadersHeight;
            int totalHeight = totalRowHeight + columnHeaderHeight + 2; // Añadir 2 para el borde

            // Ajustar la altura del DataGridView
            dataGridView1.Height = totalHeight;
        }

        // Evento para validar y formatear el número de CPIC
        private void TxtNumeroCPIC_TextChanged(object sender, EventArgs e)
        {
            // Eliminar espacios adicionales
            string text = txtNumeroCPIC.Text.Trim();

            // Verificar si el texto solo contiene dígitos y no más de 7 caracteres
            string pattern = @"^\d{1,7}$";
            if (Regex.IsMatch(text, pattern))
            {
                // Completar con ceros a la izquierda para que siempre tenga 7 dígitos
                string formattedText = text.PadLeft(7, '0');
                txtNumeroCPIC.TextChanged -= TxtNumeroCPIC_TextChanged; // Desactivar temporalmente el evento para evitar loops
                txtNumeroCPIC.Text = formattedText;
                txtNumeroCPIC.SelectionStart = txtNumeroCPIC.Text.Length; // Mantener el cursor al final
                txtNumeroCPIC.TextChanged += TxtNumeroCPIC_TextChanged; // Reasignar el evento
            }
        }

        // Evento para validar y formatear el número de factura
        // Evento para validar y formatear el número de factura
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



        // Método para calcular el ancho del texto más largo en el ComboBox
        private int GetMaxTextWidthForComboBoxItems(DataGridViewComboBoxColumn comboBoxColumn)
        {
            int maxWidth = 0;
            using (Graphics g = dataGridView1.CreateGraphics())
            {
                foreach (var item in comboBoxColumn.Items)
                {
                    SizeF size = g.MeasureString(item.ToString(), dataGridView1.Font);
                    if (size.Width > maxWidth)
                    {
                        maxWidth = (int)size.Width;
                    }
                }
            }
            return maxWidth;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no se está clicando en el encabezado
            {
                // Verifica si el clic fue en la columna "Añadir"
                if (e.ColumnIndex == dataGridView1.Columns["btnAñadir"].Index)
                {
                    // Añadir una nueva fila vacía debajo de la fila actual
                    dataGridView1.Rows.Insert(e.RowIndex + 1, "", ""); // Añade una fila vacía

                    // Opción: Puedes mostrar un mensaje si deseas
                    //MessageBox.Show("Nueva fila añadida.");
                }
                // Verifica si el clic fue en la columna "Eliminar"
                else if (e.ColumnIndex == dataGridView1.Columns["btnEliminar"].Index)
                {
                    // Verificar si hay más de una fila antes de eliminar
                    if (dataGridView1.Rows.Count > 1)
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("No puedes eliminar la última fila.");
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Finaliza la edición de cualquier celda que esté siendo editada actualmente
            if (dataGridView1.IsCurrentCellInEditMode)
            {
                dataGridView1.EndEdit();
            }

            if (ValidarCampos())
            {
                GuardarCPIC();
            }

        }

        private bool ValidarCampos()
        {
            // Verificar que el N° CPIC tenga exactamente 7 dígitos
            string cpicPattern = @"^\d{7}$";
            if (string.IsNullOrWhiteSpace(txtNumeroCPIC.Text) || !Regex.IsMatch(txtNumeroCPIC.Text.Trim(), cpicPattern))
            {
                MessageBox.Show("El número de CPIC debe tener exactamente 7 dígitos numéricos (por ejemplo, '0002437').",
                                "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Patrón correcto del formato 'F### - ########' para N° Factura
            string pattern = @"^F\d{3} - \d{8}$";
            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text) || !Regex.IsMatch(txtNumeroFactura.Text.Trim(), pattern))
            {
                MessageBox.Show("El número de factura debe tener el formato 'F### - ########' (por ejemplo, 'F222 - 00004266').",
                                "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que el valor de flete sea un número válido
            if (!decimal.TryParse(txtValorFlete.Text, out _))
            {
                MessageBox.Show("El valor del flete debe ser un número válido.");
                return false;
            }

            // Verificar que al menos un producto esté seleccionado en el DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Producto"].Value == null || string.IsNullOrWhiteSpace(row.Cells["Bolsas"].Value?.ToString()))
                {
                    MessageBox.Show("Cada fila debe tener un producto seleccionado y una cantidad de bolsas.");
                    return false;
                }
            }

            // Si todas las validaciones son correctas
            return true;
        }

        private void GuardarCPIC()
        {
            // Finaliza la edición de cualquier celda en el DataGridView que esté siendo editada
            dataGridView1.EndEdit();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Verificar si el N° CPIC ya existe en la base de datos
                    if (ExisteCPIC(txtNumeroCPIC.Text, connection, transaction))
                    {
                        MessageBox.Show("El N° CPIC ingresado ya existe. Por favor, ingrese un N° CPIC diferente.",
                                        "N° CPIC Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detener el proceso si ya existe el CPIC
                    }

                    // Buscar el idFactura basado en el numeroFactura ingresado
                    int? idFactura = ObtenerIdFactura(txtNumeroFactura.Text, connection, transaction);

                    if (idFactura == null)
                    {
                        MessageBox.Show("El número de factura no existe en la base de datos. Por favor, verifica o crea la factura primero.");
                        return;
                    }

                    // Insertar el CPIC principal (sin columna de cantidad de bolsas)
                    string queryCPIC = "INSERT INTO CPIC (numeroCPIC, idFactura, valorTotalFlete, fechaEmision) OUTPUT INSERTED.idCPIC VALUES (@numeroCPIC, @idFactura, @valorTotalFlete, @fechaEmision)";

                    using (SqlCommand command = new SqlCommand(queryCPIC, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@numeroCPIC", txtNumeroCPIC.Text);
                        command.Parameters.AddWithValue("@idFactura", idFactura);
                        command.Parameters.AddWithValue("@valorTotalFlete", decimal.Parse(txtValorFlete.Text));
                        command.Parameters.AddWithValue("@fechaEmision", dtpFechaEmision.Value);

                        // Obtener el ID del CPIC recién insertado
                        int idCPIC = (int)command.ExecuteScalar();

                        // Insertar productos asociados
                        InsertarProductos(idCPIC, connection, transaction);
                    }

                    // Confirmar transacción si todo salió bien
                    transaction.Commit();
                    MessageBox.Show("CPIC y productos guardados exitosamente.");
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, deshacer transacción
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar CPIC: " + ex.Message);
                }
            }
        }

        // Método para verificar si un N° CPIC ya existe en la base de datos
        private bool ExisteCPIC(string numeroCPIC, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT COUNT(1) FROM CPIC WHERE numeroCPIC = @numeroCPIC";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@numeroCPIC", numeroCPIC);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Método para obtener el idFactura basado en el numeroFactura
        private int? ObtenerIdFactura(string numeroFactura, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT idFactura FROM Factura WHERE numeroFactura = @numeroFactura";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
                else
                {
                    return null; // No se encontró el numeroFactura
                }
            }
        }


        private void InsertarProductos(int idCPIC, SqlConnection connection, SqlTransaction transaction)
        {
            string queryProducto = "INSERT INTO CPIC_Productos (idCPIC, idProducto, cantidadBolsasProducto) VALUES (@idCPIC, @idProducto, @cantidadBolsasProducto)";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar que las celdas no sean nulas y contengan datos válidos
                if (row.Cells["Producto"].Value != null && row.Cells["Bolsas"].Value != null)
                {
                    string producto = row.Cells["Producto"].Value.ToString();
                    string bolsasTexto = row.Cells["Bolsas"].Value.ToString().Trim();

                    // Verificar que la cantidad de bolsas sea un número válido y positivo
                    if (int.TryParse(bolsasTexto, out int cantidadBolsas) && cantidadBolsas > 0)
                    {
                        using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection, transaction))
                        {
                            int idProducto = ObtenerIdProducto(producto, connection, transaction);
                            cmdProducto.Parameters.AddWithValue("@idCPIC", idCPIC);
                            cmdProducto.Parameters.AddWithValue("@idProducto", idProducto);

                            // Aquí se asegura de que cantidadBolsas siempre tiene un valor válido
                            cmdProducto.Parameters.AddWithValue("@cantidadBolsasProducto", cantidadBolsas);

                            // Debug para verificar los valores antes de insertar
                            Debug.WriteLine($"Insertando producto: ID Producto = {idProducto}, Cantidad Bolsas = {cantidadBolsas}");

                            cmdProducto.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"La cantidad de bolsas para el producto '{producto}' debe ser un número válido mayor a 0.",
                                        "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("Cantidad de bolsas no válida.");
                    }
                }
                else
                {
                    // Mensaje si la fila tiene un valor nulo o vacío en "Producto" o "Bolsas"
                    MessageBox.Show("Cada fila debe tener un producto seleccionado y una cantidad de bolsas ingresada.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Fila con datos incompletos.");
                }
            }
        }





        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Bolsas"].Index && e.RowIndex >= 0)
            {
                // Verificar si el valor en la celda es nulo o no válido
                string valor = dataGridView1.Rows[e.RowIndex].Cells["Bolsas"].Value?.ToString().Trim();
                if (string.IsNullOrWhiteSpace(valor) || !int.TryParse(valor, out int cantidad))
                {
                    MessageBox.Show("La cantidad de bolsas debe ser un número válido y no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells["Bolsas"].Value = 1; // Colocar un valor por defecto de 1 para evitar NULL
                }
            }
        }




        private int ObtenerIdProducto(string nombreProducto, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT idProducto FROM Producto WHERE nombre = @nombreProducto";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                return (int)command.ExecuteScalar();
            }
        }

    }


}
