﻿using System;

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
				Console.WriteLine("Nombre de la película " + (i + 1) + ":");
				lista[i].nombre = Console.ReadLine();
				EscribeYLeeDouble("Costo boleto de adulto para la película " + (i + 1) + ":", "ERROR: TU COSTO NO PUEDE SER NEGATIVO Y DEBE SER UN NÚMERO.", out lista[i].costoAdulto, 0, double.MaxValue);
				EscribeYLeeDouble("Costo boleto de menores para la película " + (i + 1) + ":", "ERROR: TU COSTO NO PUEDE SER NEGATIVO Y DEBE SER UN NÚMERO.", out lista[i].costoMenores, 0, double.MaxValue);
			}


		}

		// ===== FASE 2 =====
		static void Ventas(DatosPelicula[] listas)
		{
			int cant, peliculas, clientes, boletos;
			double tot = 0, max = -1, min = 10000;
			for (int i = 0; i < listas.Length; i++)
			{
				Console.WriteLine();
				EscribeYLeeInt("¿Cuántas peliculas son?", 
					"ERROR: La cantidad de películas debe ser mayor a cero y un número", 
					out peliculas, 1, int.MaxValue);

				Console.WriteLine();

				EscribeYLeeInt("¿Cuantos boletos fueron vendidos a menores?", 
					"ERROR: La cantidad de boletos debe ser no negativa y un número", 
					out listas[i].boletosVendidosMenores, 0, int.MaxValue);

				Console.WriteLine();

				EscribeYLeeInt("¿Cuantos boletos fueron vendidos a adultos?", 
					"ERROR: La cantidad de boletos debe ser no negativa y un número", 
					out listas[i].boletosVendidosAdulto, 0, int.MaxValue);

				for (int cont = 0; cont < peliculas; cont++)
				{
					Console.WriteLine();
					EscribeYLeeInt("¿Cuántos boletos se vendieron en la pelicula" + listas[i].nombre + "?", 
						"ERROR: La cantidad de boletos debe ser no negativa y un número", out cant, 0, int.MaxValue);
				}
				Console.WriteLine("La pelicula con menor ventas fue la de: " + listas[i].nombre + "con la cantidad de " + min + "boletos");
				Console.WriteLine("La pelicula con mayor ventas fue la de: " + listas[i].nombre + "con la cantidad de " + max + "boletos");
				tot = listas[i].boletosVendidosAdulto + listas[i].boletosVendidosMenores;
				Console.WriteLine("El total de boletos vendidos en todas las peliculas fue de " + tot);

				Console.WriteLine("¿Cuantos clientes son?");
				clientes = int.Parse(Console.ReadLine());
				for (int j = 0; j < clientes; j++)
				{
					Console.WriteLine("¿Cuantos boletos va a comprar el cliente" + j + 1 + "?");
					boletos = int.Parse(Console.ReadLine());
					if (boletos >= 3)
					{
						listas[i].dineroDescontado = listas[i].costoMenores - (listas[i].costoMenores * 0.30);
					}
				}
			}
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
	10) Mostrar la cantidad de boletos vendidos
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
						EscribeDatosPelicula(BoletosMenores(tabla), true);
						break;
					case 9: // 9)	Mostrar cantidad de boletos vendidos a adultos // Uribe
						EscribeDatosPelicula(BoletosAdultos(tabla), true);
						break;
					case 10: // 10) Mostrar la cantidad de boletos vendidos
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
						return;
					default:
						break;
				}
				Console.WriteLine();
			} while(opcion != 12);

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
		static DatosPelicula BoletosMenores(DatosPelicula[] lista)
		{
			int total = 0;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				total = total + lista[i].boletosVendidosMenores;
			}
			return DatosPelicula;
		}

		//case 9
		static DatosPelicula BoletosAdultos(DatosPelicula[] lista)
		{
			int total = 0;
			DatosPelicula DatosPelicula = lista[0];
			for (int i = 0; i < lista.Length; i++)
			{
				total = total + lista[i].boletosVendidosAdulto;
			}
			return DatosPelicula;
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
				Console.WriteLine("\t\tPelícula\t\tCosto Adulto\t\tCosto Menor\t\tBoletos Adulto\t\tBoletos Menores\t\tDescontado");

			Console.WriteLine(ResultadosPelicula(pelicula));
		}

		static string ResultadosPelicula(DatosPelicula pelicula)
        {
			string fila = "\t\t" + pelicula.nombre;
			fila += "\t\t$" + pelicula.costoAdulto;
			fila += "\t\t$" + pelicula.costoMenores;
			fila += "\t\t" + pelicula.boletosVendidosAdulto;
			fila += "\t\t" + pelicula.boletosVendidosMenores;
			fila += "\t\t$" + pelicula.dineroDescontado;

			return fila;
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
					Console.WriteLine(textoError);
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
					Console.WriteLine(textoError);
			} while (continuar);
		}
	}
}
