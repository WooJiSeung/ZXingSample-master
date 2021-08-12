//using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using ZXingSample.Interface;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private IAudio iau = null;

        //BluetoothAdapter btAdapter;

        public MainPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);

            _LoadPage();
            
        }
        private void _LoadPage()
        {
            //this.Title = "NKO-B0";
            this.Title = "NIFCO Korea";
            iau = DependencyService.Get<IAudio>();
        }

        private void BtnMain_Clicked(object sender, EventArgs e)
        {
            string name = (sender as Button).ClassId;
            switch(name)
            {
                case "btnMain1": _ScanBarcode(); break;
                case "btnMain2": _LoadingBar();  break;
                case "btnMain3": _BScanner(); break;
                case "btnMain4": break;
                case "btnMain5": break;
                default:break;
            }
        }

        private async void _ScanBarcode()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.IsScanning = true;
            scanPage.AutoFocus();

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
            //NavigationPage.SetHasNavigationBar(scanPage, false);

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;
                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    iau.PlayWavSuccess();
                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
        }

        private void _LoadingBar()
        {
            Navigation.PushAsync(new ActivityIndicatorXamlPage());
            //Navigation.PushAsync(new PartialScreenScanning());
            //NavigationPage aaa = new NavigationPage(new PartialScreenScanning());
            //Navigation.PushModalAsync(aaa);

        }

        private void _BScanner()
        {
            //Navigation.PushAsync(new ActivityIndicatorXamlPage());
            //Navigation.PushAsync(new APTTransInfo());
            Navigation.PushAsync(new APTTransList());
        }
    }
}