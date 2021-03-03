using System.Linq;
using System.Collections.Generic;
using ED_MVVM.Models;

namespace ED_MVVM
{
    public partial class user
    {
        public user(string name, string surname, string login, string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            UserType = "user";
        }



        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }



        // read current user objects in database
        // check if user with provided login already exists
        // return true or false
        private bool CheckIfExistsInDatabase()
        {
            bool exists = false;

            List<string> Logins = DBQueries.QueryAllLogin();

            foreach (var item in Logins)
            {
                if(item == Login)
                    exists = true;
            }

            return exists;
        }

        // save user instance to database
        // provide feedback to VM
        // true - successfuly saved user
        // false - login already in use
        public bool SaveToDatabase()
        {
            if (!CheckIfExistsInDatabase())
            {
                DBQueries.UserSaveToDatabase(this);

                return true;
            }
            else return false;
        }
    }
}