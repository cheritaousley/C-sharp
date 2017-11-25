using System;
using System.Collections.Generic;
namespace basic_13_corrected
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Print1to255();
            PrintOdd1to255();
            PrintSum();
            IterateArray();
            FindMax();
            GetAverage(new List<int>(new int[] { 2, 10, 3 }));
            OddArray();
            GreaterThanY(new List<int>(new int[] { 1, 3, 5, 7 }), 3);
            SquareValues(new List<int>(new int[] { 1, 5, 10, -2 }));
            EliminateNegatives(new List<int>(new int[] { 1, 5, 10, -2 }));
            MinMaxAvg(new List<int>(new int[] { 1, 5, 10, -2 }));
            ShiftArray(new List<int>(new int[] { 1, 5, 10, -2 }));
            NumToString(new List<object>(new object[] { -1, -3, 2 }));
            RandomArray();
        }
        
        static void Print1to255()
        {
            Console.WriteLine("Print 1-255");
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine("{0}", i);
            }
        }
        static void PrintOdd1to255()
        {
            Console.WriteLine("Print odd numbers betwwen 1-255");
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine("{0}", i);
                }
            }
        }
        static void PrintSum()
        {
            Console.WriteLine("Print Sum");
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("New number: {0} Sum: {1}", i, sum);
            }
        }
        static void IterateArray()
        {
            Console.WriteLine("Iterating through an Array");
            List<int> myList = new List<int>(new int[] { 1, 3, 5, 7, 9, 13 });
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("{0}", myList[i]);
            }
        }
        static void FindMax()
        {
            Console.WriteLine("Find Max");
            List<int> maxList = new List<int>(new int[] { 1, 3, 5, 7, 9, -13, 100, -25, 0, 99 });
            int max = maxList[0];
            int total = maxList[0];
            for (int i = 1; i < maxList.Count; i++)
            {
                if (maxList[i] > max)
                {
                    max = maxList[i];
                }
                total += maxList[i];
            }
            Console.WriteLine("The max of the array is {0}", max);
            Console.WriteLine("Get Average");
            Console.WriteLine("The average of the array is {0}", total / maxList.Count);
        }
        static void GetAverage(List<int> array)
        {
            List<int> avgList = new List<int>(new int[] { 1, 3, 5, 7, 9, -13, 100, -25, 0, 99 });
            Console.WriteLine("Get Average");
            int sum = avgList[0];
            for (int i = 1; i < avgList.Count; i++)
            {
                sum += avgList[i];
            }
            Console.WriteLine("The average of the array is {0}", sum / avgList.Count);
        }
        static void OddArray()
        {
            Console.WriteLine("Array with Odd Numbers");
            List<int> oddList = new List<int>();
            for (int i = 1; i <= 255; i += 2)
            {
                oddList.Add(i);
            }
            Console.WriteLine(oddList);

            Console.WriteLine("Greater Than Y");
        }
        static void GreaterThanY(List<int> array, int y)
        {
            List<int> array = new List<int>();
            int count = 0;
            int y = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] > y)
                {
                    count++;
                }
                Console.WriteLine("There are {0} items greater than {1} in the array", count, y);
            }
        }
        static void SquareValues(List<int> array)
        {
            List<int> array = new List<int>(new[] { 1, 3, 5, 7, 9 });
            Console.WriteLine("Square the values");
            Console.WriteLine("The array before squaring is {0}", array);
            for (int i = 0; i < array.Count; i++)
            {
                array[i] = array[i] * array[i];
            }
            Console.WriteLine("The array after squaring is {0}", array);

        }

        static void EliminateNegatives(List<int> array)
        {
            List<int> array = new List<int>(new[] { -1, 3, -5, 7, -9 });
            Console.WriteLine("Eliminate Negative Numbers");
            Console.WriteLine("The array before eliminating negatives is {0}", array);
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < 0) { array[i] = 0; }
            }
            Console.WriteLine("The array after eliminating negatives is {0}", array);

        }

        static void MinMaxAvg(List<int> minMaxAvg)
        {
            List<int> minMaxAvg = new List<int>(new[] { -1, 3, -5, 7, -9 });
            Console.WriteLine("Min, Max, and Average");
            int min = minMaxAvg[0];
            int max2 = minMaxAvg[0];
            int sum2 = minMaxAvg[0];
            int average = 0;
            for (int i = 1; i < minMaxAvg.Count; i++)
            {
                if (minMaxAvg[i] < min) { min = minMaxAvg[i]; }
                if (minMaxAvg[i] > max2) { max2 = minMaxAvg[i]; }
                sum2 += minMaxAvg[i];
            }
            average = sum2 / minMaxAvg.Count;
            Console.WriteLine("The min is {0}, the max is {1}, and the average is {2}", min, max2, average);
        }
        static void ShiftArray(List<int> shiftArray)
        {
            List<int> shiftArray = new List<int>(new[] { -1, 3, -5, 7, -9 });
            Console.WriteLine("Shifting the values in an array");
            for (int i = 0; i < shiftArray.Count - 1; i++)
            {
                shiftArray[i] = shiftArray[i + 1];
            }
            shiftArray[shiftArray.Count - 1] = 0;
            Console.WriteLine("The shifted array is {0}.", shiftArray);
        }
        static void NumToString(List<object> numToString)
        {
            List<int> numToString = new List<int>(new[] { -1, 3, -5, 7, -9 });
            Console.WriteLine("Number to String");
            for (int i = 0; i < numToString.Count; i++)
            {
                if ((int)numToString[i] < 0) { numToString[i] = "Dojo"; }
            }
            Console.WriteLine("The array after removing negatives is: {0}", numToString);
        }

        static void RandomArray()
        {
            List<int> array = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int newVal = rand.Next(5, 25);
                array.Add(newVal);
                Console.WriteLine("Adding {0} to the array", newVal);
            }
            int min = array[0];
            int max = array[0];
            int sum = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                sum += array[i];
                if (array[i] < min) { min = array[i]; }
                if (array[i] > max) { max = array[i]; }
            }

            Console.WriteLine("The min is {0}", min);
            Console.WriteLine("The max is {0}", max);
            Console.WriteLine("The sum is {0}", sum);

            return array;
        }

    }
}
