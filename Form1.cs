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

        private void escreveTempoNoArquivo(String tempo, String path)
        {
            try
            {
                sw = new StreamWriter(path, false, Encoding.ASCII);
                sw.Write(tempo);
                sw.Close();
            }
            catch (Exception c)
            {
                Console.WriteLine("exeption:   " + c.Message);
            }
            finally
            {
                Console.WriteLine("!");
            }
        }

        private void MainTime(object sender, EventArgs e)
        {
           
            Calc = dtInicial - DateTime.Now;
            textBox1.Text = Calc.Minutes.ToString();
            textBox2.Text = Calc.Seconds.ToString();
            escreveTempoNoArquivo(textBox1.Text + ":" + textBox2.Text,"time.txt");
            
        }
        private void homePanaltyTime(object sender, EventArgs e)
        {
           
            Calc = dtInicial - DateTime.Now;
            textBox4.Text = Calc.Minutes.ToString();
            textBox3.Text = Calc.Seconds.ToString();
            escreveTempoNoArquivo(textBox4.Text + ":" + textBox3.Text, "homePenaltyTime.txt");

        }
        private void awayPanaltyTime(object sender, EventArgs e)
        {
            
            Calc = dtInicial - DateTime.Now;
            textBox11.Text = string.Format("{0:ss}", Calc.Minutes.ToString());
            textBox10.Text = string.Format("{0:ss}", Calc.Seconds.ToString());
            escreveTempoNoArquivo(textBox12 + textBox11.Text + ":" + textBox10.Text, "awayPenaltyTime.txt");

        }
        private void button1_Click(object sender, EventArgs e)
        {

            dtInicial = DateTime.Now.AddMinutes(13);
            time.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            time.Stop();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            escreveTempoNoArquivo("","time.txt");
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        //private void timeOption_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    textBox1.Text = timeOption.Text;
       // }
    }
}
