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
    public partial class DeletePageAll : UserControl
    {
        public DeletePageAll()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnclick == 1)
                {   if (StudBranch.Text.Trim() != "--All--")
                    {
                        StudentDataGrid.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select * from StudTbl where Year=@yr and Branch=@br order by Branch asc";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@yr", stuyear);
                        da.SelectCommand.Parameters.AddWithValue("@br", bran);
                        DataSet DS = new DataSet();
                        da.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = StudentDataGrid.Rows.Add();
                            StudentDataGrid.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            StudentDataGrid.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            StudentDataGrid.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            StudentDataGrid.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            StudentDataGrid.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            StudentDataGrid.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                            StudentDataGrid.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                        }
                        StudentDataGrid.ClearSelection();
                    }
                    else
                    {
                        StudentDataGrid.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select * from StudTbl where Year=@yr order by Branch asc";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@yr", stuyear);
                        DataSet DS = new DataSet();
                        da.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = StudentDataGrid.Rows.Add();
                            StudentDataGrid.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            StudentDataGrid.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            StudentDataGrid.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            StudentDataGrid.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            StudentDataGrid.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            StudentDataGrid.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                            StudentDataGrid.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                        }
                        StudentDataGrid.ClearSelection();
                    }
                }

                if(btnclick==2)
                {
                    if (StudBranch.Text.Trim() != "--All--")
                    {
                        EligibleDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from EligibleTbl where Year=@yr and Branch=@br and IndusName=@IN order by Branch asc";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@yr", stuyear);
                        da.SelectCommand.Parameters.AddWithValue("@br", bran);
                        da.SelectCommand.Parameters.AddWithValue("@IN", IndusName);
                        DataSet DS = new DataSet();
                        da.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = EligibleDataGridView.Rows.Add();
                            EligibleDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            EligibleDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            EligibleDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            EligibleDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            EligibleDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            EligibleDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                        }
                        EligibleDataGridView.ClearSelection();
                    }
                    else
                    {

                        EligibleDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from EligibleTbl where Year=@yr and IndusName=@IN order by Branch asc";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@yr", stuyear);
                        da.SelectCommand.Parameters.AddWithValue("@IN", IndusName);
                        DataSet DS = new DataSet();
                        da.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = EligibleDataGridView.Rows.Add();
                            EligibleDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            EligibleDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            EligibleDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            EligibleDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            EligibleDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            EligibleDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                        }
                        EligibleDataGridView.ClearSelection();
                    }
                }
              
                if (btnclick==3)
                {
                    if (StudBranch.Text.Trim() != "--All--")
                    {
                        ShortlistDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from ShortlistTbl where Year=@Yr and Branch=@Br and IndusName=@IN order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", stuyear);
                        DA.SelectCommand.Parameters.AddWithValue("@Br", bran);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = ShortlistDataGridView.Rows.Add();
                            ShortlistDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            ShortlistDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            ShortlistDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            ShortlistDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            ShortlistDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            ShortlistDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();

                        }

                        ShortlistDataGridView.ClearSelection();
                    }
                    else
                    {
                        ShortlistDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from ShortlistTbl where Year=@Yr and IndusName=@IN order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", stuyear);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = ShortlistDataGridView.Rows.Add();
                            ShortlistDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            ShortlistDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            ShortlistDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            ShortlistDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            ShortlistDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            ShortlistDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();

                        }

                        ShortlistDataGridView.ClearSelection();
                    }
                }

                if(btnclick==4)
                {
                    if (StudBranch.Text.Trim() != "--All--")
                    {
                        PlacementDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from PlacementTbl where PassingYear=@Yr and Branch=@Br and IndusName=@IN order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", stuyear);
                        DA.SelectCommand.Parameters.AddWithValue("@Br", bran);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = PlacementDataGridView.Rows.Add();
                            PlacementDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            PlacementDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            PlacementDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            PlacementDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            PlacementDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            PlacementDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                            PlacementDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                            PlacementDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                            PlacementDataGridView.Rows[j].Cells[8].Value = DS.Tables[0].Rows[i][8].ToString();
                            PlacementDataGridView.Rows[j].Cells[9].Value = DS.Tables[0].Rows[i][9].ToString();
                            PlacementDataGridView.Rows[j].Cells[10].Value = DS.Tables[0].Rows[i][10].ToString();
                            PlacementDataGridView.Rows[j].Cells[11].Value = DS.Tables[0].Rows[i][11].ToString();
                        }
                        PlacementDataGridView.ClearSelection();
                    }
                    else
                    {
                        PlacementDataGridView.Rows.Clear();
                        String stuyear = StudDateYear.Value.Year.ToString();
                        String bran = StudBranch.Text;
                        String IndusName = IndustryName.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from PlacementTbl where PassingYear=@Yr and IndusName=@IN order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@Yr", stuyear);
                        DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            int j = PlacementDataGridView.Rows.Add();
                            PlacementDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
                            PlacementDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][1].ToString();
                            PlacementDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][2].ToString();
                            PlacementDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][3].ToString();
                            PlacementDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][4].ToString();
                            PlacementDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][5].ToString();
                            PlacementDataGridView.Rows[j].Cells[6].Value = DS.Tables[0].Rows[i][6].ToString();
                            PlacementDataGridView.Rows[j].Cells[7].Value = DS.Tables[0].Rows[i][7].ToString();
                            PlacementDataGridView.Rows[j].Cells[8].Value = DS.Tables[0].Rows[i][8].ToString();
                            PlacementDataGridView.Rows[j].Cells[9].Value = DS.Tables[0].Rows[i][9].ToString();
                            PlacementDataGridView.Rows[j].Cells[10].Value = DS.Tables[0].Rows[i][10].ToString();
                            PlacementDataGridView.Rows[j].Cells[11].Value = DS.Tables[0].Rows[i][11].ToString();
                        }
                        PlacementDataGridView.ClearSelection();
                    }
                }

                if (btnclick == 5)
                {
                    if (StudBranch.Text.Trim() != "--All--")
                    {
                        StaffDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = StudBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from StaffTrainingTbl where Branch=@BR order by Branch";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DA.SelectCommand.Parameters.AddWithValue("@BR", Branch);
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
                                StaffDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
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
                        String Branch = StudBranch.Text;
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
                                StaffDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
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

                if (btnclick == 6)
                {
                    if (StudBranch.Text.Trim() != "--All--")
                    {
                        StudentDataGridView.Rows.Clear();
                        DateTime startdate = DateTime.Parse(TrainingDateStart.Value.ToLongDateString());
                        DateTime enddate = DateTime.Parse(TrainingDateEnd.Value.ToLongDateString());
                        String Branch = StudBranch.Text;
                        Con = Fn.Get_Connection();
                        Query = "select * from TrainingTbl where Branch LIKE \'%"+Branch.Trim()+"%\' ";
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
                                StudentDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
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
                        String Branch = StudBranch.Text;
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
                                StudentDataGridView.Rows[j].Cells[0].Value = DS.Tables[0].Rows[i][0].ToString();
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        int btnclick = 0;
        private void StudentBtn_Click(object sender, EventArgs e)
        {
            
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = StudentBtn.Left;
            StudentDataGrid.Visible = true;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = false;
            btnclick = 1;
            IndustryName.Visible = false;
            label6.Visible = false;
            label12.Visible = true;
            StudDateYear.Visible = true;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;

        }

        private void EligibleBtn_Click(object sender, EventArgs e)
        {
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = EligibleBtn.Left;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = true;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = false;
            btnclick = 2;
            IndustryName.Visible = true;
            label6.Visible = true;
            label12.Visible = true;
            StudDateYear.Visible = true;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;

        }

        private void ShortlistBtn_Click(object sender, EventArgs e)
        {
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = ShortlistBtn.Left;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = true;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = false;
            btnclick = 3;
            IndustryName.Visible = true;
            label6.Visible = true;
            label12.Visible = true;
            StudDateYear.Visible = true;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;

        }

        private void PlacementBtn_Click(object sender, EventArgs e)
        {
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = PlacementBtn.Left;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = true;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = false;
            btnclick = 4;
            IndustryName.Visible = true;
            label6.Visible = true;
            label12.Visible = true;
            StudDateYear.Visible = true;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;

        }

    
        private void TrainingBtn_Click(object sender, EventArgs e)
        {
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = StaffTrainingBtn.Left;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = true;
            StudentDataGridView.Visible = false;
            btnclick = 5;
            IndustryName.Visible = false;
            label6.Visible = false;
            label12.Visible = false;
            StudDateYear.Visible = false;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = true;
            TrainingDateStart.Visible = true;
            label21.Visible = true;
            TrainingDateEnd.Visible = true;
        }

        private void StudentTrainBtn_Click(object sender, EventArgs e)
        {
            DashbordTabOpenShower.Visible = true;
            DashbordTabOpenShower.Left = StudentTrainBtn.Left;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = true;
            btnclick = 6;
            IndustryName.Visible = false;
            label6.Visible = false;
            label12.Visible = false;
            StudDateYear.Visible = false;
            label13.Visible = true;
            StudBranch.Visible = true;
            SearchBtn.Visible = true;
            label5.Visible = true;
            TrainingDateStart.Visible = true;
            label21.Visible = true;
            TrainingDateEnd.Visible = true;
        }
        private void DeletePageAll_Load(object sender, EventArgs e)
        {
            StudDateYear.MaxDate = DateTime.Now.Date;
            StudDateYear.Format = DateTimePickerFormat.Custom;
            StudDateYear.CustomFormat = "yyyy";
            StudDateYear.ShowUpDown = true;
            DashbordTabOpenShower.Visible = false;
            StudentDataGrid.Visible = false;
            EligibleDataGridView.Visible = false;
            ShortlistDataGridView.Visible = false;
            PlacementDataGridView.Visible = false;
            StaffDataGridView.Visible = false;
            StudentDataGridView.Visible = false;
            SetComboData();
            IndustryName.Visible = false;
            label6.Visible = false;
            label12.Visible = false;
            StudDateYear.Visible = false;
            label13.Visible = false;
            StudBranch.Visible = false;
            SearchBtn.Visible = false;
            label5.Visible = false;
            TrainingDateStart.Visible = false;
            label21.Visible = false;
            TrainingDateEnd.Visible = false;
            TrainingDateStart.Value = DateTime.Now.Date;
            TrainingDateEnd.Value = DateTime.Now.Date;
        }

        public void SetComboData()
        {
            IndustryName.Items.Clear();
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
                            IndustryName.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
                        }
                    }
                }

            }
            catch { }
        } 

        int idofstudent = 0;
       

        private void StudBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (idofstudent!=0 && btnclick==1)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from StudTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    StudentDataGrid.ClearSelection();
                    idofstudent = 0;
                }

                if (idofstudent != 0 && btnclick == 2)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from EligibleTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    EligibleDataGridView.ClearSelection();
                    idofstudent = 0;
                }
                
                if (idofstudent != 0 && btnclick == 3)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from ShortlistTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    ShortlistDataGridView.ClearSelection();
                    idofstudent = 0;
                }

                if (idofstudent != 0 && btnclick == 4)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from PlacementTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    PlacementDataGridView.ClearSelection();
                    idofstudent = 0;
                }

                if (idofstudent != 0 && btnclick == 5)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from StaffTrainingTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    StaffDataGridView.ClearSelection();
                    idofstudent = 0;
                }

                if (idofstudent != 0 && btnclick == 6)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from TrainingTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchBtn.PerformClick();
                    StudentDataGridView.ClearSelection();
                    idofstudent = 0;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StudentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 1)
                    idofstudent = Int32.Parse(StudentDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            catch { }
        }

        private void EligibleDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 2)
                    idofstudent = Int32.Parse(EligibleDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            catch { }
        }

      
        private void ShortlistDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 3)
                    idofstudent = Int32.Parse(ShortlistDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(idofstudent+"");

            }
            catch { }
        }

        private void PlacementDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 4)
                    idofstudent = Int32.Parse(PlacementDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(idofstudent+"");
                
            }
            catch { }
        }

        private void StaffDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 5)
                    idofstudent = Int32.Parse(StaffDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(idofstudent+"");

            }
            catch { }
        }

        private void StudentTrainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnclick == 6)
                    idofstudent = Int32.Parse(StudentDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(idofstudent+"");

            }
            catch { }
        }
    }
}
