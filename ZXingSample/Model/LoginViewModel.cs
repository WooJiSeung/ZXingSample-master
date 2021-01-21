using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZXingSample.Model
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public Action DisplayInvalidLoginPrompt;
        public Action LoginCompleted;
        private string userid;

        public string UserId
        {
            get { return userid; }
            set
            {
                userid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserId"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            LoginCompleted();

            //if (userid == "jswoo" && password == "123www1!")
            //if (userid == "11" && password == "11")
            //    LoginCompleted();
            //else
            //    DisplayInvalidLoginPrompt();
        }
    }
}
