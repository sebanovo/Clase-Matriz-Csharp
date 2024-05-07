# Trabajo de la Universidad: Clase Matriz en C#

Este proyecto representa un trabajo académico de la universidad en el que
desarrollamos una clase Matriz en JavaScript. Esta clase permite realizar
cálculos matemáticos utilizando una Matriz bidimensional como base y está
diseñada para llevar a cabo una variedad de operaciones matemáticas.

Visita la version Web de la clase Matriz:
[Clase Matriz](https://clase-matriz-vanilla-javascript.vercel.app/)

<div align="center">
  <a href="https://clase-matriz-vanilla-javascript.vercel.app/">
    <img src="https://i.ibb.co/YtdvLqp/clase-matriz-csharp.png" alt="clase-Matriz-csharp" border="0">
  </a>
</div>

## Características

La clase Matriz en JavaScript incluye las siguientes características y
operaciones:

- **Creación de Matrices:** Puedes crear un nuevo objeto Matriz vacío e ir
  cargándolo con elementos, o cargarlo con valores aleatorios en un rango
  específico.
- **Selección de Elementos:** La clase ofrece métodos para seleccionar elementos
  específicos basados en ciertos criterios, como primos, no primos, buenos
  valores, etc.

- **Operaciones de Matrices Cuadradas:** La clase pone a disposición distintos
  metodos de la clase Matriz para poder trabajar como operaciones con las
  triangulares y las diagonales.

- **Ordenamiento:** Puedes ordenar el Matriz tanto de forma ascendente como
  descendente utilizando varios algoritmos, como el ordenamiento por intercambio
  y el ordenamiento burbuja.

- **Búsquedas:** Ofrece búsquedas binarias y secuenciales para encontrar
  elementos específicos en el Matriz.

## Metodos de la Clase MatrizCargar

- Cargar
- Descargar
- Maximo
- Frecuencia
- Cargar serie aritmetica
- Cargar serie geometrica
- Suma
- Resta
- Multiplicacion
- Multiplicacion por un escalar
- Transposicion
- Busqueda secuencial
- Pertenencia
- Verificar todos aprobados
- Verificar todos iguales
- Verificar ordenado
- Verificar ordenado por razon
- Sumar filas
- Sumar columnas
- Ordenar filas
- Ordenar columnas
- Encontrar mayor frecuencia filas
- Ordenar matriz por intercambio
- Segmentar par y no par
- Intercalar par y no par
- Intercambiar filas por el menor
- Ordenar triangular inferior derecha
- Ordenar triangular inferior izquierda
- Encontrar mayor de la triangular inferior derecha
- Segmentar par y no par triangular inferior derecha
- Segmentar par y no par triangular inferior izquierda
- Transposicion
- Rrdenar columnas triangular inferior izquierda
- Encontrar elemento de mayor frecuencia y su frecuencia
- Ordenar cuadrado interior
- Segmentar par y no par cuadrado interior
- Ordenar rangos
- Segmentar rangos par y no par
- Ordenar filas por numero de elementos diferentes
- Ordenar columnas por numero de primos
- Ordenar filas por numero de primos

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Matriz
{
  class Matriz
  {
      public const int MAXF = 50;
      public const int MAXC = 50;
      public int[,] x;
      public int f, c;

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
                  s = s + x[f1, c1] + "\t";
              s = s + "\r\n";
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

      // etc...
  }
}
```

La Clase Matriz se apoya de una clase NEnt (numero entero) para funcionar

## Metodos de la clase NEnt

- Cargar
- Descargar
- Invertir
- Numero digitos
- Verificar par
- Verificar primos
- Verificar capicua

## Ejemplo:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Matriz
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
          int i, c, r;
          c = 0;
          for(i=1;i<= valor; i++)
          {
              r = valor % i;
              if (r == 0)
                  c++;
          }
          return c == 2;
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
```

# Clonar un Repositorio en Visual Studio 2015

Este tutorial te guiará a través del proceso de clonar un repositorio de GitHub
en Visual Studio 2015 utilizando la URL proporcionada. Nota: Tambien puedes
descargar el archivo .zip y descomprimirlo en tu maquina.

## Requisitos Previos

Antes de comenzar, asegúrate de tener lo siguiente:

- [Visual Studio 2015](https://visualstudio.microsoft.com/vs/older-downloads/)
  instalado en tu sistema.
- Una cuenta de [GitHub](https://github.com/).
- Git instalado en tu sistema. Puedes descargarlo desde
  [git-scm.com](https://git-scm.com/).

## Pasos para Clonar el Repositorio 🙌

### Paso 1: Abrir Visual Studio 2015

Abre Visual Studio 2015 en tu sistema.

### Paso 2: Clonar el Repositorio

1. En el menú superior, selecciona "Archivo" y luego "Clonar repositorio".

2. Ingresa la URL del repositorio que deseas clonar:
   https://github.com/sebanovo/Clase-Matriz-Csharp

3. Haz clic en el botón "Clonar" para iniciar el proceso de clonación.

### Paso 3: Iniciar Sesión en GitHub

Si aún no has iniciado sesión en GitHub, se te pedirá que lo hagas en este paso.
Ingresa tus credenciales de GitHub si es necesario.

### Paso 4: Explorar el Repositorio

Una vez que se complete la clonación, el repositorio estará disponible en el
explorador de soluciones de Visual Studio 2015. Ahora puedes trabajar en el
proyecto localmente.

¡Listo! Has clonado con éxito el repositorio desde GitHub a Visual Studio 2015 y
estás listo para comenzar a trabajar en tu proyecto.

### Paso 5: Crear una Pull Request `Opcional`:

-Si cuentas con las ganas de seguir aportando a este proyecto puedes realizar
una pull request y mandarme tu trabajo y seguir mejorando este Repositorio.

- Haz cambios en tu código y confirma tus modificaciones localmente.
- Luego, crea una nueva rama (branch) para tu pull request.
- Sube tu rama a tu repositorio remoto.
- Visita el repositorio en GitHub y selecciona la opción "New Pull Request".
- Sigue las instrucciones en pantalla para crear tu pull request.

¡Esperamos que este repositorio te sea de ayuda!
