public class Estadisticas
{
    // 12 meses x 100 contactos
    public int[,] Llamadas = new int[12, 100];

    public void RegistrarLlamada(int mes, int indiceContacto)
    {
        if (mes >= 0 && mes < 12 &&
            indiceContacto >= 0 && indiceContacto < 100)
        {
            Llamadas[mes, indiceContacto]++;
        }
    }

    public void MostrarLlamadasContacto(int indiceContacto)
    {
        Console.WriteLine("\nHistorial de llamadas:");

        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine(
                $"Mes {i + 1}: {Llamadas[i, indiceContacto]} llamadas");
        }
    }
}