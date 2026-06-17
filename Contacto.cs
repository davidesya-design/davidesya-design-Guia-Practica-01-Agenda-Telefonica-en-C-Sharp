public record Contacto(int Id, string Nombre, string Telefono, string Correo)
{
    public void Mostrar()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Correo: {Correo}");
        Console.WriteLine("---------------------------");
    }
}