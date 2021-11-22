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
			Console.WriteLine("Cantidad de películas:");
			EscribeYLeeInt("Cantidad de películas:", "ERROR: TU CANTIDAD NO PUEDE SER NEGATIVA Y DEBE SER UN NÚMERO.", out n, 0, int.MaxValue);
			DatosPelicula[] datosPeliculas = new DatosPelicula[n]; // CAMBIAR ESTO PARA LLENAR COMO QUIERA EL USUARIO Y DEFINIR TAMAÑO

			DatosCartelera(datosPeliculas);

			MuestraResultados(datosPeliculas);
		}

		// FASE 1
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

		// FASE 2


		// FASE 3
		static void MuestraResultados(DatosPelicula[] tabla)
		{
			string menuReporte = @"ESCRIBE EL NÚMERO DE LA OPCIÓN DESEADA
	1)	Mostrar ventas en de todas las peliculas como tabla
	2)	Mostrar datos de una sóla película
	3)	Mostrar datos de las peliculas que contengan en su título un texto
	3)	Mostrar película con más boletos vendidos
	4)	Mostrar película con menos boletos vendidos
	5)	Mostrar película con mayores recaudaciones (tras descuentos)
	6)	Mostrar película con menores recaudaciones (tras descuentos)
	7)	Mostrar cantidad de boletos vendidos a menores
	8)	Mostrar cantidad de boletos vendidos a adultos
	9)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta
	10)	Mostrar película con la mayor cantidad de dinero descontado
	11)	Mostrar película con la menor cantidad de dinero descontado
	12)	Salir";

			int opcion;

			do
			{
				EscribeYLeeInt(menuReporte, "ERROR: Esa no es una opción válida", out opcion, 1, 12);

				switch (opcion)
				{
					case 1: // 1)	Mostrar ventas en de todas las peliculas como tabla
						break;
					case 2: // 2)	Mostrar datos de una sóla película
						break;
					case 3: // 2)	Mostrar datos de las peliculas que contengan en su título un texto
						break;
					case 4: // 3)	Mostrar película con más boletos vendidos
						break;
					case 5: // 4)	Mostrar película con menos boletos vendidos
						break;
					case 6: // 5)	Mostrar película con mayores recaudaciones (tras descuentos)
						break;
					case 7: // 6)	Mostrar película con menores recaudaciones (tras descuentos)
						break;
					case 8: // 7)	Mostrar cantidad de boletos vendidos a menores
						break;
					case 9: // 8)	Mostrar cantidad de boletos vendidos a adultos
						break;
					case 10: // 9)	Mostrar cobro total (sin descuentos), descuentos totales y ganancia neta
						break;
					case 11: // 10)	Mostrar película con la mayor cantidad de dinero descontado
						break;
					case 12: // 11)	Mostrar película con la menor cantidad de dinero descontado
						break;
					case 13: // 12)	Salir
						return;
					default:
						break;
				}

			} while(opcion != 12);

		}

		static string TablaResultados()
        {

        }


		// UTILIDADES
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
