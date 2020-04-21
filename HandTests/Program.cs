using System;
using MusicProviders;

namespace HandTests
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
            Console.WriteLine("At least");
            Console.ReadLine();
        }

        static async void MainAsync()
        {
            YoutubeMusicProvider youtube = new YoutubeMusicProvider();
            var result = await youtube.GetBestMathSongAsync("sosedi");
            Console.WriteLine(result.FullLink);

            
        }
    }
}
