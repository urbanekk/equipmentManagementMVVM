using ED_MVVM.Models;
using ED_MVVM.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ED_MVVM.ViewModels
{
    public class LoginVM : ObservableObject
    {
        public LoginVM()
        {
            Users = new ObservableCollection<user>();
            Users = DBQueries.GetRegisteredUsers();
        }

        private ObservableCollection<user> _users;
        private string login;
        private string password;

        public ObservableCollection<user> Users
        {
            get { return _users; }
            set { _users = value; }
        }

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

        enum LoginStatus
        { 
            Correct,
            NoSuchUser,
            IncorrectPassword
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
        // !!! need to add validation of data (no empty boxes)
        private void LoginUser()
        {
            LoginStatus status = LoginStatus.NoSuchUser;

            foreach (var item in Users)
            {
                if (Login == item.Login)
                {
                    if (Password == item.Password)
                        status = LoginStatus.Correct;
                    else status = LoginStatus.IncorrectPassword;

                    break;
                }
            }

            switch (status)
            {
                case (LoginStatus.Correct):
                    Window Main = new MainWindow();
                    Application.Current.Windows[0].Close();
                    Main.Show();
                    break;
                case (LoginStatus.IncorrectPassword):
                    MessageBox.Show("Incorrect password!");
                    Password = "";
                    break;
                case (LoginStatus.NoSuchUser):
                    MessageBox.Show("Incorrect login!");
                    Login = "";
                    Password = "";
                    break;
            }
        }
    }
}
