using Desafio2Boher.Database;
using Desafio2Boher.Models;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSeleccione el gestor para probar:");
                Console.WriteLine("1. Gestor Usuario");
                Console.WriteLine("2. Gestor Producto");
                Console.WriteLine("3. Gestor Producto Vendido");
                Console.WriteLine("4. Gestor Venta");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        TestGestorUsuario();
                        break;
                    case "2":
                        TestGestorProducto();
                        break;
                    case "3":
                        TestGestorProductoVendido();
                        break;
                    case "4":
                        TestGestorVenta();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }
            }
        }

        static void TestGestorUsuario()
        {
            GestorBDDUsuario gestorUsuario = new GestorBDDUsuario();
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Obtener Usuario");
            Console.WriteLine("3. Actualizar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Listar Usuarios");
            Console.Write("Seleccione la acción para Gestor Usuario: ");
            string action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "1":
                        Usuario newUser = new Usuario("Joaquin", "Corti", "joacocorti", "112233", "joaco@mail.com");
                        if (gestorUsuario.CreateUser(newUser))
                        {
                            Console.WriteLine("Usuario creado");
                        }
                        break;
                    case "2":
                        int userIdToGet = 1;
                        Usuario obtainedUser = gestorUsuario.GetUserById(userIdToGet);
                        if (obtainedUser != null)
                        {
                            Console.WriteLine($"Usuario obtenido: {obtainedUser}");
                        }
                        break;
                    case "3":
                        Usuario editUser = new Usuario("Joaquin", "Corti", "joacocortiUpdated2", "112233", "joaco@mail.com");
                        if (gestorUsuario.UpdateUser(3, editUser))
                        {
                            Console.WriteLine("Usuario modificado");
                        }
                        break;
                    case "4":
                        if (gestorUsuario.DeleteUser(4))
                        {
                            Console.WriteLine("Usuario eliminado");
                        }
                        break;
                    case "5":
                        var allUsers = gestorUsuario.ListaDeUsuarios();
                        foreach (Usuario user in allUsers)
                        {
                            Console.WriteLine(user);
                        }
                        break;
                    default:
                        Console.WriteLine("Acción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la operación: {ex.Message}");
            }
        }

        static void TestGestorProducto()
        {
            GestorBDDProducto gestorProducto = new GestorBDDProducto();
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Obtener Producto");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Listar Productos");
            Console.Write("Seleccione la acción para Gestor Producto: ");
            string action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "1":
                        Producto nuevoProducto = new Producto(0, "Laptop de alto rendimiento", 1200.00m, 10, 1400.00m, 3);
                        if (gestorProducto.CreateProducto(nuevoProducto))
                        {
                            Console.WriteLine("Producto creado");
                        }
                        break;
                    case "2":
                        int productoId = 1;
                        Producto productoObtenido = gestorProducto.GetProductoById(productoId);
                        Console.WriteLine($"Producto obtenido: {productoObtenido}");
                        break;
                    case "3":
                        Producto productoActualizado = new Producto(1, "Laptop actualizada", 2300.00m, 8, 2600.00m, 3);
                        if (gestorProducto.UpdateProducto(1, productoActualizado))
                        {
                            Console.WriteLine("Producto actualizado");
                        }
                        break;
                    case "4":
                        int idProductoAEliminar = 8;
                        if (gestorProducto.DeleteProducto(idProductoAEliminar))
                        {
                            Console.WriteLine("Producto eliminado correctamente");
                        }
                        break;
                    case "5":
                        List<Producto> productos = gestorProducto.ListaDeProductos();
                        Console.WriteLine("Lista de productos:");
                        foreach (var producto in productos)
                        {
                            Console.WriteLine(producto);
                        }
                        break;
                    default:
                        Console.WriteLine("Acción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la operación: {ex.Message}");
            }
        }

        static void TestGestorProductoVendido()
        {
            GestorBDDProductoVendido gestorProductoVendido = new GestorBDDProductoVendido();
            Console.WriteLine("1. Crear Producto Vendido");
            Console.WriteLine("2. Obtener Producto Vendido");
            Console.WriteLine("3. Actualizar Producto Vendido");
            Console.WriteLine("4. Eliminar Producto Vendido");
            Console.WriteLine("5. Listar Productos Vendidos");
            Console.Write("Seleccione la acción para Gestor Producto Vendido: ");
            string action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "1":
                        ProductoVendido nuevoProductoVendido = new ProductoVendido
                        {
                            Stock = 5,
                            IdProducto = 1,
                            IdVenta = 1
                        };
                        if (gestorProductoVendido.CreateProductoVendido(nuevoProductoVendido))
                        {
                            Console.WriteLine("Producto vendido creado con éxito");
                        }
                        break;
                    case "2":
                        int productoVendidoId = 1;
                        ProductoVendido productoVendidoObtenido = gestorProductoVendido.GetProductoVendidoById(productoVendidoId);
                        Console.WriteLine($"Producto vendido obtenido: {productoVendidoObtenido}");
                        break;
                    case "3":
                        ProductoVendido productoVendidoActualizado = new ProductoVendido
                        {
                            Id = 3,
                            Stock = 10,
                            IdProducto = 2,
                            IdVenta = 2
                        };
                        if (gestorProductoVendido.UpdateProductoVendido(1, productoVendidoActualizado))
                        {
                            Console.WriteLine("Producto vendido actualizado con éxito");
                        }
                        break;
                    case "4":
                        int idProductoVendidoAEliminar = 1;
                        if (gestorProductoVendido.DeleteProductoVendido(idProductoVendidoAEliminar))
                        {
                            Console.WriteLine("Producto vendido eliminado con éxito");
                        }
                        break;
                    case "5":
                        List<ProductoVendido> productosVendidos = gestorProductoVendido.ListaDeProductosVendidos();
                        Console.WriteLine("Lista de productos vendidos:");
                        foreach (var productoVendido in productosVendidos)
                        {
                            Console.WriteLine(productoVendido);
                        }
                        break;
                    default:
                        Console.WriteLine("Acción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la operación: {ex.Message}");
            }
        }

        static void TestGestorVenta()
        {
            GestorBDDVenta gestorVenta = new GestorBDDVenta();
            Console.WriteLine("1. Crear Venta");
            Console.WriteLine("2. Obtener Venta");
            Console.WriteLine("3. Actualizar Venta");
            Console.WriteLine("4. Eliminar Venta");
            Console.WriteLine("5. Listar Ventas");
            Console.Write("Seleccione la acción para Gestor Venta: ");
            string action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "1":
                        Venta nuevaVenta = new Venta
                        {
                            Comentarios = "Primera venta del producto X",
                            IdUsuario = 1  
                        };
                        if (gestorVenta.CreateVenta(nuevaVenta))
                        {
                            Console.WriteLine("Venta creada con éxito");
                        }
                        break;
                    case "2":
                        int ventaId = 1; 
                        Venta ventaObtenida = gestorVenta.GetVentaById(ventaId);
                        if (ventaObtenida != null)
                        {
                            Console.WriteLine($"Venta obtenida: {ventaObtenida}");
                        }
                        break;
                    case "3":
                        Venta ventaActualizada = new Venta
                        {
                            Id = 1,  
                            Comentarios = "Venta actualizada para incluir más detalles",
                            IdUsuario = 1  
                        };
                        if (gestorVenta.UpdateVenta(ventaActualizada.Id, ventaActualizada))
                        {
                            Console.WriteLine("Venta actualizada con éxito");
                        }
                        break;
                    case "4":
                        int idVentaAEliminar = 6; 
                        if (gestorVenta.DeleteVenta(idVentaAEliminar))
                        {
                            Console.WriteLine("Venta eliminada con éxito");
                        }
                        break;
                    case "5":
                        List<Venta> ventas = gestorVenta.ListaDeVentas();
                        Console.WriteLine("Lista de ventas:");
                        foreach (var venta in ventas)
                        {
                            Console.WriteLine(venta);
                        }
                        break;
                    default:
                        Console.WriteLine("Acción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la operación: {ex.Message}");
            }
        }

    }

}