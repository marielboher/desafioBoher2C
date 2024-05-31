using Desafio2Boher.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Desafio2Boher.Database
{
    internal class GestorBDDProducto
    {
        private string connectionString;

        public GestorBDDProducto()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=sistemaGestion;Trusted_Connection=True;";
        }

        public bool CreateProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto (Descripciones, Costo, Stock, PrecioVenta, IdUsuario) VALUES (@Descripciones, @Costo, @Stock, @PrecioVenta, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Producto SET  Descripciones = @Descripciones, Costo = @Costo, Stock = @Stock, PrecioVenta = @PrecioVenta, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Producto GetProductoById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Descripciones, Costo, Stock, PrecioVenta, IdUsuario FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Producto(
                        Convert.ToInt32(reader["Id"]),
                        reader["Descripciones"].ToString(),
                        Convert.ToDecimal(reader["Costo"]),
                        Convert.ToInt32(reader["Stock"]),
                        Convert.ToDecimal(reader["PrecioVenta"]),
                        Convert.ToInt32(reader["IdUsuario"])
                    );
                }
                throw new Exception("Producto no encontrado");
            }
        }

        public bool DeleteProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Producto> ListaDeProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Descripciones, Costo, Stock, PrecioVenta, IdUsuario FROM Producto";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Producto producto = new Producto(
                            Convert.ToInt32(dataReader["Id"]),
                            dataReader["Descripciones"].ToString(),
                            Convert.ToDecimal(dataReader["Costo"]),
                            Convert.ToInt32(dataReader["Stock"]),
                            Convert.ToDecimal(dataReader["PrecioVenta"]),
                            Convert.ToInt32(dataReader["IdUsuario"])
                        );
                        listaProductos.Add(producto);
                    }
                }
            }
            return listaProductos;
        }
    }
}
