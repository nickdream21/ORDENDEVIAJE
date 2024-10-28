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
        private Form15 formFacturaInstance; // Para formulario Factura
        private Form14 formCPICInstance; // Para formulario CPIC

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

            // Añadir los paneles ocultos para Factura y CPIC
            panelSubMenuFactura.Visible = false;
            panelSubMenuCPIC.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (panelSubMenuOrdenViaje.Visible == true)
                panelSubMenuOrdenViaje.Visible = false;
            if (panelSubMenuRegistro.Visible == true)
                panelSubMenuRegistro.Visible = false;
            if (panelSubMenuConsultas.Visible == true)
                panelSubMenuConsultas.Visible = false;

            // Ocultar también los nuevos submenús
            if (panelSubMenuFactura.Visible == true)
                panelSubMenuFactura.Visible = false;
            if (panelSubMenuCPIC.Visible == true)
                panelSubMenuCPIC.Visible = false;
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

        // SUBMENÚ ORDEN DE VIAJE
        private void botonOrdenViaje_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuOrdenViaje);
        }

        private void buttonAgregarOrdenViaje_Click(object sender, EventArgs e)
        {
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

        // SUBMENÚ REGISTRO
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

        // SUBMENÚ FACTURA
        private void buttonFactura_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuFactura);
        }

        /*  private void buttonAgregarFactura_Click(object sender, EventArgs e)
          {
              if (formFacturaInstance == null || formFacturaInstance.IsDisposed)
              {
                  formFacturaInstance = new Form12(); // Formulario para Factura
                  formFacturaInstance.FormClosed += (s, args) => formFacturaInstance = null;
                  formFacturaInstance.Show();
              }
              else
              {
                  formFacturaInstance.BringToFront();
              }

              ocultarSubMenu();
          }*/

        private void buttonBuscarFactura_Click(object sender, EventArgs e)
        {
            // Aquí iría la lógica para buscar Facturas
            ocultarSubMenu();
        }

        // SUBMENÚ CPIC
        private void buttonCPIC_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuCPIC);
        }


        private void buttonBuscarCPIC_Click(object sender, EventArgs e)
        {
            // Aquí iría la lógica para buscar CPIC
            ocultarSubMenu();
        }

        // SUBMENÚ CONSULTAS
        private void buttonConsultas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuConsultas);
        }

        private void buttonConsultasGastos_Click(object sender, EventArgs e)
        {
            // Lógica para consultar Gastos
            ocultarSubMenu();
        }

        private void buttonConsultasAlmacen_Click(object sender, EventArgs e)
        {
            // Lógica para consultar Almacén
            ocultarSubMenu();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación cuando se cierra el Form5
            Application.Exit();
        }

        private void buttonAgregarCPIC_Click_1(object sender, EventArgs e)
        {
            if (formCPICInstance == null || formCPICInstance.IsDisposed)
            {
                formCPICInstance = new Form14(); // Formulario para CPIC
                formCPICInstance.FormClosed += (s, args) => formCPICInstance = null;
                formCPICInstance.Show();
            }
            else
            {
                formCPICInstance.BringToFront();
            }

            ocultarSubMenu();
        }

        private void buttonAgregarFactura_Click(object sender, EventArgs e)
        {
            if (formCPICInstance == null || formCPICInstance.IsDisposed)
            {
                formFacturaInstance = new Form15(); // Formulario para CPIC
                formFacturaInstance.FormClosed += (s, args) => formFacturaInstance = null;
                formFacturaInstance.Show();
            }
            else
            {
                formFacturaInstance.BringToFront();
            }

            ocultarSubMenu();
        }
    }
}
