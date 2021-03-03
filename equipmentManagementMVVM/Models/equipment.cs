using ED_MVVM.Models;
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
            bool exists = false;

            List<string> equipmentNames = DBQueries.QueryAllEquipmentNames();

            foreach (var item in equipmentNames)
            {
                if (item == Name)
                    exists = true;
            }

            return exists;
        }

        // save equipment instance to database
        // provide feedback to VM
        // true - successfuly saved equipment
        // false - equipment already in exists in DB
        public bool SaveToDatabase()
        {
            if (!CheckIfExistsInDatabase())
            {
                DBQueries.EquipmentSaveToDatabase(this);
                return true;
            }
            else return false;
        }
    }
}
