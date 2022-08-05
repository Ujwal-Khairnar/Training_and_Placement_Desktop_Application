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
    public partial class UC_Placement : UserControl
    {
        public UC_Placement()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        private void UC_Placement_Load(object sender, EventArgs e)
        {
            PlacementYear.MaxDate = DateTime.Now.Date;
            PlacementYear.Format = DateTimePickerFormat.Custom;
            PlacementYear.CustomFormat = "yyyy";
            PlacementYear.ShowUpDown = true;
            PlaceDateTest.Value = DateTime.Now.Date;
            PlaceDateInterview.Value = DateTime.Now.Date;
            Placeonoff.Text = "";
            PlaceAppointDate.Value = DateTime.Now.Date;
            SetComboData();
            SetIDValue();
        }

        public void SetComboData()
        {
            PlacementIndustryCombo.Items.Clear();
            try
            {
                Query = "select Name from IndusTbl";
                DataSet Ds = Fn.GetData(Query);
                if (Ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    {
                        if (Ds.Tables[0].Rows[i][0].ToString() != "")
                        {
                            PlacementIndustryCombo.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
                        }
                    }
                }

            }
            catch { }
        }

        public void SetIDValue()
        {
            try
            {
                Query = "select * from PlacementTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'PlacementTbl\',reseed,0)";
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

        public void SetTableData(DataSet DS)
        {
            try
            {
                // MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
                PlacementDataGridView.Rows.Clear();
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    int j = PlacementDataGridView.Rows.Add();
                    PlacementDataGridView.Rows[j].Cells[0].Value = i + 1;
                    PlacementDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                    PlacementDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                    PlacementDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][2].ToString();
                    PlacementDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][3].ToString();
                    PlacementDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][4].ToString();
                }

            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void PlacementBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(PlacementYear.Text!="" && PlacementIndustryCombo.SelectedIndex!=-1 && PlacementComboBranch.SelectedIndex!=-1)
                {
                    String Branch = PlacementComboBranch.Text;
                    String Year = PlacementYear.Text;
                    String IndusName = PlacementIndustryCombo.Text;

                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "select IDCode,FullName,Branch,Year,IndusName from ShortlistTbl where Branch=@Br and Year=@Yr and IndusName=@IN ";
                    SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                    DA.SelectCommand.Parameters.AddWithValue("@Br", Branch);
                    DA.SelectCommand.Parameters.AddWithValue("@Yr", Year);
                    DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    Con.Close();
                    SetTableData(DS);
                }
            }
            catch
            {

            }
        }

        private void PlacementDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show("hello");
                String IndusName = PlacementDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                Con = Fn.Get_Connection();
                Con.Open();
                Query = "select * from ShortlistTbl where IndusName=@IN ";
                SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                Con.Close();
                Query = "select Test,Interview from ArrangeIntTbl where Name=@IN ";
                SqlDataAdapter er = new SqlDataAdapter(Query, Con);
                er.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                DataSet ds = new DataSet();
                er.Fill(ds);
                if (DS.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows.Count != 0)
                {
                    String DateOfTest = ds.Tables[0].Rows[0][0].ToString();
                    String DateOfInterview = ds.Tables[0].Rows[0][1].ToString();
                    PlaceTxtIdCode.Text = PlacementDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    PlaceTxtFullName.Text = PlacementDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    PlacementBranch.Text = PlacementDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    PlacementIndustryName.Text = PlacementDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                    PlaceDateTest.Value = Convert.ToDateTime(DateOfTest).Date;
                    PlaceDateInterview.Value = Convert.ToDateTime(DateOfInterview).Date;
                }
                else
                {
                   // MessageBox.Show("No data found");
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);

            }
        }

        public void ClearAll()
        {
            try
            {
                PlaceTxtIdCode.Text = "";
                PlaceTxtFullName.Text = "";
                PlacementBranch.Text = "";
                PlacementIndustryName.Text = "";
                PlaceDateTest.Value = DateTime.Now.Date;
                PlaceDateInterview.Value = DateTime.Now.Date;
                PlacePackage.Text = "";
                PlaceWebsite.Text = "";
                Placeonoff.SelectedIndex = -1;
                PlaceAppointDate.Value= DateTime.Now.Date;

            }
            catch { }
        }


        private void PlacementBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (PlaceTxtIdCode.Text != "" && PlaceTxtFullName.Text != "" && PlacementBranch.Text != "" && PlacementIndustryName.Text != "" && PlacePackage.Text != "" && PlaceWebsite.Text != "" && Placeonoff.Text != "" && PlaceAppointDate.Value >=PlaceDateInterview.Value )
                {
                    String IDCode = PlaceTxtIdCode.Text;
                    String FullName = PlaceTxtFullName.Text;
                    String Branch = PlacementBranch.Text;
                    String IndusName = PlacementIndustryName.Text;
                    String DOT = PlaceDateTest.Value.ToShortDateString();
                    String DOI = PlaceDateInterview.Value.ToShortDateString();
                    String Web = PlaceWebsite.Text;
                    String Package = PlacePackage.Text;
                    String OnOff = Placeonoff.Text;
                    String Appointment = PlaceAppointDate.Value.ToShortDateString();
                    String Year = PlacementYear.Text;
                    Con = Fn.Get_Connection();
                    Con.Open();
                    DataSet DS = new DataSet();

                    Query = "select * from PlacementTbl where IDCode=@ID and FullName=@FN and Branch=@BR and IndusName=@IN";
                    SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                    da.SelectCommand.Parameters.AddWithValue("@ID", IDCode);
                    da.SelectCommand.Parameters.AddWithValue("@FN", FullName);
                    da.SelectCommand.Parameters.AddWithValue("@BR", Branch);
                    da.SelectCommand.Parameters.AddWithValue("@IN", IndusName);
                    da.Fill(DS);

                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        Query = "insert into PlacementTbl(IDCode,FullName,Branch,IndusName,DOT,DOI,Website,Package,OnOffCampus,AppointmentDate,PassingYear) values(@ID,@FN,@BR,@IN,@DT,@DI,@Wb,@Pk,@Onof,@AD,@py)";
                        SqlCommand Cmd = new SqlCommand(Query, Con);
                        Cmd.Parameters.AddWithValue("@ID", IDCode);
                        Cmd.Parameters.AddWithValue("@FN", FullName);
                        Cmd.Parameters.AddWithValue("@BR", Branch);
                        Cmd.Parameters.AddWithValue("@IN", IndusName);
                        Cmd.Parameters.AddWithValue("@DT", DOT);
                        Cmd.Parameters.AddWithValue("@DI", DOI);
                        Cmd.Parameters.AddWithValue("@Wb", Web);
                        Cmd.Parameters.AddWithValue("@Pk", Package);
                        Cmd.Parameters.AddWithValue("@Onof", OnOff);
                        Cmd.Parameters.AddWithValue("@AD", Appointment);
                        Cmd.Parameters.AddWithValue("@py", Year);

                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The data you entered is already present...", "Insertion Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Con.Close();
                    
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Values...", "Value Error's", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void PlacementBtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void PlacementIndustryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Con = Fn.Get_Connection();
                Con.Open();
                String IndusName = PlacementIndustryName.Text;
                Query = "select Website from IndusTbl where Name=@IN";
                SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                PlaceWebsite.Text = DS.Tables[0].Rows[0][0].ToString();
                Con.Close();
            }
            catch { }
        }
    }
}
