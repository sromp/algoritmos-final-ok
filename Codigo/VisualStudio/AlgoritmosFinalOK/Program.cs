using System;

namespace AlgoritmosFinalOK
{
	class Program
	{
		struct DatosPelicula
		{
			public string nombre;
			public double costoAdulto;
			public double costoMenores;
			public int boletosVendidosMenores;
			public int boletosVendidosAdulto;
			public double dineroDescontado;

		}

		static void Main(string[] args)
		{
			int n;
			EscribeYLeeInt("Cantidad de películas:", "ERROR: TU CANTIDAD NO PUEDE SER NEGATIVA Y DEBE SER UN NÚMERO.", out n, 0, int.MaxValue);
			DatosPelicula[] datosPeliculas = new DatosPelicula[n];

			Console.WriteLine("\n\n\n ==== FASE 1. LLENADO DE DATOS DE LA CARTELERA ==== ");
			DatosCartelera(datosPeliculas);
			Console.WriteLine("\n\n\n ==== FASE 2. LLENADO DE DATOS DE VENTAS ==== ");
			Ventas(datosPeliculas);
			Console.WriteLine("\n\n\n ==== FASE 3. REPORTE DE INFORMACIÓN ==== ");
			MuestraResultados(datosPeliculas);

			Console.WriteLine("\n\n\n ==== ¡HASTA LUEGO! ==== ");
			Console.ReadLine();
		}

		// ===== FASE 1 =====
		static void DatosCartelera(DatosPelicula[] lista)
		{
			for (int i = 0; i < lista.Length; i++)
			{
				lista[i].nombre = ValidacionNombrePelicula("Escribe el nombre de la película " + (i + 1) + ":", lista, i);
				EscribeYLeeDouble("Escribe el costo del boleto de adulto para la película " + (i + 1) + ":", "ERROR: TU COSTO NO PUEDE SER NEGATIVO Y DEBE SER UN NÚMERO.", out lista[i].costoAdulto, 0, double.MaxValue);
				EscribeYLeeDouble("Escribe el costo del boleto de menores para la película " + (i + 1) + ":", "ERROR: TU COSTO NO PUEDE SER NEGATIVO Y DEBE SER UN NÚMERO.", out lista[i].costoMenores, 0, double.MaxValue);
				lista[i].boletosVendidosAdulto = 0;
				lista[i].boletosVendidosMenores = 0;
				lista[i].dineroDescontado = 0;
			}


		}

		// UTILIDADES FASE 1
		static string ValidacionNombrePelicula(string mensaje, DatosPelicula[] peliculas, int indice)
		{
			string nombre;
			bool nombreValido;

			do
			{
				nombreValido = true;

				Console.WriteLine(mensaje);

				nombre = Console.ReadLine();

				if (nombre.Replace(" ", "") == "")
				{
					Console.WriteLine("ERROR: El nombre de la película no puede quedar en blanco");
					nombreValido = false;
					continue;
				}

				for (int i = 0; i < indice; i++)
				{
					if (nombre.ToLower().Replace(" ", "") == peliculas[i].nombre.ToLower().Replace(" ", ""))
					{
						Console.WriteLine("ERROR: El nombre de la película no puede repetirse exactamente, de ser una versión distinta se debe diferenciar en el nombre");
						nombreValido = false;
						continue;
					}
				}

			} while(!nombreValido);

			return nombre;
			
		}

		// ===== FASE 2 =====
		static void Ventas(DatosPelicula[] listas)
		{
			int clientes;

			EscribeYLeeInt("¿Cuantos clientes son?", 
				"ERROR: Debe de haber por lo menos un cliente y debe ser un número", 
				out clientes, 1, int.MaxValue);
			
			for (int j = 0; j < clientes; j++)
			{
				int boletosAdulto, boletosMenores, indicePelicula;
				double ventaAdulto, ventaMenor, descontado;

				indicePelicula = IndicePeliculaPorNombre(listas, "Escribe el nombre de la película que va ver el cliente [" + (j+1) + "]");

				EscribeYLeeInt("¿Cuantos boletos de adulto va a comprar el cliente [" + (j + 1) + "]?",
					"ERROR: La cantidad de boletos no puede ser negativa y debe ser un número", 
					out boletosAdulto, 0, int.MaxValue);

				EscribeYLeeInt("¿Cuantos boletos de menor va a comprar el cliente [" + (j + 1) + "]?",
					"ERROR: La cantidad de boletos no puede ser negativa y debe ser un número",
					out boletosMenores, 0, int.MaxValue);

				ventaAdulto = listas[indicePelicula].costoAdulto * boletosAdulto;
				ventaMenor = listas[indicePelicula].costoMenores * boletosMenores;

				if (boletosAdulto + boletosMenores >= 3 && boletosMenores >= 1)
					descontado = ventaMenor * 0.30;
				else
					descontado = 0;

				listas[indicePelicula].dineroDescontado += descontado;
				listas[indicePelicula].boletosVendidosAdulto += boletosAdulto;
				listas[indicePelicula].boletosVendidosMenores += boletosMenores;

				Console.WriteLine("\nDESGLOSE CLIENTE: ");
				Console.WriteLine("Boletos menores: " + boletosMenores);
				Console.WriteLine("Boletos adultos: " + boletosAdulto);
				Console.WriteLine("Venta menores (sin contar descuento): $" + ventaMenor);
				Console.WriteLine("Venta adultos: $" + ventaAdulto);
				Console.WriteLine("Venta total: $" + (ventaAdulto + ventaMenor));
				Console.WriteLine("Descontado: $" + descontado);
				Console.WriteLine("Película: " + listas[indicePelicula].nombre);
				Console.WriteLine("\n\n");
			}
		}

		// UTILIDADES FASE 2
		static int IndicePeliculaPorNombre(DatosPelicula[] peliculas, string mensaje)
		{
			string nombre;
			int indiceEncontrado = -1; // -1 es el valor asignado si no se encuentra nada
			bool encontrado = false;

			do
			{
				Console.WriteLine("\n" + mensaje);
				nombre = Console.ReadLine();

				for (int i = 0; i < peliculas.Length; i++)
				{
					if (peliculas[i].nombre.ToLower().Replace(" ", "") == nombre.ToLower().Replace(" ", ""))
					{
						indiceEncontrado = i;
					}
				}

				if (indiceEncontrado == -1)
					Console.WriteLine("No se encontró esa película");
				else
					encontrado = true;
			} while(!encontrado);

			return indiceEncontrado;
		}

		// ===== FASE 3 =====
		static void MuestraResultados(DatosPelicula[] tabla)
		{
			string menuReporte = @"ESCRIBE EL NÚMERO DE LA OPCIÓN DESEADA
	1)	Mostrar ventas en de todas las peliculas como tabla
	2)	Mostrar datos de una sóla película
	3)	Mostrar datos de las peliculas que contengan en su título un texto
	4)	Mostrar película con más boletos vendidos
	5)	Mostrar película con menos boletos vendidos
	6)	Mostrar película con mayores recaudaciones (tras descuentos)
	7)	Mostrar película con menores recaudaciones (tras descuentos)
	8)	Mostrar cantidad de boletos vendidos a menores
	9)	Mostrar cantidad de boletos vendidos a adultos
	10)	Mostrar la cantidad de boletos vendidos
	11)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta
	12)	Mostrar película con la mayor cantidad de dinero descontado
	13)	Mostrar película con la menor cantidad de dinero descontado
	14)	Salir";

			int opcion;

			do
			{
				EscribeYLeeInt(menuReporte, "ERROR: Esa no es una opción válida", out opcion, 1, 14);
				Console.WriteLine();
				switch (opcion)
				{
					case 1: // 1)	Mostrar ventas en de todas las peliculas como tabla // Romero
						EscribeTablaPeliculas(tabla);
						break;
					case 2: // 2)	Mostrar datos de una sóla película // Romero
						BuscaPeliculaNombreExacto(tabla);
						break;
					case 3: // 3)	Mostrar datos de las peliculas que contengan en su título un texto // Romero
						BuscaPeliculaQueContenganTexto(tabla);
						break;
					case 4: // 4)	Mostrar película con más boletos vendidos // Uribe
						EscribeDatosPelicula(PeliculaMasVendida(tabla), true);
						break;
					case 5: // 5)	Mostrar película con menos boletos vendidos // Uribe
						EscribeDatosPelicula(PeliculaMenosVendida(tabla), true);
						break;
					case 6: // 6)	Mostrar película con mayores recaudaciones (tras descuentos) // Uribe	(recaudaciones = boletosAdulto*costoBoletoAdulto + boletosMenor*costoBoletoMenor - descuentos) // funcion (arregloPeliculas) --> (datoPelicula)
						EscribeDatosPelicula(PeliculaMasRecaudaciones(tabla), true);
						break;
					case 7: // 7)	Mostrar película con menores recaudaciones (tras descuentos) // Uribe
						EscribeDatosPelicula(PeliculaMenosRecaudaciones(tabla), true);
						break;
					case 8: // 8)	Mostrar cantidad de boletos vendidos a menores // Uribe
						Console.WriteLine("Se vendieron " + BoletosMenores(tabla) + " boletos a menores");
						break;
					case 9: // 9)	Mostrar cantidad de boletos vendidos a adultos // Uribe
						Console.WriteLine("Se vendieron " + BoletosAdultos(tabla) + " boletos a adultos");
						break;
					case 10: // 10) Mostrar la cantidad de boletos vendidos
						Console.WriteLine("Se vendieron " + BoletosTotales(tabla) + " boletos en total");
						break;
					case 11: // 11)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta // Romero
						CobroDescuentosGanancia(tabla);
						break;
					case 12: // 12)	Mostrar película con la mayor cantidad de dinero descontado // Romero
						EscribeDatosPelicula(MayorDescuento(tabla), true);
						break;
					case 13: // 13)	Mostrar película con la menor cantidad de dinero descontado // Romero
						EscribeDatosPelicula(MenorDescuento(tabla), true);
						break;
					case 14: // 14)	Salir
						break;
					default:
						break;
				}
				Console.WriteLine();
			} while(opcion != 14);

		}

		// FUNCIONES FASE 3
		//case 1
		static void EscribeTablaPeliculas(DatosPelicula[] peliculas)
		{
			for (int i = 0; i < peliculas.Length; i++)
			{
				EscribeDatosPelicula(peliculas[i], i == 0);
			}
		}

		//case 2
		static void BuscaPeliculaNombreExacto(DatosPelicula[] peliculas)
		{
			string nombre;
			DatosPelicula pelicula = peliculas[0]; // Asignado a cero para evitar error de valor no asignado
			bool encontrado = false;

			Console.WriteLine("\nEscribe el nombre de la película");
			nombre = Console.ReadLine();

			for(int i = 0; i < peliculas.Length; i++)
			{
				if(peliculas[i].nombre.ToLower().Replace(" ", "") == nombre.ToLower().Replace(" ", ""))
				{
					pelicula = peliculas[i];
					encontrado = true;
				}
			}

			if(!encontrado)
				Console.WriteLine("No se encontró esa película");
			else
				EscribeDatosPelicula(pelicula, true);
		}

		//case 3
		static void BuscaPeliculaQueContenganTexto(DatosPelicula[] peliculas)
		{
			string texto;
			DatosPelicula[] peliculasEncontradas = new DatosPelicula[peliculas.Length];
			int encontrados = 0;
			
			Console.WriteLine("\nEscribe el texto que debe contener el nombre de la película");
			texto = Console.ReadLine().ToLower().Replace(" ", "");

			for (int i = 0; i < peliculas.Length; i++)
			{
				if (peliculas[i].nombre.ToLower().Replace(" ", "").Contains(texto))
				{
					peliculasEncontradas[encontrados] = peliculas[i];
					encontrados++;
				}
			}

			if (encontrados == 0)
				Console.WriteLine("No se encontró película que contenga ese texto");
			else
			{
				for(int i = 0; i < encontrados; i++)
				{
					EscribeDatosPelicula(peliculasEncontradas[i], i == 0);
				}
			}
		}

		//case 4
		static DatosPelicula PeliculaMasVendida(DatosPelicula[] lista)
		{
			double max = -1;
			int total = 0;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				total = lista[i].boletosVendidosAdulto + lista[i].boletosVendidosMenores;
				if (total > max)
				{
					max = total;
					DatosPelicula = lista[i];
				}
			}
			return DatosPelicula;
		}

		//case 5
		static DatosPelicula PeliculaMenosVendida(DatosPelicula[] lista)
		{
			double min = double.MaxValue;
			int total = 0;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				total = lista[i].boletosVendidosAdulto + lista[i].boletosVendidosMenores;
				if (total < min)
				{
					min = total;
					DatosPelicula = lista[i];
				}
			}
			return DatosPelicula;
		}

		//case 6
		static DatosPelicula PeliculaMasRecaudaciones(DatosPelicula[] lista)
		{
			double recaudaciones, max = -1;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				recaudaciones = (lista[i].boletosVendidosAdulto * lista[i].costoAdulto) + (lista[i].boletosVendidosMenores * lista[i].costoMenores);
				if (recaudaciones > max)
				{
					max = recaudaciones;
					DatosPelicula = lista[i];
				}
			}
			return DatosPelicula;
		}

		//case 7
		static DatosPelicula PeliculaMenosRecaudaciones(DatosPelicula[] lista)
		{
			double recaudaciones, min = double.MaxValue;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				recaudaciones = (lista[i].boletosVendidosAdulto * lista[i].costoAdulto) + (lista[i].boletosVendidosMenores * lista[i].costoMenores);
				if (recaudaciones < min)
				{
					min = recaudaciones;
					DatosPelicula = lista[i];
				}
			}
			return DatosPelicula;
		}

		//case 8
		static int BoletosMenores(DatosPelicula[] lista)
		{
			int total = 0;
			for (int i = 0; i < lista.Length; i++)
			{
				total = total + lista[i].boletosVendidosMenores;
			}
			return total;
		}

		//case 9
		static int BoletosAdultos(DatosPelicula[] lista)
		{
			int total = 0;
			for (int i = 0; i < lista.Length; i++)
			{
				total = total + lista[i].boletosVendidosAdulto;
			}
			return total;
		}

		//case 10
		static int BoletosTotales(DatosPelicula[] lista)
		{
			return BoletosAdultos(lista) + BoletosMenores(lista);
		}

		//case 11
		static void CobroDescuentosGanancia(DatosPelicula[] peliculas)
		{
			double cobroTotal = 0, descuentosTotales = 0, gananciaNeta;

			for(int i = 0; i < peliculas.Length; i++)
			{
				cobroTotal += (peliculas[i].costoAdulto * peliculas[i].boletosVendidosAdulto) 
					+ (peliculas[i].costoMenores * peliculas[i].boletosVendidosMenores);

				descuentosTotales += peliculas[i].dineroDescontado;
			}

			gananciaNeta = cobroTotal - descuentosTotales;

			Console.WriteLine("Cobro total (no tomando descuentos en cuenta): $" + cobroTotal);
			Console.WriteLine("Dinero aplicado en descuentos: $" + descuentosTotales);
			Console.WriteLine("Ganancia neta: $" + gananciaNeta);
		}

		//case 12
		static DatosPelicula MayorDescuento(DatosPelicula[] peliculas)
		{
			DatosPelicula mayorDescuento = peliculas[0];

			for (int i = 1; i < peliculas.Length; i++)
			{
				if (peliculas[i].dineroDescontado > mayorDescuento.dineroDescontado)
					mayorDescuento = peliculas[i];
			}
			return mayorDescuento;
		}

		//case 13
		static DatosPelicula MenorDescuento(DatosPelicula[] peliculas)
		{
			DatosPelicula menorDescuento = peliculas[0];

			for (int i = 1; i < peliculas.Length; i++)
			{
				if (peliculas[i].dineroDescontado < menorDescuento.dineroDescontado)
					menorDescuento = peliculas[i];
			}
			return menorDescuento;
		}



		// UTILIDADES FASE 3
		static void EscribeDatosPelicula(DatosPelicula pelicula, bool encabezado)
		{
			if (encabezado)
				Console.WriteLine(FormatearFilaTabla("Nombre de la película", "Costo Adulto", "Costo Menor", "Boletos Adulto", "Boletos Menores", "Recaudado Adulto", "Recaudado Menor", "Recaudado Total", "Descuento", "Ganancia Total"
					, 40, 20, 20, 20, 20, 20, 20, 20, 20, 20));

			Console.WriteLine(ResultadosPelicula(pelicula, 40, 20, 20, 20, 20, 20, 20, 20, 20, 20));
		}

		static string ResultadosPelicula(DatosPelicula pelicula, int charsNombre, int charsCostoAdulto, int charsCostoMenores, int charsBoletosAdulto, int charsBoletosMenores, int charsRecaudadoAdulto, int charsRecaudadoMenor, int charsRecaudadoTotal, int charsDescuento, int charsTotal)
		{
			string nombre =  pelicula.nombre;
			string costoAdulto = "$" + pelicula.costoAdulto;
			string costoMenores = "$" + pelicula.costoMenores;
			string boletosAdulto = "" + pelicula.boletosVendidosAdulto;
			string boletosMenores = "" + pelicula.boletosVendidosMenores;
			string recaudadoAdulto = "$" + (pelicula.costoAdulto * pelicula.boletosVendidosAdulto);
			string recaudadoMenor = "$" + (pelicula.costoMenores * pelicula.boletosVendidosMenores);
			string recaudadoTotal = "$" + ((pelicula.costoAdulto * pelicula.boletosVendidosAdulto) + (pelicula.costoMenores * pelicula.boletosVendidosMenores));
			string descuento = "$" + pelicula.dineroDescontado;
			string total = "$" + ((pelicula.costoAdulto * pelicula.boletosVendidosAdulto) + (pelicula.costoMenores * pelicula.boletosVendidosMenores) - pelicula.dineroDescontado);


			return FormatearFilaTabla(nombre, costoAdulto, costoMenores, boletosAdulto, boletosMenores, recaudadoAdulto, recaudadoMenor, recaudadoTotal, descuento, total,
				charsNombre, charsCostoAdulto, charsCostoMenores, charsBoletosAdulto, charsBoletosMenores, charsRecaudadoAdulto, charsRecaudadoMenor, charsRecaudadoTotal, charsDescuento, charsTotal);
		}

		static string FormatearFilaTabla(string nombre, string costoAdulto, string costoMenores, string boletosAdulto, string boletosMenores, string recaudadoAdulto, string recaudadoMenor, string recaudadoTotal, string descuento, string total, int charsNombre, int charsCostoAdulto, int charsCostoMenores, int charsBoletosAdulto, int charsBoletosMenores, int charsRecaudadoAdulto, int charsRecaudadoMenor, int charsRecaudadoTotal, int charsDescuento, int charsTotal)
        {
			string textoVacio = "                                                                                                  ";
			nombre += textoVacio;
			costoAdulto += textoVacio;
			costoMenores += textoVacio;
			boletosAdulto += textoVacio;
			boletosMenores += textoVacio;
			recaudadoAdulto += textoVacio;
			recaudadoMenor += textoVacio;
			recaudadoTotal += textoVacio;
			descuento += textoVacio;
			total += textoVacio;

			nombre = nombre.Substring(0, charsNombre);
			costoAdulto = costoAdulto.Substring(0, charsCostoAdulto);
			costoMenores = costoMenores.Substring(0, charsCostoMenores);
			boletosAdulto = boletosAdulto.Substring(0, charsBoletosAdulto);
			boletosMenores = boletosMenores.Substring(0, charsBoletosMenores);
			recaudadoAdulto = recaudadoAdulto.Substring(0, charsRecaudadoAdulto);
			recaudadoMenor = recaudadoMenor.Substring(0, charsRecaudadoMenor);
			recaudadoTotal = recaudadoTotal.Substring(0, charsRecaudadoTotal);
			descuento = descuento.Substring(0, charsDescuento);
			total = total.Substring(0, charsTotal);

			return nombre + costoAdulto + costoMenores + boletosAdulto + boletosMenores + recaudadoAdulto + recaudadoMenor + recaudadoTotal + descuento + total;
		}


		// ===== UTILIDADES =====
		static void EscribeYLeeInt(string textoPedir, string textoError, out int resultado, int resultadoMayorIgualQue, int resultadoMenorIgualQue)
		{
			bool continuar = true;

			do
			{
				Console.WriteLine(textoPedir);
				if (int.TryParse(Console.ReadLine(), out resultado) && resultado >= resultadoMayorIgualQue && resultado <= resultadoMenorIgualQue)
					continuar = false;
				else
					Console.WriteLine("\t" + textoError);
			} while (continuar);
		}

		static void EscribeYLeeDouble(string textoPedir, string textoError, out double resultado, double resultadoMayorIgualQue, double resultadoMenorIgualQue)
		{
			bool continuar = true;

			do
			{
				Console.WriteLine(textoPedir);
				if (double.TryParse(Console.ReadLine(), out resultado) && resultado >= resultadoMayorIgualQue && resultado <= resultadoMenorIgualQue)
					continuar = false;
				else
					Console.WriteLine("\t" + textoError);
			} while (continuar);
		}
	}
}
