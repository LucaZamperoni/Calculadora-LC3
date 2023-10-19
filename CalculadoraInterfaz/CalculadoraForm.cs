using System;
using System.Windows.Forms;
using System.Globalization;

namespace Calculadora
{
    public partial class CalculadoraForm : Form
    {
        public CalculadoraForm()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        bool resuelto = true;

        private void escribir(string numOrOp)
        {
            Console.WriteLine(resuelto +" "+ numOrOp);
            if (resuelto)
            {
                lblResult.Text = numOrOp;
                resuelto = false;
            }
            else
            {
                lblResult.Text += numOrOp;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            escribir("0");
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            escribir("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            escribir("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            escribir("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            escribir("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            escribir("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            escribir("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            escribir("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            escribir("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            escribir("9");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            escribir(".");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Estas intentando borrar algo que no tiene nada");
                resuelto = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            escribir("(");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            escribir(")");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            escribir("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            escribir("-");
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            escribir("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            escribir("/");
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            resuelto = true;
            try
            {
                var result = Procesamiento.ResolverExpresion(lblResult.Text);
                lblResult.Text = result.ToString();
            }
            catch (Exception exception)
            {
                lblResult.Text = exception.Message;
            }
            
        }
    }
}