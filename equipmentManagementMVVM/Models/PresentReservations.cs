using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_MVVM.Models
{
    public class PresentReservations
    {
        public PresentReservations(int id, string username, ICollection<equipment> equipments, string startdate, string stopdate)
        {
            ReservationID = id;
            UserFullname = username;
            Equipments = equipments;
            StartDate = startdate;
            StopDate = stopdate;
        }

        public int ReservationID
        {
            get; set;
        }

        public string UserFullname
        {
            get; set;
        }

        public ICollection<equipment> Equipments
        {
            get; set;
        }

        public string StartDate
        {
            get; set;
        }

        public string StopDate
        {
            get; set;
        }
    }
}