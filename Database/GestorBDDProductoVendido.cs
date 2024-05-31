using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio2Boher.Models;

namespace Desafio2Boher.Database
{
    internal class GestorBDDProductoVendido
    {
        private string connectionString;

        public GestorBDDProductoVendido()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=sistemaGestion;Trusted_Connection=True;";
        }

        public bool CreateProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@Stock, @IdProducto, @IdVenta)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public ProductoVendido GetProductoVendidoById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ProductoVendido(
                        Convert.ToInt32(reader["Id"]),
                        Convert.ToInt32(reader["Stock"]),
                        Convert.ToInt32(reader["IdProducto"]),
                        Convert.ToInt32(reader["IdVenta"])
                    );
                }
                throw new Exception("Producto vendido no encontrado");
            }
        }

        public bool UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, IdVenta = @IdVenta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<ProductoVendido> ListaDeProductosVendidos()
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido(
                            Convert.ToInt32(dataReader["Id"]),
                            Convert.ToInt32(dataReader["Stock"]),
                            Convert.ToInt32(dataReader["IdProducto"]),
                            Convert.ToInt32(dataReader["IdVenta"])
                        );
                        listaProductosVendidos.Add(productoVendido);
                    }
                }
            }
            return listaProductosVendidos;
        }
    }
}
