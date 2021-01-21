using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZXingSample.Droid;
using ZXingSample.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(AudioService))]
namespace ZXingSample.Droid
{
    public class AudioService : IAudio
    {
        private MediaPlayer mediaPlayer;

        public AudioService()
        {
        }

        public bool PlayWavSuccess()
        {
            //var am = (AudioManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AudioService);

            //if (am.RingerMode == RingerMode.Normal)
            //{
            //    mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.good);
            //    mediaPlayer.Start();
            //}

            //var v = (Vibrator)Android.App.Application.Context.GetSystemService(Android.App.Application.VibratorService);
            Vibrator vibrator = (Vibrator)Android.App.Application.Context.GetSystemService(Android.App.Application.VibratorService);
            vibrator.Vibrate(VibrationEffect.CreateOneShot(200, 1));

            return true;
        }

        public bool PlayWavError()
        {
            //var am = (AudioManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AudioService);

            //if (am.RingerMode == RingerMode.Normal)
            //{
            //    mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.bad);
            //    mediaPlayer.Start();
            //}

            //var v = (Vibrator)Android.App.Application.Context.GetSystemService(Android.App.Application.VibratorService);
            //v.Vibrate(1000);

            return true;
        }
    }
}