class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la plataforma de Streaming");

        int opcion;

        do
        {
            Console.WriteLine("1. Evaluar contenido");
            Console.WriteLine("2. Ver reglas");
            Console.WriteLine("3. Ver estadisticas");
            Console.WriteLine("4. Reiniciar estadisticas");
            Console.WriteLine("5. Salir");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Evaluando contenido...");
                    break;
                case 2:
                    Console.WriteLine("Mostrando reglas...");
                    break;
                case 3:
                    Console.WriteLine("Mostrando estadisticas...");
                    break;
                case 4:
                    Console.WriteLine("Reiniciando estadisticas...");
                    break;
                case 5:
                    Console.WriteLine("Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != 5);
    }
}