using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGameProject
{
    public partial class DevSettings : Form
    {

        //Database
        DBConnection Con = new DBConnection();

        public DevSettings()
        {
            InitializeComponent();
        }

        private void addCharBtn_Click(object sender, EventArgs e)
        {
            // Validate the input
            if (int.TryParse(addCharTb.Text, out int charNo))
            {
                // SQL query to insert the new character number
                string query = "INSERT INTO CharTbl (charNo) VALUES (@charNo)";

                try
                {
                    // Open the database connection
                    Con.Connection();
                    Con.Con.Open(); // Assuming Con.Con is a SqlConnection instance

                    using (SqlCommand command = new SqlCommand(query, Con.Con))
                    {
                        command.Parameters.AddWithValue("@charNo", charNo);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Character number added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    if (Con.Con != null && Con.Con.State == System.Data.ConnectionState.Open)
                    {
                        Con.Con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void DevSettings_Load(object sender, EventArgs e)
        {

        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            // Validate the input
            if (int.TryParse(addItemTb.Text, out int itemNo))
            {
                // SQL query to insert the new character number
                string query = "INSERT INTO CharTbl (itemNo) VALUES (@itemNo)";

                try
                {
                    // Open the database connection
                    Con.Connection();
                    Con.Con.Open(); // Assuming Con.Con is a SqlConnection instance

                    using (SqlCommand command = new SqlCommand(query, Con.Con))
                    {
                        command.Parameters.AddWithValue("@itemNo", itemNo);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Item number added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    if (Con.Con != null && Con.Con.State == System.Data.ConnectionState.Open)
                    {
                        Con.Con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }

        }

        private void resetItemBtn_Click(object sender, EventArgs e)
        {
            // SQL query to delete all rows in ItemTbl
            string query = "DELETE FROM ItemTbl";

            try
            {
                // Open the database connection
                Con.Connection();
                Con.Con.Open(); // Assuming Con.Con is a SqlConnection instance

                using (SqlCommand command = new SqlCommand(query, Con.Con))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} rows reset in ItemTbl.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (Con.Con != null && Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void resetCharBtn_Click(object sender, EventArgs e)
        {
            // SQL query to delete all rows except the first three
            string query = @"
        DELETE FROM CharTbl
        WHERE charID NOT IN (
            SELECT charID
            FROM CharTbl
            ORDER BY charID
            OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY
        )";

            try
            {
                // Open the database connection
                Con.Connection();
                Con.Con.Open(); // Assuming Con.Con is a SqlConnection instance

                using (SqlCommand command = new SqlCommand(query, Con.Con))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} rows removed, except for the first three rows.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (Con.Con != null && Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void debugBtn_Click(object sender, EventArgs e)
        {
            var resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
            foreach (System.Collections.DictionaryEntry resource in resourceSet)
            {
                Debug.WriteLine($"Resource: {resource.Key}");
            }
        }
    }
}
