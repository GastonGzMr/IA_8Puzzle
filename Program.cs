using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Estado estadoInicial = new Estado(new int[][]{new int[] { 1, 3, 4 },
                                                          new int[] { 7, 2, 0 },
                                                          new int[] { 6, 8, 5 }});
            int[][] estadoFinal = new int[][] {new int[] { 1, 2, 3 },
                                               new int[] { 8, 0, 4 },
                                               new int[] { 7, 6, 5 }};
            
            List<Estado> estadosSinExpandir = new List<Estado>();
            List<Estado> secuenciaSolucion = new List<Estado>();
            List<Estado> estadosExpandidos = new List<Estado>();

            Estado estadoSinExpandir = estadoInicial;
            estadosExpandidos.Add(estadoInicial);
            int distancias = estadoSinExpandir.ObtenerDistancias(estadoFinal);
            while(distancias != 0)
            {
                foreach (Estado estado in ExpandirEstado(estadoSinExpandir))
                {
                    Console.WriteLine("Hijos:");
                    if ((estado != null) && (estadosExpandidos.Count(x => estado.ObtenerDistancias(x.EstadoDeLaPlaca) == 0) == 0))
                    {
                        estadosSinExpandir.Add(estado);
                    }
                }
                estadosSinExpandir = estadosSinExpandir.OrderBy(x => x.ObtenerDistancias(estadoFinal)).ToList();
                estadoSinExpandir = estadosSinExpandir.First();
                estadosSinExpandir.Remove(estadoSinExpandir);
                estadosExpandidos.Add(estadoSinExpandir);
                distancias = estadoSinExpandir.ObtenerDistancias(estadoFinal);
            }

            Estado estadoSiguiente = estadoSinExpandir;
            while (estadoSiguiente != null)
            {
                secuenciaSolucion.Add(estadoSiguiente);
                estadoSiguiente = estadoSiguiente.Padre;
            }

            secuenciaSolucion.Reverse();
            for (int i = 0; i < secuenciaSolucion.Count(); i++)
            {
                Console.WriteLine("Paso " + i + ":");
                estadoSiguiente = secuenciaSolucion[i];
                Escribir(estadoSiguiente.EstadoDeLaPlaca);
            }
            Console.WriteLine("Fin");
            Console.ReadLine();
        }

        static List<Estado> ExpandirEstado(Estado estado)
        {
            List<Estado> estados = new List<Estado>();
            int[][] estadoActual;
            char[] arrayDeDirecciones = { 'N', 'S', 'O', 'E' };
            foreach (char direccion in arrayDeDirecciones)
            {
                estadoActual = estado.moverCero(direccion);
                if (estadoActual != null)
                {
                    estados.Add(new Estado(estadoActual, estado));
                }
            }
            return estados;
        }

        static void Escribir(int[][] placa)
        {
            string linea;
            foreach (int[] fila in placa)
            {
                linea = "";
                foreach (int numero in fila)
                {
                    linea += " " + numero + " ";
                }
                Console.WriteLine(linea);
            }
        }
    }
}
