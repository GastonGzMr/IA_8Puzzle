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
                                                          new int[] { 8, 6, 2 },
                                                          new int[] { 0, 7, 5 }});
            Estado estadoFinal = new Estado(new int[][]{new int[] { 1, 2, 3 },
                                                        new int[] { 8, 0, 4 },
                                                        new int[] { 7, 6, 5 }});

            List<Resolvedor> resolvedores = new List<Resolvedor>{
                new Resolvedor(new FichasMalColocadas()),
                new Resolvedor(new DistanciaManhattan())
            };
            Estado estadoSiguiente;
            DateTime inicio;

            foreach (Resolvedor resolvedor in resolvedores)
            {
                inicio = DateTime.Now;
                List<Estado> secuenciaSolucion = resolvedor.Resolver(estadoInicial, estadoFinal).ToList();
                for (int i = 0; i < secuenciaSolucion.Count(); i++)
                {
                    Console.WriteLine("Paso " + i + ":");
                    estadoSiguiente = secuenciaSolucion[i];
                    Escribir(estadoSiguiente.EstadoDeLaPlaca);
                    Console.WriteLine("Distancia: " + resolvedor.Heuristica.ObtenerDistancias(estadoSiguiente, estadoFinal));
                }
                Console.WriteLine("Heuristica "+resolvedor.Heuristica.GetType().Name+" finalizó en "+
                    DateTime.Now.Subtract(inicio).TotalMilliseconds+" milisegundos.");
                Console.ReadLine();
            }
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
