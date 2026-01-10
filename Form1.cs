namespace Calculator_of_simple_fraction
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Output.Text = Input.Text;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Help MyForm = new Help();
            MyForm.Show();
        }

        private void Solution_Click(object sender, EventArgs e)
        {

            string s = Input.Text;
            var symvols = FractionCalculator.Sint(Input.Text);
            var mistake = FractionCalculator.Mistakes(symvols);
            if (mistake == false)
            {

                Output.Text = Output.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

            }

            else
            {
                //List<Symvol> result = Solut_int_part(symvols);
                
                var result = FractionCalculator.Solut(symvols);

                if (result[0].denum < 0)
                {

                    result[0].denum *= -1;
                    result[0].num *= -1;

                }
                
                if (result[0].denum == 0)
                {

                    Output.Text = Output.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

                }
                else
                {

                    if (result[0].num < result[0].denum)
                    {

                        Output.Text += " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);

                    }
                    else if (result[0].denum == 1)
                    {

                        result[0] = FractionCalculator.ConvInt(result[0]);
                        Output.Text += " = " + Convert.ToString(result[0].whole);

                    }

                    else
                    {

                        Output.Text += " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);
                        result[0] = FractionCalculator.ConvInt(result[0]);
                        Output.Text += " = " + Convert.ToString(result[0].whole) + '|' + Convert.ToString(result[0].num) + '/' + Convert.ToString(result[0].denum);

                    }

                }
            }
        }
    }

}
