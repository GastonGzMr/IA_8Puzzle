using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    public class DistanciaManhattan: Heuristica
    {
        public override int ObtenerDistancias(Estado estadoInicial, Estado estadoDeseado)
        {
            int distancia = 0;
            int[] posicionesEnEstadoDeseado;
            int[] posicionesEnPlaca;
            for (int i = 0; i < estadoDeseado.EstadoDeLaPlaca.Length; i++)
            {
                for (int j = 0; j < estadoDeseado.EstadoDeLaPlaca[i].Length; j++)
                {
                    posicionesEnEstadoDeseado = estadoDeseado.PosicionDe(estadoDeseado.EstadoDeLaPlaca[i][j]);
                    posicionesEnPlaca = estadoInicial.PosicionDe(estadoDeseado.EstadoDeLaPlaca[i][j]);
                    distancia += Math.Abs(posicionesEnEstadoDeseado[0] - posicionesEnPlaca[0]);
                    distancia += Math.Abs(posicionesEnEstadoDeseado[1] - posicionesEnPlaca[1]);
                }
            }
            return distancia;
        }
    }
}
