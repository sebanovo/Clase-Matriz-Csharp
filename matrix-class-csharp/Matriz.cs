using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_class_csharp 
{
    class Matriz
    {
        public const int MAXF = 50;
        public const int MAXC = 50;
        public int[,] x;
        public int f, c;

        // Objeto archivo
        ArchSec A1;

        // Constructor de la clase Matriz
        public Matriz()
        {
            x = new int[MAXF, MAXC];
            f = 0;
            c = 0;
        }

        // Metodo que carga la matriz de forma ramdomica
        public void Cargar(int nf, int nc, int a, int b)
        {
            int f1, c1;
            Random r = new Random();
            f = nf;
            c = nc;
            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    x[f1, c1] = r.Next(a, b + 1);
        }

        // Metodo que descarga la matriz con un formato especial con saltos de linea
        public string Descargar()
        {
            int f1, c1;
            string s = "";
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                    s = s + x[f1, c1] + '\u0009';
                s = s + '\u000D' + '\u000A';
            }
            return s;
        }

        // Metodo que encuentra el número mayor de una matriz
        public int Maximo()
        {
            int f1, c1, max;
            max = x[1, 1];
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    if (x[f1, c1] > max)
                        max = x[f1, c1];
                }
            }

            return max;
        }

        // Metodo que encuentra la frecuencia con la que aparece un número en la matriz
        public int Frecuencia(int number)
        {
            int f1, c1, fr;

            fr = 0;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (x[f1, c1] == number)
                        fr++;

            return fr;
        }

        // Metodo que carga la serie aritmetica
        public void CargarSerieAritmetica(int nf, int nc, int a1, int r)
        {
            int f1, c1, n;

            f = nf;
            c = nc;

            n = 1;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = a1 + (n - 1) * r;
                    n++;
                }
        }

        // metodo que carga la serie geometrica
        public void CargarSerieGeometrica(int nf, int nc, int a1, int r)
        {
            int f1, c1, n;

            f = nf;
            c = nc;

            n = 1;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = a1 * (int)Math.Pow(r, n - 1);
                    n++;
                }
        }

        // Metodo que realiza la suma de dos matrices
        public void Suma(Matriz M1, Matriz M2)
        {
            int f1, c1;
            f = M1.f;
            c = M1.c;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    x[f1, c1] = M1.x[f1, c1] + M2.x[f1, c1];
        }

        // Metodo que realiza la resta de dos matrices
        public void Resta(Matriz M1, Matriz M2)
        {
            int f1, c1;
            f = M1.f;
            c = M1.c;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    x[f1, c1] = M1.x[f1, c1] - M2.x[f1, c1];
        }

        // Metodo que multiplica dos matrices
        public void Multiplicacion(Matriz M1, Matriz M2)
        {
            int f1, c1;
            int sum, n, k;

            f = M1.f;
            c = M2.c;

            n = M1.c;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                {
                    sum = 0;
                    for (k = 1; k <= n; k++)
                        sum = sum + (M1.x[f1, k] * M2.x[k, c1]);
                    x[f1, c1] = sum;
                }
        }

        // Metodo  que multiplica la matriz por un escalar
        public void MultiplicacionPorUnEscalar(int k)
        {
            int f1, c1;


            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    x[f1, c1] = k * x[f1, c1];
        }

        // Metodo que convierte la matriz en una matriz transpuesta
        public void Transposicion()
        {
            int f1, c1;
            int[,] copia;
            int temp;

            copia = new int[MAXC, MAXF];

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    copia[c1, f1] = x[f1, c1];

            x = copia;

            // Intercambiando fila y columna
            temp = f;
            f = c;
            c = temp;
        }

        // Busca un elemento devolviendo por referencia la fila y la columna
        public void BusquedaSecuencial(int ele, ref int fila, ref int columna)
        {
            int f1, c1;


            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (x[f1, c1] == ele)
                    {
                        fila = f1;
                        columna = c1;
                        return;
                    }

        }

        // Busca si el elemento pertenece a la matriz
        public bool Pertenece(int ele)
        {
            int f1, c1;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (x[f1, c1] == ele)
                        return true;

            return false;
        }

        // Verifica si todos los elementos son > 51 (aprobados)
        public bool VerificarTodosAprobados()
        {
            int f1, c1;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (x[f1, c1] < 51)
                        return false;
            return true;
        }

        // Verifica si todos los elementos son iguales
        public bool VerificarTodosIguales()
        {
            int f1, c1, primero;

            primero = x[1, 1];

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (primero != x[f1, c1])
                        return false;
            return true;
        }

        // Verifica si esta ordenado ascendentemente
        public bool VerificarOrdenado()
        {
            int f1, c1, anterior;

            anterior = x[1, 1];

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    if (x[f1, c1] < anterior)
                        return false;
                    anterior = x[f1, c1];
                }
            }
            return true;
        }

        // Verifica si esta ordenado por una razón (Lo hizo chatGPT)
        public bool VerificarOrdenadoRazon(int r)
        {
            int f1, c1;

            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 < c; c1++)  // notar que  c1 < c
                    if (x[f1, c1] + r != x[f1, c1 + 1])
                        return false;

            return true;
        }

        // Suma los elementos de la fila y crea otra columna
        public int SumarFila(int nf)
        {
            int s, c1;
            s = 0;

            for (c1 = 1; c1 <= c; c1++)
            {
                s = s + x[nf, c1];
            }

            return s;
        }

        public void SumarFilas()
        {
            int nf;
            for (nf = 1; nf <= f; nf++)
            {
                x[nf, c + 1] = SumarFila(nf);
            }

            c = c + 1;
        }

        // Suma los elemento de la columna y crea otra fila
        public int SumarColumna(int nc)
        {
            int f1, s;
            s = 0;

            for (f1 = 1; f1 <= f; f1++)
            {
                s = s + x[f1, nc];
            }

            return s;
        }

        public void SumarColumnas()
        {
            int nc;
            for (nc = 1; nc <= c; nc++)
            {
                x[f + 1, nc] = SumarColumna(nc);
            }
            f = f + 1;
        }

        // Intercambia las columnas: 
        public void Intercambiar(int f1, int c1, int f2, int c2)
        {
            int temp = x[f1, c1];
            x[f1, c1] = x[f2, c2];
            x[f2, c2] = temp;
        }

        // Ordenar Columna (burbuja):

        public void OrdenarColumnaIntercambio(int nc)
        {
            int f1, p;

            for (f1 = 1; f1 <= f; f1++)
            {
                for (p = 1; p < f; p++)
                {
                    if (x[p, nc] > x[p + 1, nc])
                        Intercambiar(p, nc, p + 1, nc);
                }
            }
        }

        public void OrdenarColumnas()
        {
            int c1;

            for (c1 = 1; c1 <= c; c1++)
                OrdenarColumnaIntercambio(c1);
        }

        // Ordenar Filas (Intercambio):
        public void OrdenarFilaIntercambio(int nf)
        {
            int c1, p;

            for (c1 = 1; c1 <= c; c1++)
            {
                for (p = 1; p < c; p++)
                {
                    if (x[nf, p] > x[nf, p + 1])
                        Intercambiar(nf, p, nf, p + 1);
                }
            }
        }

        public void OrdenarFilas()
        {
            int f1;
            for (f1 = 1; f1 <= f; f1++)
            {
                OrdenarFilaIntercambio(f1);
            }
        }
        
        public int DevolverElementoMayorFrecuenciaDeFila(int fila)
        {
            int j, dato1, frec1, dato2, frec2;
            dato1 = x[fila, 1];
            frec1 = DevolverFrecuenciaDeRepeticionDeLaFila(fila, dato1);
            for(j = 2; j <= c; j++)
            {
                dato2 = x[fila, j];
                frec2 = DevolverFrecuenciaDeRepeticionDeLaFila(fila, dato2);
                if(frec1 < frec2)
                {
                    dato1 = dato2;
                    frec1 = frec2;
                }
            }
            return dato1;
        }

        public int DevolverFrecuenciaDeRepeticionDeLaFila(int fila, int ele)
        {
            int c1, frec;
            frec = 0;
            for(c1 = 1; c1 <= c; c1++)
            {
                if (x[fila, c1] == ele)
                    frec++;
            }

            return frec;
        }
        // Añade 2 columnas extra a la matriz con el elemento de mayor frecuencia y su frecuencia
        public void SumarColumnaDeMayorFrecuencia()
        {
            int nf;

            for (nf = 1; nf <= f; nf++)
            {
                x[nf, c + 1] = DevolverElementoMayorFrecuenciaDeFila(nf);
                x[nf, c + 2] = DevolverFrecuenciaDeRepeticionDeLaFila(nf, x[nf, c + 1]);
            }

            c += 2;
        }
        // Metodo diferentes que ordenan la matriz siguiendo una referencia diferente
        public void OrdenarMatriz1()
        {
            int f1, c1, f2, c2, ic;

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if (f2 == f1)
                        {
                            ic = c1;
                        }
                        else
                        {
                            ic = 1;
                        }
                        for (c2 = ic; c2 <= c; c2++)
                        {
                            if (x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public void OrdenarMatriz2()
        {
            int f1, c1, f2, c2, ic;

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = c; c1 >= 1; c1--)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if (f2 == f1)
                        {
                            ic = c1;
                        }
                        else
                        {
                            ic = c;
                        }

                        for (c2 = ic; c2 >= 1; c2--)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        public void OrdenarMatriz3()
        {
            int f1, c1, f2, c2, inf;

            for (c1 = 1; c1 <= c; c1++)
            {
                for (f1 = 1; f1 <= f; f1++)
                {
                    for (c2 = c1; c2 <= c; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = 1;
                        }
                        for (f2 = inf; f2 <= f; f2++)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        public void OrdenarMatriz4()
        {
            int f1, c1, f2, c2, inf;

            for (c1 = 1; c1 <= c; c1++)
            {
                for (f1 = f; f1 >= 1; f1--)
                {
                    for (c2 = c1; c2 <= c; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = f;
                        }
                        for (f2 = inf; f2 >= 1; f2--)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        // Segmentar Matriz
        public void SegmentarParYNoPar()
        {
            int f1, c1, f2, c2, ic;
            // ic : indice de columna
            NEnt n1, n2;

            n1 = new NEnt();
            n2 = new NEnt();

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if (f2 == f1)
                        {
                            ic = c1;
                        }
                        else
                        {
                            ic = 1;
                        }
                        for (c2 = ic; c2 <= c; c2++)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                               !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }

        // Intercalar Par Y No Par 
        public void IntercalarParYNoPar()
        {
            int f1, c1, f2, c2, ic;
            // ic : indice de columna
            NEnt n1, n2;
            bool b;

            b = true;

            n1 = new NEnt();
            n2 = new NEnt();

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    if (b)
                    {
                        for (f2 = f1; f2 <= f; f2++)
                        {
                            if (f2 == f1)
                            {
                                ic = c1;
                            }
                            else
                            {
                                ic = 1;
                            }
                            for (c2 = ic; c2 <= c; c2++)
                            {
                                n1.Cargar(x[f1, c1]);
                                n2.Cargar(x[f2, c2]);

                                if (n2.VerificarPar() && !n1.VerificarPar() ||
                                    n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                   !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                                {
                                    Intercambiar(f2, c2, f1, c1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (f2 = f1; f2 <= f; f2++)
                        {
                            if (f2 == f1)
                            {
                                ic = c1;
                            }
                            else
                            {
                                ic = 1;
                            }
                            for (c2 = ic; c2 <= c; c2++)
                            {
                                n1.Cargar(x[f1, c1]);
                                n2.Cargar(x[f2, c2]);

                                if (!n2.VerificarPar() && n1.VerificarPar() ||
                                    !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                     n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                                {
                                    Intercambiar(f2, c2, f1, c1);
                                }
                            }
                        }
                    }
                    // cambia la bandera
                    b = !b;
                }
            }
        }
        // Devuelve el menor número de la fila
        public int DevolverElMenorNumeroDeLaFila(int nf)
        {
            int c1, menor;

            menor = x[nf, 1];

            for (c1 = 2; c1 <= c; c1++)
            {
                if (x[nf, c1] < menor)
                    menor = x[nf, c1];
            }
            return menor;
        }

        // Añade una columna con el menor de cada fila
        public void AñadirColumnaConLosMenores()
        {
            int f1;
            for (f1 = 1; f1 <= f; f1++)
            {
                x[f1, c + 1] = DevolverElMenorNumeroDeLaFila(f1);
            }
            c++;
        }
        // Intercambia las filas
        public void IntercambiarFilas(int f1, int f2)
        {
            int c1;
            for (c1 = 1; c1 <= c; c1++)
            {
                Intercambiar(f1, c1, f2, c1);
            }
        }

        // Metodo que ordena las filas de menor a mayor tomando como referencia la ultiima fila
        public void OrdenarFilaMenorIntercambio()
        {
            int i, j;

            for (i = 1; i <= f; i++)
            {
                for (j = 1; j < f; j++)
                {
                    if (x[j, c] > x[j + 1, c])
                        IntercambiarFilas(j, j + 1);
                }
            }
        }
        // OPERACIONES CON MATRICES CUADRADAS:
        public void transpuesta()
        {
            int f1, c1;
            for (f1 = 2; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= f1 - 1; c1++)
                {
                    Intercambiar(f1, c1, c1, f1);
                }
            }
        }
        public void OrdenarTriangularInferiorDerecha()
        {
            int f1, c1, f2, c2, inc;
            for (f1 = 2; f1 <= f; f1++)
            {
                for (c1 = c - f1 + 2; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if(f1 == f2)
                        {
                            inc = c1;
                        }
                        else
                        {
                            inc = c - f2 + 2;
                        }
                        for (c2 = inc; c2 <= c; c2++)
                        {
                            if(x[f1,c1] > x[f2,c2])
                            {
                                Intercambiar(f1, c1, f2, c2);
                            }
                        }
                    }
                }
            }

            
        }
        public void OrdenarTriangularInferiorIzquierda()
        {
            int f1, c1, f2, c2;
            for (f1 = 2; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= f1 - 1; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        for (c2 = c1; c2 <= f2 - 1; c2++)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        public void OrdenarDiagonalPrincipal()
        {
            int f1, c1, f2, c2;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        for (c2 = c1; c2 <= c; c2++)
                        {
                            if (c1 == f1 && c2 == f2 && x[f1, c1] > x[f2, c2])
                            {
                                Intercambiar(f1, c1, f2, c2);
                            }
                        }
                    }
                }
            }
        }
        public void OrdenarDiagonalSecundaria()
        {
            int f1, c1, f2, c2;

            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = c; c1 >= 1; c1--)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        for (c2 = c1; c2 >= 1; c2--)
                        {
                            if (c1 == c - f1 + 1 && c2 == c - f2 + 1 && x[f1, c1] > x[f2, c2])
                            {
                                Intercambiar(f1, c1, f2, c2);
                            }
                        }
                    }
                }
            }
        }
        public void SegmentarParYNoParTriangularInferiorIzquierda()
        {
            int f1, c1, f2, c2;
            NEnt n1, n2;

            n1 = new NEnt(); n2 = new NEnt();

            for (f1 = 2; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= f1 - 1; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        for (c2 = c1; c2 <= f2 - 1; c2++)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                               !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public void SegmentarParYNoParDeLaTriangularInferiorDerecha1()
        {
            int f1, c1, f2, c2;
            NEnt n1, n2;

            n1 = new NEnt(); n2 = new NEnt();

            for (c1 = 2; c1 <= c; c1++)
            {
                for (f1 = f; f1 > f - c1 + 1; f1--)
                {
                    for (c2 = 2; c2 <= c; c2++)
                    {
                        for (f2 = f; f2 > f - c2 + 1; f2--)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                               n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                              !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public void SegmentarParYNoParDeLaTriangularInferiorDerecha2()
        {
            int f1, c1, f2, c2, ic;

            NEnt n1, n2;
            n1 = new NEnt();
            n2 = new NEnt();

            for (f1 = 2; f1 <= f; f1++)
            {
                for (c1 = c - f1 + 2; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if (f2 == f1)
                        {
                            ic = c1;
                        }
                        else
                        {
                            ic = c - f2 + 2;
                        }
                        for (c2 = ic; c2 <= c; c2++)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public void SegmentarParYNoParDeLaTriangularInferiorDerecha3()
        {
            int f1, c1, f2, c2, inc;
            NEnt n1, n2;

            n1 = new NEnt();
            n2 = new NEnt();

            for (f1 = f; f1 >= 2; f1--)
            {
                for (c1 = c - f1 + 2; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 >= 2; f2--)
                    {
                        if (f1 == f2)
                        {
                            inc = c1;
                        }
                        else
                        {
                            inc = c - f2 + 2;
                        }

                        for (c2 = inc; c2 <= c; c2++)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }

        // Modelos de examen: 
        public void OrdenarColumnas1(int nroC, int init)
        {
            int i, j;

            for (i = init; i <= f; i++)
            {
                for (j = init; j < f; j++)
                {
                    if (x[j, nroC] < x[j + 1, nroC])
                        Intercambiar(j, nroC, j + 1, nroC);
                }
            }
        }

        public void OrdenarColumnasTriangularInferiorIzquierda()
        {
            int c1, init;

            for (c1 = 1, init = 2; c1 < c; c1++, init++)
            {
                OrdenarColumnas1(c1, init);
            }
        }
        public void Modelo1()
        {
            int f1, c1, f2, c2, ic;

            for (f1 = 2; f1 <= f; f1++) 
            {
                for (c1 = c - f1 + 2; c1 <= c; c1++)
                {
                    for (f2 = f1; f2 <= f; f2++)
                    {
                        if (f2 == f1)
                        {
                            ic = c1;
                        }
                        else
                        {
                            ic = c - f2 + 2;
                        }
                        for (c2 = ic; c2 <= c; c2++)
                        {
                            if (x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public int EncontrarElementoDeMayorFrecuencia(int nroF)
        {
            int c1, count;
            int[] v;

            v = new int[c];
            count = 0;

            for (c1 = 1; c1 <= c; c1++)
            {
                v[count] = x[nroF, c1];
                count++;
            }

            return v
                    .GroupBy(x => x)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;
        }
        public int ContarCuantasVecesSeRepite(int nroF, int ele)
        {
            int c1, count;

            count = 0;

            for (c1 = 1; c1 <= c; c1++)
            {
                if (x[nroF, c1] == ele)
                    count++;
            }
            return count;
        }
        public void FrecuenciaDeLasFilas()
        {
            int f1;

            for (f1 = 1; f1 <= f; f1++)
            {
                x[f1, c + 1] = EncontrarElementoDeMayorFrecuencia(f1);
                x[f1, c + 2] = ContarCuantasVecesSeRepite(f1, x[f1, c + 1]);
            }

            c++;
            c++;
        }
        public void OrdenarCuadradoInterior()
        {
            int f1, c1, f2, c2, inf;

            for (c1 = 2; c1 <= c - 1; c1++)
            {
                for (f1 = c - 1; f1 >= 2; f1--)
                {
                    for (c2 = c1; c2 <= c - 1; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = c - 1;
                        }
                        for (f2 = inf; f2 >= 2; f2--)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        public void SegmentarParYNoParCuadradoInterior()
        {
            int f1, c1, f2, c2, inf;

            NEnt n1, n2;

            n1 = new NEnt();
            n2 = new NEnt();

            for (c1 = 2; c1 <= c - 1; c1++)
            {
                for (f1 = c - 1; f1 >= 2; f1--)
                {
                    for (c2 = c1; c2 <= c - 1; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = c - 1;
                        }
                        for (f2 = inf; f2 >= 2; f2--)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public void OrdenarRangos(int fi, int ff, int ci, int cf)
        {
            int f1, c1, f2, c2, inf;

            for (c1 = ci; c1 <= cf; c1++)
            {
                for (f1 = ff; f1 >= fi; f1--)
                {
                    for (c2 = c1; c2 <= cf; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = ff;
                        }
                        for (f2 = inf; f2 >= fi; f2--)
                        {
                            if (x[f1, c1] > x[f2, c2])
                                Intercambiar(f1, c1, f2, c2);
                        }
                    }
                }
            }
        }
        public void SegmentarRangosParYNoPar(int fi, int ff, int ci, int cf)
        {
            int f1, c1, f2, c2, inf;
            NEnt n1, n2;

            n1 = new NEnt();
            n2 = new NEnt();

            for (c1 = ci; c1 <= cf; c1++)
            {
                for (f1 = ff; f1 >= fi; f1--)
                {
                    for (c2 = c1; c2 <= cf; c2++)
                    {
                        if (c1 == c2)
                        {
                            inf = f1;
                        }
                        else
                        {
                            inf = ff;
                        }
                        for (f2 = inf; f2 >= fi; f2--)
                        {
                            n1.Cargar(x[f1, c1]);
                            n2.Cargar(x[f2, c2]);

                            if (n2.VerificarPar() && !n1.VerificarPar() ||
                                n2.VerificarPar() && n1.VerificarPar() && x[f2, c2] < x[f1, c1] ||
                                !n2.VerificarPar() && !n1.VerificarPar() && x[f2, c2] < x[f1, c1])
                            {
                                Intercambiar(f2, c2, f1, c1);
                            }
                        }
                    }
                }
            }
        }
        public int EncontrarElementoMayorFila(int nf, int init)
        {
            int c1, mayor;

            mayor = x[nf, init];

            for (c1 = init; c1 <= c; c1++)
            {
                if (mayor < x[nf, c1])
                    mayor = x[nf, c1];
            }

            return mayor;
        }
        public void AñadirFilaConElMayor()
        {
            int f1, init;
            init = 1;

            for (f1 = f; f1 >= 1; f1--)
            {
                x[f1, c + 1] = EncontrarElementoMayorFila(f1, init);
                init++;
            }

            c++;
        }
        public int DevolverNumeroDeElementosDiferentesDeLaFila(int nroF)
        {
            int i, j, count;
            bool esDiferente;

            count = 1;

            for (i = 2; i <= c; i++)
            {
                esDiferente = true;
                for (j = 1; j < i; j++)
                {
                    if (x[nroF, i] == x[nroF, j])
                    {
                        esDiferente = false;
                        break;
                    }
                }
                if (esDiferente)
                {
                    count++;
                }
            }
            return count;
        }
        public void AñadirColumnaConElNumeroDeElementosDiferenteDeLaFila()
        {
            int f1;

            for (f1 = 1; f1 <= f; f1++)
            {
                x[f1, c + 1] = DevolverNumeroDeElementosDiferentesDeLaFila(f1);
            }

            c++;
        }

        public void OrdenarColumnaDerecha()
        {
            int i, j;
           
            for (i = 1; i <= f; i++)
            {
                for (j = 1; j < f; j++)
                {
                    if (x[j, c] > x[j + 1, c])
                        IntercambiarFilas(j, j + 1);
                }
            }
        }
        public int DevolverNumeroDePrimosEnLaColumna(int nroC)
        {
            int f1, count;
            NEnt n1;

            count = 0;
            n1 = new NEnt();

            for (f1 = 1; f1 <= f; f1++)
            {
                n1.Cargar(x[f1, nroC]);
                if (n1.VerificarPrimo())
                    count++;
            }

            return count;
        }

        public void AñadirFilaInferiorConNumeroDePrimosDeLaColumna()
        {
            int c1;

            for (c1 = 1; c1 <= c; c1++)
            {
                x[f + 1, c1] = DevolverNumeroDePrimosEnLaColumna(c1);
            }
        }

        public void IntercambiarColumnas(int c1, int c2)
        {
            int f1;
            for (f1 = 1; f1 <= f + 1; f1++)
            {
                Intercambiar(f1, c1, f1, c2);
            }
        }

        public void OrdenarFilaInferior()
        {
            int i, j;

            for (i = 1; i <= c; i++)
            {
                for (j = 1; j < c; j++)
                {
                    if (x[f + 1, j] > x[f + 1, j + 1])
                        IntercambiarColumnas(j, j + 1);
                }
            }

        }
        public int DevolverNumeroDePrimosEnLaFila(int nroF)
        {
            int c1, count;
            NEnt n1;

            count = 0;
            n1 = new NEnt();

            for (c1 = 1; c1 <= c; c1++)
            {
                n1.Cargar(x[nroF, c1]);
                if (n1.VerificarPrimo())
                    count++;
            }

            return count;
        }

        public void AñadirColumnaConElNumeroDeElementosDeLaFila()
        {
            int f1;

            for (f1 = 1; f1 <= f; f1++)
            {
                x[f1, c + 1] = DevolverNumeroDePrimosEnLaFila(f1);
            }
        }

        public void IntercambiarFilasModel(int f1, int f2)
        {
            int c1;

            for (c1 = 1; c1 <= c + 1; c1++)
            {
                Intercambiar(f1, c1, f2, c1);
            }
        }

        public void OrdenarUltimaColumna()
        {
            int i, j;

            for (i = 1; i <= f; i++)
            {
                for(j = 1; j < f; j++)
                {
                    if (x[j, c + 1] > x[j + 1, c + 1])
                        IntercambiarFilasModel(j, j + 1);
                }
            }
        }

        // Metodos de la clase Archivo (funciona) :)
        public void Grabar(string Narch1)
        {
            A1 = new ArchSec();
            A1.Abrir_Grabar(Narch1);
            A1.Grabar(f);
            A1.Grabar(c);
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    A1.Grabar(x[f1, c1]);
                }
            }
            A1.Cerrar_Grabar();
        }
        public void Leer(string Narch1)
        {
            ArchSec A1 = new ArchSec();
            A1.Abrir_Leer(Narch1);
            f = A1.Leer();
            c = A1.Leer();
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = A1.Leer();
                }
            }
            A1.Cerrar_Leer();
        }
    }
}
