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
            cargarDatosOrdenViaje();
        }



        private void cargarDatosOrdenViaje()
        {
            using (SqlConnection conexion = new SqlConnection("server=NICK;database=SGV;integrated security=true"))
            {
                conexion.Open();
                string query = @"SELECT * FROM OrdenViaje OV
                             LEFT JOIN Cliente C ON OV.idCliente = C.idCliente
                             LEFT JOIN Conductor CO ON OV.idConductor = CO.idConductor
                             LEFT JOIN Tracto T ON OV.idTracto = T.idTracto
                             LEFT JOIN Carreta CA ON OV.idCarreta = CA.idCarreta
                             LEFT JOIN Producto P ON OV.idProducto = P.idProducto
                             LEFT JOIN GuiasTransportista GT ON OV.numeroOrdenViaje = GT.numeroOrdenViaje
                             LEFT JOIN Ingresos I ON OV.numeroOrdenViaje = I.numeroOrdenViaje
                             LEFT JOIN Egresos E ON OV.numeroOrdenViaje = E.numeroOrdenViaje
                             WHERE OV.numeroOrdenViaje = @numeroOrdenViaje";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@numeroOrdenViaje", numeroOrdenViaje);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Asignar los valores obtenidos a los controles del formulario
                            textBox5.Text = reader["numeroOrdenViaje"].ToString();
                            dateTimePicker1.Value = Convert.ToDateTime(reader["fechaSalida"]);
                            dateTimePicker2.Value = Convert.ToDateTime(reader["fechaLlegada"]);
                            comboBox1.Text = reader["nombre"].ToString();
                            comboBox2.Text = reader["placaTracto"].ToString();
                            comboBox4.Text = $"{reader["apPaterno"]} {reader["apMaterno"]} {reader["nombre"]}";
                            textBox4.Text = reader["observaciones"].ToString();
                            textBoxGuiaTransportista.Text = reader["numeroGuiaTransportista"].ToString();
                            textBoxGuiaCliente.Text = reader["numeroGuiaCliente"].ToString();
                            textBoxDescripcionProducto.Text = reader["descripcionProducto"].ToString();

                            // Y así con el resto de los controles...
                        }
                    }
                }
            }
        }
    }

    }

