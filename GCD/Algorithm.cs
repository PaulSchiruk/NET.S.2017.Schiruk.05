using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GCD
{
    public class Algorithm
    {
        private static readonly Stopwatch time = new Stopwatch();
        public static (string, int) EuclideanAlgorithm(int a, int b)
        {
            time.Restart();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (b == 0) return (time.Elapsed.ToString(), a);
            if (a == 0) return (time.Elapsed.ToString(), a);
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            time.Stop();
            return (time.Elapsed.ToString(), a);
        }

        public static (string, int) EuclideanAlgorithm(params int[] set)
        {
            time.Restart();

            if (set.Length < 2) throw new ArgumentException("Must be 2 or more arguents");
            string s;
            for (int i = 0; i < set.Length - 1; i++)
            {
                (s, set[i + 1]) = EuclideanAlgorithm(set[i], set[i + 1]);
            }
            time.Stop();
            return (time.Elapsed.ToString(), set[set.Length - 1]);
        }


        public static (string, int) BinaryAlgorithm(int a, int b)
        {

            time.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b)
            {
                time.Stop();
                return (time.Elapsed.ToString(), a);

            }
            if (a == 0)
            {
                time.Stop();
                return (time.Elapsed.ToString(), b);

            }
            if (b == 0)
            {
                time.Stop();
                return (time.Elapsed.ToString(), a);

            }
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return BinaryAlgorithm(a >> 1, b);
                else
                {
                    (string s, int p) = BinaryAlgorithm(a >> 1, b >> 1);
                    return (s, p << 1);
                }
            }
            if ((~b & 1) != 0)
                return BinaryAlgorithm(a, b >> 1);
            if (a > b)
                return BinaryAlgorithm((a - b) >> 1, b);
            return BinaryAlgorithm((b - a) >> 1, a);
        }

        public static (string, int) BinaryAlgorithm(params int[] set)
        {
            time.Restart();
            if (set.Length < 2) throw new ArgumentException("Must be 2 or more arguents");
            string s;
            for (int i = 0; i < set.Length - 1; i++)
            {
                (s, set[i + 1]) = BinaryAlgorithm(set[i], set[i + 1]);
            }
            time.Stop();
            return (time.Elapsed.ToString(), set[set.Length - 1]);
        }
    }

    public static class BinDouble
    {
        public static string DoubleToIEEE754(double number)
        {
            int sign = 0;
            if (number < 0) sign = 1;
            int counter = 0;
            double commonNum = number;
            while (commonNum % 10 != 0)
            {
                commonNum *= 10;
                counter++;
            }
            long manitisa = Convert.ToInt64(commonNum);
            StringBuilder strMantisa = new StringBuilder();// = Convert.ToString(manitisa);
            while(manitisa == 0)
            {
                strMantisa.Append(manitisa % 2);
                manitisa /= 2;
            }
            for (int i = strMantisa.Length; i < 52; i++)
            {
                strMantisa.Append("0");
            }
            int order = counter + 1023;
            BitArray bitArray = new BitArray(order);

            return sign.ToString() + bitArray + strMantisa;
        }
    }



    public class Polynom
    {
        private int[] coefArray;
        
        public int[] Coefficents => coefArray;

        public Polynom()
        {
            coefArray = new int[0];
        }

        public Polynom(int i)
        {
            coefArray = new int[i];
        }
        public Polynom(params int[] coefficient)
        {
            Array.Resize(ref coefArray, coefficient.Length);
            for (int i = 0; i < coefficient.Length; i++)
            {
                coefArray[i] = coefficient[i];
            }
        }

        public void Add(params int[] num)
        {
            int size = coefArray.Length;
            Array.Resize(ref coefArray, coefArray.Length + num.Length);
            for (int i = size; i < coefArray.Length; i++)
            {
                coefArray[i] = num[i - size];
            }
        }

        public int Length() => coefArray.Length;

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = coefArray.Length - 1; i <= 0; i++)
            {
                str.Append(coefArray[i] + "x^" + i + " + ");
            }
            return str.ToString();
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            int lngth, lngth2;
            bool flag = false;

            if (a.Length() < b.Length())
            {
                lngth = a.Length();
                lngth2 = b.Length();
                flag = true;
            }
            else
            {
                lngth = b.Length();
                lngth2 = a.Length();
            }

            Polynom res = new Polynom();
            for (int i = 0; i < lngth; i++)
            {
                res.Add(a.Coefficents[i] + b.Coefficents[i]);
            }
            
            for (int i = lngth; i < lngth2; i++)
            {
                res.Add(flag ? b.Coefficents[i] : a.Coefficents[i]);
            }
            return res;
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {

            int lngth, lngth2;
            bool flag = false;

            if (a.Length() < b.Length())
            {
                lngth = a.Length();
                lngth2 = b.Length();
                flag = true;
            }
            else
            {
                lngth = b.Length();
                lngth2 = a.Length();
            }

            Polynom res = new Polynom();
            for (int i = 0; i < lngth; i++)
            {
                res.Add(a.Coefficents[i] - b.Coefficents[i]);
            }

            for (int i = lngth; i < lngth2; i++)
            {
                res.Add(flag ? b.Coefficents[i] : a.Coefficents[i]);
            }
            return res;
        }

        public static Polynom operator *(Polynom a, Polynom b)
        {
            Polynom res = new Polynom(a.Length() + b.Length());

            for (int i = a.Length(); i >= 0; i--)
            {
                for (int j = b.Length(); j >= 0; j--)
                {
                    res.coefArray[i + j] += a.Coefficents[i] * b.Coefficents[j];
                }
            }
            return res;
        }

    }



}
