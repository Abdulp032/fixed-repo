using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kamnandi_Booking_system.Database_Layer;

namespace Phumla_Kamnandi_Booking_system.Logic_Layer
{
    public class Guest
    {
        #region fields/instance variables

        private string guestID;
        private string idNumber;
        private string name;
        private string surname;
        private string phoneNumber;
        private string email;       // not needed for the system only if the customer wants to give this info
        private string address;

        #endregion


        #region properties stuff can't remember the name

        public string GuestID{
            get { return guestID; }
            set { guestID = value; }
        }

        public string IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        #endregion

        
        #region constructor and methods

        public Guest(string idNumber, string name, string surname, string phoneNumber, string email, string address)
        {
            this.GuestID = generateUniqueID();
            this.IDNumber = idNumber;
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address; 
        }

        
        // Default Constructor to allow later assignment of fields
        public Guest()
        {

        }
        
        // add functionality
        public static string generateUniqueID()
        {
            int s = DB.getMaxGuestID()+1;
            return s.ToString();
        }

        #endregion


    }
}
