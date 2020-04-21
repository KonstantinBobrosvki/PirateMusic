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
        public override async Task<Song> GetBestMathSongAsync(string name)
        {
            var youtube = new YoutubeClient();
            SearchClient search = youtube.Search;
            var songs = search.GetVideosAsync(name).BufferAsync().Result;
            Song song = null;
           
            

            foreach (var item in songs)
            {
                var id = item.Id;
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(id);
                song = new Song() { Author = item.Author, Name = item.Title, FullLink = streamManifest.GetAudioOnly().WithHighestBitrate().Url };
                break;
            }

            return song;
        }
    }
}
