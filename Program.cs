using System.Runtime.Serialization.Formatters;

struct Naves
{
    public string nombre;
}

class Program
{
    static Naves[] nave = new Naves[50];

    static void Main()
    {
        int option;
        do
        {
            Console.WriteLine(
                "1 Crear un bloque de 10 naves\n2 Cambiar su nombre (por índice)\n3 Ver una lista de las naves fabricadas\n4 Eliminar todas las Naves\n5 Eliminar una única Nave (por índice)\n6 Listar todas las naves\n7 Pasar todos los elementos de la lista a una pila\n8 Mostrar elementos de la pila o pila vacía"
            );
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    crearNave();
                    break;
                case 2:
                    for (int j = 0; j > 10; j++)
                    {
                        crearNave();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    listaNaves();
                    break;
            }
        } while (option != 0);
        static string generarNombre()
        {
            Random rnd = new Random();
            return $"{(char)rnd.Next('A', 'Z' + 1)}{(char)rnd.Next('A', 'Z' + 1)}{rnd.Next(100, 999)}";
        }
        static void crearNave()
        {
            string nombre = generarNombre();
            for (int i = 0; i < nave.Length; i++)
                if (nombre == nave[i].nombre)
                {
                    break;
                }
                else
                {
                    if (nave[i].nombre == null)
                    {
                        nave[i].nombre = nombre;
                    }
                }
        }
        static void listaNaves()
        {
            for (int i = 0; i < nave.Length; i++)
            {
                if (nave[i].nombre != null)
                {
                    Console.WriteLine(nave[i].nombre);
                }
            }
        }
    }
}
