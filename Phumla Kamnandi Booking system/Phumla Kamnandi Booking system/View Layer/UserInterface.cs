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
            listPanel.Add(placeholder);             // at index 5
            listPanel[index].BringToFront();
            NextButton.Visible = false;
            PreviousButton.Visible = false;

            //DB.UpdateBooking("none", 4, "08/10/2012", "09/10/2023", 300);

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            NextButton.Visible = true;
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
           
            Guest guest = new Guest(idNumTxtbx.Text,nameTxtBx.Text, surnameTxtBx.Text,phoneNumTxtBx.Text,emailTxtBx.Text,addressTxtBx.Text);
            DB.InsertGuest(guest);
            
        }
    }
}
