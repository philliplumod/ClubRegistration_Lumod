using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistrations
{
    public partial class FrmClubRegistration : Form
    {
        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private ClassRegistrationQuery clubRegistrationQuery = new ClassRegistrationQuery();
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new FrmUpdateMember().Show();
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstN.Text) || string.IsNullOrEmpty(txtMiddleN.Text) || string.IsNullOrEmpty(txtLastN.Text) || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(cbGender.Text) || string.IsNullOrEmpty(cbProg.Text))
            {
                MessageBox.Show("FIELDS MUST BE FILL");
            } else
            {
                ID = count;

                StudentID = Convert.ToInt32(txtStudID.Text);
                FirstName = txtFirstN.Text;
                MiddleName = txtMiddleN.Text;
                LastName = txtLastN.Text;

                Gender = cbGender.Text;
                Program = cbProg.Text;
                Age = Convert.ToInt32(txtAge.Text);

                clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);
                RegistrationID();

                MessageBox.Show("Register Successfuly");
            }

        }

        private long StudentID;

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            ClassRegistrationQuery classRegistrationQuery = new ClassRegistrationQuery();
            RefreshListOfClubMembers();
        }

       

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        public int RegistrationID()
        {
            count++;
            return count;
        }
    }
}
