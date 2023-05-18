using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Jose Manuel Pereira Turizo - 03/05/2023
/// Para registrar o leer usuario en la base de datos
/// </summary>

namespace Regristro_Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <param name="sender" envia a la pestaña correspondiente (RegistroUsuario) ></param>
        /// <param name="e"></param>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistroUsuario VentanaUsuario = new RegistroUsuario();
            VentanaUsuario.Show();
        }
        /// <param name="sender" envia a la pestaña correspondiente (InicioSesion) ></param>
        /// <param name="e"></param>
        private void btnInicio_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            InicioSesion VentanaInicioSesion= new InicioSesion();
            VentanaInicioSesion.Show();
        }
    }
}
