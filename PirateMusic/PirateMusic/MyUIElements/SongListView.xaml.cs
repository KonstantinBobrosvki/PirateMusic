using MusicProviders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PirateMusic.MyUIElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongListView : ContentView
    {
        public ObservableCollection<Song> Items { get; set; }
        
        public SongListView()
        {
            Items = new ObservableCollection<Song>();
           
            InitializeComponent();

          
            SongsViewList.ItemsSource = Items;

        }

        private void SongsViewList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            var player = DependencyService.Get<PirateMusic.DepencetyInterfaces.IAudioPlayer>();
            var toast = DependencyService.Get<PirateMusic.DepencetyInterfaces.IMessageBox>();
            string name =((Button)sender).BindingContext as string;
            var song = Items.Where(c => c.Name == name).First();
            if (song.FullLink == null)
            {
                toast.Show("Audio hasnt load yet.Try after some secons");
                return;
            }
            player.Current = song.FullLink;
            player.Play();
        }
    }
}