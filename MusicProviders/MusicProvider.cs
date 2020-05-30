using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicProviders
{
    public abstract class MusicProvider
    {
        public abstract IAsyncEnumerable<Song> GetSongsAsync(string name,int count);

        public virtual IEnumerable<Song> GetSongs(string name, int count)
        {
            List<Song> res = new List<Song>(count);
            Task.Run(async () =>
            {
                await foreach (var item in GetSongsAsync(name, count).ConfigureAwait(true))
                {
                    res.Add(item);
                }
            }).Wait();
            return res;
        }
    }
}
