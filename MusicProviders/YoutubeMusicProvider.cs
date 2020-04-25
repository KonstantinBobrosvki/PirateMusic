using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
         
        public IAsyncEnumerable<Video> Some()
        {

            SearchClient search = YoutubeClient.Search;



           return search.GetVideosAsync("блог");
        }
      
        public override IEnumerable<Song> GetSongs(string name,int count)
        {
           
            SearchClient search = YoutubeClient.Search;


            
            var task = search.GetVideosAsync(name);
        
            var songs = task.BufferAsync(count).Result;

            var results = new List<Song>(songs.Count);

            if(songs.Count==0)
            {
                return new List<Song>();
            }

            for (int i = 0; i < count; i++)
            {
                var item = songs[i];
                var id = item.Id;         

                Song song = new Song()
                {
                    Author = item.Author,
                    Name = item.Title,
                    ImageURL=item.Thumbnails.LowResUrl
                };


                _ = Task.Run( async () => {
                    var streamManifest =await  YoutubeClient.Videos.Streams.GetManifestAsync(id); //this shit is 16s need sped up
                    song.FullLink =streamManifest.GetAudioOnly().WithHighestBitrate().Url;
                });
               // yield return song;
            }
            return results;

            
        }
    }
}
