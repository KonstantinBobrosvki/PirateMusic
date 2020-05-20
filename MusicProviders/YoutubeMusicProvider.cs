using DotNetTools.SharpGrabber;
using DotNetTools.SharpGrabber.Internal.Grabbers;
using DotNetTools.SharpGrabber.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MusicProviders
{
    public class YoutubeMusicProvider : MusicProvider
    {
        

        const string videoId = "videoId";

        private IEnumerable<string> Search(string name)
        {
            var query = name.Replace("+", "%2B").Replace(" ", "+");


            var result = new  HashSet<string>();

            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
            webClient.Headers.Add("Referer", "https://www.youtube.com");
            var rawData = webClient.DownloadString("https://www.youtube.com/results?search_query=" + query);

            var upTo = rawData.Length < 300000 ? rawData.Length-100 : 300000;

            for (int i = 50000 ; i < upTo ; i++)
            {
                var symbol = rawData[i];

              

                if(symbol=='v' )
                {
                    var current = rawData.Substring(i, 7);
                    if(current==videoId)
                    {
                        var startIdindex =rawData.IndexOf('"', rawData.IndexOf(':', i))+1;
                        var stopIdindex = rawData.IndexOf('"', startIdindex + 1);
                        var temp = stopIdindex - startIdindex;
                        var id = rawData.Substring(startIdindex,temp);
                        
                        result.Add(id);
                        i = i + 22;
                    }
                }
               


            }

            return result;
        }
      
        public async override IAsyncEnumerable<Song> GetSongs(string name,int count)
        {



            var songsIDs = Search(name).ToList();

            var results = new List<Song>(count);

            for (int i = 0; i < count; i++)
            {
               // Task.Run(() =>
               // {
                    var grabber = new DotNetTools.SharpGrabber.Internal.Grabbers.YouTubeGrabber();
                    var item = songsIDs[i];
                    var res = await grabber.GrabAsync(new Uri("https://www.youtube.com/watch?v=" + item));


                    //TODO: Get BEST sound here not first
                    var bestSound = res.Resources.Where(r => r is DotNetTools.SharpGrabber.Media.GrabbedMedia
                                                        && !(((DotNetTools.SharpGrabber.Media.GrabbedMedia)r).Channels.HasVideo())).First();

                    var image = res.Resources.Where(r => r is DotNetTools.SharpGrabber.Media.GrabbedImage).First();


                    var nameOfSong = res.Title;
                    var author = res.Statistics.Author;
                    var song = new Song() { Author = author, Name = nameOfSong, ImageURL = image.ResourceUri.AbsoluteUri, FullLink = bestSound.ResourceUri.AbsoluteUri };

                    yield return song;
               // });
            }
          
            




         
         //   return results;

            
        }
    }
}
