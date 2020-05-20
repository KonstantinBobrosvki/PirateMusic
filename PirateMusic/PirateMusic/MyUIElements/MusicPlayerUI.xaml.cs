using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicProviders;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PirateMusic.MyUIElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayerUI : ContentView
    {



        public List<Song> Playlist { get; set; }

        private Song currentSong;

        public int IndexCurrentSong {
            get 
            {
                return indexCurrentSong;
            }
            set 
            {
            
            } 
        }

        int indexCurrentSong;

        static MusicPlayerUI()
        {

        }

        public MusicPlayerUI()
        {
            InitializeComponent();
        }

        private void PreviousSongButton_Clicked(object sender, EventArgs e)
        {
            if (indexCurrentSong - 1 == -1)
                indexCurrentSong = Playlist.Count;
            else
                indexCurrentSong--;
        }

        private void NextSongButton_Clicked(object sender, EventArgs e)
        {
            if (indexCurrentSong + 1 == Playlist.Count)
                indexCurrentSong = 0;
            else
                indexCurrentSong++;
        }
    }
}