using System;

namespace C__Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // for (int i = 1; i<= 255; i++)
            // {
            //     Console.WriteLine(i);
            // }
            // for (int i = 1; i <= 100; i++)
            // {
            //     if(i % 2 ==1)
            //     {
            //         Console.WriteLine(i);
            //     }
            //     else if(i % 4==1)
            //     {
            //         Console.WriteLine(i);
            //     }
            // }
            // for (int i = 1; i <= 100; i++)
            // {
            //     if( i % 2 == 1 && i % 4 ==1)
            //     {
            //         Console.WriteLine("FizzBuzz");
            //     }
            //     else if(i % 2 ==1)
            //     {
            //         Console.WriteLine("Fizz");
            //     }
            //     else if(i % 4 ==1)
            //     {
            //         Console.WriteLine("Buzz");
            //     }
            
            // }
            int dividedby3 (int num)
            {
                int sum = 0;
                while (num > 3)
                {
                    sum = add(num >>2, sum);
                    num = add(num >> 2, num & 3);
                }
                if (num == 3)
                {
                    sum = add(sum, 1);
                }
                return sum;
            }
            
        }
    }
}
