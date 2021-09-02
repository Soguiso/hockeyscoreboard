using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace hockeyScoreboard
{
    public partial class Form1 : Form
    {
        private DateTime dtInicial;
        private TimeSpan Calc;
        private StreamWriter sw;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void escreveTempoNoArquivo(String tempo)
        {
            try
            {
                sw = new StreamWriter("time.txt", false, Encoding.ASCII);
                sw.Write(tempo);
                sw.Close();
            }
            catch (Exception c)
            {
                Console.WriteLine("exeption:   " + c.Message);
            }
            finally
            {
                Console.WriteLine("Finaly Block!!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //apagaTempoNoArquivo();
            Calc = dtInicial - DateTime.Now;
            textBox1.Text = string.Format("{0:ss}", Calc.Minutes.ToString());
            textBox2.Text = string.Format("{0:ss}", Calc.Seconds.ToString());
            escreveTempoNoArquivo(textBox1.Text + ":" + textBox2.Text);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = timeOption.Text;
            if (textBox1.Text == "15")
            {
                dtInicial = DateTime.Now.AddMinutes(Convert.ToInt32(textBox1.Text));
                timer1.Enabled = true;
            }
            if (textBox1.Text == "20")
            {
                dtInicial = DateTime.Now.AddMinutes(Convert.ToInt32(textBox1.Text));
                timer1.Enabled = true;
            }
            else
            {
                timer1.Start();
            }
            //stopWatch.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            escreveTempoNoArquivo("");
        }

        
    }
}
