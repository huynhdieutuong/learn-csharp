using System;
using System.Collections.Generic;

namespace Queue
{
    public class Program
    {
        static void PrintProfiles(Queue<string> profiles)
        {
            Console.WriteLine("Print profiles: ");
            foreach (var profile in profiles)
            {
                Console.WriteLine(profile + " ");
            }
        }
        static void Main()
        {
            Queue<string> profiles = new Queue<string>();
            // Add Queue
            profiles.Enqueue("Profile 1");
            profiles.Enqueue("Profile 2");
            profiles.Enqueue("Profile 3");
            PrintProfiles(profiles);

            // Remove Queue
            var profile1 = profiles.Dequeue();
            Console.WriteLine($"Hanlde profile: {profile1} - Rest: {profiles.Count} profiles.");

            var profile2 = profiles.Dequeue();
            Console.WriteLine($"Hanlde profile: {profile2} - Rest: {profiles.Count} profiles.");

            var profile3 = profiles.Dequeue();
            Console.WriteLine($"Hanlde profile: {profile3} - Rest: {profiles.Count} profiles.");
        }
    }
}