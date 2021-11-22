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
