using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            listPanel.Add(existingGuestPanel);   // at index 9
            listPanel.Add(enquirePanel);         // at index 10
            listPanel[index].BringToFront();
            NextButton.Visible = false;
            PreviousButton.Visible = false;

            // test code
            /*Guest guest = new Guest("IDNumber", "Name", "Surname", "1234567890", "someone@example.com", "123 This Road");
            DB.InsertGuest(guest);*/
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            confirmButton.Visible = false;
            NextButton.Visible = true;
            
            if(index == 9)
            {
                index = 3;
                newGuestOrOldGuestPanel.BringToFront();
                NextButton.Visible=false;
                return;
            }
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
            if(index == 4)
            {
                confirmButton.Visible = false;
            }
            if (index!= 4)
            {
                confirmButton.Visible = false;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            if (index == 9)
            {
                if (DB.CheckIDNumberInSystem((existingGuestIDNumberTxtBx.Text)))
                {
                    MessageBox.Show("Guest has been found in system, proceed with booking.");
                    guest = new Guest();
                    guest.GuestID = existingGuestIDNumberTxtBx.Text;
                    creditCardPanel.BringToFront();
                    fakePreviousButton.Visible = false;
                    NextButton.Visible=false;
                    PreviousButton.Visible = true;
                    index = 5;
                    return;
                }
                MessageBox.Show("Guest does not exist in system, try again.");
                return;
            }
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

            string depositStatus = "Confirmed";

            Booking booking = new Booking(guest.GuestID, 1, checkInDatePicker.Value.Date.ToString(), checkOutDatePicker.Value.Date.ToString(), depositStatus);
            DB.InsertBooking(booking);
            
            // Display information of the newly-made reservation
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
            NextButton.Visible = false;
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
            NextButton.Visible = false;
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
            NextButton.Visible = false;
        }

        private void saveNewRoomIDButton_Click(object sender, EventArgs e)
        {
            string bookingID = changeBookingTextBox.Text;
            string roomID = newRoomIDTextBox.Text;
            DB.UpdateBookingRoomID(bookingID, roomID);
        }

        private void saveNewCheckInDate_Click(object sender, EventArgs e)
        {
            string bookingID = changeBookingTextBox.Text;
            string newCheckInDate = newCheckInDatePicker.Value.Date.ToString();
            DB.UpdateBookingCheckInDate(bookingID, newCheckInDate);
        }

        private void saveNewCheckOutDate_Click(object sender, EventArgs e)
        {
            string bookingID = changeBookingTextBox.Text;
            string newCheckOutDate = newCheckOutDatePicker.Value.Date.ToString();
            DB.UpdateBookingCheckOutDate(bookingID, newCheckOutDate);
        }

        private void existingGuestBtn_Click(object sender, EventArgs e)
        {
            existingGuestPanel.BringToFront();
            NextButton.Visible = true;
            fakePreviousButton.Visible = true;
            index = 9;
        }

        private void fakePreviousButton_Click(object sender, EventArgs e)
        {
            newGuestOrOldGuestPanel.BringToFront();
            NextButton.Visible = false;
            fakePreviousButton.Visible = false;
            index = 3;
        }

        private void makeEnquiryButton_Click(object sender, EventArgs e)
        {
            enquirePanel.BringToFront();
            NextButton.Visible = false;
            enquiryPreviousButton.Visible = true;

        }

        private void enquiryEnterBtn_Click(object sender, EventArgs e)
        {
            
            bookingEnquiryGridView.DataSource = DB.displayBookingInfo(bookingEnquiryTxtBx.Text);
            bookingEnquiryGridView.Visible = true;
            bookingInfoLabel.Visible = true;
        }

        private void enquiryPreviousButton_Click(object sender, EventArgs e)
        {
                homePanel.BringToFront();
                index = 0;
                enquiryPreviousButton.Visible = false;
  
        }
    }
}
