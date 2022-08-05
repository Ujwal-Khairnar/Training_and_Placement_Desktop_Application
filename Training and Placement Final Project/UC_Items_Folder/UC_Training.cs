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

namespace Training_and_Placement_Final_Project.UC_Items_Folder
{
    public partial class UC_Training : UserControl
    {
        public UC_Training()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con;
        String Query = "";

        public void ClearAll()
        {
            try
            {
                TrainingTxtCoor.Text = "";
                TrainingTxtAgencyName.Text = "";
                TrainingComboType.SelectedIndex = -1;
                CivilCB.Checked = MechCB.Checked = CompCB.Checked = ItCB.Checked = ElectronCB.Checked = ElecCB.Checked = PapCB.Checked = AppMathCB.Checked = SciHumCB.Checked = PharCB.Checked = WorkSCB.Checked = ChemicalCB.Checked = AllCB.Checked = false;
                TrainingDateStart.Value = DateTime.Now.Date;
                TrainingDateEnd.Value = DateTime.Now.Date;
                TotalAttendance.Text = "";
               
            }
            catch { }
        }

        public void SetIDValue()
        {
            try
            {
                Query = "select * from TrainingTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'TrainingTbl\',reseed,0)";
                    Con = Fn.Get_Connection();
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                }
            }
            catch
            {

            }
        }
        private void TrainBtnAdd_Click(object sender, EventArgs e)
        {
            try
            { SetIDValue();
                if (TrainingTxtCoor.Text != "" && TrainingTxtAgencyName.Text != "" && TrainingComboType.SelectedIndex != -1 && (CivilCB.Checked || MechCB.Checked || CompCB.Checked || ItCB.Checked || ElectronCB.Checked || ElecCB.Checked || PapCB.Checked || AppMathCB.Checked || SciHumCB.Checked || PharCB.Checked || WorkSCB.Checked || ChemicalCB.Checked || AllCB.Checked) && TrainingDateStart.Value>=DateTime.Now.Date && TrainingDateEnd.Value>=DateTime.Now.Date && TotalAttendance.Text!="")
                {
                    WrongMessage.Visible = false;
                    String Coordinator = TrainingTxtCoor.Text;
                    String AgencyName = TrainingTxtAgencyName.Text;
                    String Type = TrainingComboType.Text;
                    String Branch = "";
                    if(CivilCB.Checked)
                    {
                        Branch = "Civil,";
                    }
                    
                    if(MechCB.Checked)
                    {
                        Branch +="Mechanical,";
                    }

                    if (CompCB.Checked)
                    {
                        Branch += "Computer,";
                    }
                    
                    if (ItCB.Checked)
                    {
                        Branch += "Information Technology,";
                    }
                   
                    if (ElectronCB.Checked)
                    {
                        Branch += "Electronics & Telecommunication,";
                    }
                    
                    if (ElecCB.Checked)
                    {
                        Branch += "Electrical,";
                    }
                    
                    if (PapCB.Checked)
                    {
                        Branch += "Plastic and Polymer,";
                    }
                    
                    if (AppMathCB.Checked)
                    {
                        Branch += "Applied Mathematics,";
                    }
                    
                    if (SciHumCB.Checked)
                    {
                        Branch += "Science and Human,";
                    }
                    
                    if (PharCB.Checked)
                    {
                        Branch += "Pharmacy,";
                    }
                    
                    if (WorkSCB.Checked)
                    {
                        Branch += "Workshop,";
                    }
                    
                    if (ChemicalCB.Checked)
                    {
                        Branch += "Chemical,";
                    }
                    
                    if (AllCB.Checked)
                    {
                        Branch += "All Branches,";
                    }
                    
                    String StartDate = TrainingDateStart.Value.ToLongDateString();
                    String EndDate = TrainingDateEnd.Value.ToLongDateString();
                    String TotalAtte = TotalAttendance.Text;
                    //MessageBox.Show(IndusName+"\n"+TestDate+"\n"+InterviewDate);


                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "insert into TrainingTbl(Coordinator,AgencyName,Type,Branch,StartDate,DateEnd,Total) values(@co,@An,@Tpe,@Br,@St,@Ed,@Tol)";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@co",Coordinator);
                    Cmd.Parameters.AddWithValue("@An", AgencyName);
                    Cmd.Parameters.AddWithValue("@Tpe", Type);
                    Cmd.Parameters.AddWithValue("@Br", Branch);
                    Cmd.Parameters.AddWithValue("@St", StartDate);
                    Cmd.Parameters.AddWithValue("@Ed", EndDate);
                    Cmd.Parameters.AddWithValue("@Tol", TotalAtte);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                   

                }
                else
                {
                    WrongMessage.Visible = true;
                }
            
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void UC_Training_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDateStart.Value = DateTime.Now.Date;
                TrainingDateEnd.Value = DateTime.Now.Date;
                WrongMessage.Visible = false;
                //SearchTabOpenShower.Visible = false;
            }
            catch { }
        }

        bool check;
        private void AllCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (AllCB.Checked == true)
                {
                    CivilCB.Checked = MechCB.Checked = CompCB.Checked = ItCB.Checked = ElectronCB.Checked = ElecCB.Checked = PapCB.Checked = AppMathCB.Checked = SciHumCB.Checked = PharCB.Checked = WorkSCB.Checked = ChemicalCB.Checked = false;
                    CivilCB.Enabled = MechCB.Enabled = CompCB.Enabled = ItCB.Enabled = ElectronCB.Enabled = ElecCB.Enabled = PapCB.Enabled = AppMathCB.Enabled = SciHumCB.Enabled = PharCB.Enabled = WorkSCB.Enabled = ChemicalCB.Enabled = false;

                }
                else
                {
                    CivilCB.Enabled = MechCB.Enabled = CompCB.Enabled = ItCB.Enabled = ElectronCB.Enabled = ElecCB.Enabled = PapCB.Enabled = AppMathCB.Enabled = SciHumCB.Enabled = PharCB.Enabled = WorkSCB.Enabled = ChemicalCB.Enabled = true;

                }
            }
            catch { }
        }

        private void TrainingStudTabButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                //SearchTabOpenShower.Visible = true;
                //SearchTabOpenShower.Left = TrainingStudTabButton.Left;
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrainBtnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
