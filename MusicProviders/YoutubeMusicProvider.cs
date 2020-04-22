using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Search;
using YoutubeExplode.Videos.Streams;

namespace MusicProviders
{
    public class YoutubeMusicProvider : MusicProvider
    {
        

        public async override Task<IEnumerable<Song>> GetSongs(string name)
        {
            var youtube = new YoutubeClient();
            SearchClient search = youtube.Search;
            var songs = await search.GetVideosAsync(name).BufferAsync(20);
           

            var results = new List<Song>(songs.Count);

            foreach (var item in songs)
            {
                var id = item.Id;
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(id);
                Song song = new Song() { Author = item.Author, 
                    Name = item.Title, 
                    FullLink = streamManifest.GetAudioOnly().WithHighestBitrate().Url };
                
                results.Add(song);
            }

            return results;
        }
    }
}
