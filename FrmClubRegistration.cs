using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration_Lumod
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ID = count;

            StudentID = Convert.ToInt32(txtStudentID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;

            Gender = cbGender.Text;
            Program = cbProgram.Text;
            Age = Convert.ToInt32(txtAge.Text);

            clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);
            RegistrationID();
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
