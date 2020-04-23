using System;
using System.Collections.Generic;
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

        public async override Task<IEnumerable<Song>> GetSongs(string name)
        {
           
            SearchClient search = YoutubeClient.Search;

            var task = search.GetVideosAsync(name);
          
            var songs = task.BufferAsync(6).Result;

            var results = new List<Song>(songs.Count);

            for (int i = 0; i < 5; i++)
            {
                var item = songs[i];
                var id = item.Id;

                

                Song song = new Song()
                {
                    Author = item.Author,
                    Name = item.Title     
                };
                _ = Task.Run( async () => {
                    var streamManifest = await YoutubeClient.Videos.Streams.GetManifestAsync(id);
                    song.FullLink = streamManifest.GetAudioOnly().WithHighestBitrate().Url;
                }); 
                results.Add(song);
            }
            

            return results;
        }
    }
}
