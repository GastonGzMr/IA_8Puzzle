using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    public class Resolvedor
    {
        public Heuristica Heuristica { get; set; }

        public Resolvedor(Heuristica heuristica)
        {
            Heuristica = heuristica;
        }

        public ICollection<Estado> Resolver(Estado estadoInicial, Estado estadoFinal)
        {
            List<Estado> estadosSinExpandir = new List<Estado>();
            List<Estado> secuenciaSolucion = new List<Estado>();
            List<Estado> estadosExpandidos = new List<Estado>();

            Estado estadoSinExpandir = estadoInicial;
            estadosExpandidos.Add(estadoInicial);
            int distancias = Heuristica.ObtenerDistancias(estadoSinExpandir, estadoFinal);
            while (distancias != 0)
            {
                foreach (Estado estado in ExpandirEstado(estadoSinExpandir))
                {
                    if ((estado != null) && (estadosExpandidos.Count(x => x.IgualA(estado.EstadoDeLaPlaca)) == 0))
                    {
                        estadosSinExpandir.Add(estado);
                    }
                }
                estadosSinExpandir = estadosSinExpandir.OrderBy(x => Heuristica.ObtenerDistancias(x, estadoFinal)).ToList();
                estadoSinExpandir = estadosSinExpandir.First();
                estadosSinExpandir.Remove(estadoSinExpandir);
                estadosExpandidos.Add(estadoSinExpandir);
                distancias = Heuristica.ObtenerDistancias(estadoSinExpandir,estadoFinal);
            }

            Estado estadoSiguiente = estadoSinExpandir;
            while (estadoSiguiente != null)
            {
                secuenciaSolucion.Add(estadoSiguiente);
                estadoSiguiente = estadoSiguiente.Padre;
            }

            secuenciaSolucion.Reverse();
            return secuenciaSolucion;
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
    }
}
