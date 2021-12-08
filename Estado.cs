using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP03_4
{
    public class Estado
    {
        public int[][] EstadoDeLaPlaca;
        public Estado Padre;
        public Estado[] Hijos;

        public Estado(int[][] estadoInicial, Estado padre = null)
        {
            EstadoDeLaPlaca = estadoInicial;
            Padre = padre;
        }

        public int[][] moverCero(char direccion)
        {
            int[][] resultado = EstadoDeLaPlaca;
            int[] posicionDeCero = PosicionDe(0, EstadoDeLaPlaca);
            bool igualAlPadre = false;
            switch (direccion)
            {
                case 'N':
                    if (posicionDeCero[0] > 0)
                    {
                        resultado = DesplazarValor(resultado, posicionDeCero[0], posicionDeCero[1], 0, -1);
                    }
                    break;
                case 'S':
                    if (posicionDeCero[0] < resultado.Length - 1)
                    {
                        resultado = DesplazarValor(resultado, posicionDeCero[0], posicionDeCero[1], 0, 1);
                    }
                    break;
                case 'E':
                    if (posicionDeCero[1] < resultado[1].Length - 1)
                    {
                        resultado = DesplazarValor(resultado, posicionDeCero[0], posicionDeCero[1], 1, 0);
                    }
                    break;
                case 'O':
                    if (posicionDeCero[1] > 0)
                    {
                        resultado = DesplazarValor(resultado, posicionDeCero[0], posicionDeCero[1], -1, 0);
                    }
                    break;
            }
            if(Padre != null)
            {
                igualAlPadre = (ObtenerDistancias(Padre.EstadoDeLaPlaca) == 0);
            }
            if ((ObtenerDistancias(resultado) == 0) || igualAlPadre)
            {
                resultado = null;
            }
            return resultado;
        }

        public int[] PosicionDe(int elemento, int[][] array)
        {
            int[] posiciones = new int[2];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if(array[i][j] == elemento)
                    {
                        posiciones = new int[]{ i, j };
                        break;
                    }
                }
            }
            return posiciones;
        }

        public int[][] DesplazarValor(int[][] array, int fila, int columna,  int incrementoHorizontal,
            int incrementoVertical)
        {
            int[][] resultado = new int[][] { new int[3], new int[3], new int[3] };
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    resultado[i][j] = array[i][j];
                }
            }
            int aux = resultado[fila + incrementoVertical][columna + incrementoHorizontal];
            resultado[fila + incrementoVertical][columna + incrementoHorizontal] = resultado[fila][columna];
            resultado[fila][columna] = aux;
            return resultado;
        }

        public int ObtenerDistancias(int[][] estadoDeseado)
        {
            int distancia = 0;
            int[] posicionesEnEstadoDeseado;
            int[] posicionesEnPlaca;
            for (int i = 0; i < estadoDeseado.Length; i++)
            {
                for (int j = 0; j < estadoDeseado[0].Length; j++)
                {
                    posicionesEnEstadoDeseado = PosicionDe(estadoDeseado[i][j], estadoDeseado);
                    posicionesEnPlaca = PosicionDe(estadoDeseado[i][j], EstadoDeLaPlaca);
                    distancia += Math.Abs(posicionesEnEstadoDeseado[0] - posicionesEnPlaca[0]);
                    distancia += Math.Abs(posicionesEnEstadoDeseado[1] - posicionesEnPlaca[1]);
                }
            }
            return distancia;
        }
    }
}
