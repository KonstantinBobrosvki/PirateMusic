using System;
using System.Collections.Generic;
using System.Text;

namespace PirateMusic.DepencetyInterfaces
{
    public interface IAudioPlayer
    {
        string Current { get; set; }
        void Play();
        void Pause();
        void Stop();
        void SetTime(TimeSpan time);
    }
}
