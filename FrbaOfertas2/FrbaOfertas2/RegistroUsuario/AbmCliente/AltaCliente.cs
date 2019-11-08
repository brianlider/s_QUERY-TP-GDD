﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas2.RegistroUsuario.AbmCliente
{
    public partial class AltaCliente : Form
    {

        public String registrarUsuario_TextBox_username;
        SqlDataAdapter generico = new SqlDataAdapter();


        public AltaCliente(String username )
        {
            InitializeComponent();
            registrarUsuario_TextBox_username = username;

            int prueba = this.obtener_usuario(username);

            MessageBox.Show(prueba.ToString());

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox_mail_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_Click(object sender, EventArgs e)
        {

            this.crear_direccion();
    
            int id_usuario = this.obtener_usuario(registrarUsuario_TextBox_username);
            int id_direccion = this.obtener_direccion(//falta pasar parametros aca);

            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();
            String query_insert_rol_nuevo = "INSERT INTO S_QUERY.Cliente(clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo, direc_codigo, usuario_codigo) VALUES('" + textBox_nombre.Text.ToString() +
                "', '" + textBox_nombre + "', '" +
                "', '" + textBox_apellido + "', '" +
                "', '" + textBox_dni + "', '" +
                "', '" + textBox_mail + "', '" +
                "', '" + textBox_telefono + "', '" +
                "', '" + dateTimePicker_fecha_nacimiento + "', '" +
                "', '200', '" +
                "', '" + id_direccion + "', '" +
                "', '" + id_usuario.ToString() + "')";
            //SqlDataAdapter sda_insert = new SqlDataAdapter(query_insert_rol, connection);
            generico.InsertCommand = new SqlCommand(query_insert_rol_nuevo, connection);
            MessageBox.Show("llega");
            int a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
            }
            generico.InsertCommand.Dispose();
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private int obtener_direccion(String calle, String numero , String localidad, String piso , String)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_usuario_id = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE direc_localidad = '" + localidad + "' ,";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_usuario_id, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            connection.Close();



            return (int)data_usuario.Rows[0].ItemArray[0];

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        private void crear_direccion()
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_insert_direccion_nuevo = "INSERT INTO S_QUERY.Direccion(direc_localidad, direc_calle , direc_nro, direc_piso, direc_depto) VALUES('" + textBox_localidad.Text.ToString() + "', '"
                + textBox_calle.Text.ToString() + "', '"
                + textBox_numero.Text.ToString() + "', '"
                + textBox_numero_piso.Text.ToString() + "', '" 
                + textBox_departamento + "')"; //despues cambiar la contra a encriptacion
            //SqlDataAdapter sda_insert = new SqlDataAdapter(query_insert_rol, connection);
            generico.InsertCommand = new SqlCommand(query_insert_direccion_nuevo, connection);

            int a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
                MessageBox.Show("Fallo al ingresar el usuario");
            }

            generico.InsertCommand.Dispose();
        }
        
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private int obtener_usuario(String username)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_usuario_id = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = '" + username + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_usuario_id, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            connection.Close();



            return (int) data_usuario.Rows[0].ItemArray[0];

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
