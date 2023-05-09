using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arch3_arop_sys
{
    internal class Program
    {
        static void Main(string[] args)
        { //введенні параметрів
            Console.Write("Choose number system:\n1. Binary\n2. Octal\n3.Hexcadecimal\n");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: n = 2; break;
                case 2: n = 8; break;
                case 3: n= 16; break;
            }
            Console.Write("Enter first number: ");
            string num1 = Console.ReadLine();
            Console.Write("Enter second number: ");
            string num2 =Console.ReadLine();
            string result = "";

            int carry = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;

            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0)
                {
                    sum += num1[i] - '0';
                    i--;
                }
                if (j >= 0)
                {
                    sum += num2[j] - '0';
                    j--;
                }

                result = (sum % n).ToString() + result;
                carry = sum / n;
            }

            if (carry != 0)
            {
                result = carry.ToString() + result;
            }
            Console.WriteLine(num1+" + "+num2+" = " + result);

            result = "";
            int borrow = 0;
            i = num1.Length - 1;
            j = num2.Length - 1;
            while (i >= 0 || j >= 0)
            {
                int diff = borrow;
                if (i >= 0)
                {
                    diff += num1[i] - '0';
                    i--;
                }
                if (j >= 0)
                {
                    diff -= num2[j] - '0';
                    j--;
                }

                if (diff < 0)
                {
                    diff += 2;
                    borrow = -1;
                }
                else
                {
                    borrow = 0;
                }

                result = diff.ToString() + result;
            }
            Console.WriteLine(num1 + " - " + num2 + " = " + result);

            i = num1.Length;
            j = num2.Length; 
            int[] result2 = new int[i + j];
            for (int k = i - 1; k >= 0; k--)
            {
                for (int m = j - 1; m >= 0; m--)
                {
                    int mult = (num1[k] - '0') * (num2[m] - '0');
                    int p1 = k + m;
                    int p2 = k + m + 1;
                    int sum = mult + result2[p2];

                    result2[p2] = sum % n;
                    result2[p1] += sum / n;
                }
            }

            string resultStr = "";
            foreach (int digit in result2)
            {
                resultStr += digit.ToString();
            }

            Console.WriteLine(num1 + " * " + num2 + " = " + resultStr);
            Console.ReadLine();
        }
    }
}
