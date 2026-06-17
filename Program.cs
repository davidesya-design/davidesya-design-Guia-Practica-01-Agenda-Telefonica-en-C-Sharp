using System;

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("     AGENDA TELEFÓNICA");
            Console.WriteLine("================================");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Listar contactos");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Registrar llamada");
            Console.WriteLine("5. Ver estadísticas");
            Console.WriteLine("6. Ver top contactos por llamadas");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opción: ");

            int opcionLocal;
            while (!int.TryParse(Console.ReadLine(), out opcionLocal))
            {
                Console.Write("Entrada inválida. Seleccione una opción: ");
            }
            opcion = opcionLocal;

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    agenda.AgregarContacto();
                    break;

                case 2:
                    agenda.ListarContactos();
                    break;

                case 3:
                    agenda.BuscarContacto();
                    break;

                case 4:
                    agenda.RegistrarLlamada();
                    break;

                case 5:
                    agenda.MostrarEstadisticas();
                    break;

                case 6:
                    agenda.MostrarTopContactosPorLlamadas();
                    break;

                case 7:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }
}