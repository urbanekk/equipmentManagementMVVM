using ED_MVVM.Models;
using System.Windows;
using System.Windows.Input;

namespace ED_MVVM.ViewModels
{
    public enum LoginStatus
    {
        Correct,
        NoSuchUser
    }

    public class LoginVM : ObservableObject
    {
        public LoginVM()
        {

        }



        private string login;
        private string password;



        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChangedEvent("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChangedEvent("Password");
            }
        }

        

        /// <summary>
        /// ICommands - binded to View
        /// </summary>
        /// 

        public ICommand LoginCommand
        {
            get { return new DelegateCommand(LoginUser); }
        }



        /// <summary>
        /// Methods used in VM
        /// </summary>
        /// 

        // login user
        // check if provided login exists in db
        private void LoginUser()
        {
            if (Login != null && Password != null)
            {
                LoginStatus status = DBQueries.CheckUserExists(Login, Password);

                switch (status)
                {
                    case (LoginStatus.Correct):
                        Window Main = new MainWindow();
                        Application.Current.Windows[0].Close();
                        Main.Show();
                        break;
                    case (LoginStatus.NoSuchUser):
                        MessageBox.Show("Incorrect login or password!");
                        Password = "";
                        break;
                }
            }
            else MessageBox.Show("Provide login and password!");
        }
    }
}
