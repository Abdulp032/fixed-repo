using Phumla_Kamnandi_Booking_system.View_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi_Booking_system
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new UserInterface());

        }

        public void searchAvailableRoom()
        {
            // makes this query
            //SELECT RoomID
            //        FROM Rooms
            //        WHERE RoomID NOT IN(SELECT RoomID FROM Bookings WHERE CheckIn <= theInputtedCheckingDate AND CheckOut >= theOutputtedCheckoutDate);
        }
    }
}
