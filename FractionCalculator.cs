using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_simple_fraction
{
    public partial class FractionCalculator
    {

        public class Symvol
        {
            public int num;
            public int denum;
            public int whole;
            public string move = "";


            enum Move;

            public override String ToString()
            {
                return num + ":" + denum + ":" + move;
            }
        }


        public static List<Symvol> Sint(String s) // переписываем строку в лист особого класса
        {
            List<Symvol> symvols = [];
            Symvol currSymvol = new Symvol();
            bool Numerator = true;
            for (int i = 0; i < s.Length; i++)
            {

                char sym = s[i];
                if ((char.IsNumber(sym) == true) && (Numerator == true)) // числитель ли это
                {
                    currSymvol.num *= 10;
                    string k = Convert.ToString(sym);
                    int l = Convert.ToInt32(k);
                    currSymvol.num += l;
                }
                else if ((char.IsNumber(sym) == true) && (Numerator == false)) // знаменатель ли это
                {
                    currSymvol.denum *= 10;
                    string k = Convert.ToString(sym);
                    int l = Convert.ToInt32(k);
                    currSymvol.denum += l;
                }
                else if (char.IsNumber(sym) == false && sym != '/' && sym != '|' && i != 0) // получили ли не число и не слэш - любой символ (проверка на ариметические действия происходт позже)
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
                else if (sym == '/' && Numerator == true) // изменить флаг, если до этого был числитель
                {
                    Numerator = false;
                }
                else if (sym == '/' && Numerator == false) // если после знаменателя идет знаменатель
                {
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    currSymvol.move = "Fail";
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    Numerator = true;

                }
                else if (sym == '|')
                {

                    currSymvol.denum = 1;
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    currSymvol.move = "+";
                    symvols.Add(currSymvol);
                    currSymvol = new Symvol();
                    Numerator = true;
                }

            }

            symvols.Add(currSymvol);

            for (int i = 0; i < symvols.Count; i++) // убрать пробелы
            {

                if (symvols[i].move == "" && symvols[i].num == 0 && symvols[i].denum == 0 && symvols[i].whole == 0)
                {

                    symvols.RemoveAt(i);
                    i--;

                }

            }

            return symvols;
        }


        public static bool Mistakes(List<Symvol> symvols) // проверка на ошибки
        {

            int flag = 0;
            int k = 0;
            while (k < symvols.Count) // сбалансированность скобок
            {

                if (symvols[k].move == "(")
                {
                    flag++;
                }
                else if (symvols[k].move == ")")
                {
                    flag--;
                }

                k++;

            }

            if (flag != 0)
            {

                return false;

            }

            for (int i = 0; i < symvols.Count; i++) // проверка на деление на ноль в дробях и на лишние символы
            {

                if (symvols[i].denum == 0 && symvols[i].move == "" && symvols[i].whole == 0)
                {

                    return false;

                }

                else if (symvols[i].move != "*" && symvols[i].move != ":" && symvols[i].move != "-" && symvols[i].move != "+" && symvols[i].move != "(" && symvols[i].move != ")" && symvols[i].move != "|" && symvols[i].num == 0 && symvols[i].denum == 0 && symvols[i].whole == 0)
                {

                    return false;

                }

            }

            for (int i = 0; i < symvols.Count - 1; i++) // подряд идущие арифметические действии (1/2++2/3)
            {

                if (symvols[i].move == symvols[i + 1].move && (symvols[i + 1].move != "(" && symvols[i].move != "(") && (symvols[i + 1].move != ")" && symvols[i].move != ")"))
                {

                    return false;

                }

            }

            return true;

        }


        public static List<Symvol> Minus(List<Symvol> symvols) // переписываем числа с минусом перед собой как отрицаетльный числитель
        {

            for (int i = 0; i < symvols.Count - 1; i++)
            {

                if (symvols[i].move == "-" && ((symvols[i + 1].num == 0 && symvols[i + 1].denum == 0) || i == 0 || symvols[i - 1].move != ""))
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

        //public static Symvol Int_part(Symvol a, Symvol b)
        //{

        //    int num = a.whole * b.denum + b.num;
        //    int denum = b.denum;
        //    int gcd = GCD(num, denum);
        //    return new Symvol { num = num / gcd, denum = denum / gcd, move = "" };
        //}

        private static int FindBracket(List<Symvol> symvols, int start = 0) // поиск закрывающей скобки
        {
            int flag = 1;
            int i = start + 1;
            while ((flag != 0) && (i < symvols.Count))
            {

                if (symvols[i].move == "(")
                {
                    flag++;
                }
                else if (symvols[i].move == ")")
                {
                    flag--;
                }

                i++;

            }


            return i - 1;


        }

        public static List<Symvol> SolutBrackets(List<Symvol> symvols) // решение только скобок
        {

            for (int i = 0; i < symvols.Count; i++)
            {

                if (symvols[i].move == "(")
                {

                    int fin = FindBracket(symvols, i);
                    int start = i;
                    List<Symvol> part = symvols.GetRange(start + 1, fin - start - 1);
                    part = Solut(part);                                                     // происходит рекурсия
                    symvols.RemoveRange(start, fin - start + 1); //
                    symvols.InsertRange(start, part);          // замена скобки на результат скобки
                    i += part.Count - 1;                       //

                }

            }

            return symvols;

        }

        //public static List<Symvol> Solut_int_part(List<Symvol> symvols)
        //{

        //    for (int i = 0; i < symvols.Count - 1; i++)
        //    {

        //        if (symvols[i].move == "|")
        //        {

        //            symvols[i + 1] = Int_part(symvols[i - 1], symvols[i + 1]);
        //            symvols.RemoveAt(i - 1);
        //            i--;
        //            symvols.RemoveAt(i);
        //            i--;

        //        }

        //    }

        //    return symvols;

        //}

        public static List<Symvol> SolutFirstPriority(List<Symvol> symvols) // решение слева направо все действия умножения и деления
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

        public static List<Symvol> SolutSecondPriority(List<Symvol> symvols)  // решение слева направо все действия сложения и вычитания
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


        public static List<Symvol> Solut(List<Symvol> symvols) // решить пример, который ввели, либо же часть примера из скобок
        {

            List<Symvol> result = SolutBrackets(symvols);
            result = Minus(result);
            result = SolutFirstPriority(result);
            result = SolutSecondPriority(result);

            return result;

        }

        public static Symvol ConvInt(Symvol a)
        {
            bool minuser = a.num < 0;
            int num = Math.Abs(a.num);

            a.whole = num / a.denum;
            a.num = num % a.denum;

            if (minuser)
            {

                a.whole *= -1;

            }

            return a;

        }


    }
}
