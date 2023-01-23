using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace compilador1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            codigos.Select();

        }

        int tokenllevado = 0;



        private void HomeButton_Click(object sender, EventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "documento de texto|*.txt";
            guardar.Title = "GUARDAR";
            guardar.FileName = "Sin titulo";
            var resultado = guardar.ShowDialog();
            if (resultado==DialogResult.OK) {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in codigos.Lines) {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }

        private void AbrirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "documento de texto|*.txt";
            abrir.Title = "Abrir";
            abrir.FileName = "Sin titulo";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                codigos.Text = leer.ReadToEnd();
                    
                
                leer.Close();
            }


        }



        private void compi(string cadena)
        {


            
            int inicioestado ;                                         
            char cadenaconcatenar;
            string saber_espacio = "";
            string token1 = "";
            string variables = "";
            dataLexemas.Rows.Clear();
           
            for (inicioestado = 0; inicioestado < cadena.Length; inicioestado++)
            {
                cadenaconcatenar = cadena[inicioestado];
                if(inicioestado+1 != cadena.Length)
                {
                    saber_espacio = cadena[inicioestado + 1].ToString();
                }
                variables += cadenaconcatenar;
                token1 += cadenaconcatenar;
                Boolean gg = false;



                if (


                    token1 == " " |
                    token1 == "int" |
                    token1 == "float" |
                    token1 == "void" |
                    token1 == "<" |
                    token1 == "<=" |
                    token1 == ">" |
                    token1 == ">=" |
                    token1 == "||" |
                    token1 == "&&" |

                    token1 == "!=" |
                    token1 == ";" |
                    token1 == "," |
                    token1 == "(" |
                    token1 == ")" |
                    token1 == "{" |
                    token1 == "}" |
                    token1 == "if" |
                    token1 == "while" |
                    token1 == "return" |
                    token1 == "else" |
                    token1 == "$" |
                    token1 == "+" |
                    token1 == "-" |
                    token1 == "/" |
                    token1 == "*"  //este lo agregue extra

                        )
                {

                    DescripciondelosToken(token1);
                    TokenValidos(token1);
                    token1 = "";
                    gg = true;
                    variables = "";

                }
                else if (token1 == "=")
                {


                    if (saber_espacio == "=")
                    {

                        txtSalida.Text = txtSalida.Text + "==" + " " + "opIgualdad = 11\n";
                        tokenllevado = dataLexemas.Rows.Add();
                        dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = token1+"=";
                        dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "11";
                        token1 = "";
                        gg = true;
                        variables = "";
                        inicioestado++;
                        

                    }
                    else
                    {
                        txtSalida.Text = txtSalida.Text + "=" + " " + "= 18\n";
                        tokenllevado = dataLexemas.Rows.Add();
                        dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = token1;
                        dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "18";

                        token1 = "";
                        gg = true;
                        variables = "";
                    }


                }
                else if (variables.Length > 0 && ( saber_espacio == " "))
                {


                    if (Regex.IsMatch(token1, @"^[a-zA-Z][a-zA-Z0-9]+") == true) //si es variable entramos
                    {
                        txtSalida.Text = txtSalida.Text + token1 + " " + "Identificador = 0\n";
                        tokenllevado = dataLexemas.Rows.Add();
                        dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = token1;
                        dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "0";
                        token1 = "";
                        gg = true;
                        variables = "";

                    }
                    else if(Regex.IsMatch(token1, @"^[0-9]*") == true) //si es un numero podria ser entero o real entramos
                    {
                        if (token1.Contains(".")) //si tiene un . el numero es real
                        {
                            txtSalida.Text = txtSalida.Text + token1 + " " + "Real= 2\n";
                            tokenllevado = dataLexemas.Rows.Add();
                            dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = token1;
                            dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "2";
                            token1 = "";
                            gg = true;
                            variables = "";
                        }
                        else // si no tiene punto va a hacer el entero
                        {
                            txtSalida.Text = txtSalida.Text + token1 + " " + "Entero= 1\n";
                            tokenllevado = dataLexemas.Rows.Add();
                            dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = token1;
                            dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "1";
                            token1 = "";
                            gg = true;
                            variables = "";
                        }

                    }

                }
                
            }







        }



        public void DescripciondelosToken(string tokeniguala)
        {
            switch (tokeniguala)
            {
            

                    //lo agregue
                case "int":
                    txtSalida.Text = txtSalida.Text + "int" + " " + "tipo = 6\n";
                    break;
                case "float":
                    txtSalida.Text = txtSalida.Text + "float" + " " + "tipo = 6\n";
                    break;
                case "void":
                    txtSalida.Text = txtSalida.Text + "void" + " " + "tipo = 6\n";
                    break;
                case "+":
                    txtSalida.Text = txtSalida.Text + "+" + " " + " opSuma = 5\n";
                    break;
                case "-":
                    txtSalida.Text = txtSalida.Text + "-" + " " + "opSuma = 5\n";
                    break;
                case "/":
                    txtSalida.Text = txtSalida.Text + "/" + " " + "opMul = 6\n";
                    break;
                case "*":
                    txtSalida.Text = txtSalida.Text + "*" + " " + "opMul = 6\n";
                    break;

                case "<":
                    txtSalida.Text = txtSalida.Text + "<" + " " + "opRelac = 7\n";
                    break;
                case "<=":
                    txtSalida.Text = txtSalida.Text + "<=" + " " + "opRelac = 7\n";
                    break;
                case ">":
                    txtSalida.Text = txtSalida.Text + ">" + " " + "opRelac = 7\n";
                    break;
                case ">=":
                    txtSalida.Text = txtSalida.Text + ">=" + " " + "opRelac = 7\n";
                    break;

                case "||":
                    txtSalida.Text = txtSalida.Text + "||" + " " + "opOr = 8\n";
                    break;
                case "&&":
                    txtSalida.Text = txtSalida.Text + "&&" + " " + "opAnd = 9\n";
                    break;
                case "!":
                    txtSalida.Text = txtSalida.Text + "!" + " " + "opNot = 10\n";
                    break;

                case "!=":
                    txtSalida.Text = txtSalida.Text + "!=" + " " + "opIgualdad = 11\n";
                    break;
                case ";":
                    txtSalida.Text = txtSalida.Text + ";" + " " + "= 12\n";
                    break;
                case ",":
                    txtSalida.Text = txtSalida.Text + "," + " " + "= 13\n";
                    break;
                case "(":
                    txtSalida.Text = txtSalida.Text + "*(*" + " " + "= 14\n";
                    break;
                case ")":
                    txtSalida.Text = txtSalida.Text + "*)*" + " " + "= 15\n";
                    break;
                case "{":
                    txtSalida.Text = txtSalida.Text + "*{*" + " " + "= 16\n";
                    break;
                case "}":
                    txtSalida.Text = txtSalida.Text + "*}*" + " " + "= 17\n";
                    break;
                case "if":
                    txtSalida.Text = txtSalida.Text + "if" + " " + "= 19\n";
                    break;
                case "while":
                    txtSalida.Text = txtSalida.Text + "while" + " " + "= 20\n";
                    break;
                case "return":
                    txtSalida.Text = txtSalida.Text + "return" + " " + "= 21\n";
                    break;
                case "else":
                    txtSalida.Text = txtSalida.Text + "else" + " " + "= 22\n";
                    break;
                case "$":
                    txtSalida.Text = txtSalida.Text + "$" + " " + "= 23\n";
                    break;
                case " ":
                    txtSalida.Text = txtSalida.Text + "(espacio)" + " " + "= 24\n";
                    break;

            }



        }




        private void TokenValidos(string lexema)
        {
            tokenllevado = dataLexemas.Rows.Add();
            switch (lexema)
            {

                    //agregado

                case "int":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "4";
                    break;
                case "void":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "4";
                    break;
                case "float":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "4";
                    break;
                case "-":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "5";
                    break;
                case "+":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "5";
                    break;
                case "*":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "6";
                    break;
                case "/":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "6";
                    break;

                case "<":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "7";
                    break;
                case "<=":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "7";
                    break;
                case ">":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "7";
                    break;
                case ">=":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "7";
                    break;
                case "||":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "8";
                    break;
                case "&&":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "9";
                    break;
                case "!":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "10";
                    break;

 
                case "!=":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "11";
                    break;

                case ";":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "12";
                    break;
                case ",":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "13";
                    break;
                case "(":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "14";
                    break;
                case ")":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "15";
                    break;
                case "{":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "16";
                    break;
                case "}":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "17";
                    break;
                case "if":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "19";
                    break;
                case "while":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "20";
                    break;
                case "return":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "21";
                    break;
                case "else":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "22";
                    break;
                case "$":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "23";
                    break;
                case " ":
                    dataLexemas.Rows[tokenllevado].Cells["Lexema"].Value = lexema;
                    dataLexemas.Rows[tokenllevado].Cells["Token"].Value = "24";
                    break;


            }


        }








        private void PictureBox1_Click(object sender, EventArgs e)
        {
           DialogResult res = MessageBox.Show("Seguro que quieres BORRAR TODO sin guardar?", "ALERTA", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res== DialogResult.Yes) {

                txtSalida.Text = "";
                dataLexemas.Rows.Clear();
                codigos.Text = "";

            }



           
        }

        private void CompilarButton_Click(object sender, EventArgs e)
        {
            
            string cadenatoken = codigos.Text;      
            compi(cadenatoken);    
            dataLexemas.Visible = true;
           





        }
        
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            StreamReader leer = new StreamReader("C:/Users/kevdc/Desktop/proyectos/compilador1/sintaxis.txt");
            codigos.Text = leer.ReadToEnd();


            leer.Close();
        }
        

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form2 fo = new Form2();
            fo.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            

            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
           
                
        }

        private void codigos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataLexemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
