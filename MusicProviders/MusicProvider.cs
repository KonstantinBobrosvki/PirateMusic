using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicProviders
{
    public abstract class MusicProvider
    {
        public abstract Task<IEnumerable<Song>> GetSongs(string name);
    }
}
