﻿using Desafio2Boher.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2Boher.Database
{
    internal class GestorBDDUsuario
    {
        private string connectionString;

        public GestorBDDUsuario()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=sistemaGestion;Trusted_Connection=True;";
        }

        public bool DeleteUser(int userId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.Parameters.AddWithValue("id", userId);

                return command.ExecuteNonQuery() > 0;
            }

        }

        public bool CreateUser(Usuario usuario)
        {
            using(SqlConnection connection =  new SqlConnection(this.connectionString))
            {
                string query = "INSERT INTO Usuario(nombre, apellido, nombreUsuario, contraseña, mail) values(@nombre, @apellido, @nombreUsuario, @password, @email)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Password);
                command.Parameters.AddWithValue("email", usuario.Email);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public Usuario GetUserById(int id)
        {
            using(SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader[0]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(userId, nombre, apellido, nombreUsuario, password, email);

                    return usuario;
                }

                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateUser(int id, Usuario usuario)
        {
            using(SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "UPDATE Usuario SET nombre = @nombre, apellido = @apellido, nombreUsuario = @nombreUsuario, contraseña = @password, mail = @email WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Password);
                command.Parameters.AddWithValue("email", usuario.Email);
                command.Parameters.AddWithValue("id", id);


                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List <Usuario> ListaDeUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string query = "SELECT * FROM Usuario";

            using(SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Password = dataReader["Contraseña"].ToString();
                            usuario.Email = dataReader["Mail"].ToString();

                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
            return listaUsuarios;
        }
    }

}
