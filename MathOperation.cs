using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trpz_Calculator
{
    public static class MathOperation
    {
        public static string Add(string num1, string num2)
        {
            double a;
            double b;
            if(!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)){ return null; }
            return (a + b).ToString();
        }
        public static string Sub(string num1, string num2)
        {
            double a;
            double b;
            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)){ return null; }
            return (a - b).ToString();
        }
        public static string Mul(string num1, string num2)
        {
            double a;
            double b;
            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)){ return null; }
            return (a * b).ToString();
        }
        public static string Dev(string num1, string num2)
        {
            double a;
            double b;
            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)) { return null; }
            return (a / b).ToString();
        }
        public static string Perc(string num1, string num2)
        {
            double a;
            double b;
            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)) { return null; }
            return (a * b / 100).ToString();
        }
        public static string Sqrt(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)){ return null; }
            return Math.Sqrt(a).ToString();
        }
        public static string Pow(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return Math.Pow(a,2).ToString();
        }
        public static string OneDev(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return (1 / a).ToString();
        }
        public static string Sin(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return Math.Sin(a).ToString();
        }
        public static string Cos(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return Math.Cos(a).ToString();
        }
        public static string Tg(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return Math.Tan(a).ToString();
        }
        public static string Ctg(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return (1 / Math.Tan(a)).ToString();
        }
        public static string Round(string num1)
        {
            double a;
            if (!Double.TryParse(num1, out a)) { return null; }
            return Math.Round(a,1).ToString();
        }
        
    }
}
