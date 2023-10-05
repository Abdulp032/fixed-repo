using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi_Booking_system.Logic_Layer
{
    internal class Room
    {
        #region fields/instance variables

        private int roomID;
        private string roomType;    // single, double, triple
        private int numBeds;

        #endregion

        #region property method stuff

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }
        public int NumBeds
        {
            get { return numBeds; }
            set { numBeds = value; }
        }
        #endregion

        #region constructor and methods

        public Room(int roomID, string roomType)
        {
            RoomID = roomID;
            RoomType = roomType;
            if(roomType == "Single")
            {
                numBeds = 1;
            }else if(roomType == "Double")
            {
                numBeds = 2;
            }
            else
            {
                numBeds = 3;
            }

        }
        public Room(int roomID)
        {
            RoomID =roomID;
            RoomType = "Single";
            numBeds = 1;
        }

            #endregion

        }
}
