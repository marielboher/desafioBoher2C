using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2Boher.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }  
        public decimal Costo { get; set; }         
        public int Stock { get; set; }             
        public decimal PrecioVenta { get; set; }   
        public int IdUsuario { get; set; }         

        public Producto() { }

        public Producto(int id, string descripciones, decimal costo, int stock, decimal precioVenta, int idUsuario)
        {
            Id = id;
            Descripciones = descripciones;
            Costo = costo;
            Stock = stock;
            PrecioVenta = precioVenta;
            IdUsuario = idUsuario;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Descripciones = {Descripciones}, Costo = {Costo}, Stock = {Stock}, PrecioVenta = {PrecioVenta}, IdUsuario = {IdUsuario}";
        }
    }
}
