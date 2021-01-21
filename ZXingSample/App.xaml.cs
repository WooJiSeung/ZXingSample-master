using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZXingSample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//var LoginPage = new TabbedPage();
			//LoginPage.Children.Add(new FullScreenScanning());
			////LoginPage.Children.Add(new PartialScreenScanning());
			////LoginPage.Children.Add(new GenerateBarcodePage());
            //
			//LoginPage = LoginPage;
            

            MainPage = new NavigationPage(new LoginPage());

            //fdsfsdfsdfsdfsd
            
        }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
