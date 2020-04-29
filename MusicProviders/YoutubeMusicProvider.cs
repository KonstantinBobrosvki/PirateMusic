using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Search;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace MusicProviders
{
    public class YoutubeMusicProvider : MusicProvider
    {
        YoutubeClient YoutubeClient = new YoutubeClient();

        const string videoId = "videoId";

        private IEnumerable<VideoId> Search(string name)
        {
            var query = name.Replace("+", "%2B").Replace(" ", "+");


            var result = new  HashSet<VideoId>();

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
                        
                        result.Add(new VideoId(id));
                        i = i + 22;
                    }
                }
               


            }

            return result;
        }
      
        public override IEnumerable<Song> GetSongs(string name,int count)
        {



            var songsIDs = Search(name).ToList();
            
           
        
            

            var results = new List<Song>(songsIDs.Count);

            if(songsIDs.Count==0)
            {
                return new List<Song>();
            }

            for (int i = 0; i < 2; i++)
            {
                var id = songsIDs[i];

               

                var item = YoutubeClient.Videos.GetAsync(id).Result;
               

                Song song = new Song()
                {
                    Author = item.Author,
                    Name = item.Title,
                    ImageURL=item.Thumbnails.LowResUrl
                };

                results.Add(song);
              //  _ = Task.Run( async () => {
              //      var streamManifest =await  YoutubeClient.Videos.Streams.GetManifestAsync(id); //this shit is 16s need sped up
              //      song.FullLink =streamManifest.GetAudioOnly().WithHighestBitrate().Url;
              //  });


               // yield return song;
            }
            return results;

            
        }
    }
}
