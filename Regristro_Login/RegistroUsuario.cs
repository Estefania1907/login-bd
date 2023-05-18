using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using System.IO;
using System.Data.SQLite;

namespace Regristro_Login
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            /// <param name="sender"Limpia o borra lo que se encuentre en la caja de texto "TextBox" ></param>
            /// <param name="e"></param>
            txtNombre.Clear();
            txtClave.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd_sqlite;



                SQLiteConnection conexion_sqlite = new SQLiteConnection("Data Source=database.db;Version=3;Compress=True;");
                conexion_sqlite.Open();
                cmd_sqlite = conexion_sqlite.CreateCommand();


                cmd_sqlite.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='Personas';";
                object result = cmd_sqlite.ExecuteScalar();

                if (result == null)
                {
                    cmd_sqlite.CommandText = "CREATE TABLE Personas (id INTEGER PRIMARY KEY AUTOINCREMENT, nombre VARCHAR(100), clave VARCHAR(100));";
                    cmd_sqlite.ExecuteNonQuery();
                }




                string nombre = txtNombre.Text;
                string clave = txtClave.Text;
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
                {
                    MessageBox.Show("Por favor, ingrese un nombre de usuario y una clave");
                    return;
                }

                cmd_sqlite.CommandText = "INSERT INTO Personas (nombre, clave) VALUES ('" + nombre + "', '" + clave + "');";
                cmd_sqlite.ExecuteNonQuery();

                conexion_sqlite.Close();

                MessageBox.Show("Usuario registrado exitosamente");


                /*
                string name=txtUser.Text;
                string pass = txtPass.Text;

                Persona persona = new Persona(name, pass);
                _Personas.Add(persona);

                txtUser.Text = "";
                txtPass.Text = "";

                using(StreamWriter crear = new StreamWriter("usuarios.csv", true))
                {
                    crear.WriteLine(name + ";" + pass);
                }
                MessageBox.Show("Usuario registrado");
                */
            }
            catch (Exception x)
            {
                MessageBox.Show("Error al agregar el registro: " + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            /// <param name="sender" Retroceso a pestaña inicial o anterior ></param>
            /// <param name="e"></param>
            
            this.Hide();
            Form1 Atras = new Form1();
            Atras.Show();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
