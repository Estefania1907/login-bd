using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data.SQLite;

namespace Regristro_Login
{
    
    public partial class InicioSesion : Form
    {
        bool validar = false;
        int fallo = 0;

        private MySqlConnection connection;

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string clave = txtClave.Text;


                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
                {
                    MessageBox.Show("Por favor, ingrese un nombre de usuario y una clave");
                    return;
                }


                SQLiteConnection conexion_sqlite;
                SQLiteCommand cmd_sqlite;



                conexion_sqlite = new SQLiteConnection("Data Source=database.db;Version=3;Compress=True;");
                conexion_sqlite.Open();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                string connectionString = "Data Source=database.db;Version=3;Compress=True;";
                string query = "SELECT COUNT(*) FROM Personas WHERE nombre = '" + nombre + "' AND clave = '" + clave + "'";

                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Inicio de sesión exitoso!");
                          

                        }
                        else
                        {
                            fallo += 1;
                            MessageBox.Show("Nombre de usuario o clave incorrectos");
                        }

                        if (fallo == 3)
                        {
                            MessageBox.Show("Bruh, Adiós");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception y)
            {
                MessageBox.Show("Hubo un error" + y, "Error");
            }
                
            }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtClave.Clear();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Atras = new Form1();
            Atras.Show();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
