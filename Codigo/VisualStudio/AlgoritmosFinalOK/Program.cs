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

			DatosCartelera(datosPeliculas);
			Ventas(datosPeliculas);
			MuestraResultados(datosPeliculas);
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
			int cant, peliculas;
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
	10)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta
	11)	Mostrar película con la mayor cantidad de dinero descontado
	12)	Mostrar película con la menor cantidad de dinero descontado
	13)	Salir";

			int opcion;

			do
			{
				EscribeYLeeInt(menuReporte, "ERROR: Esa no es una opción válida", out opcion, 1, 12);

				switch (opcion)
				{
					case 1: // 1)	Mostrar ventas en de todas las peliculas como tabla
						EscribeTablaPeliculas(tabla);
						break;
					case 2: // 2)	Mostrar datos de una sóla película
						break;
					case 3: // 3)	Mostrar datos de las peliculas que contengan en su título un texto
						break;
					case 4: // 4)	Mostrar película con más boletos vendidos
						break;
					case 5: // 5)	Mostrar película con menos boletos vendidos
						break;
					case 6: // 6)	Mostrar película con mayores recaudaciones (tras descuentos)
						break;
					case 7: // 7)	Mostrar película con menores recaudaciones (tras descuentos)
						break;
					case 8: // 8)	Mostrar cantidad de boletos vendidos a menores
						break;
					case 9: // 9)	Mostrar cantidad de boletos vendidos a adultos
						break;
					case 10: // 10)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta
						break;
					case 11: // 11)	Mostrar película con la mayor cantidad de dinero descontado
						break;
					case 12: // 12)	Mostrar película con la menor cantidad de dinero descontado
						break;
					case 13: // 13)	Salir
						return;
					default:
						break;
				}

			} while(opcion != 12);

		}

		// UTILIDADES FASE 3
		static void EscribeTablaPeliculas(DatosPelicula[] peliculas)
        {
			for(int i = 0; i < peliculas.Length; i++)
            {
				EscribeDatosPelicula(peliculas[i], i == 0);
			}
        }

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
