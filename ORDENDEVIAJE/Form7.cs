using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeDataGridViewGastos();
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

            // Ajustar la altura del DataGridView
            AdjustDataGridViewHeight();
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
            dataGridViewGastos.Columns.Add("descripcion", "Descripción"); // Añadir columna Descripción
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

            // Deshabilitar la barra de desplazamiento vertical
            dataGridViewGastos.ScrollBars = ScrollBars.Horizontal;

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
                dataGridViewGastos.Rows.Add(i + 1, gastos[i], "", "", "");
            }

            // Agregar fila total
            dataGridViewGastos.Rows.Add("Total", "", "", "", "");

            // Ajustar el ancho de la columna "N°" al tamaño de sus celdas
            dataGridViewGastos.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewGastos.Columns["gastos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewGastos.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Ajustar ancho de Descripción
            dataGridViewGastos.Columns["soles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewGastos.Columns["dolares"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Hacer que las columnas "N°" y "Gastos" sean de solo lectura
            foreach (DataGridViewRow row in dataGridViewGastos.Rows)
            {
                if (row.Cells["gastos"].Value.ToString() != "")
                {
                    row.Cells["gastos"].ReadOnly = true;
                }
            }

            // Hacer que las celdas de "Total" en "Soles" y "Dolares" sean de solo lectura
            int totalRowIndex = dataGridViewGastos.Rows.Count - 1;
            dataGridViewGastos.Rows[totalRowIndex].Cells["soles"].ReadOnly = true;
            dataGridViewGastos.Rows[totalRowIndex].Cells["dolares"].ReadOnly = true;

            // Manejar el evento KeyDown para evitar la creación de nuevas filas
            dataGridViewGastos.KeyDown += DataGridViewGastos_KeyDown;

            // Manejar el evento CellValueChanged para actualizar los totales
            dataGridViewGastos.CellValueChanged += DataGridViewGastos_CellValueChanged;

            // Ajustar la altura del DataGridView
            AdjustDataGridViewHeight(dataGridViewGastos);

            // Deshabilitar la fila de encabezado de fila
            dataGridViewGastos.RowHeadersVisible = false;
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


        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            // Obtener el número de la nueva fila
            int nuevoNumero = dataGridViewGastos.Rows.Count + 1;

            // Agregar una nueva fila
            dataGridViewGastos.Rows.Add(nuevoNumero, "", "", "");

            // Ajustar la altura del DataGridView
            AdjustDataGridViewHeight(dataGridViewGastos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar una ventana emergente con los botones Sí y No
            DialogResult result = MessageBox.Show("¿Quieres agregar un gasto adicional?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige Sí, agrega una nueva fila
            if (result == DialogResult.Yes)
            {
                // Obtener el número de la nueva fila
                int nuevoNumero = dataGridViewGastos.Rows.Count; // Contará la fila total también, por lo que esto es correcto

                // Insertar una nueva fila antes de la fila total
                dataGridViewGastos.Rows.Insert(nuevoNumero - 1, nuevoNumero, "", "", "", "");

                // Ajustar la altura del DataGridView
                AdjustDataGridViewHeight(dataGridViewGastos);

                // Permitir la edición en la nueva fila agregada
                dataGridViewGastos.Rows[nuevoNumero - 1].Cells["gastos"].ReadOnly = false;
            }
        }

        private void UpdateTotals(DataGridView dataGridView)
        {
            decimal totalSoles = 0;
            decimal totalDolares = 0;

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++) // No contar la última fila (Total)
            {
                if (decimal.TryParse(dataGridView.Rows[i].Cells["soles"].Value?.ToString(), out decimal soles))
                {
                    totalSoles += soles;
                }
                if (decimal.TryParse(dataGridView.Rows[i].Cells["dolares"].Value?.ToString(), out decimal dolares))
                {
                    totalDolares += dolares;
                }
            }

            // Deshabilitar temporalmente el evento CellValueChanged para evitar recursión
            dataGridView.CellValueChanged -= DataGridViewIngresos_CellValueChanged;
            dataGridView.CellValueChanged -= DataGridViewGastos_CellValueChanged;

            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["soles"].Value = totalSoles;
            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["dolares"].Value = totalDolares;

            // Habilitar nuevamente el evento CellValueChanged
            dataGridView.CellValueChanged += DataGridViewIngresos_CellValueChanged;
            dataGridView.CellValueChanged += DataGridViewGastos_CellValueChanged;
        }


        private void DataGridViewIngresos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewIngresos.Columns["soles"].Index || e.ColumnIndex == dataGridViewIngresos.Columns["dolares"].Index)
            {
                UpdateTotals(dataGridViewIngresos);
            }
        }

        private void DataGridViewGastos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewGastos.Columns["soles"].Index || e.ColumnIndex == dataGridViewGastos.Columns["dolares"].Index)
            {
                UpdateTotals(dataGridViewGastos);
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


    }
}
