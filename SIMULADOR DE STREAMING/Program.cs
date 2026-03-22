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
                    int tipo, duracion, clasificacion, hora, produccion;

                    Console.WriteLine("Tipo de contenido:");
                    Console.WriteLine("1. Pelicula");
                    Console.WriteLine("2. Serie");
                    Console.WriteLine("3. Documental");
                    Console.WriteLine("4. Eveneto en vivo");
                    tipo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Duracion en minutos:");
                    duracion = int.Parse(Console.ReadLine());

                    Console.WriteLine("Clasificacion:");
                    Console.WriteLine("1. Todo publico");
                    Console.WriteLine("2. +13");
                    Console.WriteLine("3. +18");
                    clasificacion = int.Parse(Console.ReadLine());

                    Console.WriteLine("Hora de visualizacion (0-23):");
                    hora = int.Parse(Console.ReadLine());

                    Console.WriteLine("Nivel de produccion:");
                    Console.WriteLine("1. Bajo");
                    Console.WriteLine("2. Medio");
                    Console.WriteLine("3. Alto");
                    produccion = int.Parse(Console.ReadLine());

                    bool aprobado = true;

                    //Regla de horario
                    if (clasificacion == 2)
                    {
                        if (hora < 6 || hora > 22)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: +13 solo entre 6 y 22 horas");
                        }
                    }

                    if (clasificacion == 3)
                    {
                        if (hora >= 6 && hora <= 21)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: +18 solo entre 22 y 5 horas");
                        }
                    }

                    //Regla de duracion - De pelicula
                    if (tipo == 1)
                    {
                        if (duracion < 60 || duracion > 180)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Peliculas deben durar entre 60 y 180 minutos");
                        }
                    }

                    if (tipo == 2)
                    {
                        if (duracion < 20 || duracion > 90)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Series deben durar entre 20 y 90 minutos");
                        }
                    }

                    if (tipo == 3)
                    {
                        if (duracion < 30 || duracion > 120)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Documentales deben durar entre 30 y 120 minutos");
                        }
                    }

                    if (tipo == 4)
                    {
                        if (duracion < 30 || duracion > 240)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Eventos en vivo deben durar entre 30 y 240 minutos");
                        }
                    }
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