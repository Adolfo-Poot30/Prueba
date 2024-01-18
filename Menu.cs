using System;
using System.Linq;

class Menu
{
    public static void Menuprincipal()
    {
        GestorProductos gestor = new GestorProductos();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Ver lista de productos");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Editar producto");
            Console.WriteLine("4. Salir");
            Console.Write("Ingrese la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    gestor.ListarProductos();
                    break;
                case "2":
                    Producto productoNuevo = crearProducto();
                    gestor.AgregarProducto(productoNuevo);
                    break;
                case "3":
                    try
                    {
                        Console.Write("ID del producto a editar: ");
                        if (int.TryParse(Console.ReadLine(), out int idAEditar))
                        {
                            gestor.EditarProducto(idAEditar);        
                        }
                        else
                        {
                            Console.WriteLine("Formato de ID incorrecto. Se cancelará la edición del producto.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error al editar el producto: {e.Message}");
                    }
                    
                    break;
                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
            Console.Clear();
        }
    }

    public static Producto crearProducto()
    {
        Producto nuevoProducto = new Producto();

        Console.Write("Ingrese el ID del producto: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            nuevoProducto.Id = id;
        }
        else
        {
            Console.WriteLine("Formato de ID incorrecto. Se asignará el valor predeterminado (0).");
        }

        Console.Write("Ingrese el título del producto: ");
        nuevoProducto.Title = Console.ReadLine();

        Console.Write("Ingrese la descripción del producto: ");
        nuevoProducto.Description = Console.ReadLine();

        Console.Write("Ingrese el precio del producto: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            nuevoProducto.Price = price;
        }
        else
        {
            Console.WriteLine("Formato de precio incorrecto. Se asignará el valor predeterminado (0.0).");
        }

        Console.Write("Ingrese el porcentaje de descuento del producto: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal discountPercentage))
        {
            nuevoProducto.DiscountPercentage = discountPercentage;
        }
        else
        {
            Console.WriteLine("Formato de descuento incorrecto. Se asignará el valor predeterminado (0.0).");
        }

        Console.Write("Ingrese la calificación del producto: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal rating))
        {
            nuevoProducto.Rating = rating;
        }
        else
        {
            Console.WriteLine("Formato de calificación incorrecto. Se asignará el valor predeterminado (0.0).");
        }

        Console.Write("Ingrese el stock del producto: ");
        if (int.TryParse(Console.ReadLine(), out int stock))
        {
            nuevoProducto.Stock = stock;
        }
        else
        {
            Console.WriteLine("Formato de stock incorrecto. Se asignará el valor predeterminado (0).");
        }

        Console.Write("Ingrese la marca del producto: ");
        nuevoProducto.Brand = Console.ReadLine();

        Console.Write("Ingrese la categoría del producto: ");
        nuevoProducto.Category = Console.ReadLine();

        Console.Write("Ingrese la URL de la miniatura del producto: ");
        nuevoProducto.Thumbnail = Console.ReadLine();

        Console.Write("Ingrese las URLs de las imágenes del producto (separadas por comas): ");
        nuevoProducto.Images = Console.ReadLine().Split(',').ToList();

        return nuevoProducto;
    }
}