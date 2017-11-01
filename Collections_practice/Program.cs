using System;
using System.Collections.Generic;
namespace Collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // int[] numArray = new int[10];
            // int[] numArray2 = {0,1,2,3,4,5,6,7,8,9};
            // // an array can be declared like above of like this
            // int[] array3; 
            // array3 = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // string[] myNames = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            // foreach (string name in myNames)
            // {
            //     Console.WriteLine("My name is {0}", name);
            // }
            // bool[] switches = new bool[10];
            // for (int i = 0; i < switches.Length; i++) { switches[i] = true; }
            // for (int i = 1; i <= 10; i++)
            // {
            //     for (int j = 1; j <= 10; j++)
            //     {
            //         Console.Write(i + "x" + j + "=" + (i * j) + "\t");
            //     }
            //     Console.ReadLine();
            //     }
                
            // }
            // for (int i = 1; i <= 10; i++) //this was the correct way to get the multtiplication table
            // {
            //     for (int j = 1; j <= 10; j++)
            //     {
            //          Console.Write(i * j + "\t");
        
            //     }
            //     Console.Write("\n");
            // }
            //     Console.ReadLine();
            
            // List<string> flavors = new List<string>();
            // flavors.Add("Vanilla");
            // flavors.Add("Strawberry");
            // flavors.Add("Chocolate");
            // flavors.Add("Cake Batter");
            // flavors.Add("Dark Chocolate");
            // Console.WriteLine(flavors[3]);
            // Console.WriteLine("We currently know of {0} icream flavors.", flavors.Count);

            // Console.WriteLine("The current flavors we have are");
            // for (var idx = 0; idx < flavors.Count; idx++)
            // {
            //     Console.WriteLine("-" + flavors[idx]);
            // }
            // flavors.Remove("Chocolate");

            Dictionary<string,string> profile = new Dictionary<string,string>();
            profile.Add("Flavor", "Vanilla");
            Console.WriteLine("Flavor-" + profile["Flavor"]);
        }
    }
}

            
        
    
