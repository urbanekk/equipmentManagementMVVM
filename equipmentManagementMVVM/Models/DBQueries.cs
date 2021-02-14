using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ED_MVVM.Models
{
    public static class DBQueries
    {
        public static ObservableCollection<user> GetRegisteredUsers()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                List<user> userList = context.user.ToList<user>();
                ObservableCollection<user> userCollection = new ObservableCollection<user>();
                
                foreach (var item in userList)
                    userCollection.Add(item);

                return userCollection;
            }
        }
    }
}
