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

        public async IAsyncEnumerable<Song> Some(string name)
        {
          

            SearchClient search = YoutubeClient.Search;

            var task = search.GetVideosAsync(name);

            var songs = task.BufferAsync(6).Result;

            var results = new List<Song>(songs.Count);

            for (int i = 0; i < 5; i++)
            {
                var item = songs[i];
                var id = item.Id;
                
            //  var streamManifest = YoutubeClient.Videos.Streams.Get;

                Song song = new Song()
                {
                    Author = item.Author,
                    Name = item.Title //,
                   // FullLink = streamManifest.GetAudioOnly().WithHighestBitrate().Url
                };

                yield return song;
            }


           
        }

        public async override IAsyncEnumerable<Song> GetSongs(string name,int count)
        {
           
            SearchClient search = YoutubeClient.Search;

            var task = search.GetVideosAsync(name);

            
          
            var songs = task.BufferAsync(count).Result;

            var results = new List<Song>(songs.Count);

            for (int i = 0; i < count; i++)
            {
                var item = songs[i];
                var id = item.Id;

                

                Song song = new Song()
                {
                    Author = item.Author,
                    Name = item.Title     
                };
                _ = Task.Run( async () => {
                    var streamManifest =await  YoutubeClient.Videos.Streams.GetManifestAsync(id); //this shit is 16s need sped up
                    song.FullLink =streamManifest.GetAudioOnly().WithHighestBitrate().Url;
                });
                yield return song;
            }
            

            
        }
    }
}
