using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    public abstract class Heuristica
    {
        public abstract int ObtenerDistancias(Estado estadoInicial, Estado estadoDeseado);
    }
}
