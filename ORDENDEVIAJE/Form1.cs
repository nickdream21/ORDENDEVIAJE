using System.Windows.Forms;

namespace ORDENDEVIAJE
{
    public partial class Login : Form
    {
        private bool mostrandoContrase�a = false; // Declarar la variable aqu�
        private bool isInitialImage = true;
        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;

            // Establecer la imagen inicial del PictureBox al ojo cerrado

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

            Form5 menu = new Form5();
            menu.Show();
            this.Hide();
        }



        private void checkBoxVerContrase�a_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerContrase�a.Checked)
            {
                textBox2.UseSystemPasswordChar = false; // Mostrar contrase�a
            }
            else
            {
                textBox2.UseSystemPasswordChar = true; // Ocultar contrase�a
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
                e.SuppressKeyPress = true; // Esto previene el beep de sistema al presionar Enter
            }
        }
        private void iniciarSesion()
        {
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;
            /*
            if (usuario == "Sistemas" && contrasena == "SGV-sistem@s")
            {
                //MessageBox.Show("Inicio de sesi�n exitoso.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el siguiente formulario y ocultar el formulario de inicio de sesi�n
                
            }
            else
            {
                MessageBox.Show("Usuario o contrase�a incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/


            Form5 menu = new Form5();
            menu.Show();
            this.Hide();
        }

        private void pictureBoxOjo_Click(object sender, EventArgs e)
        {
            // Alternar la visibilidad de la contrase�a

        }
    }
    }

