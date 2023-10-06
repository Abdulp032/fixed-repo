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
            listPanel.Add(homePanel);
            listPanel.Add(reservationPanel);
            listPanel.Add(availableRoomsPanel);
            listPanel.Add(newGuestOrOldGuestPanel);
            listPanel[index].BringToFront();
            NextButton.Visible = false;
            PreviousButton.Visible = false;
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


    }
}
