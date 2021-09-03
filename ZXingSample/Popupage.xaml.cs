using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class Popupage : PopupPage
    {
		public Popupage ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<APTTransList>(this, "Hi", (sender) => {
                Closepage();
            });

            uint duration = 10 * 60 * 1000;

            animatePage1(duration);
            //animatePage2(duration);
            //animatePage3(duration);
        }

        async void animatePage1(uint duration)
        {
            await Task.WhenAll(
                  Image1.RotateTo(307 * 360, duration),
                  Image2.RotateXTo(251 * 360, duration),
                  Image3.RotateYTo(199 * 360, duration)
                );
            //await Image1.RelRotateTo(307 * 360, duration);
        }
        async void animatePage2(uint duration)
        {
            await Image2.RelRotateTo(251 * 360, duration);
        }
        async void animatePage3(uint duration)
        {
            await Image3.RelRotateTo(199 * 360, duration);
        }
        async void Closepage()
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return Content.FadeTo(0.5);
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return Content.FadeTo(1);
        }
    }
}