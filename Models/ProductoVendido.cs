using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2Boher.Models
{
    internal class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido() { }

        public ProductoVendido(int id, int stock, int idProducto, int idVenta)
        {
            Id = id;
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Stock = {Stock}, IdProducto = {IdProducto}, IdVenta = {IdVenta}";
        }
    }
}
