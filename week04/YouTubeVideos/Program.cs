using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Foudations of C#", "CodeMaster", 950);
        video1.AddComment(new Comment("Alice", "Great explanation on classes and objects!"));
        video1.AddComment(new Comment("Bob", "Very helpful for beginners."));
        video1.AddComment(new Comment("Carlos", "It could use more examples, but overall good."));
        videos.Add(video1);

        Video video2 = new Video("Carrot cake recipe", "Chef Ana", 480);
        video2.AddComment(new Comment("Duda", "The best recipe I've seen. My family loved it!"));
        video2.AddComment(new Comment("Enzo", "The step-by-step instructions were very clear."));
        video2.AddComment(new Comment("Fabi", "Perfect for a quick dessert."));
        video2.AddComment(new Comment("John", "I didn't have all the ingredients, but it still turned out great!"));
        videos.Add(video2);

        Video video3 = new Video("Travel to Amazonas", "Mundo Sem Fronteiras", 1800);
        video3.AddComment(new Comment("Mary", "The landscapes are breathtaking!"));
        video3.AddComment(new Comment("Igor", "What an adventure! Adding this to my travel bucket list."));
        videos.Add(video3); 

        foreach (Video video in videos)
        {
            Console.WriteLine($"**Title:** {video.Title}");
            Console.WriteLine($"**Author:** {video.Author}");
            
            int minutes = video.Length / 60;
            int seconds = video.Length % 60;
            Console.WriteLine($"**Length:** {minutes} min e {seconds} seg ({video.Length} segundos)");
            
            Console.WriteLine($"**Total Comments:** {video.GetNumComments()}");
            Console.WriteLine("--- Comments ---");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"   > **{comment.Name}:** \"{comment.Text}\"");
            }

            Console.WriteLine("-------------------------------------------------\n");
        }
    }
}