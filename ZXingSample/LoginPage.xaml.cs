using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using ZXingSample.Model;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

#if __ANDROID__
            
#endif
            var vm = new LoginViewModel();
            this.BindingContext = vm;

            ImageSource imageSource = ImageSource.FromResource("ZXingSample.logo.png",  System.Reflection.Assembly.GetExecutingAssembly());
            Img_logo.Source = imageSource;

            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.LoginCompleted += () => _NextPage();
            //vm.LoginCompleted += () => scan();

            UserId.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };
            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        private async void scan()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.IsScanning = true;
            scanPage.AutoFocus();
            
            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;
                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {

                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
        }


        private void _NextPage()
        {
            Navigation.PushAsync(new MainPage());
        }

    }
}