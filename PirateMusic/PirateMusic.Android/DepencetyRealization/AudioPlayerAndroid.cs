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
        
        static MediaPlayer player = new MediaPlayer();

        public string Current { get; set; }

        public AudioSerivce()
        {
            
        }

        public bool Play()
        {

            if (player.IsPlaying)
                return false;
               
                player.SetDataSource(Current);
                player.SetAudioStreamType(Stream.Music);
                player.Prepare();
            
                player.Start();
           


            return true;
        }

        public bool Stop()
        {
            if (!player.IsPlaying)
                return false;

            player.Stop();
            return true;
        }

        public bool Pause()
        {
            if (!player.IsPlaying)
                return false;

            player.Pause();
            return true;
        }
    }

}