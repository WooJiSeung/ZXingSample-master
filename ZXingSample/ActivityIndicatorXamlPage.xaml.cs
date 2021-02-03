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
    public partial class ActivityIndicatorXamlPage : ContentPage
    {
        private bool _isTaskRunning = false;
        private IAudio iau = null;

        public ActivityIndicatorXamlPage()
        {
            InitializeComponent();

            iau = DependencyService.Get<IAudio>();
        }
        private void UpdateUiState()
        {
            //defaultActivityIndicator.IsRunning = !_isTaskRunning;
            //styledActivityIndicator.IsRunning = _isTaskRunning;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            //_isTaskRunning = !_isTaskRunning;
            //UpdateUiState();

            _ScanBarcode();
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
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    runningStatusLabel.Text = result.Text;
                });
            };
        }
    }
}