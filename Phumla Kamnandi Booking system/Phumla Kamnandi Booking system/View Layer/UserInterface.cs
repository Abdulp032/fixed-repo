using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_Kamnandi_Booking_system.Database_Layer;
using Phumla_Kamnandi_Booking_system.Logic_Layer;


namespace Phumla_Kamnandi_Booking_system.View_Layer
{
    public partial class UserInterface : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;
        Guest guest;
        public UserInterface()
        {  
            InitializeComponent(); 
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            listPanel.Add(homePanel);               // at index 0
            listPanel.Add(reservationPanel);        // at index 1
            listPanel.Add(availableRoomsPanel);     // at index 2
            listPanel.Add(newGuestOrOldGuestPanel); // at index 3
            listPanel.Add(addGuestPanel);           // at index 4
            listPanel.Add(creditCardPanel);         // at index 5
            listPanel.Add(reservationCompletePanel);// at index 6
            listPanel.Add(editReservationPanel); // at index 7
            listPanel.Add(cancelBookingPanel);   // at index 8
            listPanel[index].BringToFront();
            NextButton.Visible = false;
            PreviousButton.Visible = false;
            

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            NextButton.Visible = true;
            if (index == 7)
            {
                index = 0;
                homePanel.BringToFront();
            }
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
            if (index < 1)
            {
                PreviousButton.Visible = false;
                NextButton.Visible = false;
            }
            if (index == 3)
            {
                NextButton.Visible = false;
            }
            if (index!= 4)
            {
                confirmButton.Visible = false;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
            if(index > 1)
            {
                PreviousButton.Visible=true;
            }
            if (index == 2)
            {
                dataGridView1.DataSource = DB.getAvailableRoomsTable(checkInDatePicker.Value.Date, checkOutDatePicker.Value.Date);
                availableRoomsLabel.Text = "There are " + DB.getNumRoomsAvailable(checkInDatePicker.Value.Date, checkOutDatePicker.Value.Date).ToString() + " rooms available.";
            }
            if(index == 3)
            {
                NextButton.Visible = false;
            }

        }

        private void makeReservationButton_Click(object sender, EventArgs e)
        {
            reservationPanel.BringToFront();
            index++;
            NextButton.Visible = true;
            PreviousButton.Visible = true;
        }

        private void addNewGuestButton_Click(object sender, EventArgs e)
        {
            addGuestPanel.BringToFront();
            index = 4;
            NextButton.Visible=false;
            confirmButton.Visible = true;

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            guest = new Guest(idNumTxtbx.Text,nameTxtBx.Text, surnameTxtBx.Text,phoneNumTxtBx.Text,emailTxtBx.Text,addressTxtBx.Text);
            DB.InsertGuest(guest);
            confirmButton.Visible = false;
            creditCardPanel.BringToFront();
            index = 5;
            MessageBox.Show("Guest account successfully created.");

            
        }

        private void creditCardEnterBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Credit card payment verified.");
            Booking booking = new Booking(guest.GuestID, 1, checkInDatePicker.Value.Date.ToString(), checkOutDatePicker.Value.Date.ToString());
            DB.InsertBooking(booking);
            referenceNoLabel.Text = booking.BookingID;
            RoomNoLabel.Text = booking.RoomID.ToString();
            priceLabel.Text = booking.Price.ToString();
            reservationCompletePanel.BringToFront();
            returnToHomeBtn.Visible = true;
            index = 6;
        }

        private void returnToHomeBtn_Click(object sender, EventArgs e)
        {
            homePanel.BringToFront();
            index = 0;
            PreviousButton.Visible = false;
        }

        private void editReservationButton_Click_1(object sender, EventArgs e)
        {
            editReservationPanel.BringToFront();
            index = 7;
            PreviousButton.Visible = true;

        }

        private void secondReturnHomeButton_Click(object sender, EventArgs e)
        {
            homePanel.BringToFront();
            index = 0;
            PreviousButton.Visible = false;
        }

        private void cancelReservationButton_Click(object sender, EventArgs e)
        {
            
            cancelBookingPanel.BringToFront();
            index = 8;
            cancelReturnToHomeBtn.Visible = true;

        }

        private void deleteBookingButton_Click(object sender, EventArgs e)
        {
            DB.DeleteBooking(cancelBookingIDTxtBx.Text);
            MessageBox.Show("Booking successfully deleted.");
        }

        private void cancelReturnToHomeBtn_Click(object sender, EventArgs e)
        {
            PreviousButton.Visible=false;
            homePanel.BringToFront();
            index = 0;
            cancelReturnToHomeBtn.Visible = false;
        }
    }
}
