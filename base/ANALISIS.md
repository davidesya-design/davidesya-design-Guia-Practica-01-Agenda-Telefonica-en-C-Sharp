Análisis de estructuras usadas

Sistema: Agenda telefónica

Estructuras utilizadas:
- Vector (`Contacto[] contactos`): arreglo con tamaño fijo (100) para almacenar contactos.
- Matriz (`int[,] Llamadas`): matriz 12x100 para registrar llamadas por mes y contacto.

Ventajas:
- Simplicidad: implementaciones y acceso O(1) por índice.
- Bajo overhead: estructuras nativas de C# son eficientes.

Desventajas:
- Tamaño fijo: limita a 100 contactos; habría que redimensionar o usar listas dinámicas.
- Uso de matriz 12x100 desperdicia espacio si hay pocos contactos.

Alternativas:
- `List<Contacto>` para tamaño dinámico.
- `Dictionary<int, Contacto>` para búsquedas por ID más rápidas.
