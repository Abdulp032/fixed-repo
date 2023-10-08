using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kamnandi_Booking_system.Database_Layer;

namespace Phumla_Kamnandi_Booking_system.Logic_Layer
{
    public class Booking
    {
        #region fields/instance variables

        private string bookingID;
        private string guestID;
        private int roomID;
        private string checkInDate;
        private string checkOutDate;
        private float price;
        private string depositStatus;

        #endregion

        #region property methods stuff

        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public string CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }
        public string CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public string DepositStatus
        {
            get { return depositStatus; }
            set { depositStatus = value; }
        }
        #endregion

        #region constructor and methods

        public Booking(string guestID, int roomID, string checkInDate, string checkOutDate, string depositStatus)
        {
            this.BookingID = generateUniqueBookingID();
            this.guestID = guestID;
            this.roomID = roomID;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.price = calculatePrice();
            this.depositStatus = depositStatus;
        }

        // Default constructor allowing later instantiation of properties
        public Booking()
        {

        }

        public static string generateUniqueBookingID()
        {
            DB db = new DB();
            int uniqueID = db.getMaxBookingID() + 1;
            return uniqueID.ToString();
        }

        public float calculatePrice()
        {
            return 1;       // need to add some implementation here
        }

        #endregion
    }
}
