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
                else if (char.IsNumber(sym) == false && sym != '/')
                {
                    symvols.Add(currSymvol);
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
            return symvols;
        }

        private static readonly Dictionary<string, int> Protocol = new()
    {
        { "(", 0 },
        { ")", 0 },
        { "|", 1 },
        { "*", 2 },
        { "/", 2 },
        { "+", 3 },
        { "-", 3 }
    };

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
            return new Symvol { num = num / gcd, denum = denum / gcd };
        }

        private static Symvol Subtraction(Symvol a, Symvol b)
        {
            int num = a.num * b.denum - b.num * a.denum;
            int denum = a.denum * b.denum;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd };
        }

        private static Symvol Multip(Symvol a, Symvol b)
        {
            int num = a.num * b.num;
            int denum = a.denum * b.denum;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd };
        }

        private static Symvol Divide(Symvol a, Symvol b)
        {
            int num = a.num * b.denum;
            int denum = a.denum * b.num;
            int gcd = GCD(num, denum);
            return new Symvol { num = num / gcd, denum = denum / gcd };
        }

        public static List<Symvol> ToRPN(List<Symvol> symvol)
        {
            var symvols = new List<Symvol>();
            var stack = new Stack<Symvol>();

            foreach (var symv in symvol)
            {
                if (symv.move == "")
                {
                    symvols.Add(symv);
                }
                else if (symv.move == "(")
                {
                    stack.Push(symv);
                }
                else if (symv.move == ")")
                {
                    while (stack.Count > 0 && stack.Peek().move != "(")
                    {
                        symvols.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 &&
                           stack.Peek().move != "(" &&
                           Protocol[stack.Peek().move] <= Protocol[symv.move])
                   
                    {
                        symvols.Add(stack.Pop());
                    }
                    stack.Push(symv);
                }
            }

            while (stack.Count > 0)
            {
                symvols.Add(stack.Pop());
            }

            return symvols;
        }

        public static Symvol CalculateRPN(List<Symvol> symvol)
        {
            var stack = new Stack<Symvol>();

            foreach (var symv in symvol)
            {
                if (symv.move == "")
                {
                    stack.Push(symv);
                }
                else
                {
                    Symvol b = stack.Pop();
                    Symvol a = stack.Pop();
                    var CurrSymv = new Symvol();

                    switch (symv.move)
                    {
                        case "+":
                            CurrSymv = Addition(a, b);
                            break;
                        case "-":
                            CurrSymv = Subtraction(a, b);
                            break;
                        case "*":
                            CurrSymv = Multip(a, b);
                            break;
                        case "/":
                            CurrSymv = Divide(a, b);
                            break;
                    }

                    stack.Push(CurrSymv);
                }
            }

            return stack.Pop();
        }

        private void Solution_Click(object sender, EventArgs e)
        {

            string s = Input.Text;
            List<Symvol> symvols = Sint(s);
            symvols = ToRPN(symvols);
            Symvol result = CalculateRPN(symvols);
            Output.Text = $"{result.num}/{result.denum}";

            //int i = 0;
            //char char1 = '*';
            //char char2 = ':';
            //int index1 = s.IndexOf(char1);
            //int index2 = s.IndexOf(char2);

            //if ((index1 < 0) && (index2 < 0))
            //{
            //    int counter = 1;
            //    for (int _ = 0; _ < symvols.Count; i++)
            //    {
            //        if (symvols[_].move != "")
            //        {
            //            symvols[_].prot = counter;
            //            counter++;
            //        }
            //    }
            //}

            //while (symvols.Count != 1)
            //{

            //    if (symvols[i].move != "")

            //    {

            //        if (symvols[i].move == "*")
            //        {

            //            symvols = Multip(i, symvols);
            //            i -= 1;

            //        }

            //        if (symvols[i].move == "*")
            //        {

            //            symvols = Addition(i, symvols);
            //            i -= 1;

            //        }

            //        if (symvols[i].move == "*")
            //        {

            //            symvols = Subtraction(i, symvols);
            //            i -= 1;

            //        }

            //    }

            //    i += 1;

            //}

            Output.Text = Convert.ToString(symvols[0].num) + '/' + Convert.ToString(symvols[0].denum);
        }
    }
}
