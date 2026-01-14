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
            Numerator.Text = Input.Text;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            OutDenumerator.Text = Denumerator.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

     

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {
            Help MyForm = new Help();
            MyForm.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                OutDenumerator.Visible = false;
                Output.Visible = false;
                Denumerator.Visible = false;

            }
            else
            {

                Output.Visible = true;
                OutDenumerator.Visible = true;
                Denumerator.Visible = true;

            }
        }

        private void Solution_Click(object sender, EventArgs e)
        {

            string s = Input.Text;
            var symvols = FractionCalculator.Sint(Input.Text);
            var mistake = FractionCalculator.Mistakes(symvols);
            if (mistake == false)
            {

                Numerator.Text = Numerator.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

            }

            else
            {

                var result = FractionCalculator.Solut(symvols);

                if (result[0].denum < 0)
                {

                    result[0].denum *= -1;
                    result[0].num *= -1;

                }

                if (radioButton2.Checked == false)
                {

                    if (result[0].denum == 0)
                    {

                        Numerator.Text = Numerator.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

                    }
                    else
                    {

                        if (result[0].num < result[0].denum)
                        {

                            Numerator.Text += " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);

                        }
                        else if (result[0].denum == 1)
                        {

                            result[0] = FractionCalculator.ConvInt(result[0]);
                            Numerator.Text += " = " + Convert.ToString(result[0].whole);

                        }

                        else
                        {

                            Numerator.Text += " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);
                            result[0] = FractionCalculator.ConvInt(result[0]);
                            Numerator.Text += " = " + Convert.ToString(result[0].whole) + '|' + Convert.ToString(result[0].num) + '/' + Convert.ToString(result[0].denum);

                        }
                    }

                }
                else
                {

                    string s1 = Denumerator.Text;
                    var symvols1 = FractionCalculator.Sint(Denumerator.Text);
                    var mistake1 = FractionCalculator.Mistakes(symvols1);
                    if (mistake1 == false)
                    {

                        Numerator.Text = Numerator.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

                    }

                    else
                    {

                        var result1 = FractionCalculator.Solut(symvols1);

                        if (result1[0].denum < 0)
                        {

                            result1[0].denum *= -1;
                            result1[0].num *= -1;

                        }

                        result[0] = FractionCalculator.Divide(result[0], result1[0]);

                        if (result[0].denum == 0)
                        {

                            Output.Text = "-------------------------------" + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

                        }
                        else
                        {

                            if (result[0].num < result[0].denum)
                            {

                                Output.Text = "-------------------------------" + " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);

                            }
                            else if (result[0].denum == 1)
                            {

                                result[0] = FractionCalculator.ConvInt(result[0]);
                                Output.Text = "-------------------------------" + " = " + Convert.ToString(result[0].whole);

                            }

                            else
                            {

                                Output.Text = "-------------------------------" + " = " + Convert.ToString(result[0].num) + "/" + Convert.ToString(result[0].denum);
                                result[0] = FractionCalculator.ConvInt(result[0]);
                                Output.Text = "-------------------------------" + " = " + Convert.ToString(result[0].whole) + '|' + Convert.ToString(result[0].num) + '/' + Convert.ToString(result[0].denum);

                            }
                        }

                    }

                }

            }


        }
    }
}
