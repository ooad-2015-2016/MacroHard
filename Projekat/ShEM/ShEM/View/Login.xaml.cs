using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ShEM.BazaPodataka.Static_variables;
using System.ComponentModel;
using Windows.UI.ViewManagement;
using ShEM.ViewModel;
using ShEM.BazaPodataka.Static_variables;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShEM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            //ApplicationView.PreferredLaunchViewSize = new Size(2160, 1440);
          //  ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        private string userInput;
        private string pass;
        StaticVariablesClass stc;
        LoginViewModel loginViewModel;
        StaticVariablesClass statika = new StaticVariablesClass();

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            userInput = textBoxUsername.Text;
            pass = textBoxPass.Password;           
            loginViewModel = new LoginViewModel(userInput, pass);
            DataContext = loginViewModel;
            loginViewModel.povuciUsera();
            statika.username = userInput;      
        }

        private void ShowPassClick(object sender, RoutedEventArgs e)
        {
            if (textBoxPass.PasswordRevealMode == PasswordRevealMode.Visible)
            {
                textBoxPass.PasswordRevealMode = PasswordRevealMode.Hidden;
            }
            else
            {
                textBoxPass.PasswordRevealMode = PasswordRevealMode.Visible;
            }
        }

        private void SignInFun(object sender, RoutedEventArgs e)
        {
            RegisterForm.Visibility = Visibility.Visible;
        }

        private void ForgottenPassword_Click(object sender, RoutedEventArgs e)
        {
            RecoverForm.Visibility = Visibility.Visible;

        }

        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            
        }
       
        private void RecoverUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
