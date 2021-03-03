using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using ED_MVVM.Models;

namespace ED_MVVM.ViewModels
{
    public class AddEquipmentVM : ObservableObject
    {
        public AddEquipmentVM()
        {
            Users = new ObservableCollection<string>(DBQueries.GetRegisteredUsersFullnames());
        }

        public ObservableCollection<string> Users
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Owner
        {
            get; set;
        }

        public string EID
        {
            get; set;
        }


        /// <summary>
        /// ICommands - binded to View
        /// </summary>
        /// 

        public ICommand AddEquipmentCommand
        {
            get { return new DelegateCommand(AddEquipment); }
        }



        /// <summary>
        /// Methods used in VM
        /// </summary>
        /// 

        // create new user in DB using provided data in View
        // !!! need to add validation of data (no empty boxes)
        private void AddEquipment()
        {
            bool addingStatus;

            if (Name != null && Owner != null && EID != null)
            {
                equipment newEquipment = new equipment(Name, Owner, EID);
                addingStatus = newEquipment.SaveToDatabase();

                if (addingStatus)
                    MessageBox.Show("Success! Equipment added to database!");
                else
                    MessageBox.Show("Equipment could not be added to database!");
            }
            else MessageBox.Show("Fill in all empty boxes!");
            
        }
    }
}