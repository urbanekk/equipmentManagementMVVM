using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ED_MVVM.Models;

namespace ED_MVVM.ViewModels
{
    public class ManageReservationsVM : ObservableObject
    {
        public ManageReservationsVM()
        {
            Reservations = new ObservableCollection<PresentReservations>(DBQueries.GetAllReservations());
        }

        private ObservableCollection<PresentReservations> _reservations;
        private PresentReservations _reseravation;


        public ObservableCollection<PresentReservations> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        public PresentReservations Reservation
        {
            get { return _reseravation; }
            set { _reseravation = value; }
        }
    }
}
