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

        public class Symvol
        {
            public int num;
            public int denum;
            public int prot;
            public string move = "";


            enum Move;

            public override String ToString()
            {
                return num + ":" + denum + ":" + move;
            }
        }


        static List<Symvol> Sint(String s)
        {
            List<Symvol> symvols = [];
            Symvol currSymvol = new Symvol();
            bool Numerator = true;
            for (int i = 0; i < s.Length; i++)
            {

                char sym = s[i];
                if ((char.IsNumber(sym) == true) && (Numerator == true))
                {
                    currSymvol.num *= 10;
                    string k = Convert.ToString(sym);
                    int l = Convert.ToInt32(k);
                    currSymvol.num += l;
                }
                else if ((char.IsNumber(sym) == true) && (Numerator == false))
                {
                    currSymvol.denum *= 10;
                    string k = Convert.ToString(sym);
                    int l = Convert.ToInt32(k);
                    currSymvol.denum += l;
                }
                else if (char.IsNumber(sym) == false && sym != '/' && i != 0)
                {
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    currSymvol.move = Convert.ToString(sym);
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    Numerator = true;
                }
                else if (char.IsNumber(sym) == false && sym != '/' && i == 0)
                {
                    currSymvol = new Symvol();
                    currSymvol.move = Convert.ToString(sym);
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    Numerator = true;
                }
                else if (sym == '/')
                {
                    Numerator = false;
                }

            }

            symvols.Add(currSymvol);

            for (int i = 0; i < symvols.Count; i++)
            {

                if (symvols[i].move == "" && symvols[i].num == 0 && symvols[i].denum == 0)
                {

                    symvols.RemoveAt(i);
                    i--;

                }

            }

            return symvols;
        }


        public static bool Mistakes(List<Symvol> symvols)
        {

            int flag = 0;
            int k = 0;
            while (k < symvols.Count - 1)
            {
                k++;

                if (symvols[k].move == "(")
                {
                    flag++;
                }
                else if (symvols[k].move == ")")
                {
                    flag--;
                }

            }

            if (flag != 0)
            {

                return false;

            }

            for (int i = 0; i < symvols.Count; i++)
            {
              
                if (symvols[i].denum == 0 && symvols[i].move == "")
                {

                    return false;

                }

                else if (symvols[i].move != "*" && symvols[i].move != ":" && symvols[i].move != "-" && symvols[i].move != "+" && symvols[i].num == 0 && symvols[i].denum == 0)
                {

                    return false;

                }

            }

            for (int i = 0; i < symvols.Count - 1; i++)
            {

                if (symvols[i].move == symvols[i+1].move)
                {

                    return false;

                }

            }

            return true;

        }

        
        public static List<Symvol> Minus(List<Symvol> symvols)
        {

            for (int i = 0; i < symvols.Count - 1; i++)
            {

                if (symvols[i].move == "-" && ((symvols[i+1].num == 0 && symvols[i + 1].denum == 0) || i == 0 || symvols[i-1].move != ""))
                {

                    symvols[i + 1].num *= -1;
                    symvols.RemoveAt(i);

                }
                
            }

            return symvols;

        }

        public static int GCD(int val1, int val2)
        {
            if (val2 == 0)
                return val1;
            else
                return GCD(val2, val1 % val2);
        }

        private static Symvol Addition(Symvol a, Symvol b)
        {
            int num = a.num * b.denum + b.num * a.denum;
            int denum = a.denum * b.denum;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd, move = "" };
        }

        private static Symvol Subtraction(Symvol a, Symvol b)
        {
            int num = a.num * b.denum - b.num * a.denum;
            int denum = a.denum * b.denum;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd, move = "" };
        }

        private static Symvol Multip(Symvol a, Symvol b)
        {
            int num = a.num * b.num;
            int denum = a.denum * b.denum;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd, move = "" };
        }

        private static Symvol Divide(Symvol a, Symvol b)
        {
            int num = a.num * b.denum;
            int denum = a.denum * b.num;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd, move = "" };
        }

        private static int FindBracket(List<Symvol> symvols, int start=0)
        {
            int flag = 1;
            int i = start + 1;
            while ((flag != 0) && (i < symvols.Count))
            {
                i++;

                if (symvols[i].move == "(")
                {
                    flag++;
                }
                else if (symvols[i].move == ")")
                {
                    flag--;
                }

            }

           
            return i;


        }

        public static List<Symvol> SolutBrackets(List<Symvol> symvols)
        {

            for (int i = 0; i < symvols.Count; i++)
            {

                if (symvols[i].move == "(")
                {

                    int fin = FindBracket(symvols, i);
                    int start = i;
                    List<Symvol> part = symvols.GetRange(start + 1, fin - start - 1);
                    part = Solut(part);
                    symvols.RemoveRange(start, fin - start + 1);
                    symvols.InsertRange(start, part);
                    i += part.Count - 1;

                }

            }

            return symvols;

        }

        public static List<Symvol> SolutFirstPriority(List<Symvol> symvols)
        {

            for (int i = 0; i < symvols.Count; i++)
            {

                if (symvols[i].move == "*")
                {

                    symvols[i] = Multip(symvols[i - 1], symvols[i + 1]);
                    symvols.RemoveAt(i - 1);
                    i--;
                    symvols.RemoveAt(i + 1);
                    i--;

                }
                else if (symvols[i].move == ":")
                {

                    symvols[i] = Divide(symvols[i - 1], symvols[i + 1]);
                    symvols.RemoveAt(i - 1);
                    i--;
                    symvols.RemoveAt(i + 1);
                    i--;

                }


            }

            List<Symvol> result = symvols;

            return result;

        }

        public static List<Symvol> SolutSecondPriority(List<Symvol> symvols)
        {

            for (int i = 0; i < symvols.Count; i++)
            {

                if (symvols[i].move == "+")
                {

                    symvols[i] = Addition(symvols[i - 1], symvols[i + 1]);
                    symvols.RemoveAt(i - 1);
                    i--;
                    symvols.RemoveAt(i + 1);
                    i--;

                }
                else if (symvols[i].move == "-")
                {

                    symvols[i] = Subtraction(symvols[i - 1], symvols[i + 1]);
                    symvols.RemoveAt(i - 1);
                    i--;
                    symvols.RemoveAt(i + 1);
                    i--;

                }


            }

            List<Symvol> result = symvols;

            return result;

        }


        public static List<Symvol> Solut(List<Symvol> symvols)
        {

            List<Symvol> result = SolutBrackets(symvols);
            result = Minus(result);
            result = SolutFirstPriority(result);
            result = SolutSecondPriority(result);

            return result;

        }

        private void Solution_Click(object sender, EventArgs e)
        {

            string s = Input.Text;
            List<Symvol> symvols = Sint(s);
            bool mistake = Mistakes(symvols);
            if (mistake == false)
            {

                Output.Text = Output.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

            }

            else
            {
                List<Symvol> result = Solut(symvols);

                if (result[0].denum < 0)
                {

                    result[0].denum *= -1;
                    result[0].num *= -1;

                }
                else if (result[0].denum == 0)
                {

                    Output.Text = Output.Text + " = " + "Ошибка может быть в синтаксисе, либо же в корректности выражения";

                }
                else
                {

                    Output.Text = Output.Text + " = " + Convert.ToString(result[0].num) + '/' + Convert.ToString(result[0].denum);

                }
            }
        }
    }
}
