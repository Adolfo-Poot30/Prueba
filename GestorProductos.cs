using System;
using System.Collections.Generic;
using System.Linq;

class GestorProductos
{
    public List<Producto> productsList;

    public GestorProductos()
    {
        ObtenerProductos obtener = new ObtenerProductos();
        productsList = obtener.ObtenerProductosDesdeAPI(); 
    }

    public void AgregarProducto(Producto producto)
    {
        productsList.Add(producto);
        Console.WriteLine("Producto agregado con éxito.");
    }

    public void EditarProducto(int id)
    {
        Producto productoExistente = productsList.Find(p => p.Id == id);

        if (productoExistente != null)
        {
        try
        {
            Console.Write("Nuevo título: ");
            productoExistente.Title = Console.ReadLine();

            Console.Write("Nueva descripción: ");
            productoExistente.Description = Console.ReadLine();

            Console.Write("Nuevo precio: ");
    
            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
            {
                productoExistente.Price = nuevoPrecio;
            }
            else
            {
                Console.WriteLine("Formato de precio incorrecto. Se mantendrá el valor actual.");
            }

            Console.Write("Nuevo porcentaje de descuento: ");
    
            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoDescuento))
            {
                productoExistente.DiscountPercentage = nuevoDescuento;
            }
            else
            {
                Console.WriteLine("Formato de descuento incorrecto. Se mantendrá el valor actual.");
            }

            Console.Write("Nueva calificación: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal nuevaCalificacion))
            {
                productoExistente.Rating = nuevaCalificacion;
            }
            else
            {
                Console.WriteLine("Formato de calificación incorrecto. Se mantendrá el valor actual.");
            }

            Console.Write("Nuevo stock: ");
            if (int.TryParse(Console.ReadLine(), out int nuevoStock))
            {
                productoExistente.Stock = nuevoStock;
            }
            else
            {
                Console.WriteLine("Formato de stock incorrecto. Se mantendrá el valor actual.");
            }

            Console.Write("Nueva marca: ");
            productoExistente.Brand = Console.ReadLine();

            Console.Write("Nueva categoría: ");
            productoExistente.Category = Console.ReadLine();

            Console.Write("Nueva URL de miniatura: ");
            productoExistente.Thumbnail = Console.ReadLine();

            Console.Write("Nuevas imágenes (separadas por comas): ");
    
            productoExistente.Images = Console.ReadLine().Split(',').ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al editar el producto: {e.Message}");
        }

            Console.WriteLine("Producto editado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado. No se pudo editar.");
        }
    }

    public void ListarProductos()
    {
        Console.WriteLine("Listado de Productos:");
        foreach (var producto in productsList)
        {
            Console.WriteLine($"ID: {producto.Id}, Título: {producto.Title}, Precio: {producto.Price:C}");
        }
    }
}