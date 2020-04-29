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
using YoutubeExplode;

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

        private  void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
           
        }

        

        private void SearchButton_Clicked(object sender, EventArgs e)
        {

            YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

            SomeName.Items.Clear();
            //await foreach (var item in youtubeMusicProvider.Some(SearchBar.Text))
            //{
            //    SomeName.Items.Add(item);
            //}

            //YoutubeClient youtubeClient = new YoutubeClient();

            //YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

            //foreach (var item in youtubeClient.Search.GetVideosAsync("блог").BufferAsync(20).Result)
            //{
            //    SomeName.Items.Add(new Song() { Name = item.Title, Author = item.Description });
            //}

            new Thread(async () =>
            {
                // YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();
              //  RuMusicMusicProvider youtubeMusicProvider = new RuMusicMusicProvider();


                SomeName.Items.Clear();
                var result = youtubeMusicProvider.GetSongs(SearchBar.Text, 10);
                foreach (var item in result)
                {
                   SomeName.Items.Add(item);
                }

            }).Start();


            //_ = Task.Run(
            //    async () =>
            //    {
            //        YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

            //        SomeName.Items.Clear();

            //        foreach (var item in youtubeMusicProvider.GetSongs(SearchBar.Text, 10))
            //        {
            //            SomeName.Items.Add(item);
            //        }

            //    });

        }
    }
}
