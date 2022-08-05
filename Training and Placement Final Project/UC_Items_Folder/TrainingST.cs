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
    public partial class TrainingST : UserControl
    {
        public TrainingST()
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
            {
                SetIDValue();
                if (TrainingTxtCoor.Text != "" && TrainingTxtAgencyName.Text != "" && TrainingComboType.SelectedIndex != -1 && (CivilCB.Checked || MechCB.Checked || CompCB.Checked || ItCB.Checked || ElectronCB.Checked || ElecCB.Checked || PapCB.Checked || AppMathCB.Checked || SciHumCB.Checked || PharCB.Checked || WorkSCB.Checked || ChemicalCB.Checked || AllCB.Checked) && TrainingDateStart.Value >= DateTime.Now.Date && TrainingDateEnd.Value >= DateTime.Now.Date && TotalAttendance.Text != "")
                {
                    WrongMessage.Visible = false;
                    String Coordinator = TrainingTxtCoor.Text;
                    String AgencyName = TrainingTxtAgencyName.Text;
                    String Type = TrainingComboType.Text;
                    String Branch = "";
                    if (CivilCB.Checked)
                    {
                        Branch = "Civil,";
                    }

                    if (MechCB.Checked)
                    {
                        Branch += "Mechanical,";
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
                        Branch += "Plastic & Polymer,";
                    }

                    if (AppMathCB.Checked)
                    {
                        Branch += "APPLIED MECHANICS,";
                    }

                    if (SciHumCB.Checked)
                    {
                        Branch += "SCIENCE & HUMANITIES,";
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
                    Cmd.Parameters.AddWithValue("@co", Coordinator);
                    Cmd.Parameters.AddWithValue("@An", AgencyName);
                    Cmd.Parameters.AddWithValue("@Tpe", Type);
                    Cmd.Parameters.AddWithValue("@Br", Branch.ToUpper());
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
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

        private void TrainBtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void TrainingST_Load(object sender, EventArgs e)
        {
            tabPage1_Click(this, e);
            tabPage2_Click(this,e);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (TrainingTxtLec.Text != "" && TxtOrganizedby.Text!="" && TrainingTxtOrgName.Text != "" && TrainingComboStafftrain.SelectedIndex != -1 && (CivilCB1.Checked || MechCB1.Checked || CompCB1.Checked || ItCB1.Checked || ElectronCB1.Checked || ElecCB1.Checked || PapCB1.Checked || AppMathCB1.Checked || SciHumCB1.Checked || PharCB1.Checked || WorkSCB1.Checked || ChemicalCB1.Checked ) && TrainingDateStart1.Value >= DateTime.Now.Date && TrainingDateEnd1.Value >= DateTime.Now.Date && TxtDuration.Text!="" )
                {
                    WrongMessage1.Visible = false;
                    String Lecturer = TrainingTxtLec.Text;
                    String OrgName = TrainingTxtOrgName.Text;
                    String OrganizedBy = TxtOrganizedby.Text;
                    String Type = TrainingComboStafftrain.Text;
                    String Branch = "";
                    if (CivilCB1.Checked)
                    {
                        Branch = "Civil";
                    }

                    if (MechCB1.Checked)
                    {
                        Branch += "Mechanical";
                    }

                    if (CompCB1.Checked)
                    {
                        Branch += "Computer";
                    }

                    if (ItCB1.Checked)
                    {
                        Branch += "Information Technology";
                    }

                    if (ElectronCB1.Checked)
                    {
                        Branch += "Electronics & Telecommunication";
                    }

                    if (ElecCB1.Checked)
                    {
                        Branch += "Electrical";
                    }

                    if (PapCB1.Checked)
                    {
                        Branch += "Plastic & Polymer";
                    }

                    if (AppMathCB1.Checked)
                    {
                        Branch += "APPLIED MECHANICS";
                    }

                    if (SciHumCB1.Checked)
                    {
                        Branch += "SCIENCE & HUMANITIES";
                    }

                    if (PharCB1.Checked)
                    {
                        Branch += "Pharmacy";
                    }

                    if (WorkSCB1.Checked)
                    {
                        Branch += "Workshop";
                    }

                    if (ChemicalCB1.Checked)
                    {
                        Branch += "Chemical";
                    }

                    String StartDate = TrainingDateStart1.Value.ToLongDateString();
                    String EndDate = TrainingDateEnd1.Value.ToLongDateString();
                    String Duration = TxtDuration.Text;
                    //MessageBox.Show(IndusName+"\n"+TestDate+"\n"+InterviewDate);


                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "insert into StaffTrainingTbl(Lecturer,Organization,Organized,Type,Branch,StartDate,DateEnd,Duration) values(@Lec,@ON,@OB,@Tpe,@Br,@St,@Ed,@Du)";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Lec", Lecturer);
                    Cmd.Parameters.AddWithValue("@ON", OrgName);
                    Cmd.Parameters.AddWithValue("@OB", OrganizedBy);
                    Cmd.Parameters.AddWithValue("@Tpe", Type);
                    Cmd.Parameters.AddWithValue("@Br", Branch.ToUpper());
                    Cmd.Parameters.AddWithValue("@St", StartDate);
                    Cmd.Parameters.AddWithValue("@Ed", EndDate);
                    Cmd.Parameters.AddWithValue("@Du", Duration);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll1();


                }
                else
                {
                    WrongMessage1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Int32 i = 0;
        private void TrainingDateEnd1_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fdate = TrainingDateStart1.Value;
                DateTime edate = TrainingDateEnd1.Value;

                if(fdate<edate && edate>fdate)
                {
                    Double diff2 = Double.Parse((edate - fdate).TotalDays.ToString());
                   // MessageBox.Show(diff2+"");
                    TxtDuration.Text = Math.Round(diff2).ToString()+" Days";
                }
                else
                {
                    //MessageBox.Show("Please Give the right dates...", "Wrong Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtDuration.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            TrainingDateStart1.Value = DateTime.Now;
            TrainingDateEnd1.Value = DateTime.Now;
            WrongMessage1.Visible = false;
        }

        public void ClearAll1()
        {
            try
            {

                TrainingTxtLec.Text = "";
                TxtOrganizedby.Text = "";
                TrainingTxtOrgName.Text = "";
                TrainingComboStafftrain.SelectedIndex = -1;
                CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                TrainingDateStart1.Value = DateTime.Now.Date;
                TrainingDateEnd1.Value = DateTime.Now.Date;
                TxtDuration.Text = "";
            }
            catch
            {

            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll1();
            }
            catch
            {

            }
        }

        private void CivilCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CivilCB1.Checked == true)
                {
                    MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch
            {

            }
        }

        private void MechCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (MechCB1.Checked == true)
                {
                    CivilCB1.Checked  = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled  = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch
            {

            }
        }

        private void CompCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CompCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked  = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled  = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void ItCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked  = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled  = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void ElectronCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ElectronCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked  = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled  = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch
            {

            }
        }

        private void ElecCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ElecCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked= PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void PapCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (PapCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void AppMathCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (AppMathCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled =  SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch
            {

            }
        }

        private void SciHumCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (SciHumCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked  = PharCB1.Checked = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void PharCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (PharCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked  = WorkSCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled  = WorkSCB1.Enabled = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled  = WorkSCB1.Enabled = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void WorkSCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (WorkSCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = ChemicalCB1.Checked = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled  = ChemicalCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled  = ChemicalCB1.Enabled = true;

                }
            }
            catch { }
        }

        private void ChemicalCB1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChemicalCB1.Checked == true)
                {
                    CivilCB1.Checked = MechCB1.Checked = CompCB1.Checked = ItCB1.Checked = ElectronCB1.Checked = ElecCB1.Checked = PapCB1.Checked = AppMathCB1.Checked = SciHumCB1.Checked = PharCB1.Checked = WorkSCB1.Checked  = false;
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = false;

                }
                else
                {
                    CivilCB1.Enabled = MechCB1.Enabled = CompCB1.Enabled = ItCB1.Enabled = ElectronCB1.Enabled = ElecCB1.Enabled = PapCB1.Enabled = AppMathCB1.Enabled = SciHumCB1.Enabled = PharCB1.Enabled = WorkSCB1.Enabled = true;

                }
            }
            catch { }
        }
    }
}
