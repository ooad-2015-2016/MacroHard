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
using ShEM.View;
using System.Text.RegularExpressions;
using System.Globalization;
using Windows.UI.Popups;
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
        }

        private string userInput;
        private string pass;
        private string registerUsername;
        private string registerEmail;
        private string registerPassword;
        private string registerRepassword;
        LoginViewModel loginViewModel;
        StaticVariablesClass statika = new StaticVariablesClass();

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            userInput = textBoxUsername.Text;
            pass = textBoxPass.Password;           
            loginViewModel = new LoginViewModel(userInput, pass);
            DataContext = loginViewModel;
            loginViewModel.povuciUsera();  
        }
        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            registerUsername = textBoxRegisterUsername.Text;
            registerEmail = emailBoxRegisterUsername.Text;
            registerPassword = textBoxRegisterPass.Password;
            registerRepassword = textBoxRegisterRePass.Password;
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

            //this.ValidateUserRegistrationEmail();
        }

        private void ForgottenPassword_Click(object sender, RoutedEventArgs e)
        {
            RecoverForm.Visibility = Visibility.Visible;
        }

        //validacija za korektno unijeti recovery email
        private async void ValidateUserRecoveryEmail()
        {
            bool valid = true;
            string mail = EmailRecoverInput.ToString();

            if (String.IsNullOrEmpty(mail)) valid = false;

            try
            {
                mail = Regex.Replace(mail, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                valid = false;
            }

            try
            {
                if(!Regex.IsMatch(mail,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    valid = false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                valid = false;
            }

            if (!valid)
            {
                var dialog = new MessageDialog("Invalid E-mail format");
                await dialog.ShowAsync();
            }
            if (valid)
            {
                await loginViewModel.validirajEmailUsera(EmailRecoverInput.ToString());
            }
        }

        private void RecoverUser(object sender, RoutedEventArgs e)
        {
            bool tmp = false;
            ValidateUserRecoveryEmail();
            tmp = true;
            if(tmp)
            {
                //loginViewModel.povuciUsera();
                //posalji mu mail o informacijama
            }
        }

        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException e)
            {
                e.Message.ToString();
            }
            return match.Groups[1].Value + domainName;
        }

        //validacija na korektnost registracionog mail-a
        private async void ValidateUserRegistrationEmail()
        {
            bool valid = true;
            string mail = emailBoxRegisterUsername.ToString();

            if (String.IsNullOrEmpty(mail)) valid = false;

            try
            {
                mail = Regex.Replace(mail, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                valid = false;
            }

            try
            {
                if (!Regex.IsMatch(mail,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    valid = false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                valid = false;
            }

            if (!valid)
            {
                var dialog = new MessageDialog("Invalid E-mail format");
                await dialog.ShowAsync();
            }
        }
    }
}
