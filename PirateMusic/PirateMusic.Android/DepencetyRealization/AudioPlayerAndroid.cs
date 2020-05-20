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

        public void Play()
        {
            
            

            if (player.IsPlaying)
                player.Stop();
            
            player.SetDataSource(Current);
            

            player.Prepare();
            player.Start();
           


            
        }

        public void Stop()
        {
            if (!player.IsPlaying)
                return;

            player.Stop();
          
        }

        public void Pause()
        {
            if (!player.IsPlaying)
                return ;

            player.Pause();
            
        }

        public void SetTime(TimeSpan time)
        {
            if (!player.IsPlaying)
                return;
            player.SeekTo(time.Milliseconds);

        }
    }

}