using System;
using System.Globalization;
using System.Windows.Forms;

namespace nose
{
    public partial class CalculadoraForm : Form
    {
        public CalculadoraForm()
        {
            InitializeComponent();

            // Establecer la cultura con punto como separador decimal
            CultureInfo culture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "0";
            }
            else
            {
                lblResult.Text += "0";
            }
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "1";
            }
            else
            {
                lblResult.Text += "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "2";
            }
            else
            {
                lblResult.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "3";
            }
            else
            {
                lblResult.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "4";
            }
            else
            {
                lblResult.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "5";
            }
            else
            {
                lblResult.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "6";
            }
            else
            {
                lblResult.Text += "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "7";
            }
            else
            {
                lblResult.Text += "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "8";
            }
            else
            {
                lblResult.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "9";
            }
            else
            {
                lblResult.Text += "9";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = ".";
            }
            else
            {
                lblResult.Text += ".";
            }
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
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "(";
            }
            else
            {
                lblResult.Text += "(";
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = ")";
            }
            else
            {
                lblResult.Text += ")";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "+";
            }
            else
            {
                lblResult.Text += "+";
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "-";
            }
            else
            {
                lblResult.Text += "-";
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "*";
            }
            else
            {
                lblResult.Text += "*";
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Ha ocurrido un error")
            {
                lblResult.Text = "/";
            }
            else
            {
                lblResult.Text += "/";
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            var result = Procesamiento.ResolverExpresion(lblResult.Text);
            lblResult.Text = result.ToString();
        }
    }
}