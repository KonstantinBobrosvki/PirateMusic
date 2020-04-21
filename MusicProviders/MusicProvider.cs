using System;
using System.Threading.Tasks;

namespace MusicProviders
{
    public abstract class MusicProvider
    {
        public abstract Task<Song> GetBestMathSongAsync(string name);
    }
}
