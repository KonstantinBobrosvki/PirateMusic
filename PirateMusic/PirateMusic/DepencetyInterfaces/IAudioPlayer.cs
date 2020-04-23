using System;
using System.Collections.Generic;
using System.Text;

namespace PirateMusic.DepencetyInterfaces
{
    public interface IAudioPlayer
    {
        string Current { get; set; }
        bool Play();
        bool Pause();
        bool Stop();
    }
}
