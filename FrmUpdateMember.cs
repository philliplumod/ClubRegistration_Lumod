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
    public partial class FrmUpdateMember : Form
    {
        public FrmUpdateMember()
        {
            InitializeComponent();
            classRegistrationQuery.IdSelect(cbStudentID);
        }
        ClassRegistrationQuery classRegistrationQuery = new ClassRegistrationQuery();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            classRegistrationQuery.UpdateStudent(Convert.ToInt32(cbStudentID.Text), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, Convert.ToInt32(txtAge.Text), cbGender.Text, cbProgram.Text);
            FrmClubRegistration frmClubRegistration = new FrmClubRegistration();
            frmClubRegistration.RefreshListOfClubMembers();
        }

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            classRegistrationQuery.AutoSearch(txtFirstName, txtMiddleName, txtLastName, txtAge, cbGender, cbProgram, Convert.ToInt32(cbStudentID.Text));
        }
    }
}
