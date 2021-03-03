using ED_MVVM.ViewModels;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;

namespace ED_MVVM.Models
{
    public static class DBQueries
    {
        #region Queries used in LoginVM   

        #region Read

        // verification of provided login and password during login process
        public static LoginStatus CheckUserExists(string login, string password)
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                user User = context.user.Where(i => i.Login == login).Where(i => i.Password == password).FirstOrDefault();

                if (User != null)
                {
                    App.Current.Properties["CurrentUserFullName"] = User.FullName;
                    App.Current.Properties["CurrentUserID"] = User.idUser;
                    App.Current.Properties["CurrentUserType"] = User.UserType;

                    return LoginStatus.Correct;
                }
                else return LoginStatus.NoSuchUser;
            }
        }

        #endregion

        #endregion



        #region Queries used in User Model

        #region Read

        // return List of all Logins in User Table
        public static List<string> QueryAllLogin()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                List<string> LoginListString = new List<string>();

                var LoginList = context.user.Select(i => new { Login = i.Login });

                foreach (var item in LoginList)
                    LoginListString.Add(item.Login);

                return LoginListString;
            }
        }

        #endregion

        #region Save

        // save new User to DB
        public static void UserSaveToDatabase(user userInstance)
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                context.user.Add(userInstance);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion



        #region Queries used in Equipment Model

        #region Read
        
        // return List of all Registered Users (UserPartial - only Name and Surname)
        public static ObservableCollection<string> GetRegisteredUsersFullnames()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                ObservableCollection<string> userList = new ObservableCollection<string>();

                var userPartialList = context.user.Select(i => new { Name = i.Name, Surname = i.Surname}).OrderBy(i => i.Surname);

                foreach (var item in userPartialList)
                    userList.Add(item.Name + " " + item.Surname);

                return userList;
            }
        }

        //
        public static List<string> QueryAllEquipmentNames()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                List<string> equipmentListString = new List<string>();
                
                var equipmentList = context.equipment.Select(i => new { Name = i.Name});

                foreach (var item in equipmentList)
                    equipmentListString.Add(item.Name);

                return equipmentListString;
            }
        }
    
        #endregion

        #region Save

        // save new User to DB
        public static void EquipmentSaveToDatabase(equipment eqInstance)
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                context.equipment.Add(eqInstance);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion



        #region Queries used in PresentReservation Model

        #region Read

        // used in ManageReservationsVM 
        // query for list of all PresentReservation objects
        public static ObservableCollection<PresentReservations> GetAllReservations()
        {
            using (reservations_dbEntities context = new reservations_dbEntities())
            {
                var reservationsList = context.reservations.ToList();

                ObservableCollection<PresentReservations> reservationCollection = new ObservableCollection<PresentReservations>();

                foreach (var item in reservationsList)
                {
                    reservationCollection.Add( new PresentReservations( item.idReservations, item.user.FullName, item.equipment, item.StartDate.Value.ToString("dd/MM/yyyy"), item.StopDate.Value.ToString("dd/MM/yyyy")));
                }

                return reservationCollection;
            }
        }

        #endregion

        #region Save



        #endregion

        #endregion

    }
}