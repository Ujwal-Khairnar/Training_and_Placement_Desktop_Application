using DGVPrinterHelper;
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
    public partial class UC_Search_All : UserControl
    {
        public UC_Search_All()
        {
            InitializeComponent();
        }
        String CheckDataGridView = "";
        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";
        private void UC_Search_All_Load(object sender, EventArgs e)
        {
            SearchTabOpenShower.Visible = false;
            SearchDPDateYear.MaxDate = DateTime.Now.Date;
            SearchDPDateYear.Format = DateTimePickerFormat.Custom;
            SearchDPDateYear.CustomFormat = "yyyy";
            SearchDPDateYear.ShowUpDown = true;
            ShortlistDataGridView.Visible = false;
            PlacementDataGrid.Visible = false;
            StudentDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            CheckDataGridView = "";
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;
            label8.Visible = false;
            SearchDPDateYear.Visible = false;
            SearchBtn.Visible = false;
            BranchLabel.Visible = false;
            SearchComboBranch.Visible = false;
            IndustryTxtName.Visible = false;
            SearchIndusCombo.Visible = false;
            TrainingDateStart.Value = DateTime.Now.Date;
            TrainingDateEnd.Value = DateTime.Now.Date;
        }

        private void ShortlistTabButton_Click(object sender, EventArgs e)
        {
            SearchTabOpenShower.Visible = true;
            SearchTabOpenShower.Left = ShortlistTabButton.Left;
            ShortlistDataGridView.Visible = true;
            PlacementDataGrid.Visible = false;
            StudentDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            BranchLabel.Visible = true;
            SearchComboBranch.Visible = true;
            CheckDataGridView = "Shortlist";
            IndustryTxtName.Text = "Industry Name";
            SetComboData();
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;
            label8.Visible = true;
            SearchDPDateYear.Visible = true;
            SearchBtn.Visible = true;
            IndustryTxtName.Visible = true;
            SearchIndusCombo.Visible = true;
        }

        private void PlacementTabBtn_Click(object sender, EventArgs e)
        {
            SearchTabOpenShower.Visible = true;
            SearchTabOpenShower.Left = PlacementTabBtn.Left;
            ShortlistDataGridView.Visible = false;
            PlacementDataGrid.Visible = true;
            StudentDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            CheckDataGridView = "Placement";
            IndustryTxtName.Text = "Industry Name";
            BranchLabel.Visible = true;
            SearchComboBranch.Visible = true;
            SetComboData();
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;
            label8.Visible = true;
            SearchDPDateYear.Visible = true;
            SearchBtn.Visible = true;
            IndustryTxtName.Visible = true;
            SearchIndusCombo.Visible = true;
        }

        private void TrainingTabBtn_Click(object sender, EventArgs e)
        {

            SearchTabOpenShower.Visible = true;
            SearchTabOpenShower.Left = TrainingTabBtn.Left;
            ShortlistDataGridView.Visible = false;
            PlacementDataGrid.Visible = false;
            StudentDataGridView.Visible = true;
            StaffDataGridView.Visible = false;
            CheckDataGridView = "Training";
            IndustryTxtName.Visible = false;
            SearchIndusCombo.Visible = false;
            BranchLabel.Visible = true;
            SearchComboBranch.Visible = true;
            label5.Visible = true;
            TrainingDateStart.Visible = true;
            label21.Visible = true;
            TrainingDateEnd.Visible = true;
            label8.Visible = false;
            SearchDPDateYear.Visible = false;
            SearchBtn.Visible = true;

        }

        private void StaffTrainBtn_Click(object sender, EventArgs e)
        {
            SearchTabOpenShower.Visible = true;
            SearchTabOpenShower.Left = StaffTrainBtn.Left;
            ShortlistDataGridView.Visible = false;
            PlacementDataGrid.Visible = false;
            StudentDataGridView.Visible = false;
            StaffDataGridView.Visible = true;
            CheckDataGridView = "Staff";
            IndustryTxtName.Visible = false;
            SearchIndusCombo.Visible = false;
            BranchLabel.Visible = true;
            SearchComboBranch.Visible = true;
            label5.Visible = true;
            TrainingDateStart.Visible = true;
            label21.Visible = true;
            TrainingDateEnd.Visible = true;
            label8.Visible = false;
            SearchDPDateYear.Visible = false;
            SearchBtn.Visible = true;
        }
        public void SetTableData(DataSet DS)
        {
            try
            {
                // MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
                ShortlistDataGridView.Rows.Clear();
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    int j = ShortlistDataGridView.Rows.Add();
                    ShortlistDataGridView.Rows[j].Cells[0].Value = i + 1;
                    ShortlistDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                    ShortlistDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                    ShortlistDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][2].ToString();
                    ShortlistDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][3].ToString();
                    ShortlistDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][4].ToString();
                }

            }
            catch 
            {
               // MessageBox.Show(ex.Message);
            }
        }

        public void SetTableDataPlace(DataSet DS)
        {
            try
            {
                // MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
                PlacementDataGrid.Rows.Clear();
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    int j = PlacementDataGrid.Rows.Add();
                    PlacementDataGrid.Rows[j].Cells[0].Value = i + 1;
                    PlacementDataGrid.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                    PlacementDataGrid.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                    PlacementDataGrid.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][2].ToString();
                    PlacementDataGrid.Rows[j].Cells[4].Value = SearchDPDateYear.Text;
                    PlacementDataGrid.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][3].ToString();
                    PlacementDataGrid.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][4].ToString();
                    PlacementDataGrid.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][5].ToString();
                    PlacementDataGrid.Rows[j].Cells[8].Value = DS.Tables[0].Rows[i][6].ToString();
                    PlacementDataGrid.Rows[j].Cells[9].Value = DS.Tables[0].Rows[i][7].ToString();
                    PlacementDataGrid.Rows[j].Cells[10].Value = DS.Tables[0].Rows[i][8].ToString();
                }

            }
            catch 
            {
                //MessageBox.Show(ex.Message+"Hello");
            }
        }


        public void SetTableDataTrain(DataSet DS)
        {
            try
            {
                // MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
                StudentDataGridView.Rows.Clear();
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    int j = StudentDataGridView.Rows.Add();
                    StudentDataGridView.Rows[j].Cells[0].Value = i + 1;
                    StudentDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                    StudentDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                    StudentDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][2].ToString();
                    StudentDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][3].ToString();
                    StudentDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][4].ToString();
                    StudentDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][5].ToString();
                    StudentDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][6].ToString();
                }

            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public void SetComboData()
        {
            SearchIndusCombo.Items.Clear();
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
                            SearchIndusCombo.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
                        }
                    }
                    SearchIndusCombo.Items.Add("--All--");
                }

            }
            catch { }
        }

        public void SetAgencyData()
        {
            SearchIndusCombo.Items.Clear();
            try
            {
                Query = "select AgencyName from TrainingTbl";
                DataSet Ds = Fn.GetData(Query);
                if (Ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    {
                        if (Ds.Tables[0].Rows[i][0].ToString() != "")
                        {
                            SearchIndusCombo.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
                        }
                    }
                    SearchIndusCombo.Items.Add("All");
                }

            }
            catch { }
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {   
                if (CheckDataGridView == "Shortlist")
                {
                    ShortlistDataGridView.Rows.Clear();
                    String Year = SearchDPDateYear.Text;
                    String Branch = SearchComboBranch.Text.Trim();
                    String IndusName = SearchIndusCombo.Text.Trim();

                    Con = Fn.Get_Connection();
                    Con.Open();
                    if (Branch != "--All--" && IndusName != "--All--")
                    {
                        Query = "select IDCode,FullName,Branch,Year,IndusName from ShortlistTbl where Branch=@Br and Year=@Yr and IndusName=@IN order by Branch asc ";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Br", Branch);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", Year);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        SetTableData(DS);
                        //MessageBox.Show("no all");
                    }

                    if(IndusName!="--All--" && Branch=="--All--")
                    {
                        Query = "select IDCode,FullName,Branch,Year,IndusName from ShortlistTbl where Year=@Yr and IndusName=@IN order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", Year);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        SetTableData(DS);
                        //MessageBox.Show("branch all");
                    }

                    if (IndusName == "--All--" && Branch == "--All--")
                    {
                        Query = "select IDCode,FullName,Branch,Year,IndusName from ShortlistTbl where Year=@Yr order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", Year);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        SetTableData(DS);
                       // MessageBox.Show("2all");
                    }
                    Con.Close();
                }

                if (CheckDataGridView == "Placement")
                {
                    PlacementDataGrid.Rows.Clear();
                    String Branch = SearchComboBranch.Text;
                    String Year = SearchDPDateYear.Text;
                    String IndusName = SearchIndusCombo.Text;
                    //MessageBox.Show("Hello");
                    Con = Fn.Get_Connection();
                    Con.Open();
                    if (Branch != "--All--" && IndusName != "--All--")
                    {
                        Query = "select IDCode,FullName,Branch,OnOffCampus,IndusName,Website,DOI,Package,AppointmentDate from PlacementTbl where Branch=@Br and IndusName=@IN and PassingYear=@Year order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Br", Branch);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DA.SelectCommand.Parameters.AddWithValue("@Year ", Year);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        //MessageBox.Show(DS.Tables[0].Rows.Count+"");
                       
                            if (DS.Tables[0].Rows.Count != 0)
                            {

                                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                {
                                    /* if (Convert.ToDateTime(DS.Tables[0].Rows[i][5].ToString()).Year.ToString() == Year && Convert.ToDateTime(DS.Tables[0].Rows[i][9].ToString()).Year.ToString() == Year)
                                     {*/
                                    SetTableDataPlace(DS);
                                    /*}*/
                                }
                            }
                        
                    }

                    if (IndusName != "--All--" && Branch == "--All--")
                    {
                        Query = "select IDCode,FullName,Branch,OnOffCampus,IndusName,Website,DOI,Package,AppointmentDate from PlacementTbl where IndusName=@IN and PassingYear=@Year order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DA.SelectCommand.Parameters.AddWithValue("@Year ", Year);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        //MessageBox.Show(DS.Tables[0].Rows.Count+"");
                      
                            if (DS.Tables[0].Rows.Count != 0)
                            {

                                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                {
                                    /* if (Convert.ToDateTime(DS.Tables[0].Rows[i][5].ToString()).Year.ToString() == Year && Convert.ToDateTime(DS.Tables[0].Rows[i][9].ToString()).Year.ToString() == Year)
                                     {*/
                                    SetTableDataPlace(DS);
                                    /*}*/
                                }
                            }
                        
                    }

                    if (IndusName == "--All--" && Branch == "--All--")
                    {
                        Query = "select IDCode,FullName,Branch,OnOffCampus,IndusName,Website,DOI,Package,AppointmentDate from PlacementTbl where PassingYear=@Year order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Year ", Year);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        //MessageBox.Show(DS.Tables[0].Rows.Count+"");
                        if (DS.Tables[0].Rows.Count != 0)
                        {

                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                /* if (Convert.ToDateTime(DS.Tables[0].Rows[i][5].ToString()).Year.ToString() == Year && Convert.ToDateTime(DS.Tables[0].Rows[i][9].ToString()).Year.ToString() == Year)
                                 {*/
                                SetTableDataPlace(DS);
                                /*}*/
                            }
                        }
                    }
                        Con.Close();
                        //SetTableData(DS);
                }

                if (CheckDataGridView == "Training")
                {
                    if (SearchComboBranch.Text.Trim() != "--All--")
                    {
                        StudentDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = SearchComboBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from TrainingTbl where Branch LIKE \'%" + Branch.Trim() + "%\' ";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            DateTime dsd = DateTime.Parse(DS.Tables[0].Rows[i][5].ToString());
                            DateTime ded = DateTime.Parse(DS.Tables[0].Rows[i][6].ToString());
                            //MessageBox.Show(startdate + "\n" + enddate + "\n" + dsd + "\n" + ded);
                            // MessageBox.Show("h1" );
                            if (dsd >= startdate && ded <= enddate)
                            {

                                int j = StudentDataGridView.Rows.Add();
                                StudentDataGridView.Rows[j].Cells[0].Value = i + 1;
                                StudentDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                                StudentDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                                StudentDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                                StudentDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                                StudentDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                                StudentDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                                StudentDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                            }
                            // MessageBox.Show("h2");
                        }
                        StudentDataGridView.ClearSelection();
                    }
                    else
                    {
                        StudentDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = SearchComboBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from TrainingTbl where Branch=@BR order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@BR", "ALL BRANCHES,");
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            DateTime dsd = DateTime.Parse(DS.Tables[0].Rows[i][5].ToString());
                            DateTime ded = DateTime.Parse(DS.Tables[0].Rows[i][6].ToString());
                            //MessageBox.Show(startdate + "\n" + enddate + "\n" + dsd + "\n" + ded);
                            if (dsd >= startdate && ded <= enddate)
                            {

                                int j = StudentDataGridView.Rows.Add();
                                StudentDataGridView.Rows[j].Cells[0].Value = i + 1;
                                StudentDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                                StudentDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                                StudentDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                                StudentDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                                StudentDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                                StudentDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                                StudentDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                            }
                        }
                        StudentDataGridView.ClearSelection();
                    }
                }

                if(CheckDataGridView == "Staff")
                {
                    //MessageBox.Show("hello");
                    if (SearchComboBranch.Text.Trim() != "--All--")
                    {
                        StaffDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = SearchComboBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from StaffTrainingTbl where Branch=@BR order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@BR", Branch);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        //MessageBox.Show(startdate + "\n" +DS.Tables[0].Rows.Count);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            DateTime dsd = DateTime.Parse(DS.Tables[0].Rows[i][6].ToString());
                            DateTime ded = DateTime.Parse(DS.Tables[0].Rows[i][7].ToString());
                            //MessageBox.Show(startdate + "\n" + enddate + "\n" + dsd + "\n" + ded);
                            if (dsd >= startdate && ded <= enddate)
                            {
                                int j = StaffDataGridView.Rows.Add();
                                StaffDataGridView.Rows[j].Cells[0].Value = i + 1;
                                StaffDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                                StaffDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                                StaffDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                                StaffDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                                StaffDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                                StaffDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                                StaffDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                                StaffDataGridView.Rows[j].Cells[8].Value = DS.Tables[0].Rows[i][8].ToString();
                            }
                        }
                        StaffDataGridView.ClearSelection();
                    }
                    else
                    {
                        StaffDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = SearchComboBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from StaffTrainingTbl order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        //MessageBox.Show(startdate + "\n" + enddate);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            DateTime dsd = DateTime.Parse(DS.Tables[0].Rows[i][6].ToString());
                            DateTime ded = DateTime.Parse(DS.Tables[0].Rows[i][7].ToString());
                            //MessageBox.Show(startdate + "\n" + enddate + "\n" + dsd + "\n" + ded);
                            if (dsd >= startdate && ded <= enddate)
                            {
                                int j = StaffDataGridView.Rows.Add();
                                StaffDataGridView.Rows[j].Cells[0].Value = i + 1;
                                StaffDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                                StaffDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                                StaffDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                                StaffDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                                StaffDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                                StaffDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                                StaffDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                                StaffDataGridView.Rows[j].Cells[8].Value = DS.Tables[0].Rows[i][8].ToString();
                            }
                        }
                        StaffDataGridView.ClearSelection();
                    }

                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message);
                    }
        }

       

        private void SearchAllResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SearchDPDateYear.ResetText();
                SearchIndusCombo.SelectedIndex = -1;
                SearchComboBranch.SelectedIndex = -1;
                if (CheckDataGridView == "Training")
                {
                    StudentDataGridView.Rows.Clear();
                }
                if (CheckDataGridView == "Placement")
                {
                    PlacementDataGrid.Rows.Clear();
                }
                if (CheckDataGridView == "Shortlist")
                {
                    ShortlistDataGridView.Rows.Clear();
                }
            }
            catch
            {
               
            }
        }

        private void SearchTabOpenShower_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlacementDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudBtnPrint_Click(object sender, EventArgs e)
        {
            if (CheckDataGridView == "Shortlist")
            {
                if (ShortlistDataGridView.Rows.Count != 0)
                {
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "Shortlisted Students List";
                    print.SubTitle = "for " + SearchIndusCombo.Text + " Company";
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = false;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "List of Shortlisted Students for " + SearchIndusCombo.Text + " Company";
                    print.FooterSpacing = 15;
                    print.PrintDataGridView(ShortlistDataGridView);
                }
                else
                {
                    MessageBox.Show("Table Doesn't contain any data...", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            if (CheckDataGridView == "Placement")
            {
                if (PlacementDataGrid.Rows.Count != 0)
                {
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "Placement Students List";
                    print.SubTitle = "for " + SearchIndusCombo.Text + " Company";
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "List of Placement Students for " + SearchIndusCombo.Text + " Company";
                    print.FooterSpacing = 15;
                    print.PrintDataGridView(PlacementDataGrid);
                }
                else
                {
                    MessageBox.Show("Table Doesn't contain any data...", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }

            if (CheckDataGridView == "Training")
            {
                if (StudentDataGridView.Rows.Count != 0)
                {
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "Training Students List";
                    print.SubTitle = "from " + TrainingDateStart.Value.ToLongDateString() + " to " + TrainingDateEnd.Value.ToLongDateString();
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "List of Training Students ";
                    print.FooterSpacing = 15;
                    print.PrintDataGridView(StudentDataGridView);
                }
                else
                {
                    MessageBox.Show("Table Doesn't contain any data...", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }

            if (CheckDataGridView == "Staff")
            {
                if (StaffDataGridView.Rows.Count != 0)
                {
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "Staff Training List";
                    print.SubTitle = "from " + TrainingDateStart.Value.ToLongDateString() + " to " + TrainingDateEnd.Value.ToLongDateString();
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "List of Staff Training ";
                    print.FooterSpacing = 15;
                    print.PrintDataGridView(StaffDataGridView);
                }
                else
                {
                    MessageBox.Show("Table Doesn't contain any data...", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
    }
}
