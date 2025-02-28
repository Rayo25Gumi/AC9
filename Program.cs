using System;
using System.Collections.Generic;

struct Naves
{
    public string nombre;
}

class Program
{
    static List<Naves> listaNaves = new List<Naves>();
    static Stack<Naves> pilaNaves = new Stack<Naves>();

    static void Main()
    {
        int option;
        do
        {
            Console.WriteLine(
                "\n1. Crear un bloque de 10 naves" +
                "\n2. Cambiar nombre de una nave (por índice)" +
                "\n3. Ver lista de naves fabricadas" +
                "\n4. Eliminar todas las naves" +
                "\n5. Eliminar una única nave (por índice)" +
                "\n6. Listar todas las naves" +
                "\n7. Pasar todas las naves a la pila" +
                "\n8. Mostrar elementos de la pila" +
                "\n0. Salir"
            );
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CrearNave();
                    break;
                case 2:
                    CambiarNave();
                    break;
                case 3:
                    VerNaves();
                    break;
                case 4:
                    EliminarTodasNaves();
                    break;
                case 5:
                    EliminarNave();
                    break;
                case 6:
                    ListarNaves();
                    break;
                case 7:
                    MoverNavesAPila();
                    break;
                case 8:
                    MostrarPila();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (option != 0);
    }

    static string GenerarNombre()
    {
        Random rnd = new Random();
        return $"{(char)rnd.Next('A', 'Z' + 1)}{(char)rnd.Next('A', 'Z' + 1)}{rnd.Next(100, 999)}";
    }

    static void CrearNave()
    {
        for (int i = 0; i < 10; i++)
        {
            string nombre;
            do
            {
                nombre = GenerarNombre();
            } while (listaNaves.Exists(n => n.nombre == nombre));

            listaNaves.Add(new Naves { nombre = nombre });
        }

        Console.WriteLine("10 naves creadas exitosamente.");
    }

    static void CambiarNave()
    {
        ListarNaves();
        Console.Write("Ingrese el número de la nave a cambiar: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < listaNaves.Count)
        {
            Console.Write("Ingrese el nuevo nombre: ");
            listaNaves[index] = new Naves { nombre = Console.ReadLine() };
            Console.WriteLine("Nombre cambiado con éxito.");
        }
        else
        {
            Console.WriteLine("Índice fuera de rango.");
        }
    }

    static void VerNaves()
    {
        Console.WriteLine("\nNaves fabricadas:");
        foreach (var nave in listaNaves)
        {
            Console.WriteLine(nave.nombre);
        }
    }

    static void EliminarTodasNaves()
    {
        listaNaves.Clear();
        Console.WriteLine("Todas las naves han sido eliminadas.");
    }

    static void EliminarNave()
    {
        ListarNaves();
        Console.Write("Ingrese el número de la nave a eliminar: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < listaNaves.Count)
        {
            listaNaves.RemoveAt(index);
            Console.WriteLine("Nave eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("Índice fuera de rango.");
        }
    }

    static void ListarNaves()
    {
        Console.WriteLine("\nLista de naves:");
        for (int i = 0; i < listaNaves.Count; i++)
        {
            Console.WriteLine($"{i}: {listaNaves[i].nombre}");
        }
    }

    static void MoverNavesAPila()
    {
        pilaNaves.Clear();
        foreach (var nave in listaNaves)
        {
            pilaNaves.Push(nave);
        }
        listaNaves.Clear();
        Console.WriteLine("Todas las naves han sido movidas a la pila.");
    }

    static void MostrarPila()
    {
        if (pilaNaves.Count == 0)
        {
            Console.WriteLine("La pila está vacía.");
            return;
        }

        Console.WriteLine("\nNaves en la pila:");
        foreach (var nave in pilaNaves)
        {
            Console.WriteLine(nave.nombre);
        }
    }
}
