using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human myPerson = new Human("Jane");
            // Console.WriteLine(myPerson.numOrgans);
            // Console.WriteLine(myPerson.name);
            // Console.WriteLine(myPerson.health);
            // Console.WriteLine(myPerson.strength);
            // Console.WriteLine(myPerson.intelligence);
            // Console.WriteLine(myPerson.dexerity);
            Human myPerson2 = new Human("Joe", 20, 20, 40, 200);
            Console.WriteLine(myPerson2.name);
            myPerson2.Attack(myPerson);
            Console.WriteLine(myPerson.health);
        }
    }
}
