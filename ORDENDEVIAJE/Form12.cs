using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Form12 : Form
    {
        private string numeroOrdenViaje; // Variable de clase

        public Form12(string numeroOrdenViaje)
        {
            this.numeroOrdenViaje = numeroOrdenViaje;

            // Deshabilitar la opción de maximizar
            this.MaximizeBox = false;

            // Configurar el borde del formulario para que no pueda redimensionarse
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Posicionar el formulario en el centro de la pantalla al aparecer
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            panel1.AutoScrollMinSize = new Size(0, 2900); // Establecer la altura mínima para el scroll

            // Cargar datos en los ComboBox
            cargarClientes();
            cargarTractos();
            cargarCarretas();
            cargarConductores();

            // Cargar los datos específicos de la orden de viaje
            cargarDatosOrdenViaje();
            cargarGuiasTransportista();
        }

        private void cargarClientes()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
            {
                conexion.Open();
                string query = "SELECT nombre FROM Cliente";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["nombre"].ToString());
                        }
                    }
                }
            }
        }

        private void cargarTractos()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
            {
                conexion.Open();
                string query = "SELECT placaTracto FROM Tracto";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["placaTracto"].ToString());
                        }
                    }
                }
            }
        }

        private void cargarCarretas()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
            {
                conexion.Open();
                string query = "SELECT placaCarreta FROM Carreta";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader["placaCarreta"].ToString());
                        }
                    }
                }
            }
        }

        private void cargarConductores()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
            {
                conexion.Open();
                string query = "SELECT RTRIM(apPaterno) + ' ' + RTRIM(apMaterno) + ' ' + RTRIM(nombre) AS NombreConductor FROM Conductor";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox4.Items.Add(reader["NombreConductor"].ToString());
                        }
                    }
                }
            }
        }

        private void cargarDatosOrdenViaje()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=SGV;integrated security=true"))
            {
                conexion.Open();
                string query = @"SELECT OV.*, C.nombre AS Cliente, 
                            RTRIM(CO.apPaterno) + ' ' + RTRIM(CO.apMaterno) + ' ' + RTRIM(CO.nombre) AS NombreConductor,
                            T.placaTracto, CA.placaCarreta
                         FROM OrdenViaje OV
                         LEFT JOIN Cliente C ON OV.idCliente = C.idCliente
                         LEFT JOIN Conductor CO ON OV.idConductor = CO.idConductor
                         LEFT JOIN Tracto T ON OV.idTracto = T.idTracto
                         LEFT JOIN Carreta CA ON OV.idCarreta = CA.idCarreta
                         WHERE OV.numeroOrdenViaje = @numeroOrdenViaje";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@numeroOrdenViaje", numeroOrdenViaje);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox5.Text = reader["numeroOrdenViaje"].ToString();
                            dateTimePicker1.Value = Convert.ToDateTime(reader["fechaSalida"]);
                            dateTimePicker4.Value = Convert.ToDateTime(reader["fechaLlegada"]);
                            dateTimePicker3.Value = DateTime.Parse(reader["horaSalida"].ToString());
                            dateTimePicker2.Value = DateTime.Parse(reader["horaLlegada"].ToString());
                            comboBox1.Text = reader["Cliente"].ToString();
                            comboBox2.Text = reader["placaTracto"].ToString();
                            comboBox3.Text = reader["placaCarreta"].ToString();
                            comboBox4.Text = reader["NombreConductor"].ToString();
                            textBox4.Text = reader["observaciones"].ToString();
                        }
                    }
                }
            }
        }


        private void cargarGuiasTransportista()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=OrdenViajeSGV;integrated security=true"))
            {
                conexion.Open();
                string query = @"SELECT numeroGuiaTransportista, numeroGuiaCliente, ruta1, descripcionProducto 
                                 FROM GuiasTransportista 
                                 WHERE numeroOrdenViaje = @numeroOrdenViaje";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@numeroOrdenViaje", numeroOrdenViaje);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxGuiaTransportista.Text = reader["numeroGuiaTransportista"].ToString();
                            textBoxGuiaCliente.Text = reader["numeroGuiaCliente"].ToString();
                            //  textBoxRuta.Text = reader["ruta1"].ToString();  // Este campo debería ser un TextBox, o un ComboBox si tiene múltiples rutas
                            textBoxDescripcionProducto.Text = reader["descripcionProducto"].ToString();
                        }
                    }
                }
            }
        }

        private void buttonElegir_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Owner = this;
            form3.ShowDialog();
        }
    }
}


