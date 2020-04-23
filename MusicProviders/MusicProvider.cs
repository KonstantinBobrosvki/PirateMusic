using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicProviders
{
    public abstract class MusicProvider
    {
        public abstract IAsyncEnumerable<Song> GetSongs(string name,int count);
    }
}
