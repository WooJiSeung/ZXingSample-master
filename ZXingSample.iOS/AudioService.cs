using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioToolbox;
using Foundation;
using UIKit;
using ZXingSample.Interface;
using ZXingSample.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(AudioService))]
namespace ZXingSample.iOS
{
    public class AudioService : IAudio
    {
        public AudioService()
        {
        }

        public bool PlayWavSuccess()
        {
            SystemSound.Vibrate.PlayAlertSound();

            return true;
        }

        public bool PlayWavError()
        {
            //SystemSound.Vibrate.pl();

            return true;
        }
    }
}