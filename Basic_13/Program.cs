using System;
using System.Collections.Generic;
namespace Basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // print 1-255
            // for (int i=1; i <= 255; i ++)
            // {
            //     Console.WriteLine(i);
            // }
            //corrected
            Console.WriteLine("Print 1-255");
            for (int i = 0; i <= 255; i++)
            {
                Console.Write("{0}", i);
            }
            //print odd numbers between 1-255
            // for (int i=1; i <= 255; i++)
            // {
            //     if(i % 2 == 1)
            //     {
            //        Console.WriteLine(i);
            //     }
            // }
            //print sum
            //     var sum = 0;
            //     for (int i = 0; i <= 255; i++)
            //     {
            //         sum = sum + i;
            //         Console.WriteLine(i);
            //     }
            //    Console.WriteLine(sum);
            //inerate through an array and print each value
            //    int[] myNums = new int[6] { 1, 3, 5, 7, 9, 13 };
            //     foreach (int num in myNums)
            //     {
            //         Console.WriteLine(num);
            //     }
            //find max
            //     int n = Convert.ToInt32(Console.ReadLine());
            //     int[] numbers = new int[n];
            //     for (int i =0; i < n; i++)
            //     {
            //         numbers[1] = Convert.ToInt32(Console.ReadLine());
            //     }
            //     int min = numbers[0];
            //     int max = numbers[0];
            //     for (int i = 0; i < n; i++)
            //     {
            //         if(min > numbers[i]) 
            //         {
            //             min = numbers[i];
            //         }
            //         if(max < numbers[i])
            //         {
            //             max = numbers[i];
            //         }
            //         Console.WriteLine("The minimum is: {0}", min);
            //         Console.WriteLine("The maximum is: {0}", max);
            //         Console.ReadKey();
            //     }

            // }
            //Get average
            //print odd numbers in an array
            // int[] myNums = new int[6] {-1, 3, 0, -3, 7, 9};
            // max = {0};
            // min = {0};
            // sum = 0;
            // foreach (int num in myNums)
            // {
            //     if(num > max)
            //     {
            //         max = num;
            //     }
            //     if(num < min)
            //     {
            //         min = num;
            //     }
            //     sum = sum + num
            // }
        }
    }
}

