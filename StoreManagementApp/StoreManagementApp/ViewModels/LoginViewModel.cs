using StoreManagementApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreManagementApp.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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

        public INavigation Navigation { get; set; }
        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            SubmitCommand = new Command(OnSubmit);
        }
        async void OnSubmit()
        {
            var user = await UserService.GetUserAsync(email);

            if (email == user.UserName || password == user.Password)
            {
                ((App)Application.Current).IsManager = user.IsManager;
                App.Current.MainPage = new MainPage();              
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
