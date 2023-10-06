using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Phumla_Kamnandi_Booking_system.Logic_Layer;

namespace Phumla_Kamnandi_Booking_system.Database_Layer
{
    public class CustomerDB: DB
    {
        #region Data Fields
        private string table1 = "Bookings";
        private string table2 = "Guests";
        private string table3 = "Rooms";

        // SQL Queries for Filling DataSets
        private string sqlLocal1 = "SELECT * FROM Bookings";
        private string sqlLocal2 = "SELECT * FROM Guests";
        private string sqlLocal3 = "SELECT * FROM Rooms";

        // stores lists of all guests and all bookings
        private Collection<Guest> guests;
        private Collection<Booking> bookings;
        #endregion

        #region Property Methods
/*         this block of code has an error that needs to be fixed 
        public Collection<Guest> AllGuests
        {
            get { return guests; }
        }
*/
/*      this block also has som error
        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }
*/
        #endregion

        #region Constructors

        public CustomerDB()
        {
            bookings = new Collection<Booking>();
            guests = new Collection<Guest>();
        }

        #endregion

        #region Utility Methods

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        // Used to read in records from the Bookings and Guests tables and populate each Collection
        public void Add2Collection()
        {
            DataRow myRow = null;
            Booking aBooking;
            Guest aGuest;
            
            // Reading each row of the Bookings Table and creating Booking objects for the Collection
            foreach (DataRow myRow_loopVariable in dsMain.Tables["Bookings"].Rows) 
            {
                myRow = myRow_loopVariable;

                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aBooking = new Booking();
                    aBooking.BookingID = Convert.ToString(myRow["BookingID"]).TrimEnd();
                    aBooking.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    aBooking.RoomID = Convert.ToInt32(myRow["RoomID"]); // room ID is an int?
                    aBooking.CheckInDate = Convert.ToString(myRow["CheckInDate"]);
                    aBooking.CheckOutDate = Convert.ToString(myRow["CheckOutDate"]);
                    aBooking.Price = (float)Convert.ToDecimal(myRow["Price"]);

                    bookings.Add(aBooking);
                }
            }


            // Reading each row of the Guests Table and creating Guest objects for the Collection
            // this first line also has some error here
           /*
            foreach (Data myRow_loopVariable in dsMain.Tables["Guests"].Rows)
            {
                myRow = myRow_loopVariable;

                if((myRow.RowState != DataRowState.Deleted))
                {
                    aGuest = new Guest();
                    aGuest.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    aGuest.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    aGuest.Surname = Convert.ToString(myRow["Surname"]).TrimEnd();
                    aGuest.PhoneNumber = Convert.ToString(myRow["PhoneNumber"]).TrimEnd();
                    aGuest.Email = Convert.ToString(myRow["Email"]).TrimEnd();
                    aGuest.Address = Convert.ToString(myRow["Address"]).TrimEnd();

                    guests.Add(aGuest);
                }
            }
           */

        }

        #endregion 


    }
}