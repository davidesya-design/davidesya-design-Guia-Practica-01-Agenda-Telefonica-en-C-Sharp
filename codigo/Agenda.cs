public class Agenda
{
    private Contacto[] contactos = new Contacto[100];
    private int cantidad = 0;
    private int nextId = 1;

    public Estadisticas estadisticas = new Estadisticas();

    public void AgregarContacto()
    {
        Console.Write("ID (Enter para autogenerar): ");
        string? sid = Console.ReadLine();
        int id;
        if (string.IsNullOrWhiteSpace(sid))
        {
            id = nextId++;
        }
        else
        {
            while (!int.TryParse(sid, out id))
            {
                Console.Write("ID inválido. ID (Enter para autogenerar): ");
                sid = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sid))
                {
                    id = nextId++;
                    break;
                }
            }
            if (id >= nextId) nextId = id + 1;
        }

        string nombre = ReadString("Nombre: ");
        string telefono = ReadString("Teléfono: ");
        string correo = ReadString("Correo: ");

        contactos[cantidad] = new Contacto(id, nombre, telefono, correo);
        cantidad++;

        Console.WriteLine("\nContacto agregado correctamente.");
    }

    public void ListarContactos()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("No existen contactos.");
            return;
        }

        Console.WriteLine("\nLISTA DE CONTACTOS\n");

        for (int i = 0; i < cantidad; i++)
        {
            contactos[i].Mostrar();
        }
    }

    public void BuscarContacto()
    {
        string nombre = ReadString("\nIngrese nombre: ");

        bool encontrado = false;

        for (int i = 0; i < cantidad; i++)
        {
            if (contactos[i].Nombre
                .ToLower()
                .Contains(nombre.ToLower()))
            {
                contactos[i].Mostrar();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void RegistrarLlamada()
    {
        int id = ReadInt("\nID del contacto: ");

        for (int i = 0; i < cantidad; i++)
        {
            if (contactos[i].Id == id)
            {
                int mes = 0;
                do
                {
                    mes = ReadInt("Mes (1-12): ");
                } while (mes < 1 || mes > 12);

                estadisticas.RegistrarLlamada(mes - 1, i);

                Console.WriteLine("Llamada registrada.");
                return;
            }
        }

        Console.WriteLine("Contacto no encontrado.");
    }

    public void MostrarEstadisticas()
    {
        int id = ReadInt("\nID del contacto: ");

        for (int i = 0; i < cantidad; i++)
        {
            if (contactos[i].Id == id)
            {
                estadisticas.MostrarLlamadasContacto(i);
                return;
            }
        }

        Console.WriteLine("Contacto no encontrado.");
    }

    public void MostrarTopContactosPorLlamadas(int top = 5)
    {
        if (cantidad == 0)
        {
            Console.WriteLine("No existen contactos.");
            return;
        }

        var totals = new (int indice, int total)[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            int suma = 0;
            for (int m = 0; m < 12; m++) suma += estadisticas.Llamadas[m, i];
            totals[i] = (i, suma);
        }

        Array.Sort(totals, (a, b) => b.total.CompareTo(a.total));

        Console.WriteLine($"\nTop {top} contactos por llamadas:");
        for (int i = 0; i < Math.Min(top, cantidad); i++)
        {
            var t = totals[i];
            contactos[t.indice].Mostrar();
            Console.WriteLine($"Total llamadas: {t.total}\n");
        }
    }

    private int ReadInt(string prompt)
    {
        int value;
        string? s;
        do
        {
            Console.Write(prompt);
            s = Console.ReadLine();
        } while (!int.TryParse(s, out value));
        return value;
    }

    private string ReadString(string prompt)
    {
        string? s;
        do
        {
            Console.Write(prompt);
            s = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(s));
        return s!;
    }
}