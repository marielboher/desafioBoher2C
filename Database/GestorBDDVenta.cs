using Desafio2Boher.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Desafio2Boher.Database
{
    internal class GestorBDDVenta
    {
        private string connectionString;

        public GestorBDDVenta()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=sistemaGestion;Trusted_Connection=True;";
        }

        public bool CreateVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Venta GetVentaById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Venta(
                        Convert.ToInt32(reader["Id"]),
                        reader["Comentarios"].ToString(),
                        Convert.ToInt32(reader["IdUsuario"])
                    );
                }
                throw new Exception("Venta no encontrada");
            }
        }

        public bool UpdateVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Venta> ListaDeVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Comentarios, IdUsuario FROM Venta";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Venta venta = new Venta(
                            Convert.ToInt32(dataReader["Id"]),
                            dataReader["Comentarios"].ToString(),
                            Convert.ToInt32(dataReader["IdUsuario"])
                        );
                        listaVentas.Add(venta);
                    }
                }
            }
            return listaVentas;
        }
    }
}
