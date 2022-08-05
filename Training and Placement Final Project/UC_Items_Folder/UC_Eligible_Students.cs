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
    public partial class UC_Eligible_Students : UserControl
    {
        public UC_Eligible_Students()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        private void UC_Eligible_Students_Load(object sender, EventArgs e)
        {
            DateYearLabel.Text = DateTime.Now.Date.Year.ToString();
            SetComboData();
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

        public void SetIDValue()
        {
            try
            {
                Query = "select * from EligibleTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'EligibleTbl\',reseed,0)";
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
        public void ClearAll()
        {
            try
            {
                IndustryName.SelectedIndex = -1;
                Percentage.SelectedIndex = -1;
                Backlog.SelectedIndex = -1;
                EligibleComboBranch.SelectedIndex = -1;
                DateYearLabel.Text = DateTime.Now.Date.Year.ToString();
                EligibleDataGridView.Rows.Clear();
            }
            catch { }
        }

        private void UpControl_Click(object sender, EventArgs e)
        {
            Int32 year = Convert.ToInt32(DateYearLabel.Text);
            if (year != 1955)
            {
                Int32 DateYear = Int32.Parse(DateYearLabel.Text);
                Int32 Year = DateYear - 1;
                DateYearLabel.Text = Year.ToString();
            }
        }

        private void DownControl_Click(object sender, EventArgs e)
        {
            if (DateYearLabel.Text != DateTime.Now.Date.Year.ToString())
            {
                Int32 DateYear = Int32.Parse(DateYearLabel.Text);
                Int32 Year = DateYear + 1;
                DateYearLabel.Text = Year.ToString();
            }
        }

        public void SetTableData(DataSet DS)
        {
            EligibleDataGridView.Rows.Clear();
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                int j = EligibleDataGridView.Rows.Add();
                EligibleDataGridView.Rows[j].Cells[0].Value = i + 1;
                EligibleDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                EligibleDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                EligibleDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][4].ToString();
                EligibleDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][5].ToString();
            }
        }
        private void EligibleBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (IndustryName.Text != "" && Percentage.SelectedIndex != -1 && Backlog.SelectedIndex != -1 &&EligibleComboBranch.SelectedIndex!=-1 )
                {
                    String FPercent = "";
                    String Percent = Percentage.Text.Trim();
                    if (Percent == "Above 60%")
                    {
                        FPercent = "Yes";
                    }

                    if (Percent == "Below 60%")
                    {
                        FPercent = "No";
                    }

                    if (Percent == "None")
                    {
                        FPercent = "None";
                    }


                    String YeartoSearch = DateYearLabel.Text.Trim();
                    String Blog = Backlog.Text.Trim();
                    String FBlog = "";
                    if (Blog == "Yes")
                    {
                        FBlog = "Yes";
                    }

                    if (Blog == "No")
                    {
                        FBlog = "No";
                    }
                    if (Blog == "Both")
                    {
                        FBlog = "Both";
                    }

                    String Branch = EligibleComboBranch.Text.Trim();
                    
                    if((Blog=="Yes" || Blog=="No") && (FPercent=="Yes" || FPercent=="No") )
                    {
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Percentage=@Percent and Backlog=@Back and Year=@Yr and Branch=@Branch order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        if (Branch == "--All--")
                        {
                            Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Percentage=@Percent and Backlog=@Back and Year=@Yr order by Branch asc";
                            SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                            da.SelectCommand.Parameters.AddWithValue("@Percent", FPercent);
                            da.SelectCommand.Parameters.AddWithValue("@Back", Blog);
                            da.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            da.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                        else
                        {
                            DA.SelectCommand.Parameters.AddWithValue("@Percent", FPercent);
                            DA.SelectCommand.Parameters.AddWithValue("@Back", Blog);
                            DA.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            DA.SelectCommand.Parameters.AddWithValue("@Branch", Branch);
                            DA.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                        
                    }

                    if (FPercent == "None" && (Blog == "Yes" || Blog == "No") )
                    {
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Backlog=@Back and Year=@Yr and Branch=@Branch order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        if (Branch == "--All--")
                        {
                            Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Backlog=@Back and Year=@Yr order by Branch asc";
                            SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                            da.SelectCommand.Parameters.AddWithValue("@Back", Blog);
                            da.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            da.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                        else
                        {
                            DA.SelectCommand.Parameters.AddWithValue("@Back", Blog);
                            DA.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            DA.SelectCommand.Parameters.AddWithValue("@Branch", Branch);
                            DA.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                    }

                    if (FPercent == "None" && Blog == "Both" )
                    {
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Year=@Yr and Branch=@Branch order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        if (Branch == "--All--")
                        {
                            Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Year=@Yr order by Branch asc";
                            SqlDataAdapter ds = new SqlDataAdapter(Query, Con);
                            ds.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            ds.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                        else
                        {
                            DA.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            DA.SelectCommand.Parameters.AddWithValue("@Branch", Branch);
                            DA.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                    }
                
                    if((FPercent == "Yes" || FPercent == "No") && Blog=="Both" )
                    {
                        Con = Fn.Get_Connection();
                        Con.Open();
                        Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Percentage=@Percent and Year=@Yr and Branch=@Branch order by Branch asc";
                        SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                        DataSet DS = new DataSet();
                        if (Branch == "--All--")
                        {
                            Query = "select IDCode,FullName,Percentage,Backlog,Branch,Year from StudTbl where Percentage=@Percent and Year=@Yr order by Branch asc";
                            SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                            da.SelectCommand.Parameters.AddWithValue("@Percent", FPercent);
                            da.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            da.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                        else
                        {
                           
                            DA.SelectCommand.Parameters.AddWithValue("@Percent", FPercent);
                            DA.SelectCommand.Parameters.AddWithValue("@Yr", YeartoSearch);
                            DA.SelectCommand.Parameters.AddWithValue("@Branch", Branch);

                            DA.Fill(DS);
                            Con.Close();
                            SetTableData(DS);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct details to search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void EligibleBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (EligibleDataGridView.Rows.Count!=0)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    DataSet DS = new DataSet();
                    int count = 0;
                    for (int i = 0; i < EligibleDataGridView.Rows.Count; i++)
                    {
                        String IDCode = EligibleDataGridView.Rows[i].Cells[1].Value.ToString();
                        String FullName = EligibleDataGridView.Rows[i].Cells[2].Value.ToString();
                        String Branch = EligibleDataGridView.Rows[i].Cells[3].Value.ToString();
                        String Year = EligibleDataGridView.Rows[i].Cells[4].Value.ToString();
                        String IndusName = IndustryName.Text;

                        Query = "select * from EligibleTbl where IDCode=@id and FullName=@fn and Branch=@br and Year=@yr and IndusName=@in ";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@id", IDCode);
                        da.SelectCommand.Parameters.AddWithValue("@fn", FullName);
                        da.SelectCommand.Parameters.AddWithValue("@br", Branch);
                        da.SelectCommand.Parameters.AddWithValue("@yr", Year);
                        da.SelectCommand.Parameters.AddWithValue("@in", IndusName);
                        da.Fill(DS);
                        if (DS.Tables[0].Rows.Count==0)
                        {


                            Query = "insert into EligibleTbl(IDCode,FullName,Branch,Year,IndusName) values(@IC,@FN,@Br,@Yr,@IN)";
                            SqlCommand Cmd = new SqlCommand(Query, Con);
                            Cmd.Parameters.AddWithValue("@IC", IDCode);
                            Cmd.Parameters.AddWithValue("@FN", FullName);
                            Cmd.Parameters.AddWithValue("@Br", Branch);
                            Cmd.Parameters.AddWithValue("@Yr", Year);
                            Cmd.Parameters.AddWithValue("@IN", IndusName);
                            Cmd.ExecuteNonQuery();
                            count++;
                        }
                    }
                    Con.Close();
                    if(count>0)
                    {
                        MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Seems like Data alerady exist in Shortlist \n -- Data not inserted --", "Insertion problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Table doesn't contain any data", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
            }
        }

        private void EligibleBtnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void EligibleBtnPrint_Click(object sender, EventArgs e)
        {
            if (EligibleDataGridView.Rows.Count > 0)
            {
                Int64 year = Int64.Parse(DateYearLabel.Text) - 1;
                DGVPrinter print = new DGVPrinter();
                print.Title = "Eligible Students";
                print.SubTitle = "for " + IndustryName.Text + " Company " + year + " - " + DateYearLabel.Text;
                print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                print.PageNumbers = true;
                print.PageNumberInHeader = false;
                print.PorportionalColumns = false;
                print.HeaderCellAlignment = StringAlignment.Near;
                print.Footer = "List of Eligible Students for " + IndustryName.Text + " Company";
                print.FooterSpacing = 15;
                print.PrintDataGridView(EligibleDataGridView);
            }
            else
            {
                MessageBox.Show("Table Doesn't contain any data...","No data found",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }

       
    }
}
