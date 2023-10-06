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
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel[index].BringToFront();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
            //MessageBox.Show(checkInDatePicker.Value.Date.ToString());
            if (index == 1)
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\abdul\\OneDrive\\Desktop\\infos project\\Phumla Kamnandi Booking system\\Phumla Kamnandi Booking system\\Database Layer\\Database.mdf\";Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RoomID as AvailableRooms FROM Rooms WHERE RoomID NOT IN(SELECT RoomID FROM Bookings WHERE CheckInDate >= @checkInDate AND CheckOutDate <= @checkOutDate)", con);
                cmd.Parameters.AddWithValue("@checkInDate", checkInDatePicker.Value.Date);
                cmd.Parameters.AddWithValue("@checkOutDate", checkOutDatePicker.Value.Date);
                //cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd = new SqlCommand("SELECT COUNT(RoomID) FROM Rooms WHERE RoomID NOT IN (    SELECT RoomID  FROM Bookings   WHERE CheckInDate >= @checkInDate AND CheckOutDate <= @checkOutDate);", con);
                cmd.Parameters.AddWithValue("@checkInDate", checkInDatePicker.Value.Date);
                cmd.Parameters.AddWithValue("@checkOutDate", checkOutDatePicker.Value.Date);
                availableRoomsLabel.Text = "There are " + ((int)cmd.ExecuteScalar()).ToString() + " rooms available.";
                con.Close();
                NextButton.Text = "Continue";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void availableRoomsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
