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
    public partial class FrmUpdateMember : Form
    {
        public FrmUpdateMember()
        {
            InitializeComponent();
            classRegistrationQuery.IdSelect(cbStudID);
        }
        ClassRegistrationQuery classRegistrationQuery = new ClassRegistrationQuery();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            classRegistrationQuery.UpdateStudent(Convert.ToInt32(cbStudID.Text), txtFirstN.Text, txtMiddleN.Text, txtLastN.Text, Convert.ToInt32(txtAge.Text), cbGender.Text, cbProg.Text);
            FrmClubRegistration frmClubRegistration = new FrmClubRegistration();
            frmClubRegistration.RefreshListOfClubMembers();

            MessageBox.Show("Update Succesfully");

      
        }

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            classRegistrationQuery.AutoSearch(txtFirstN, txtMiddleN, txtLastN, txtAge, cbGender, cbProg, Convert.ToInt32(cbStudID.Text));
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
