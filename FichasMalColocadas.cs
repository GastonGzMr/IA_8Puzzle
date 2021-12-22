using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    public class FichasMalColocadas: Heuristica
    {
        public override int ObtenerDistancias(Estado estadoInicial, Estado estadoDeseado)
        {
            int distancia = 0;
            for (int i = 0; i < estadoDeseado.EstadoDeLaPlaca.Length; i++)
            {
                for (int j = 0; j < estadoDeseado.EstadoDeLaPlaca[0].Length; j++)
                {
                    if (estadoInicial.EstadoDeLaPlaca[i][j] != estadoDeseado.EstadoDeLaPlaca[i][j])
                    {
                        distancia++;
                    }
                }
            }
            return distancia;
        }
    }
}
