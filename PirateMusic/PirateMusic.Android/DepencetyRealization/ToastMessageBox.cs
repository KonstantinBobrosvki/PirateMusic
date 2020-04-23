using System;
using Android.Widget;
using PirateMusic.DepencetyInterfaces;
using Xamarin.Forms;
using PirateMusic.Droid.DepencetyRealization;

[assembly: Dependency(typeof(ToastMessageBox))]
namespace PirateMusic.Droid.DepencetyRealization
{

    public class ToastMessageBox : IMessageBox
    {
        public ToastMessageBox()
        {

        }

        public void Show(string text)
        {
            Toast.MakeText(Android.App.Application.Context, text, ToastLength.Short).Show();
        }
    }
}