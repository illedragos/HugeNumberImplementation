using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Huge
{
    class Huge 
    {
        private byte[] data;
        private int digits;
        public Huge()
        {

        }
        public Huge(int v)
        {
            int digits;

            digits = CountDigits(v);

            data = new byte[digits];
            this.digits = digits;
            for (int i = 0; v > 0; i++)
            {
                data[i] = (byte)(v % 10);
                v = v / 10;
            }
        }

        public int Digits
        {
            get
            {
                return digits;
            }
        }
        public Huge(string v)
        {
            digits = v.Length;
            data = new byte[digits];

            for (int i = digits - 1; i >= 0; i--)
            {
                data[digits - 1 - i] = (byte)(v[i] - '0');
            }
        }

        private int CountDigits(int v)
        {
            int contor = 0;
            while (v > 0)
            {
                v = v / 10;
                contor++;
            }
            return contor;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = digits - 1; i >= 0; i--)
            {
                sb.Append(data[i]);
            }

            return sb.ToString();
        }

        public int Compare(Huge h1, Huge h2)
        {
            string x = h1.ToString();
            string y = h2.ToString();

            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return -1;
                if (x[i] > y[i]) return 1;
            }
            return 0;
        }
        public static Huge operator+(Huge left, int right)
        {
            Huge rightH = new Huge(right);
            return left + rightH;
        }
        public static Huge operator+(Huge left, Huge right)
        {
            Huge result = new Huge();
            int contor = 0;
            byte[] suma = new byte[Math.Max(left.digits, right.Digits) + 1];
            int carry = 0;
            int i;
            for (i = 0; i < Math.Min(left.Digits, right.digits); i++)
            {
                suma[i] = (byte)((carry + left.data[i] + right.data[i]) % 10);
                contor++;
                carry = (carry + left.data[i] + right.data[i]) / 10;
            }
            int j;
            for (j = i; j < left.Digits; j++)
            {
                suma[j] = (byte)((carry + left.data[j]) % 10);
                contor++;
                carry = (carry + left.data[j]) / 10;
            }
            int k;
            for (k = i; k < right.Digits; k++)
            {
                suma[k] = (byte)((carry + right.data[k]) % 10);
                contor++;
                carry = (carry + right.data[k]) / 10;
            }
            if (carry > 0)
            {
                suma[Math.Max(j, k)] = (byte)carry;
                contor++;
            }
            result.data = suma;
            result.digits = contor;
            return result;
        }

        public static Huge operator *(Huge left, int right)
        {
            Huge rightH = new Huge(right);
            return left * rightH;
        }
        public static Huge operator *(Huge left, Huge right)
        {
            string num1 = left.ToString();
            string num2 = right.ToString();

            int len1 = num1.Length;
            int len2 = num2.Length;
            if (len1 == 0 || len2 == 0)
                return new Huge(0);

            // will keep the result number in vector  
            // in reverse order  
            int[] result = new int[len1 + len2];

            // Below two indexes are used to  
            // find positions in result.  
            int i_n1 = 0;
            int i_n2 = 0;
            int i;

            // Go from right to left in num1  
            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = num1[i] - '0';

                // To shift position to left after every  
                // multipliccharAtion of a digit in num2  
                i_n2 = 0;

                // Go from right to left in num2              
                for (int j = len2 - 1; j >= 0; j--)
                {
                    // Take current digit of second number  
                    int n2 = num2[j] - '0';

                    // Multiply with current digit of first number  
                    // and add result to previously stored result  
                    // charAt current position.  
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;

                    // Carry for next itercharAtion  
                    carry = sum / 10;

                    // Store result  
                    result[i_n1 + i_n2] = sum % 10;

                    i_n2++;
                }

                // store carry in next cell  
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;

                // To shift position to left after every  
                // multipliccharAtion of a digit in num1.  
                i_n1++;
            }

            // ignore '0's from the right  
            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            // If all were '0's - means either both  
            // or one of num1 or num2 were '0'  
            if (i == -1)
                return new Huge(0);

            // genercharAte the result String  
            String s = "";

            while (i >= 0)
                s += (result[i--]);

            return new Huge(s);
         
        }

        public static Boolean operator <(Huge h1, Huge h2)
        {

            string x = h1.ToString();
            string y = h2.ToString();

            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return true;
                if (x[i] > y[i]) return false;
            }
            return false;
        }
        public static Boolean operator >(Huge h1, Huge h2)
        {
            string x = h1.ToString();
            string y = h2.ToString();

            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return false;
                if (x[i] > y[i]) return true;
            }
            return false;
        }

        public static Boolean operator <(Huge h1, int h2)
        {

            string x = h1.ToString();
            string y = h2.ToString();

            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return true;
                if (x[i] > y[i]) return false;
            }
            return false;
        }
        public static Boolean operator >(Huge h1, int h2)
        {
            string x = h1.ToString();
            string y = h2.ToString();

            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return false;
                if (x[i] > y[i]) return true;
            }
            return false;
        }
    }
}
