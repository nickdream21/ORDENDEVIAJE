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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            // Configurar el DataGridView
            dataGridView1.AllowUserToAddRows = false; // Deshabilitar la opción de agregar filas por defecto
            dataGridView1.Rows.Add(); // Agregar una fila inicial

            // Configurar la fila inicial
            DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[0].Cells["Ruta"];
            comboBoxCell.Value = "Sullana-Trujillo-Sullana"; // Seleccionar por defecto

            comboBox2.Enabled = false;
            textBox3.Enabled = false;

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Añadir"].Index && e.RowIndex >= 0)
            {
                bool isChecked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Añadir"].Value);
                if (isChecked)
                {
                    var result = MessageBox.Show("¿Desea agregar una nueva ruta?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (dataGridView1.Rows.Count < 2) // Permitir hasta 2 filas adicionales
                        {
                            DataGridViewRow newRow = new DataGridViewRow();
                            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                            comboBoxCell.Items.Add("Sullana-Trujillo-Sullana");
                            comboBoxCell.Items.Add("Sullana-Guayaquil-Sullana");

                            // Eliminar la opción seleccionada de las filas previas
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells["Ruta"].Value != null)
                                {
                                    comboBoxCell.Items.Remove(row.Cells["Ruta"].Value.ToString());
                                }
                            }

                            newRow.Cells.Add(comboBoxCell);
                            newRow.Cells.Add(new DataGridViewCheckBoxCell());
                            dataGridView1.Rows.Add(newRow);
                        }
                        else
                        {
                            MessageBox.Show("Solo se pueden agregar 2 filas.");
                            dataGridView1.Rows[e.RowIndex].Cells["Añadir"].Value = false; // Desmarcar el checkbox
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Añadir"].Value = false; // Desmarcar el checkbox
                    }
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Ruta"].Index)
            {
                ComboBox combo = e.Control as ComboBox;
                if (combo != null)
                {
                    combo.SelectedIndexChanged -= Combo_SelectedIndexChanged;
                    combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
                }
            }
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();

            if (selectedValue == "Sullana-Guayaquil-Sullana")
            {
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }
    }
}
