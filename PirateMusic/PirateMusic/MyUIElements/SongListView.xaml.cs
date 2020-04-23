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
            player.Current = ((Button)sender).BindingContext as string;
            player.Play();
        }
    }
}