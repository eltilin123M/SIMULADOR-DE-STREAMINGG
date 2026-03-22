class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la plataforma de Streaming");

        int opcion;
        int totalevaluados = 0;
        int totalpublicados = 0;
        int totalrechazados = 0;
        int totalrevision = 0;
        int impactobajo = 0;
        int impactomedio = 0;
        int impactoalto = 0;

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
                    string impacto = "";
                    //Entrada de datos
                    //1
                    Console.WriteLine("Tipo de contenido:");
                    Console.WriteLine("1. Pelicula");
                    Console.WriteLine("2. Serie");
                    Console.WriteLine("3. Documental");
                    Console.WriteLine("4. Evento en vivo");
                    tipo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Duracion en minutos:");
                    duracion = int.Parse(Console.ReadLine());
                    //2
                    Console.WriteLine("Clasificacion:");
                    Console.WriteLine("1. Todo publico");
                    Console.WriteLine("2. +13");
                    Console.WriteLine("3. +18");
                    clasificacion = int.Parse(Console.ReadLine());

                    Console.WriteLine("Hora de visualizacion (0-23):");
                    hora = int.Parse(Console.ReadLine());
                    //3
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

                    //Duracion de series
                    if (tipo == 2)
                    {
                        if (duracion < 20 || duracion > 90)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Series deben durar entre 20 y 90 minutos");
                        }
                    }

                    //duracion de documentales
                    if (tipo == 3)
                    {
                        if (duracion < 30 || duracion > 120)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Documentales deben durar entre 30 y 120 minutos");
                        }
                    }

                    //duracion de eventos en vivo
                    if (tipo == 4)
                    {
                        if (duracion < 30 || duracion > 240)
                        {
                            aprobado = false;
                            Console.WriteLine("Error: Eventos en vivo deben durar entre 30 y 240 minutos");
                        }
                    }

                    //Regla de produccion
                    if (produccion == 1 && clasificacion == 3)
                    {
                        aprobado = false;
                        Console.WriteLine("Error: Produccion baja no permitida para +18");
                    }

                    //Resultado
                    if (aprobado)
                    {
                        Console.WriteLine("Aprobado");
                    }
                    else
                    {
                        Console.WriteLine("Rechazado ");
                    }

                    //CLASIFICACIÓN DE IMPACTO
                    if (aprobado) //impacto alto
                    {
                        if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
                        {
                            impacto = "Alto";
                        }
                        else if (produccion == 2 || (duracion > 60 && duracion <= 120)) //Impacto medio
                        {
                            impacto = "Medio";
                        }
                        else //Impacto bajo
                        {
                            impacto = "Bajo";
                        }
                        Console.WriteLine("Impacto: " + impacto);
                    }
                    //Decisión final
                    if (impacto == "Alto")
                    {
                        Console.WriteLine("Decision: Enviar a revision");
                    }
                    else if (impacto == "Medio" || impacto == "Bajo")
                    {
                        Console.WriteLine("Decision: Aprobado para publicar");
                    }

                    //Actualizar estadisticas
                    totalevaluados++;

                    if (aprobado)
                    {
                        totalpublicados++;
                    }
                    else
                    {
                        totalrechazados++;
                    }

                    if (impacto == "alto")
                    {
                        impactoalto++;
                        totalrevision++;
                    }
                    else if (impacto == "Medio")
                    {
                        impactomedio++;
                    }
                    else if (impacto == "Bajo")
                    {
                        impactobajo++;
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