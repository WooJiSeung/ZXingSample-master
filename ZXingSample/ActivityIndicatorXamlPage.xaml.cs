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
    public partial class ActivityIndicatorXamlPage : ContentPage
    {
        private bool _isTaskRunning = false;

        public ActivityIndicatorXamlPage()
        {
            InitializeComponent();
        }
        private void UpdateUiState()
        {
            defaultActivityIndicator.IsRunning = !_isTaskRunning;
            styledActivityIndicator.IsRunning = _isTaskRunning;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            _isTaskRunning = !_isTaskRunning;
            UpdateUiState();
        }
    }
}