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
    public partial class Form7 : Form
    {
        private int currentOrderId;

        public Form7(Form2 form2Instance)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            currentOrderId = int.Parse(form2Instance.textBox5.Text);
            InitializeDataGridView();
            InitializeDataGridViewGastos();
            InitializeDataGridViewTotales();

            CustomizeDataGridViewSelectionColors(dataGridViewIngresos);
            CustomizeDataGridViewSelectionColors(dataGridViewGastos);
            CustomizeDataGridViewSelectionColors(dataGridViewTotales);
        }
        

        private void InitializeDataGridView()
        {
            // Definir las columnas del DataGridView
            dataGridViewIngresos.Columns.Add("numero", "N°");
            dataGridViewIngresos.Columns.Add("ingresos", "Ingresos");
            dataGridViewIngresos.Columns.Add("descripcion", "Descripción");
            dataGridViewIngresos.Columns.Add("soles", "Soles (S/)");
            dataGridViewIngresos.Columns.Add("dolares", "Dolares ($)");


            // Deshabilitar la ordenación por columna
            foreach (DataGridViewColumn column in dataGridViewIngresos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Centrar los encabezados de columna
            dataGridViewIngresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar el tamaño de las columnas al tamaño del DataGridView
            dataGridViewIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Deshabilitar la barra de desplazamiento vertical
            dataGridViewIngresos.ScrollBars = ScrollBars.Horizontal;

            // Deshabilitar el cambio de tamaño de las filas
            dataGridViewIngresos.AllowUserToResizeRows = false;

            // Deshabilitar el cambio de tamaño de las columnas
            dataGridViewIngresos.AllowUserToResizeColumns = false;

            // Deshabilitar la adición de nuevas filas por el usuario
            dataGridViewIngresos.AllowUserToAddRows = false;


            // Configurar el estilo de las filas para que no se puedan cambiar de tamaño
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True;
            dataGridViewIngresos.RowsDefaultCellStyle = style;

            // Agregar filas predefinidas
            string[] ingresos = { "Despacho", "Mensualidad", "Otros Autorizados", "Prestamo" };
            for (int i = 0; i < ingresos.Length; i++)
            {
                int rowIndex = dataGridViewIngresos.Rows.Add(i + 1, ingresos[i], "", "", "");
                dataGridViewIngresos.Rows[rowIndex].Cells["ingresos"].ReadOnly = true; // Hacer que las celdas de la columna "Ingresos" sean de solo lectura
                dataGridViewIngresos.Rows[rowIndex].Cells["numero"].ReadOnly = true;
            }

            // Agregar la fila de total
            int totalRowIndex = dataGridViewIngresos.Rows.Add();
            dataGridViewIngresos.Rows[totalRowIndex].Cells["ingresos"].Value = "Total";
            dataGridViewIngresos.Rows[totalRowIndex].Cells["numero"].ReadOnly = true;
            dataGridViewIngresos.Rows[totalRowIndex].Cells["ingresos"].ReadOnly = true;
            dataGridViewIngresos.Rows[totalRowIndex].Cells["descripcion"].ReadOnly = true;
            dataGridViewIngresos.Rows[totalRowIndex].Cells["soles"].ReadOnly = true;
            dataGridViewIngresos.Rows[totalRowIndex].Cells["dolares"].ReadOnly = true;

            // Ajustar el ancho de la columna "N°" al tamaño de sus celdas
            dataGridViewIngresos.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewIngresos.Columns["ingresos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewIngresos.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewIngresos.Columns["soles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewIngresos.Columns["dolares"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Manejar el evento CellValueChanged para actualizar el total cuando se cambian los valores
            dataGridViewIngresos.CellValueChanged += DataGridViewIngresos_CellValueChanged;

            dataGridViewIngresos.EditingControlShowing += DataGridViewIngresos_EditingControlShowing;


            // Ajustar la altura del DataGridView
            AdjustDataGridViewHeight();
            //CustomizeDataGridViewSelectionColors(dataGridViewIngresos);

            // Configurar el modo de selección para seleccionar solo celdas individuales
            dataGridViewIngresos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Ajustar estilos de selección
            dataGridViewIngresos.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridViewIngresos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void DataGridViewIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnSoles_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDolares_KeyPress);

            if (dataGridViewIngresos.CurrentCell.ColumnIndex == dataGridViewIngresos.Columns["soles"].Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(ColumnSoles_KeyPress);
            }

            if (dataGridViewIngresos.CurrentCell.ColumnIndex == dataGridViewIngresos.Columns["dolares"].Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(ColumnDolares_KeyPress);
            }

            // Establecer un color de selección visible solo cuando esté en modo de edición
            e.Control.Enter -= Control_Enter;
            e.Control.Leave -= Control_Leave;

            e.Control.Enter += Control_Enter;
            e.Control.Leave += Control_Leave;
        }

        private void Control_Enter(object sender, EventArgs e)
        {
            dataGridViewIngresos.CurrentCell.Style.SelectionBackColor = Color.LightBlue;
            dataGridViewIngresos.CurrentCell.Style.SelectionForeColor = Color.Black;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            dataGridViewIngresos.CurrentCell.Style.SelectionBackColor = dataGridViewIngresos.DefaultCellStyle.BackColor;
            dataGridViewIngresos.CurrentCell.Style.SelectionForeColor = dataGridViewIngresos.DefaultCellStyle.ForeColor;
        }



        private void ColumnSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


        }
        private void ColumnDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void UpdateTotal()
        {
            decimal totalSoles = 0;
            decimal totalDolares = 0;

            foreach (DataGridViewRow row in dataGridViewIngresos.Rows)
            {
                if (row.IsNewRow || row.Cells["ingresos"].Value?.ToString() == "Total") continue;

                if (decimal.TryParse(row.Cells["soles"].Value?.ToString(), out decimal soles))
                {
                    totalSoles += soles;
                }

                if (decimal.TryParse(row.Cells["dolares"].Value?.ToString(), out decimal dolares))
                {
                    totalDolares += dolares;
                }
            }

            dataGridViewIngresos.Rows[dataGridViewIngresos.Rows.Count - 1].Cells["soles"].Value = totalSoles;
            dataGridViewIngresos.Rows[dataGridViewIngresos.Rows.Count - 1].Cells["dolares"].Value = totalDolares;
        }

        private void AdjustDataGridViewHeight()
        {
            int totalHeight = dataGridViewIngresos.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridViewIngresos.Rows)
            {
                totalHeight += row.Height;
            }

            dataGridViewIngresos.Height = totalHeight + dataGridViewIngresos.Margin.Vertical;
        }

        private void InitializeDataGridViewGastos()
        {
            // Definir las columnas del DataGridView
            dataGridViewGastos.Columns.Add("numero", "N°");
            dataGridViewGastos.Columns.Add("gastos", "Gastos");
            dataGridViewGastos.Columns.Add("descripcion", "Descripción");
            dataGridViewGastos.Columns.Add("soles", "Soles (S/)");
            dataGridViewGastos.Columns.Add("dolares", "Dolares ($)");

            // Deshabilitar la ordenación por columna
            foreach (DataGridViewColumn column in dataGridViewGastos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Centrar el encabezado de las columnas
            dataGridViewGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar el tamaño de las columnas al tamaño del DataGridView
            dataGridViewGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Habilitar la barra de desplazamiento vertical
            dataGridViewGastos.ScrollBars = ScrollBars.Vertical;

            // Deshabilitar el cambio de tamaño de las filas
            dataGridViewGastos.AllowUserToResizeRows = false;

            // Deshabilitar el cambio de tamaño de las columnas
            dataGridViewGastos.AllowUserToResizeColumns = false;

            // Deshabilitar la adición de nuevas filas por el usuario
            dataGridViewGastos.AllowUserToAddRows = false;

            // Configurar el estilo de las filas para que no se puedan cambiar de tamaño
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewGastos.RowsDefaultCellStyle = style;

            // Ajustar la altura de las filas para que se ajusten al contenido
            dataGridViewGastos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Agregar filas predefinidas
            string[] gastos = { "Peajes", "Alimentación", "Apoyo-Seguridad", "Reparaciones Varios", "Movilidad", "Encarpada/Desencarpada", "Hospedaje", "Combustible" };
            for (int i = 0; i < gastos.Length; i++)
            {
                int rowIndex = dataGridViewGastos.Rows.Add(i + 1, gastos[i], "", "", "");
                dataGridViewGastos.Rows[rowIndex].Cells["gastos"].ReadOnly = true; // Hacer que las celdas de la columna "Gastos" sean de solo lectura
                dataGridViewGastos.Rows[rowIndex].Cells["numero"].ReadOnly = true;
            }

            // Ajustar el ancho de la columna "N°" al tamaño de sus celdas
            dataGridViewGastos.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewGastos.Columns["gastos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewGastos.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewGastos.Columns["soles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewGastos.Columns["dolares"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Manejar el evento KeyDown para evitar la creación de nuevas filas
            dataGridViewGastos.KeyDown += DataGridViewGastos_KeyDown;

            // Manejar el evento CellValueChanged para actualizar los totales
            dataGridViewGastos.CellValueChanged += DataGridViewGastos_CellValueChanged;

            dataGridViewGastos.EditingControlShowing += DataGridViewGastos_EditingControlShowing;

            // Deshabilitar la fila de encabezado de fila
            dataGridViewGastos.RowHeadersVisible = false;

            CustomizeDataGridViewSelectionColors(dataGridViewGastos);
        }




        private void InitializeDataGridViewTotales()
        {
            // Definir las columnas del DataGridView
            dataGridViewTotales.Columns.Add("descripcion", "");
            dataGridViewTotales.Columns.Add("soles", "Soles (S/)");
            dataGridViewTotales.Columns.Add("dolares", "Dolares ($)");

            // Deshabilitar la ordenación por columna
            foreach (DataGridViewColumn column in dataGridViewTotales.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Centrar los encabezados de columna
            dataGridViewTotales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Ajustar el tamaño de las columnas al tamaño del DataGridView
            dataGridViewTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Deshabilitar la barra de desplazamiento
            dataGridViewTotales.ScrollBars = ScrollBars.None;

            // Deshabilitar el cambio de tamaño de las filas
            dataGridViewTotales.AllowUserToResizeRows = false;

            // Deshabilitar el cambio de tamaño de las columnas
            dataGridViewTotales.AllowUserToResizeColumns = false;

            // Deshabilitar la adición de nuevas filas por el usuario
            dataGridViewTotales.AllowUserToAddRows = false;

            // Deshabilitar la fila de encabezado de fila
            dataGridViewTotales.RowHeadersVisible = false;

            // Configurar el estilo de las filas para que no se puedan cambiar de tamaño
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True;
            dataGridViewTotales.RowsDefaultCellStyle = style;

            // Agregar filas predefinidas
            dataGridViewTotales.Rows.Add("Total Ingresos", "", "");
            dataGridViewTotales.Rows.Add("Total Gastos", "", "");
            dataGridViewTotales.Rows.Add("Diferencia de Saldo", "", "");

            // Hacer que las celdas sean de solo lectura
            foreach (DataGridViewRow row in dataGridViewTotales.Rows)
            {
                row.Cells["descripcion"].ReadOnly = true;
                row.Cells["soles"].ReadOnly = true;
                row.Cells["dolares"].ReadOnly = true;
            }

            // Ajustar la altura del DataGridView
            AdjustDataGridViewHeight(dataGridViewTotales);

            CustomizeDataGridViewSelectionColors(dataGridViewTotales);
        }

        private void DataGridViewGastos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnSolesGastos_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDolaresGastos_KeyPress);

            if (dataGridViewGastos.CurrentCell.ColumnIndex == dataGridViewGastos.Columns["soles"].Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(ColumnSolesGastos_KeyPress);
            }

            if (dataGridViewGastos.CurrentCell.ColumnIndex == dataGridViewGastos.Columns["dolares"].Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(ColumnDolaresGastos_KeyPress);
            }
        }

        private void ColumnSolesGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ColumnDolaresGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void AdjustDataGridViewHeight(DataGridView dataGridView)
        {
            int totalHeight = dataGridView.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalHeight += row.Height;
            }

            dataGridView.Height = totalHeight + dataGridView.Margin.Vertical;
        }

        private void DataGridViewGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Evitar la creación de nuevas filas al presionar Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar el MessageBox con la pregunta
            DialogResult result = MessageBox.Show("¿Quieres agregar un gasto adicional?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige "Sí", agregar una nueva fila
            if (result == DialogResult.Yes)
            {
                // Obtener el número de la nueva fila
                int nuevoNumero = dataGridViewGastos.Rows.Count + 1;

                // Agregar una nueva fila al final
                dataGridViewGastos.Rows.Add(nuevoNumero, "", "", "", "");
            }
        }



        private void UpdateIngresosTotal()
        {
            decimal totalSoles = 0;
            decimal totalDolares = 0;

            for (int i = 0; i < dataGridViewIngresos.Rows.Count - 1; i++) // No contar la última fila (Total)
            {
                if (decimal.TryParse(dataGridViewIngresos.Rows[i].Cells["soles"].Value?.ToString(), out decimal soles))
                {
                    totalSoles += soles;
                }
                if (decimal.TryParse(dataGridViewIngresos.Rows[i].Cells["dolares"].Value?.ToString(), out decimal dolares))
                {
                    totalDolares += dolares;
                }
            }

            // Deshabilitar temporalmente el evento CellValueChanged para evitar recursión
            dataGridViewIngresos.CellValueChanged -= DataGridViewIngresos_CellValueChanged;

            dataGridViewIngresos.Rows[dataGridViewIngresos.Rows.Count - 1].Cells["soles"].Value = totalSoles; // Fila Total
            dataGridViewIngresos.Rows[dataGridViewIngresos.Rows.Count - 1].Cells["dolares"].Value = totalDolares; // Fila Total

            // Habilitar nuevamente el evento CellValueChanged
            dataGridViewIngresos.CellValueChanged += DataGridViewIngresos_CellValueChanged;

            // Actualizar los totales en la tabla dataGridViewTotales
            UpdateTotals();
        }


        private void UpdateTotals()
        {
            // Actualizar totales en la tabla de ingresos
            decimal totalIngresosSoles = 0;
            decimal totalIngresosDolares = 0;

            for (int i = 0; i < dataGridViewIngresos.Rows.Count - 1; i++) // No contar la última fila (Total)
            {
                if (decimal.TryParse(dataGridViewIngresos.Rows[i].Cells["soles"].Value?.ToString(), out decimal soles))
                {
                    totalIngresosSoles += soles;
                }
                if (decimal.TryParse(dataGridViewIngresos.Rows[i].Cells["dolares"].Value?.ToString(), out decimal dolares))
                {
                    totalIngresosDolares += dolares;
                }
            }

            // Actualizar totales en la tabla de gastos
            decimal totalGastosSoles = 0;
            decimal totalGastosDolares = 0;

            foreach (DataGridViewRow row in dataGridViewGastos.Rows)
            {
                if (decimal.TryParse(row.Cells["soles"].Value?.ToString(), out decimal soles))
                {
                    totalGastosSoles += soles;
                }
                if (decimal.TryParse(row.Cells["dolares"].Value?.ToString(), out decimal dolares))
                {
                    totalGastosDolares += dolares;
                }
            }

            // Calcular diferencia de saldo
            decimal diferenciaSoles = totalIngresosSoles - totalGastosSoles;
            decimal diferenciaDolares = totalIngresosDolares - totalGastosDolares;

            // Actualizar la tabla de totales
            dataGridViewTotales.Rows[0].Cells["soles"].Value = totalIngresosSoles;
            dataGridViewTotales.Rows[0].Cells["dolares"].Value = totalIngresosDolares;

            dataGridViewTotales.Rows[1].Cells["soles"].Value = totalGastosSoles;
            dataGridViewTotales.Rows[1].Cells["dolares"].Value = totalGastosDolares;

            dataGridViewTotales.Rows[2].Cells["soles"].Value = diferenciaSoles;
            dataGridViewTotales.Rows[2].Cells["dolares"].Value = diferenciaDolares;
        }





        private void DataGridViewIngresos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewIngresos.Columns["soles"].Index || e.ColumnIndex == dataGridViewIngresos.Columns["dolares"].Index)
            {
                UpdateIngresosTotal();
            }
        }

        private void DataGridViewGastos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewGastos.Columns["soles"].Index || e.ColumnIndex == dataGridViewGastos.Columns["dolares"].Index)
            {
                UpdateTotals();
            }
        }

        private void DataGridViewIngresos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Evitar la creación de nuevas filas al presionar Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void CustomizeDataGridViewSelectionColors(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;
        }


        private void SaveIngresos()
        {
            string connectionString = "Data Source=NICK;Initial Catalog=OrdenViajeSGV;Integrated Security=True"; // Asegúrate de que esta sea tu cadena de conexión

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
INSERT INTO Ingresos (
    despachoSoles, despachoDolares, prestamoSoles, prestamosDolares, 
    mensualidadSoles, mensualidadDolares, otrosSoles, otrosDolares, 
    totalDolares, totalSoles, numeroOrdenViaje, 
    descDespacho, descMensualidad, descOtrosAutorizados, descPrestamo)
VALUES (
    @despachoSoles, @despachoDolares, @prestamoSoles, @prestamosDolares, 
    @mensualidadSoles, @mensualidadDolares, @otrosSoles, @otrosDolares, 
    @totalDolares, @totalSoles, @numeroOrdenViaje, 
    @descDespacho, @descMensualidad, @descOtrosAutorizados, @descPrestamo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parámetros de valores
                    command.Parameters.AddWithValue("@despachoSoles", GetValueOrDefault(dataGridViewIngresos.Rows[0].Cells["soles"].Value));
                    command.Parameters.AddWithValue("@despachoDolares", GetValueOrDefault(dataGridViewIngresos.Rows[0].Cells["dolares"].Value));
                    command.Parameters.AddWithValue("@prestamoSoles", GetValueOrDefault(dataGridViewIngresos.Rows[3].Cells["soles"].Value));
                    command.Parameters.AddWithValue("@prestamosDolares", GetValueOrDefault(dataGridViewIngresos.Rows[3].Cells["dolares"].Value));
                    command.Parameters.AddWithValue("@mensualidadSoles", GetValueOrDefault(dataGridViewIngresos.Rows[1].Cells["soles"].Value));
                    command.Parameters.AddWithValue("@mensualidadDolares", GetValueOrDefault(dataGridViewIngresos.Rows[1].Cells["dolares"].Value));
                    command.Parameters.AddWithValue("@otrosSoles", GetValueOrDefault(dataGridViewIngresos.Rows[2].Cells["soles"].Value));
                    command.Parameters.AddWithValue("@otrosDolares", GetValueOrDefault(dataGridViewIngresos.Rows[2].Cells["dolares"].Value));
                    command.Parameters.AddWithValue("@totalDolares", GetValueOrDefault(dataGridViewIngresos.Rows[4].Cells["dolares"].Value));
                    command.Parameters.AddWithValue("@totalSoles", GetValueOrDefault(dataGridViewIngresos.Rows[4].Cells["soles"].Value));
                    command.Parameters.AddWithValue("@numeroOrdenViaje", currentOrderId); // Asegurarse de usar currentOrderId aquí

                    // Parámetros de descripciones
                    command.Parameters.AddWithValue("@descDespacho", GetDescriptionValueOrDefault(dataGridViewIngresos.Rows[0].Cells["descripcion"].Value));
                    command.Parameters.AddWithValue("@descMensualidad", GetDescriptionValueOrDefault(dataGridViewIngresos.Rows[1].Cells["descripcion"].Value));
                    command.Parameters.AddWithValue("@descOtrosAutorizados", GetDescriptionValueOrDefault(dataGridViewIngresos.Rows[2].Cells["descripcion"].Value));
                    command.Parameters.AddWithValue("@descPrestamo", GetDescriptionValueOrDefault(dataGridViewIngresos.Rows[3].Cells["descripcion"].Value));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            MessageBox.Show("Datos de ingresos guardados exitosamente.");
        }

        private object GetValueOrDefault(object value)
        {
            return value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToSingle(value);
        }

        private object GetDescriptionValueOrDefault(object value)
        {
            return value == DBNull.Value || value == null ? DBNull.Value : value.ToString();
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            SaveIngresos(); // Llamar al método para guardar los datos de ingresos
            SaveGastos();
            this.Hide();

        }

        private void SaveGastosAdicionales()
        {
            string connectionString = "Data Source=NICK;Initial Catalog=OrdenViajeSGV;Integrated Security=True"; // Asegúrate de que esta sea tu cadena de conexión

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO CategoriasAdicionales (
                numeroOrdenViaje,
                nombreCategoria,
                soles,
                dolares,
                descripcion)
            VALUES (
                @numeroOrdenViaje,
                @nombreCategoria,
                @soles,
                @dolares,
                @descripcion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (DataGridViewRow row in dataGridViewGastos.Rows)
                    {
                        if (row.Index >= 8 && !row.IsNewRow) // Asegurarse de que solo los gastos adicionales (filas a partir del índice 8) se guarden
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@numeroOrdenViaje", currentOrderId);
                            command.Parameters.AddWithValue("@nombreCategoria", row.Cells["gastos"].Value ?? "");
                            command.Parameters.AddWithValue("@soles", row.Cells["soles"].Value ?? 0);
                            command.Parameters.AddWithValue("@dolares", row.Cells["dolares"].Value ?? 0);
                            command.Parameters.AddWithValue("@descripcion", row.Cells["descripcion"].Value ?? "");

                            command.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }

        private void SaveGastos()
        {
            string connectionString = "Data Source=NICK;Initial Catalog=OrdenViajeSGV;Integrated Security=True"; // Asegúrate de que esta sea tu cadena de conexión

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Egresos (numeroOrdenViaje, peajesSoles, peajesDolares, descPeajes, alimentacionSoles, alimentacionDolares, descAlimentacion, apoyoseguridadSoles, apoyoseguridadDolares, descApoyoSeguridad, reparacionesVariosSoles, repacionesVariosDolares, descReparacionesVarios, movilidadSoles, movilidadDolares, descMovilidad, encarpada_desencarpadaSoles, encarpada_desencarpadaDolares, descEncarpadaDesencarpada, hospedajeSoles, hospedajeDolares, descHospedaje, combustibleSoles, combustibleDolares, descCombustible)
            VALUES (@numeroOrdenViaje, @peajesSoles, @peajesDolares, @descPeajes, @alimentacionSoles, @alimentacionDolares, @descAlimentacion, @apoyoseguridadSoles, @apoyoseguridadDolares, @descApoyoSeguridad, @reparacionesVariosSoles, @repacionesVariosDolares, @descReparacionesVarios, @movilidadSoles, @movilidadDolares, @descMovilidad, @encarpada_desencarpadaSoles, @encarpada_desencarpadaDolares, @descEncarpadaDesencarpada, @hospedajeSoles, @hospedajeDolares, @descHospedaje, @combustibleSoles, @combustibleDolares, @descCombustible)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numeroOrdenViaje", currentOrderId);

                    command.Parameters.AddWithValue("@peajesSoles", dataGridViewGastos.Rows[0].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@peajesDolares", dataGridViewGastos.Rows[0].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descPeajes", dataGridViewGastos.Rows[0].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@alimentacionSoles", dataGridViewGastos.Rows[1].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@alimentacionDolares", dataGridViewGastos.Rows[1].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descAlimentacion", dataGridViewGastos.Rows[1].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@apoyoseguridadSoles", dataGridViewGastos.Rows[2].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@apoyoseguridadDolares", dataGridViewGastos.Rows[2].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descApoyoSeguridad", dataGridViewGastos.Rows[2].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@reparacionesVariosSoles", dataGridViewGastos.Rows[3].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@repacionesVariosDolares", dataGridViewGastos.Rows[3].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descReparacionesVarios", dataGridViewGastos.Rows[3].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@movilidadSoles", dataGridViewGastos.Rows[4].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@movilidadDolares", dataGridViewGastos.Rows[4].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descMovilidad", dataGridViewGastos.Rows[4].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@encarpada_desencarpadaSoles", dataGridViewGastos.Rows[5].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@encarpada_desencarpadaDolares", dataGridViewGastos.Rows[5].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descEncarpadaDesencarpada", dataGridViewGastos.Rows[5].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@hospedajeSoles", dataGridViewGastos.Rows[6].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@hospedajeDolares", dataGridViewGastos.Rows[6].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descHospedaje", dataGridViewGastos.Rows[6].Cells["descripcion"].Value ?? "");

                    command.Parameters.AddWithValue("@combustibleSoles", dataGridViewGastos.Rows[7].Cells["soles"].Value ?? 0);
                    command.Parameters.AddWithValue("@combustibleDolares", dataGridViewGastos.Rows[7].Cells["dolares"].Value ?? 0);
                    command.Parameters.AddWithValue("@descCombustible", dataGridViewGastos.Rows[7].Cells["descripcion"].Value ?? "");

                    command.ExecuteNonQuery();
                }

                SaveGastosAdicionales(); // Llamar al método para guardar los gastos adicionales

                connection.Close();
            }

            MessageBox.Show("Datos de gastos guardados exitosamente.");
        }



        private object GetCellValue(DataGridView gridView, int rowIndex, string columnName)
        {
            return gridView.Rows[rowIndex].Cells[columnName].Value ?? DBNull.Value;
        }

    }
}
