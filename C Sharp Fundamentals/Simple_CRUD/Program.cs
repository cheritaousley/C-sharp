using System;
using DbConnection;
using System.Collections.Generic;

namespace Simple_CRUD
{
    class Program
    {
        static public void Read()
        {
            List<Dictionary<string, object>> userInfo = DbConnector.Query("SELECT FirstName as 'First Name', LastName as 'Last Name', FavoriteNum as 'Favorite Number' from User");
            Console.WriteLine("User Information as follows:");
            foreach (var info in userInfo)
            {
                foreach (KeyValuePair<string, object> user in info)
                    Console.Write("{user.Key}: {user.Value}" + "");
            }
            Console.WriteLine();
        }
        static public void Create()
        {
            // string first = Console.ReadLine();
            // string last = Console.ReadLine();
            // string number = Console.ReadLine();
            
            //  OR you could do this 
            string first = "";
            string last = "";
            string number = "";
            string Id ="";
            //and use readLine below

            // string first = "first";//Console.ReadLine();
            // string last = "last"; //Console.ReadLine();
            // string number = "10";//Console.ReadLine();

        //the $ sign tells the program I want to insert some variables so the first name, last name and favnum become a different color indicating they're variables
            //(Opitonal) update and delete
            Console.Write("Please enter the ID of the record you wish to update");
            Id = Console.ReadLine();
            string selectquery = $"select * from users where id = {Id}";
            List<Dictionary<string, object>> result =DbConnector.Query(selectquery);

            if(result.Count > 0)
            {
                Console.Write("Great, I have found that id, what is the new first name? :");
                Console.WriteLine("1: Update the user");
                Console.WriteLine("2: Delete the user");
                Console.Write("Choose :");
                string answer = Console.ReadLine();
                if(answer.Trim()== "1")
                {
                    first = Console.ReadLine();
                    Console.Write("Got it. Now tell me the new last name:");
                    last = Console.ReadLine();
                    Console.Write("Very good. What is this person's new fav number?");
                    number = Console.ReadLine();

                    string updateQuery = $"update users set FirstName = '{first}', LastName = '{last}', FavNum ='{number}'";
                    DbConnector.Query(updateQuery);

                    Console.Write("Success!");
                }
                else if(answer.Trim()== "2")
                {
                    string deleteQuery =$"delete from User where id ={Id}";
                    DbConnector.Execute(deleteQuery);
                    Console.WriteLine("I,ve terminated that user, goodbye");
                }
            }
            else{
                Console.WriteLine("User you do not exist or I cannot do that");
            }

        //write== inline block; write line == block

            Console.Write("Please enter your first name: ");
            first = Console.ReadLine(); //this allows the user to input informatiion. turns info into a string
            Console.WriteLine(); //this will print the line

            Console.Write("Now enter your last name: ");
            last = Console.ReadLine(); //this allows the user to input informatiion
            Console.WriteLine(); //this will print the line

            Console.Write("Finally, tell me your favorite number: ");
            number = Console.ReadLine(); //this allows the user to input informatiion
            Console.WriteLine(); //this will print the line

            string x= $"INSERT INTO User(firstName, lastName, favoriteNum) VALUES('{first}', '{last}', '{number}')";
            System.Console.WriteLine(x);
            DbConnector.Execute(x);
        }  
        static void Main(string[] args)
        {
            // string InputLine = Console.ReadLine();
            // DbConnector.Query("Some query string expecting data returned");
            Read();
            Create();
        }

        }
}
///.ToList... .ToString