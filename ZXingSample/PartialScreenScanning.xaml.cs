using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXingSample.Interface;

namespace ZXingSample
{
	public partial class PartialScreenScanning : ContentPage
	{
        private IAudio iau = null;

        public PartialScreenScanning()
		{
			InitializeComponent();

            iau = DependencyService.Get<IAudio>();
           
        }

		public void Handle_OnScanResult(Result result)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
                iau.PlayWavSuccess();
                //await DisplayAlert("Scanned result", result.Text, "OK");
                runningStatusLabel.Text = result.Text;
            });
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

            _scanView.IsScanning = true;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			_scanView.IsScanning = false;
		}
	}
}