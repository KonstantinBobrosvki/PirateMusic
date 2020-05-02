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

        private  void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
           
        }

        

        private void SearchButton_Clicked(object sender, EventArgs e)
        {

            YoutubeMusicProvider youtubeMusicProvider = new YoutubeMusicProvider();

           
            new Thread(async () =>
            {
                

                SomeName.Items.Clear();
                var result = youtubeMusicProvider.GetSongs(SearchBar.Text, 10);
                foreach (var item in result)
                {
                   SomeName.Items.Add(item);
                }

            }).Start();



        }
    }
}
