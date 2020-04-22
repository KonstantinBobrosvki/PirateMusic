using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MusicProviders;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using PirateMusic.MyUIElements;

namespace PirateMusic
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            YoutubeMusicProvider musicProvider = new YoutubeMusicProvider();
            var query = ((Xamarin.Forms.SearchBar)sender).Text;
            var songs= await musicProvider.GetSongs(query);
            foreach (var item in songs)
            {

            }
        }

        

        private void SearchButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
