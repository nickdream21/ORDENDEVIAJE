using ClosedXML.Excel;
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
    public partial class Form16 : Form
    {
        private string connectionString = @"Data Source=NICK;Initial Catalog=OrdenViajeSGV;Integrated Security=True";
        public Form16()
        {
            InitializeComponent();
            InitializeDataGridView();

        }

        private void InitializeDataGridView()
        {
            // Configuración del DataGridView
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            // Columnas
            var colNumeroOrden = new DataGridViewTextBoxColumn
            {
                Name = "NumeroOrdenViaje",
                HeaderText = "N° Orden de Viaje",
                DataPropertyName = "numeroOrdenViaje" // Nombre de columna en DataTable
            };
            dataGridView1.Columns.Add(colNumeroOrden);

            var colFechaSalida = new DataGridViewTextBoxColumn
            {
                Name = "FechaSalida",
                HeaderText = "Fecha de Salida",
                DataPropertyName = "fechaSalida" // Nombre de columna en DataTable
            };
            dataGridView1.Columns.Add(colFechaSalida);

            var colFechaLlegada = new DataGridViewTextBoxColumn
            {
                Name = "FechaLlegada",
                HeaderText = "Fecha de Llegada",
                DataPropertyName = "fechaLlegada" // Nombre de columna en DataTable
            };
            dataGridView1.Columns.Add(colFechaLlegada);

            var colConductor = new DataGridViewTextBoxColumn
            {
                Name = "Conductor",
                HeaderText = "Conductor",
                DataPropertyName = "Conductor" // Nombre de columna en DataTable
            };
            dataGridView1.Columns.Add(colConductor);

            // Columna de botón Detalle
            DataGridViewButtonColumn detalleButton = new DataGridViewButtonColumn
            {
                Name = "Detalle",
                HeaderText = "Detalle",
                Text = "Ver Detalle",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(detalleButton);

            // Evento para manejar clic en botón Detalle
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Detalle")
            {
                // Obtener el número de orden de viaje de la fila seleccionada
                string numeroOrdenViaje = dataGridView1.Rows[e.RowIndex].Cells["NumeroOrdenViaje"].Value.ToString();

                // Abrir el formulario de detalle (puedes pasar el número de orden de viaje como parámetro)
                // FormDetalleOrden formDetalle = new FormDetalleOrden(numeroOrdenViaje);
                // formDetalle.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroCPIC = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(numeroCPIC))
            {
                MessageBox.Show("Por favor, ingrese un número de CPIC.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Realizar la búsqueda
            BuscarOrdenesDeViaje(numeroCPIC);
        }

        private void BuscarOrdenesDeViaje(string numeroCPIC)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT o.numeroOrdenViaje, o.fechaSalida, o.fechaLlegada, 
                                 CONCAT(c.nombre, ' ', c.apPaterno, ' ', c.apMaterno) AS Conductor
                                 FROM OrdenViaje o
                                 INNER JOIN CPIC cp ON o.idCPIC = cp.idCPIC
                                 INNER JOIN Conductor c ON o.idConductor = c.idConductor
                                 WHERE cp.numeroCPIC = @numeroCPIC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@numeroCPIC", numeroCPIC);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos para el DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar las órdenes de viaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el libro y la hoja de trabajo
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte");

                // Exportar encabezados de columnas
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                }

                // Exportar filas y celdas
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Convertir el valor de la celda a cadena antes de asignarlo a la celda de Excel
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                    }
                }

                // Guardar el archivo Excel
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Reporte.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Datos exportados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


    }
}



