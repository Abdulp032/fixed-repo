using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Phumla_Kamnandi_Booking_system.Properties;
using Phumla_Kamnandi_Booking_system.View_Layer;
using Phumla_Kamnandi_Booking_system.Logic_Layer;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Phumla_Kamnandi_Booking_system.Database_Layer
{
    public class DB
    {
        #region Fields and Data Members
        static string strConn = Settings.Default.DatabaseConnectionString;
        static SqlConnection con = new SqlConnection(strConn);
        //static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\abdul\\OneDrive\\Desktop\\infos project\\Phumla Kamnandi Booking system\\Phumla Kamnandi Booking system\\Database Layer\\Database.mdf\";Integrated Security=True");
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        private Collection<Guest> guests;
        private Collection<Booking> bookings;

        public enum DBOperation
        {
            Add = 0,
            Edit = 1,
            Delete = 2
        }
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error: Can't load database");
                return;
            }
            guests = new Collection<Guest> ();
            bookings = new Collection<Booking>();
        }
        #endregion

        #region Property Methods
        public Collection<Guest> GetAllGuests
        {
            get { return guests; }
        }

        public Collection<Booking> GetAllBookings
        {
            get { return bookings;}
        }
        #endregion

        public void FillDataSet(string aSQLstring, string aTable)
        {
            //fills dataset fresh from the db for a specific table and with a specific Query
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                dsMain.Clear();
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success;
            try
            {
                //open the connection
                cnMain.Open();
                //***update the database table via the data adapter
                daMain.Update(dsMain, table);
                //---close the connection
                cnMain.Close();
                //refresh the dataset
                FillDataSet(sqlLocal, table);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }

        #region Utility Methods

        // Method to populate guest and booking collections with records from the database
        public void PopulateCollections()
        {
            DataRow myRow = null;
            Guest guest;
            Booking booking;

            guests.Clear();
            bookings.Clear();

            string sqlQuery = "SELECT * FROM Guests";
            daMain = new SqlDataAdapter(sqlQuery, cnMain);
            daMain.Fill(dsMain, "Guests");

            // Adding all guest records to the guests collection
            foreach (DataRow myRow_loopVariable in dsMain.Tables["Guests"].Rows)
            {
                myRow = myRow_loopVariable;

                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    guest = new Guest();
                    guest.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    guest.IDNumber = Convert.ToString(myRow["IDNumber"]).TrimEnd();
                    guest.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    guest.Surname = Convert.ToString(myRow["Surname"]).TrimEnd();
                    guest.PhoneNumber = Convert.ToString(myRow["PhoneNumber"]).TrimEnd();
                    guest.Email = Convert.ToString(myRow["Email"]).TrimEnd();
                    guest.Address = Convert.ToString(myRow["Address"]).TrimEnd();

                    guests.Add(guest);
                }
            }

            sqlQuery = "SELECT * FROM Bookings";
            daMain = new SqlDataAdapter( sqlQuery, cnMain );
            daMain.Fill(dsMain, "Bookings");

            // Adding all booking records to the bookings collection
            foreach (DataRow myRow_loopVariable in dsMain.Tables["Bookings"].Rows)
            {
                myRow = myRow_loopVariable;

                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    booking.BookingID = Convert.ToString(myRow["BookingID"]).TrimEnd();
                    booking.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    booking.RoomID = Convert.ToInt32(myRow["RoomID"]);
                    booking.CheckInDate = Convert.ToString(myRow["CheckInDate"]).TrimEnd();
                    booking.CheckOutDate = Convert.ToString(myRow["CheckOutDate"]).TrimEnd();
                    booking.Price = (float)Convert.ToDecimal(myRow["Price"]);

                    bookings.Add(booking);
                }
            }
        }

        // Returns the highest guest id in the table of guests
        public int getMaxGuestID()
        {
            PopulateCollections();

            // Looping through each guest in the collection of guests to find the highest GuestID
            int highest = 0;
            foreach (Guest guest in guests)
            {
                if (int.Parse(guest.GuestID) > highest)
                {
                    highest = int.Parse(guest.GuestID);
                }
            }

            return highest;
        }

        // Returns the highest booking id in the table of bookings
        public int getMaxBookingID()
        {
            PopulateCollections();

            // Looping through each booking in the collection of bookings to find the highest BookingID
            int highest = 0;
            foreach (Booking booking in bookings)
            {
                if (int.Parse(booking.BookingID) > highest)
                {
                    highest = int.Parse(booking.BookingID);
                }
            }

            return highest;
        }

        #endregion

        #region CRUD Operations
        // Returns a table of the rooms available, filtered between a given date period
        public static DataTable getAvailableRoomsTable(DateTime checkInDate, DateTime checkOutDate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT RoomID as AvailableRooms FROM Rooms WHERE RoomID NOT IN ( SELECT RoomID FROM Bookings WHERE ( CheckInDate >= @checkInDate AND CheckInDate < @checkOutDate ) OR ( CheckOutDate > @checkInDate AND CheckOutDate <= @checkOutDate ) OR ( CheckInDate <= @checkInDate AND CheckOutDate >= @checkOutDate ) ); ", con);
            cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
            cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            return dt;
        } 

        public static int getNumRoomsAvailable(DateTime checkInDate, DateTime checkOutDate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(RoomID) FROM Rooms WHERE RoomID NOT IN ( SELECT RoomID FROM Bookings WHERE ( CheckInDate >= @checkInDate AND CheckInDate < @checkOutDate ) OR ( CheckOutDate > @checkInDate AND CheckOutDate <= @checkOutDate ) OR ( CheckInDate <= @checkInDate AND CheckOutDate >= @checkOutDate ) ); ", con);
            cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
            cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);
            int s = ((int)cmd.ExecuteScalar());
            con.Close();
            return s;
        }

        // Inserts a guest record into the Guests table
        public static void InsertGuest(Guest guest)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Guests VALUES (@GuestID, @IDNumber, @Name, @Surname, @PhoneNumber, @Email, @Address)", con);
            cmd.Parameters.AddWithValue("@GuestID", guest.GuestID);
            cmd.Parameters.AddWithValue("@IDNumber", guest.IDNumber);
            cmd.Parameters.AddWithValue("@Name", guest.Name);
            cmd.Parameters.AddWithValue("@Surname", guest.Surname);
            cmd.Parameters.AddWithValue("@PhoneNumber", guest.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", guest.Email);
            cmd.Parameters.AddWithValue("@Address", guest.Address);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Inserts a booking record into the Bookings table
        public static void InsertBooking(Booking booking) 
        { 
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Bookings VALUES (@BookingID, @GuestID, @RoomID, @CheckInDate, @CheckOutDate, @Price, @DepositStatus)", con);
            cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
            cmd.Parameters.AddWithValue("@GuestID", booking.GuestID);
            cmd.Parameters.AddWithValue("@RoomID", booking.RoomID);
            cmd.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
            cmd.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
            cmd.Parameters.AddWithValue("@Price", booking.Price);
            cmd.Parameters.AddWithValue("@DepositStatus", booking.DepositStatus);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteGuest(string guestID)
        {
            con.Open();
            // First Delete from Bookings table due to foreign key
            SqlCommand cmd = new SqlCommand("DELETE FROM Bookings WHERE (GuestID=@GuestID)", con);
            cmd.Parameters.AddWithValue("@GuestID", guestID);
            cmd.ExecuteNonQuery();

            // Then Delete from Guests table
            cmd = new SqlCommand("DELETE FROM Guests WHERE (GuestID=@GuestID)", con);
            cmd.Parameters.AddWithValue("@GuestID", guestID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteBooking(string bookingID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Bookings WHERE (BookingID=@BookingID)", con);
            cmd.Parameters.AddWithValue("@BookingID", bookingID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateGuest(string guestID, string newIDNumber, string newName, string newSurname, string newPhoneNumber, string newEmail, string newAddress)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Guests SET (IDNumber=@IDNumber, Name=@Name, Surname=@Surname, PhoneNumber=@PhoneNumber, " +
                                            "Email=@Email, Address=@Address) WHERE GuestID=@GuestID", con);
            cmd.Parameters.AddWithValue("@GuestID", guestID); // guestID cannot be changed
            cmd.Parameters.AddWithValue("@IDNumber", newIDNumber);
            cmd.Parameters.AddWithValue("@Name", newName);
            cmd.Parameters.AddWithValue("@Surname", newSurname);
            cmd.Parameters.AddWithValue("@PhoneNumber", newPhoneNumber);
            cmd.Parameters.AddWithValue("@Email", newEmail);
            cmd.Parameters.AddWithValue("@Address", newAddress);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Updates all the information of a given Booking
        public static void UpdateBooking(string bookingID, int newRoomID, string newCheckInDate, string newCheckOutDate, float newPrice)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Bookings SET (RoomID=@RoomID, CheckInDate=@CheckInDate, CheckOutDate=@CheckOutDate, Price=@Price) " +
                                            "WHERE BookingID=@BookingID", con);
            cmd.Parameters.AddWithValue("@BookingID", bookingID); // bookingID cannot be changed
            cmd.Parameters.AddWithValue("@RoomID", newRoomID);
            cmd.Parameters.AddWithValue("@CheckInDate", newCheckInDate);
            cmd.Parameters.AddWithValue("@CheckOutDate", newCheckOutDate);
            cmd.Parameters.AddWithValue("@Price", newPrice);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Update only the check in date and check out date of the given booking
        public static void UpdateBooking(string bookingID, string newCheckInDate, string newCheckOutDate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Bookings SET (CheckInDate=@CheckInDate, CheckOutDate=@CheckOutDate) WHERE BookingID=@BookingID", con);
            cmd.Parameters.AddWithValue("@BookingID", bookingID);
            cmd.Parameters.AddWithValue("@CheckInDate", newCheckInDate);
            cmd.Parameters.AddWithValue("@CheckOutDate", newCheckOutDate);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion

    }
}