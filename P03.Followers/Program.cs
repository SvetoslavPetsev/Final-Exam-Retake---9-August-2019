using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.Followers
{
    public class Status
    {
        public int CountLike { get; set; }
        public int CountComment { get; set; }

        public Status(int countLike, int countComent)
        {
            this.CountLike = countLike;
            this.CountComment = countComent;
        }
        public int Total => this.CountLike + this.CountComment;
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Status> peshoFollowers = new Dictionary<string, Status>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Log out")
                {
                    break;
                }
                string[] cmdCollection = input.Split(": ");
                string cmd = cmdCollection[0];
                string username = cmdCollection[1];
                if (cmd == "New follower")
                {
                    if (!peshoFollowers.ContainsKey(username))
                    {
                        peshoFollowers.Add(username, new Status(0, 0));
                    }
                }
                else if (cmd == "Like")
                {
                    int count = int.Parse(cmdCollection[2]);
                    if (!peshoFollowers.ContainsKey(username))
                    {
                        peshoFollowers.Add(username, new Status(count, 0));
                    }
                    else
                    {
                        peshoFollowers[username].CountLike += count;
                    }
                }
                else if (cmd == "Comment")
                {
                    if (!peshoFollowers.ContainsKey(username))
                    {
                        peshoFollowers.Add(username, new Status(0, 1));
                    }
                    else
                    {
                        peshoFollowers[username].CountComment++;
                    }
                }
                else if (cmd == "Blocked")
                {
                    if (!peshoFollowers.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist."); ;
                    }
                    else
                    {
                        peshoFollowers.Remove(username);
                    }
                }
            }
            Console.WriteLine($"{peshoFollowers.Count} followers");
            foreach (var users in peshoFollowers.OrderByDescending(x => x.Value.CountLike).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{users.Key}: {users.Value.Total}");
            }
        }
    }
}
