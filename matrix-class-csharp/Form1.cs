using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace matrix_class_csharp 
{
    public partial class Form1 : Form
    {
        Matriz M1;
        Matriz M2;
        Matriz M3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            M1 = new Matriz();
            M2 = new Matriz();
            M3 = new Matriz();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = M1.Descargar();
        }

        private void maximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"El maximo es: {M1.Maximo()}");
        }

        private void frecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(Interaction.InputBox($"Introduzca un número: "));

            MessageBox.Show($"La frecuencia de {numero} es: {M1.Frecuencia(numero)}");
        }

        private void cargarSerieAritmeticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.CargarSerieAritmetica(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void cargarSerieGeometricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.CargarSerieGeometrica(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            M2.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox6.Text = M2.Descargar();
        }

        private void cargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            M3.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox7.Text = M3.Descargar();
        }

        private void sumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M1.f == 0 || M1.c == 0 || M2.f == 0 || M2.c == 0)
                return;
            M3.Suma(M1, M2);
        }

        private void restaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M1.f == 0 || M1.c == 0 || M2.f == 0 || M2.c == 0)
                return;
            M3.Resta(M1, M2);
        }

        private void multiplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M1.f == 0 || M1.c == 0 || M2.f == 0 || M2.c == 0)
                return;
            if (M1.c != M2.f)
            {
                MessageBox.Show($"No se puede realizar la multiplicación de matrices porque {M1.c} != {M2.f}");
                return;
            }
            M3.Multiplicacion(M1, M2);
        }

        private void multiplicaciónPorUnEscalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = int.Parse(Interaction.InputBox($"Introduce un escalar: "));
            M1.MultiplicacionPorUnEscalar(k);
        }

        private void trasposiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.Transposicion();
        }

        private void busquedaSecuencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fila, columna, ele;
            fila = 0;
            columna = 0;
            ele = int.Parse(Interaction.InputBox("Introduce el elemento a buscar: "));
            M1.BusquedaSecuencial(ele, ref fila, ref columna);

            if (fila == 0 && columna == 0) return;
            MessageBox.Show($"Elemento {ele} encontrado en fila: {fila} columna: {columna}");
        }

        private void pertenenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ele;

            ele = int.Parse(Interaction.InputBox("Introduce el elemento a buscar: "));
            MessageBox.Show($"{M1.Pertenece(ele)}");

        }

        private void verificarTodosAprobadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{M1.VerificarTodosAprobados()}");
        }

        private void verificarTodosIgualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{M1.VerificarTodosIguales()}");
        }

        private void verificarOrdenadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{M1.VerificarOrdenado()}");
        }

        private void veriricarOrdenadoPorRazónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int r;
            r = int.Parse(Interaction.InputBox("Introduce la razón"));

            MessageBox.Show($"{M1.VerificarOrdenadoRazon(r)}");
        }

        private void sumarFilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SumarFilas();
            textBox6.Text = M1.Descargar();
        }

        private void sumarColumnasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SumarColumnas();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarColumnasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarColumnas();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarFilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarFilas();
            textBox6.Text = M1.Descargar();
        }

        private void encontrarMayorFrecuenciaFilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SumarColumnaDeMayorFrecuencia();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarMatrizPorIntercambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarMatriz1();
            //M1.OrdenarMatriz2();
            //M1.OrdenarMatriz3();
            //M1.OrdenarMatriz4();
            textBox6.Text = M1.Descargar();
        }

        private void segmentarParYNoParToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SegmentarParYNoPar();
            textBox6.Text = M1.Descargar();
        }

        private void intercalarParYNoParToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.IntercalarParYNoPar();
            textBox6.Text = M1.Descargar();
        }

        private void intercambiarFilasPorElMenorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.AñadirColumnaConLosMenores();
            M1.OrdenarFilaMenorIntercambio();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarTriangularInferiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarTriangularInferiorDerecha();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarTriangularInferiorIzquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarTriangularInferiorIzquierda();
            textBox6.Text = M1.Descargar();
        }

        private void encontrarElMayorDeLaTriangularInferiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.AñadirFilaConElMayor();
            textBox6.Text = M1.Descargar();
        }

        private void segmentarParYNoParTriangularInferiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SegmentarParYNoParDeLaTriangularInferiorDerecha2();
            textBox6.Text = M1.Descargar();
        }

        private void segmentarParYNoParTriangularInferiorIzquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SegmentarParYNoParTriangularInferiorIzquierda();
            textBox6.Text = M1.Descargar();
        }

        private void transposiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.transpuesta();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarColumnasTriangularInferiorIzquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarColumnasTriangularInferiorIzquierda();
            textBox6.Text = M1.Descargar();
        }

        private void encontrarElementoDeMayorFrecuenciaYSuFrecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.FrecuenciaDeLasFilas();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarCuadradoInteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarCuadradoInterior();
            textBox6.Text = M1.Descargar();
        }

        private void segmentarParYNoParCuadradoInteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SegmentarParYNoParCuadradoInterior();
            textBox6.Text = M1.Descargar();
        }

        private void ordenarRangosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.OrdenarRangos(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox6.Text = M1.Descargar();
        }

        private void segmentarRangosParYNoParToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M1.SegmentarRangosParYNoPar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox6.Text = M1.Descargar();
        }

        private void ordenarFilasPorNumeroDeElementosDiferentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M2.AñadirColumnaConElNumeroDeElementosDiferenteDeLaFila();
            M2.OrdenarColumnaDerecha();
            textBox7.Text = M2.Descargar();
        }

        private void ordenarColumnasPorNumeroDePrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M2.AñadirFilaInferiorConNumeroDePrimosDeLaColumna();
            M2.OrdenarFilaInferior();
            textBox7.Text = M2.Descargar();

        }

        private void ordenarFilasPorNumeroDePrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M2.AñadirColumnaConElNumeroDeElementosDeLaFila();
            M2.OrdenarUltimaColumna();
            textBox7.Text = M2.Descargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M1 = new Matriz();
            M2 = new Matriz();
            M3 = new Matriz();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            M1.Grabar(saveFileDialog1.FileName);
        }

        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            M1.Leer(openFileDialog1.FileName);
        }
    }
}
