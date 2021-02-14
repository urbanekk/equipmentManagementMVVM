using System.Windows;
using System.Windows.Input;

namespace ED_MVVM.ViewModels
{
    public class AddUserVM : ObservableObject
    {
        public AddUserVM()
        {

        }

        private string firstname;
        private string lastname;
        private string login;
        private string password;
        private string fullname;

        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                FullName = FirstName + " " + LastName;
            }
        }

        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                FullName = FirstName + " " + LastName;
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

        public string FullName
        {
            get { return fullname; }
            set
            {
                fullname = value;
                RaisePropertyChangedEvent("FullName");
            }
        }



        /// <summary>
        /// ICommands - binded to View
        /// </summary>
        /// 

        public ICommand AddUserCommand
        {
            get { return new DelegateCommand(CreateAccount); }
        }



        /// <summary>
        /// Methods used in VM
        /// </summary>
        /// 

        // create new user in DB using provided data in View
        // !!! need to add validation of data (no empty boxes)
        private void CreateAccount()
        {   
            bool createStatus;

            user newUser = new user(FirstName, LastName, Login, Password);
            createStatus = newUser.SaveToDatabase();

            if (createStatus)
                MessageBox.Show("Account created successfully!");
            else
                MessageBox.Show("Login already exists. Try another one.");
        }
    }
}
