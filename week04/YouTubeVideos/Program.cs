using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Introduction to C#", "Ramon", 400);
        Video video2 = new Video("OOP", "Stuart", 520);
        Video video3 = new Video("Design Ptterns in C#", "Messi", 1000);
        Video video4 = new Video("C# tutorial", "Martha", 900);

        Comment comment1 = new Comment("Alice", "Great video!");
        Comment comment2 = new Comment("Marcos", "This help me a lot");
        Comment comment3 = new Comment("Martin", "Can you make part two?");
        Comment comment4 = new Comment("Maria", "Very informative, thanks!");
        Comment comment5 = new Comment("Jhon", "Awesome content!");
        Comment comment6 = new Comment("Charlie", "I really enjoy this!");
        Comment comment7 = new Comment("Diana", "Perfect timing!");
        Comment comment8 = new Comment("Eve", "Nice explanations, keep it up!");
        Comment comment9 = new Comment("Mike", "Great video! Really enjoyed it");
        video1.AddCommnet(comment1);
        video1.AddCommnet(comment2);
        video2.AddCommnet(comment3);
        video2.AddCommnet(comment4);
        video3.AddCommnet(comment5);
        video4.AddCommnet(comment6);
        video4.AddCommnet(comment7);
        video4.AddCommnet(comment8);
        video4.AddCommnet(comment9);
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);
        foreach (Video v in videos)
        {
            v.Display();
        }



    }
}