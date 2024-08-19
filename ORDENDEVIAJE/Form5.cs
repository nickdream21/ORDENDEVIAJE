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
    public partial class Form5 : Form
    {
        private Form2 form2Instance;
        private Form8 form8Instance;
        private Form9 form9Instance;
        private Form10 form10Instance;
        private Form11 form11Instance;
        public Form5()
        {
            InitializeComponent();
            personalizarDiseño();
            this.FormClosing += new FormClosingEventHandler(Form5_FormClosing);
        }

        private void personalizarDiseño()
        {
            panelSubMenuOrdenViaje.Visible = false;
            panelSubMenuRegistro.Visible = false;
            panelSubMenuConsultas.Visible = false;
            //se puede añadir otras formas para personalizar el diseño

        }


        private void ocultarSubMenu()
        {
            if (panelSubMenuOrdenViaje.Visible == true)
                panelSubMenuOrdenViaje.Visible = false;
            if (panelSubMenuRegistro.Visible == true)
                panelSubMenuRegistro.Visible = false;
            if (panelSubMenuConsultas.Visible == true)
                panelSubMenuConsultas.Visible = false;

        }


        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // region subMenuOrdenDeViaje

        private void botonOrdenViaje_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuOrdenViaje);


        }

        private void buttonAgregarOrdenViaje_Click(object sender, EventArgs e)
        {

            // Verificar si form2Instance ya está abierto
            if (form2Instance == null || form2Instance.IsDisposed)
            {
                form2Instance = new Form2();
                form2Instance.FormClosed += (s, args) => form2Instance = null;
                form2Instance.Show();
            }
            else
            {
                form2Instance.BringToFront();
            }

            ocultarSubMenu();

        }

        private void buttonBuscarOrdenViaje_Click(object sender, EventArgs e)
        {
            // codificar que hace cuando presionemos click en el boton Buscar del menu orden de viaje
            // depues de todo eso invocamos el ocultar sub Menu


            // Verificar si form2Instance ya está abierto
            if (form11Instance == null || form11Instance.IsDisposed)
            {
                form11Instance = new Form11();
                form11Instance.FormClosed += (s, args) => form11Instance = null;
                form11Instance.Show();
            }
            else
            {
                form11Instance.BringToFront();
            }

            ocultarSubMenu();
        }


        //SUB MENU REGISTRO
        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuRegistro);
        }

        private void buttonRegistroChoferes_Click(object sender, EventArgs e)
        {
            if (form8Instance == null || form8Instance.IsDisposed)
            {
                form8Instance = new Form8();
                form8Instance.FormClosed += (s, args) => form8Instance = null;
                form8Instance.Show();
            }
            else
            {
                form8Instance.BringToFront();
            }

            ocultarSubMenu();

        }

        private void buttonRegistroTractos_Click(object sender, EventArgs e)
        {
            if (form9Instance == null || form9Instance.IsDisposed)
            {
                form9Instance = new Form9();
                form9Instance.FormClosed += (s, args) => form9Instance = null;
                form9Instance.Show();
            }
            else
            {
                form9Instance.BringToFront();
            }

            ocultarSubMenu();
        }

        private void buttonRegistroCarretas_Click(object sender, EventArgs e)
        {
            if (form10Instance == null || form10Instance.IsDisposed)
            {
                form10Instance = new Form10();
                form10Instance.FormClosed += (s, args) => form10Instance = null;
                form10Instance.Show();
            }
            else
            {
                form10Instance.BringToFront();
            }

            ocultarSubMenu();
        }


        //SUB MENU CONSULTAS
        private void buttonConsultas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuConsultas);
        }

        private void buttonConsultasGastos_Click(object sender, EventArgs e)
        {
            // codificar que hace cuando presionemos click en el boton gastos del menu Consultas
            // depues de todo eso invocamos el ocultar sub Menu

            ocultarSubMenu();
        }

        private void buttonConsultasAlmacen_Click(object sender, EventArgs e)
        {
            // codificar que hace cuando presionemos click en el boton almacen del menu Consultas
            // depues de todo eso invocamos el ocultar sub Menu

            ocultarSubMenu();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación cuando se cierra el Form5
            Application.Exit();
        }



    }
}
