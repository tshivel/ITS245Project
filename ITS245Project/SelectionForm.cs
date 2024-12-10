using HealthcareForms;
using ITS245Project;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectV2
{
    public partial class SelectionForm : Form
    {
        private int ScreenMode = 0; // 1 = Modify, 2 = Add
        MySqlConnection conn;
        DataTable dt;
        int pid;
        string fullName;
        int age;
        DateTime bday;
        DateTime today = DateTime.Now;
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            LoadGridView();

        }

        private void LoadGridView()
        {
            try
            {
                using (var connection = Tools.DatabaseTools.MakeConnection())
                {
                    DataTable dt = Tools.DatabaseTools.GetAllPatientsUsingSP(connection);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No records found.");
                        return;
                    }

                    // Bind to DataGridView
                    dataGridView1.DataSource = dt;

                    // Hide unnecessary columns
                    if (dataGridView1.Columns.Contains("PatientID"))
                    {
                        dataGridView1.Columns["PatientID"].Visible = false;
                    }

                    // Ensure DataGridView is read-only
                    //dataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error binding DataGridView: {ex.Message}\n{ex.StackTrace}");
            }
        }

   

    

      

        //private void btnViewDemographics_Click(object sender, EventArgs e)
        //{
        //    DemographicsForm demo = new DemographicsForm(pid, fullName, age);
        //    demo.Show();
        //}

        private void btnGetPatientList_Click(object sender, EventArgs e)
        {
            
            LoadGridView();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                pid = Convert.ToInt32(dataGridView1[0, rowIndex].Value);
                //MessageBox.Show("You selected Patient ID: "+ pid);

                string firstName = Convert.ToString(dataGridView1[2, rowIndex].Value);
                string lastName = Convert.ToString(dataGridView1[1, rowIndex].Value);
                fullName = ("" + firstName + " " + lastName);
                //MessageBox.Show("You selected " + fullName);

                bday = Convert.ToDateTime(dataGridView1[3, rowIndex].Value);
                TimeSpan timeDifference = today - bday;

                age = Convert.ToInt32(timeDifference.Days / 365);
                MessageBox.Show("You selected Patient ID: " + pid +
                    "\n" + fullName + "\n" + age + " years old");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GeneralHistoryForm generalHistoryForm = new GeneralHistoryForm(pid, fullName, age);
            generalHistoryForm.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current SelectionForm
        }

        private void btnViewDemographics_Click(object sender, EventArgs e)
        {
            DemographicsForm demographicsForm = new DemographicsForm(pid, fullName, age);
            demographicsForm.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current SelectionForm
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Allergies allergies = new Allergies(pid, fullName, age);
            allergies.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current SelectionForm
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FamilyHistoryForm familyHistoryForm = new FamilyHistoryForm(pid, fullName, age);
            familyHistoryForm.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current SelectionForm
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medication medication = new Medication(pid, fullName, age);
            medication.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current SelectionForm
        }
    }
}
