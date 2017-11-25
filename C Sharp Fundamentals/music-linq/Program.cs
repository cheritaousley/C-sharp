using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist firstArtist = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine(firstArtist.ArtistName + " "+  firstArtist.Age);

            //Who is the youngest artist in our collection of artists?
            Artist youngArtist = Artists.OrderBy(young => young.Age).First();
            Console.WriteLine(youngArtist.ArtistName + " " + youngArtist.Age);

            //Display all artists with 'William' somewhere in their real name
            IEnumerable <Artist> nameArtist = Artists.Where(name => name.RealName.Contains( "William"));
            foreach(var artist_ in nameArtist)
            {
                Console.WriteLine(artist_.RealName + "" + artist_.ArtistName);
            }
            
            //Display the 3 oldest artist from Atlanta
            IEnumerable <Artist> oldArtist = Artists.OrderByDescending(old => old.Age).Take(3);
            foreach(var aged in oldArtist)
            {
                Console.WriteLine(aged.ArtistName);
            }


            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // IEnumerable <Group> groupme = Groups.Join(Artists, Groups)
            var noNewYork = (from band in Groups
                            join artist in Artists on band.Id equals artist.GroupId
                            where artist.Hometown != "New York"
                            select new {band.GroupName}).Distinct();
            foreach (var artistGroup in noNewYork )
            {
                Console.WriteLine(artistGroup.GroupName);
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            // var WuTang = Group.Where(Group => Group.GroupName == "Wu-Tang Clan"); //Platform's way in solutions
            //             .GroupJoin(Artists,
            //             group => group.ID, 
            //             artist => artist.GroupId, 
            //             (group, artists) => {group.Members = artists.ToList(); 
            //             return group});
            //             .Single();

            //     Console.WriteLine("List of Artist in the Wu-Tang Clam");
            //     foreach(var artist in WuTang.Members){
            //         Console.WriteLine(artist.Members);
            //     }
            IEnumerable <Group> groupArtist = Groups.Where(artistingroup_ => artistingroup_.GroupName == "Wu-Tang Clan").Take(5);
            foreach (var artist in groupArtist)
            {
                Console.WriteLine(artist.Members);
            }
        }
    }
}
