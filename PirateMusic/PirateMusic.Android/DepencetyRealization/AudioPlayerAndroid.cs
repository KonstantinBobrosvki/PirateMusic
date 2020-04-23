using System;
using Xamarin.Forms;
using PirateMusic.Droid;
using Android.Media;
using PirateMusic.DepencetyInterfaces;

[assembly: Dependency(typeof(AudioSerivce))]
namespace PirateMusic.Droid
{
    public class AudioSerivce : IAudioPlayer
    {
        
        MediaPlayer player;

        public string Current { get; set; }

        public AudioSerivce()
        {
            player = new MediaPlayer();
        }

        public bool Play()
        {    


               
                this.player.SetDataSource(Current);
                this.player.SetAudioStreamType(Stream.Music);
                this.player.Prepare();
            
                this.player.Start();
           


            return true;
        }

        public bool Stop()
        {
            this.player.Stop();
            return true;
        }

        public bool Pause()
        {
            player.Pause();
            return true;
        }
    }

}