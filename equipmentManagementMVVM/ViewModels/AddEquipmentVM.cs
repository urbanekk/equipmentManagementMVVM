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
            Users = new ObservableCollection<user>();
            Users = DBQueries.GetRegisteredUsers();
        }

        private ObservableCollection<user> _users;
        private user _user;

        private string _name;
        private string _owner; // accessible via comboBox -> only user which is already in database
        private string _EID;

        public ObservableCollection<user> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public user User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
            }
        }

        public string EID
        {
            get { return _EID; }
            set
            {
                _EID = value;
            }
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

            equipment newEquipment = new equipment(Name, Owner, EID);
            addingStatus = newEquipment.SaveToDatabase();

            if (addingStatus)
                MessageBox.Show("Success! Equipment added to database!");
            else
                MessageBox.Show("Equipment could not be added to database!");
        }
    }
}