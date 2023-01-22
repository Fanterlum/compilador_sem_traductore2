using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace compilador1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();



            StreamReader leer = new StreamReader("C:/Users/kevdc/Desktop/proyectos/compilador1/informacion.txt");
            richTextBox1.Text = leer.ReadToEnd();


            leer.Close();
            button1.Select();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
