using System.Windows;

namespace ED_MVVM.ViewModels
{
    public class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            UserFullname = Application.Current.Properties["CurrentUserFullName"].ToString();

            if (App.Current.Properties["CurrentUserType"].ToString() == "admin")
            {
                AccountTabVisibility = Visibility.Visible;
                EquipmentTabVisibility = Visibility.Visible;
            }
            else
            {
                AccountTabVisibility = Visibility.Collapsed;
                EquipmentTabVisibility = Visibility.Collapsed;
            }

        }

        private Visibility accountTabVisibility;
        private Visibility equipmentTabVisibility;
        private string userFullname;


        public string UserFullname
        {
            get { return userFullname; }
            set
            {
                userFullname = value;
                RaisePropertyChangedEvent("UserFullname");
            }
        }

        public Visibility AccountTabVisibility
        {
            get { return accountTabVisibility; }
            set
            {
                accountTabVisibility = value;
                RaisePropertyChangedEvent("AccountTabVisibility");
            }
        }

        public Visibility EquipmentTabVisibility
        {
            get { return equipmentTabVisibility; }
            set
            {
                equipmentTabVisibility = value;
                RaisePropertyChangedEvent("EquipmentTabVisibility");
            }
        }
    }
}