class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al Simulador de plataforma de Streaming");

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
            Console.WriteLine("1. Evaluar el contenido");
            Console.WriteLine("2. Ver reglas");
            Console.WriteLine("3. Ver estadisticas");
            Console.WriteLine("4. Reiniciar estadisticas");
            Console.WriteLine("5. Salir...");
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
                    Console.WriteLine("2. +13 años");
                    Console.WriteLine("3. +18 años");
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

                    //ACTUALIZAR LAS ESTADISTICAS
                    totalevaluados++;

                    if (aprobado)
                    {
                        totalpublicados++;
                    }
                    else
                    {
                        totalrechazados++;
                    }

                    if (impacto == "Alto")
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

                    //Todas son las reglas de horarios
                case 2:
                    Console.WriteLine("Reglas de evaluacion:");
                    Console.WriteLine("Horarios:"); 
                    Console.WriteLine(" Todo publico: Sin restricciones de horario");
                    Console.WriteLine(" +13 años: Solo entre 6 y 22 horas");
                    Console.WriteLine(" +18: entre 22 y 5 horas");
                    Console.WriteLine("Duracion:");
                    Console.WriteLine(" Peliculas: entre 60 a 180 minutos");
                    Console.WriteLine(" Series: entre 20 a 90 minutos");
                    Console.WriteLine(" Documentales: entre 30 a 120 minutos");
                    Console.WriteLine(" Eventos en vivo: entre 30 a 240 minutos");
                    Console.WriteLine("Produccion:");
                    Console.WriteLine(" Baja: Solo para todo publico o +13");
                    Console.WriteLine(" Media y Alta: Cualquier clasificacion");
                    break;

                //Este case muestra las estadisticas del programa
                case 3:
                    Console.WriteLine("Estadisticas:");
                    Console.WriteLine("Total evaluados: " + totalevaluados);
                    Console.WriteLine("Total publicados: " + totalpublicados);
                    Console.WriteLine("Total rechazados: " + totalrechazados);
                    Console.WriteLine("Total en revision: " + totalrevision);
                    Console.WriteLine("Impacto alto: " + impactoalto);
                    Console.WriteLine("Impacto medio: " + impactomedio);
                    Console.WriteLine("Impacto bajo: " + impactobajo);
                    break;
                // Reiniciar estadisticas del programa y pone todas las variables en 0 otra vez
                case 4:
                    totalevaluados = 0;
                    totalpublicados = 0;
                    totalrechazados = 0;
                    totalrevision = 0;
                    impactobajo = 0;
                    impactomedio = 0;
                    impactoalto = 0;
                    Console.WriteLine("Estadisticas reiniciadas");
                    break;

                case 5:
                    
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != 5);
    }
}