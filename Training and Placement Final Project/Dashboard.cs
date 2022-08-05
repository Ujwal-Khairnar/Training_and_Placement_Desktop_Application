using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_and_Placement_Final_Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        String user = "";
        public Dashboard(String lg)
        {
            InitializeComponent();
            user = lg;
        }

        //this is used when the dashboard loads
        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {   if (user != "Admin")
                {
                    uC_Student1.Visible = false;
                    uC_Industry1.Visible = false;
                    DashbordTabOpenShower.Visible = false;
                    DashBtnHome.PerformClick();
                    uC_Arrange_Interview1.Visible = false;
                    trainingST1.Visible = false;
                    uC_Eligible_Students1.Visible = false;
                    uC_Shortlisted_Students1.Visible = false;
                    uC_Search_All1.Visible = false;
                    uC_Industry_Information1.Visible = false;
                    AddUserBtn.Visible = false;
                    uC_ADD_User1.Visible = false;
                    DashBordDeleteButton.Visible = true;

                }
                else
                {
                    studentForm1.Visible = false;
                    uC_Industry1.Visible = false;
                    DashbordTabOpenShower.Visible = false;
                    DashBtnHome.PerformClick();
                    uC_Arrange_Interview1.Visible = false;
                    uC_Training1.Visible = false;
                    uC_Eligible_Students1.Visible = false;
                    uC_Shortlisted_Students1.Visible = false;
                    uC_Search_All1.Visible = false;
                    uC_Industry_Information1.Visible = false;
                    deletePageAll1.Visible = true;
                    AddUserBtn.Visible = true;
                    uC_ADD_User1.Visible = false;
                    StudTabButton.Visible = false;
                    IndusTabButton.Visible = false;
                    DashBtnTrain.Visible = false;
                    DashBtnPlacement.Visible = false;
                    IndustryInfo.Left = AddUserBtn.Right;
                    SearchTabBtn.Left = IndustryInfo.Right;
                    ArrangeBtnTeItv.Visible = false;
                    DashBtnEligible.Visible = false;
                    DashBtnSortlist.Visible = false;
                    DashBordDeleteButton.Visible = false;
                }
            }
            catch { }
        }

        //this code is used when we click on student button
        private void StudTabButton_Click(object sender, EventArgs e)
        {
            try
            {
                studentForm1.Visible = true;
                studentForm1.BringToFront();
                DashbordTabOpenShower.Visible = true;
                DashbordTabOpenShower.Left = StudTabButton.Left;
            }
            catch { }
        }

        private void IndusTabButton_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Industry1.Visible = true;
                uC_Industry1.BringToFront();
                DashbordTabOpenShower.Visible = true;
                DashbordTabOpenShower.Left = IndusTabButton.Left;
            }
            catch { }
        }

        private void DashBtnTrain_Click(object sender, EventArgs e)
        {
            trainingST1.Visible = true;
            trainingST1.BringToFront();
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = DashBtnTrain.Left;
        }

        private void DashBtnPlacement_Click(object sender, EventArgs e)
        {
            uC_Placement1.Visible = true;
            uC_Placement1.BringToFront();
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = DashBtnPlacement.Left;
            uC_Placement1.SetComboData();
        }

        private void SearchTabBtn_Click_1(object sender, EventArgs e)
        {
            uC_Search_All1.Visible = true;
            uC_Search_All1.BringToFront();
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = SearchTabBtn.Left;
        }

        private void IndustryInfo_Click(object sender, EventArgs e)
        {
            uC_Industry_Information1.Visible = true;
            uC_Industry_Information1.BringToFront();
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = IndustryInfo.Left;
            uC_Industry_Information1.GetIndusData();
        }
        //this code is used when we click on close button
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show(this,"Do You Really want to close the Application","Asking",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch
            {

            }
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch
            {

            }
        }

        private void DashButtonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void DashBtnHome_Click(object sender, EventArgs e)
        {
            uC_Welcome1.Visible = true;
            uC_Welcome1.BringToFront();
        }

        private void ArrangeBtnTeItv_Click(object sender, EventArgs e)
        {
            uC_Arrange_Interview1.Visible = true;
            uC_Arrange_Interview1.BringToFront();
            uC_Arrange_Interview1.SetComboData();
        }

        private void DashBtnEligible_Click(object sender, EventArgs e)
        {
            uC_Eligible_Students1.Visible = true;
            uC_Eligible_Students1.BringToFront();
            uC_Eligible_Students1.SetComboData();
        }

        private void DashBtnSortlist_Click(object sender, EventArgs e)
        {
            uC_Shortlisted_Students1.Visible = true;
            uC_Shortlisted_Students1.BringToFront();
            uC_Shortlisted_Students1.SetComboData();
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            uC_ADD_User1.Visible = true;
            uC_ADD_User1.BringToFront();
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = AddUserBtn.Left;
        }

        private void uC_ADD_User1_Load(object sender, EventArgs e)
        {

        }

        private void DashBordDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                deletePageAll1.Visible = true;
                deletePageAll1.BringToFront();

            }
            catch { }
        }
    }
}
