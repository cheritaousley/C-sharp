using System;
using System.Collections.Generic;
namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            List<object> things = new List<object>();
            things.Add(7);
            things.Add(28);
            things.Add(-1);
            things.Add(true);
            things.Add("chair");

            object ActuallyString = "chair";
            string ExplicitString = ActuallyString as string;

            var sum = 0;
            foreach( var item in things)
            {
                if( item is int)
                {
                    int num = (int)item;
                    sum = sum + num;
                }
            }
            Console.WriteLine(sum);
            }
        }
    }
