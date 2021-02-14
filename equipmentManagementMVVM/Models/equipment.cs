using System.Collections.Generic;
using System.Linq;

namespace ED_MVVM
{
    public partial class equipment
    {
        public equipment(string name, string owner, string eid)
        {
            Name = name;
            Owner = owner;
            EID = eid;
        }

        // read current equipment objects in database
        // check if equipment with provided name already exists
        // return true or false
        private bool CheckIfExistsInDatabase()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                List<equipment> equipmentList = context.equipment.ToList<equipment>();

                bool exists = false;

                foreach (var item in equipmentList)
                {
                    if (item.Name == Name)
                        exists = true;
                }

                return exists;
            }
        }

        // save equipment instance to database
        // provide feedback to VM to present proper message in View
        // true - successfuly saved equipment
        // false - equipment already in exists in DB
        public bool SaveToDatabase()
        {
            if (!CheckIfExistsInDatabase())
            {
                using (reservations_dbEntities context = new reservations_dbEntities())
                {
                    // save to DB.user
                    context.equipment.Add(this);
                    context.SaveChanges();
                }

                return true;
            }
            else return false;
        }
    }
}
