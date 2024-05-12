﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_class_csharp 
{
    class NEnt
    {
        private int valor;

        public NEnt()
        {
            valor = 0;
        }

        public void Cargar(int numero)
        {
            valor = numero;
        }

        public string Descargar()
        {
            return valor.ToString();
        }

        public void Invertir()
        {
            int digito;
            int resultado = 0;
            int numero = valor;
            while (numero > 0)
            {
                digito = numero % 10;
                resultado = resultado * 10 + digito;
                numero /= 10;
            }
            valor = resultado;
        }

        public void Ndigs()
        {
            int numeroDigs = valor.ToString().Length;
            valor = numeroDigs;
        }

        public bool VerificarPar()
        {
            return valor % 2 == 0;
        }

        public bool VerificarPrimo()
        {
            for (int i = 2; i < valor; i++)
            {
                if (valor % i == 0)
                    return false;
            }
            return valor > 1;
        }

        public bool VerificarCapicua()
        {
            int capicua = this.valor;
            this.Invertir();
            return capicua == this.valor;
        }

        public bool VerificarCuadradoPerfecto(int num)
        {
            int raizCua = (int)Math.Sqrt(num);
            return raizCua * raizCua == num;
        }

        public bool VerificarFibonacci()
        {
            return VerificarCuadradoPerfecto(5 * valor * valor + 4) || VerificarCuadradoPerfecto(5 * valor * valor - 4);
        }
    }
}
