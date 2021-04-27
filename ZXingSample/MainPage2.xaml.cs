using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage2 : ContentPage
	{
		public MainPage2 ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);

            _LoadPage();
        }
        private void _LoadPage()
        {
            this.Title = "NIFCO Korea";
        }
        private void BtnMain_Clicked(object sender, EventArgs e)
        {
            string name = (sender as Button).ClassId;
            switch (name)
            {
                case "btnMain1": _ScanBarcode(); break;
                case "btnMain2": _LoadingBar(); break;
                default: break;
            }
        }

        private void _ScanBarcode()
        {
            Navigation.PushAsync(new APTTransInfo());
        }

        private void _LoadingBar()
        {
            Navigation.PushAsync(new APTTransList());
        }
    }
}