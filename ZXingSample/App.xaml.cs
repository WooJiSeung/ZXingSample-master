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


            //MainPage = new MasterDetailPage1();

            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new MainPage2());

            //MainPage = new MasterDetailPage()
            //{
            //    Master = new MainPage() { Title = "Main Page" },
            //    //Master = new NavigationPage(new MainPage2()) { Title = "Main Page" },
            //    Detail = new NavigationPage(new MainPage2())
            //};

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
