using System;
using System.Numerics;
namespace Huge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello World!");

            /////////////////////////////////TEST SUMA
            Huge h2 = new Huge("999999999999999999999999");
            Huge h3 = new Huge("11");
            Huge sum = h2 + h3;
            Console.WriteLine(sum);
            ///////////////////////////////////////////

            //Huge h5 = h1.Power(10);

            //int mod = h4 % 135849752;

            //Console.WriteLine(h5);

            // Huge i = new Huge(1);
            //  Huge n = new Huge(1000);
            Huge produs_factorial = new Huge(1);

            int j = 1;
            while (j <= 1000)
            {
                produs_factorial = produs_factorial * j;
                j++;
            }
            Console.WriteLine("Produs Factorial prin tipul de date Huge");
            Console.WriteLine(produs_factorial);

            /////////////////////////Verificare 
            BigInteger big_produs = new BigInteger(1);
            j = 1;
            while (j <= 1000)
            {
                big_produs = big_produs * j;
                j++;
            }
            Console.WriteLine("Produs Factorial prin tipul de date BigInteger");
            Console.WriteLine(big_produs);

            Console.WriteLine(produs_factorial.ToString().Equals(big_produs.ToString()));
            Console.WriteLine("Elementul cu numarul 100 din sirul lui Fibonacci");
            Console.WriteLine(Fib(new Huge(100)));


        }



        public static Huge Fib(Huge number)
        {
            Huge firstNumber = new Huge(0), secondNumber = new Huge(1), nextNumber = new Huge(0),i;
            if (number == new Huge(0))
                return firstNumber;
            for (i = new Huge(2); i < number + 1; i += 1)
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
            return secondNumber;
        }
    }
}
