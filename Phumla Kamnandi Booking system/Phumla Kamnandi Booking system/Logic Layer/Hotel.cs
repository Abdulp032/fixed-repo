using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi_Booking_system.Logic_Layer
{
    internal class Hotel
    {
        #region fields/instance variables

        private int numRooms;
        private string name;
        private string location;        // address/location
        private int numRoomsAvailable;
        private int numRoomsBooked;

        #endregion

        #region property methods stuff

        public int NumRooms
        {
            get { return numRooms; }
            set { numRooms = value; }
        }
        public int NumRoomsAvailable
        {
            get { return numRoomsAvailable; }
            set { numRoomsAvailable = value; }
        }
        public int NumRoomsBooked
        {
            get { return numRoomsBooked;}
            set { numRoomsBooked = value;}
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        #endregion

        #region constructor and methods

        public Hotel(string name, string location, int numRooms)
        {
            this.name = name;
            this.location = location;
            this.numRooms = numRooms;
            this.numRoomsAvailable = numRooms;
            this.numRoomsBooked=numRooms;
        }

        #endregion
    }
}
