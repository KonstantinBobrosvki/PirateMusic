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
using System.Threading;

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
           
        }

        

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {

            //YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

            //SomeName.Items.Clear();
            //await foreach (var item in youtubeMusicProvider.Some(SearchBar.Text))
            //{
            //    SomeName.Items.Add(item);
            //}



            new Thread(async() => {
                YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

                SomeName.Items.Clear();

                await foreach (var item in youtubeMusicProvider.GetSongs(SearchBar.Text, 10))
                {
                    SomeName.Items.Add(item);
                }
            }).Start();

            return;
            _ = Task.Run(
                async () =>
                {
                    YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

                    SomeName.Items.Clear();

                    await foreach (var item in youtubeMusicProvider.GetSongs(SearchBar.Text, 10))
                    {
                        SomeName.Items.Add(item);
                    }

                });

        }
    }
}
