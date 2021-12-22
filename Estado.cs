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
            int[] posicionDeCero = PosicionDe(0);
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
                igualAlPadre = IgualA(Padre.EstadoDeLaPlaca);
            }
            if (IgualA(resultado) || igualAlPadre)
            {
                resultado = null;
            }
            return resultado;
        }

        public int[] PosicionDe(int elemento)
        {
            int[] posiciones = new int[2];
            for (int i = 0; i < EstadoDeLaPlaca.Length; i++)
            {
                for (int j = 0; j < EstadoDeLaPlaca[i].Length; j++)
                {
                    if(EstadoDeLaPlaca[i][j] == elemento)
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

        public bool IgualA(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != EstadoDeLaPlaca[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
