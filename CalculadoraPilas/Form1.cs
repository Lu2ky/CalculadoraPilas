using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraPilaInterfaz
{
    public partial class Form1: Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Text == "E")
                {
                    if (richTextBox1.Text.Length > 0)
                    {
                        richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                    }
                }
                else
                {
                    richTextBox1.Text += btn.Text;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.Text += btn.Text;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string operacion = richTextBox1.Text;
            richTextBox1.Clear();
            PilaNumeros pNum = new PilaNumeros(20);
            PilaOperadores pOp = new PilaOperadores(20);

            if (OperadoresConsecutivos(operacion))
            {
                richTextBox1.Text = "Operacion invalida: contiene operadores consecutivos";
                timer.Start();
                return;
            }

            string digits = "0123456789";
            string operadores = "+-*/";
            string invalidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&()_=[]{};:?.> ";


            int c1 = 0;
            int c2 = 0;

            for (int i = 0; i < operacion.Length; i++)
            {
                if (digits.Contains(operacion[i]))
                {
                    c1++;
                }
                if (operadores.Contains(operacion[i]))
                {
                    c2++;
                }
            }

            if (c1 > 20)
            {
                richTextBox1.Text = ("Solo pueden haber 20 numeros");
                timer.Start();
                return;
            }
            if (c2 > 20)
            {
                richTextBox1.Text = ("Solo pueden haber 20 operadores");
                timer.Start();
                return;
            }

            for (int i = 0; i < operacion.Length; i++)
            {
                
                    if (invalidos.Contains(operacion[i]))
                    {
                        
                        richTextBox1.Text = ($"Error: La operacion contiene caracteres invalidos ('{operacion[i]}')");
                        timer.Start();

                    return;
                    }
                
            }
            string numeroTemporal = "";
            int Rtemp = 0;
            boolean neg = false;

            for (int i = 0; i < operacion.Length; i++)
            {
                char cTemp = operacion[i];
                if (digits.Contains(cTemp))
                {
                    numeroTemporal += cTemp;
                }
                else if(cTemp == "-" && ((i == 0) || operadores.Contains(operacion[i-1]))){
                    neg = true;
                }
                
                else if (operadores.Contains(cTemp))
                {
                    if (!string.IsNullOrEmpty(numeroTemporal))
                    {
                        int Ntemp = int.Parse(numeroTemporal);
                        if(neg){
                            Ntemp = -Ntemp;
                        }
                        neg = false;
                        pNum.push(Ntemp);
                        numeroTemporal = "";
                    }

                    string operadorTemporal = cTemp.ToString();
                    if (operadorTemporal.Equals("*") || operadorTemporal.Equals("/"))
                    {
                        int j = i + 1;
                        string siguienteNumero = "";
                        while (j < operacion.Length && digits.Contains(operacion[j]))
                        {
                            siguienteNumero += operacion[j];
                            j++;
                        }
                        if (string.IsNullOrEmpty(siguienteNumero))
                        {
                            richTextBox1.Text = "Error: Falta operando derecho para el operador " + operadorTemporal;
                            timer.Start();
                            return;
                        }
                        if (pNum.isEmpty())
                        {
                            richTextBox1.Text = "Error: Falta operando izquierdo para el operador " + operadorTemporal;
                            timer.Start();
                            return;
                        }
                        int operadorIzquierdo = pNum.pop().Value;
                        int operadorDerecho = int.Parse(siguienteNumero);
                        if (operadorTemporal.Equals("*"))
                        {
                            Rtemp = operadorIzquierdo * operadorDerecho;
                        }
                        else
                        {
                            if (operadorDerecho == 0)
                            {
                                richTextBox1.Text = "Division entre cero";
                                timer.Start();
                                return;
                            }
                            Rtemp = operadorIzquierdo / operadorDerecho;
                        }
                        pNum.push(Rtemp);
                        i = j - 1;
                    }
                    else
                    {
                        pOp.push(operadorTemporal);
                    }
                }
            }
            if (!string.IsNullOrEmpty(numeroTemporal))
            {
                pNum.push(int.Parse(numeroTemporal));
            }

            List<int> numerosOrdenados = new List<int>();
            while (!pNum.isEmpty())
            {
                numerosOrdenados.Add(pNum.pop().Value);
            }
            numerosOrdenados.Reverse();

            List<string> operadoresOrdenados = new List<string>();
            while (!pOp.isEmpty())
            {
                operadoresOrdenados.Add(pOp.pop().Value);
            }
            operadoresOrdenados.Reverse();


            int resultadoFinal = numerosOrdenados[0];
            for (int i = 0; i < operadoresOrdenados.Count; i++)
            {
                char op = operadoresOrdenados[i][0];
                int siguienteNumero = numerosOrdenados[i + 1];

                if (op == '+')
                    resultadoFinal += siguienteNumero;
                else if (op == '-')
                    resultadoFinal -= siguienteNumero;
            }

            richTextBox1.Text = $"{resultadoFinal}";

        }
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static bool OperadoresConsecutivos(string expresion)
        {
            string ops = "+-*/";
            for (int i = 0; i < expresion.Length - 1; i++)
            {
                if (ops.Contains(expresion[i]) && ops.Contains(expresion[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            timer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
