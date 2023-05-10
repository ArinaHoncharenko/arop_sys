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
        { 
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
                if (n != 16)
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
                if (n == 16)
                {
                    int sum = carry;
                    if (i >= 0)
                    {
                        if (Char.IsDigit(num1[i])) {sum += num1[i] - '0';}
                        else { sum += num1[i] - 'A' + 10;}
                        i--;
                    }
                    if (j >= 0)
                    {
                        if (Char.IsDigit(num2[j])) { sum += num2[j] - '0'; }
                        else{sum += num2[j] - 'A' + 10; }
                        j--;
                    }
                    carry = sum / n;
                    if (sum%n < 10)
                    {
                        result = (sum%n).ToString() + result;
                    }
                    else
                    {
                        result = (char)(sum%n - 10 + 'A') + result;
                    }
                }

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
            if (n != 16) {
                while (i >= 0 || j >= 0)
                {
                    int diff = borrow;
                    if (i >= 0)
                    { diff += num1[i] - '0'; i--; }
                    if (j >= 0)
                    { diff -= num2[j] - '0'; j--; }

                    if (diff < 0) { diff += n; borrow = -1; }
                    else { borrow = 0; }
                    result = diff.ToString() + result;
                }
                Console.WriteLine(num1 + " - " + num2 + " = " + result);
            }
            
            if (n == 16)
            {
                while (i >= 0 || j >= 0)
                {
                    int diff = borrow;
                    if (i >= 0)
                    {
                        if (Char.IsDigit(num1[i]))
                        {diff += num1[i] - '0';}
                        else
                        {diff += num1[i] - 'A' + 10;}
                        i--;
                    }
                    if (j >= 0)
                    {
                        if (Char.IsDigit(num2[j])) {diff -= num2[j] - '0';}
                        else { diff -= num2[j] - 'A' + 10;}
                        j--;
                    }

                    if (diff < 0)
                    {
                        diff += n;
                        borrow = -1;
                    }
                    else{borrow = 0; }
                    if (diff < 10) {result = diff.ToString() + result;}
                    else{result = (char)(diff - 10 + 'A') + result;}
                }
                Console.WriteLine(num1 + " - " + num2 + " = " + result);
            }

            i = num1.Length;
            j = num2.Length; 
            int[] result2 = new int[i + j];
            if (n != 16)
            {
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

                string resultStr2 = "";
                foreach (int digit in result2)
                {resultStr2 += digit.ToString();}
                Console.WriteLine(num1 + " * " + num2 + " = " + resultStr2.TrimStart('0'));
            }
            int[] arr1 = new int[i];
            int[] arr2 = new int[j];
            if (n == 16)
            {
                for (int k = 0; k < i; k++)
                {
                    if (Char.IsDigit(num1[k])){arr1[k] = num1[k] - '0';}
                    else{arr1[k] = num1[k] - 'A' + 10; }
                }

                for (int k = 0; k < j; k++)
                {
                    if (Char.IsDigit(num2[k])){arr2[k] = num2[k] - '0';}
                    else{arr2[k] = num2[k] - 'A' + 10;}
                }
                int[] product = new int[i + j];
                for (int k = i - 1; k >= 0; k--)
                {
                    for (int m = j - 1; m >= 0; m--)
                    {
                        int p1 = arr1[k];
                        int p2 = arr2[m];
                        int sum = p1 * p2 + product[k + m + 1];
                        product[k + m + 1] = sum % n;
                        product[k + m] += sum / n;
                    }
                }
                string resultStr = "";

                for (int k = 0; k < i + j; k++)
                {
                    if (product[k] < 10){resultStr += product[k].ToString();}
                    else
                    {resultStr += (char)(product[k] - 10 + 'A');}
                }
                while (resultStr.Length > 1 && resultStr[0] == '0'){resultStr = resultStr.Substring(1);}
                Console.WriteLine(num1 + " * " + num2 + " = " + resultStr.TrimStart('0'));
            }
            Console.ReadLine();
        }
    }
}
