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
			DatosPelicula[] datosPeliculas = new DatosPelicula[1]; // CAMBIAR ESTO PARA LLENAR COMO QUIERA EL USUARIO Y DEFINIR TAMAÑO

			DatosCartelera(datosPeliculas);

			MuestraResultados(datosPeliculas);

			Console.WriteLine("Hello World!");
		}

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

		static void MuestraResultados(DatosPelicula[] tabla)
		{
			string opciones = @"ESCRIBE EL NÚMERO DE LA OPCIÓN DESEADA
	1)	Mostrar ventas en de todas las peliculas como tabla
	2)	Mostrar datos de una sóla película
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
				EscribeYLeeInt(opciones, "ERROR: Esa no es una opción válida", out opcion, 1, 12);

				switch (opcion)
				{
					case 1:
						break;
					case 2:
						break;
					case 3:
						break;
					case 4:
						break;
					case 5:
						break;
					case 6:
						break;
					case 7:
						break;
					case 8:
						break;
					case 9:
						break;
					case 10:
						break;
					case 11:
						break;
					case 12:
						break;
					default:
						break;
				}

			} while(opcion != 12);

		}

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
