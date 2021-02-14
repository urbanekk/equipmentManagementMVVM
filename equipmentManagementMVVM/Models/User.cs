using System.Linq;
using System.Collections.Generic;

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

        // read current user objects in database
        // check if user with provided login already exists
        // return true or false
        private bool CheckIfExistsInDatabase()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                List<user> userList = context.user.ToList<user>();

                bool exists = false;

                foreach (var item in userList)
                {
                    if (item.Login == Login)
                        exists = true;
                }

                return exists;
            }
        }

        // save user instance to database
        // provide feedback to VM to present proper message in View
        // true - successfuly saved user
        // false - login already in use
        public bool SaveToDatabase()
        {
            if (!CheckIfExistsInDatabase())
            {
                using (reservations_dbEntities context = new reservations_dbEntities())
                {
                    // save to DB.user
                    context.user.Add(this);
                    context.SaveChanges();
                }

                return true;
            }
            else return false;
        }
    }
}

// to do - baza danych - autoinkrementacja rekordów