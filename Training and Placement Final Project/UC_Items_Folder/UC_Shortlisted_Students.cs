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
    public partial class UC_Shortlisted_Students : UserControl
    {
        public UC_Shortlisted_Students()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        private void UC_Shortlisted_Students_Load(object sender, EventArgs e)
        {
            ShortlistYear.MaxDate = DateTime.Now.Date;
            ShortlistYear.Format = DateTimePickerFormat.Custom;
            ShortlistYear.CustomFormat = "yyyy";
            ShortlistYear.ShowUpDown = true;
            ShortlistDataGridView.Rows.Clear();
            SetComboData();
            SetIDValue();
        }

        public void SetComboData()
        {
            ShortlistIndustryCombo.Items.Clear();
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
                            ShortlistIndustryCombo.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
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
                Query = "select * from ShortlistTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'ShortlistTbl\',reseed,0)";
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
                ShortlistIndustryCombo.SelectedIndex = -1;
                ShortlistYear.Value = DateTime.Now.Date;
                ShortlistedComboBranch.SelectedIndex = -1;
                ShortlistDataGridView.Rows.Clear();
            }
            catch { }
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
                    ShortlistDataGridView.Rows[j].Cells[0].Value = i+1;
                    ShortlistDataGridView.Rows[j].Cells[1].Value = DS.Tables[0].Rows[i][0].ToString();
                    ShortlistDataGridView.Rows[j].Cells[2].Value = DS.Tables[0].Rows[i][1].ToString();
                    ShortlistDataGridView.Rows[j].Cells[3].Value = DS.Tables[0].Rows[i][2].ToString();
                    ShortlistDataGridView.Rows[j].Cells[4].Value = DS.Tables[0].Rows[i][3].ToString();
                    ShortlistDataGridView.Rows[j].Cells[5].Value = DS.Tables[0].Rows[i][4].ToString();
                }
               
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void ShortlistBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (ShortlistYear.Text != "" && ShortlistIndustryCombo.SelectedIndex != -1 && ShortlistedComboBranch.SelectedIndex != -1)
                {
                    String Branch = ShortlistedComboBranch.Text;
                    String Year = ShortlistYear.Text;
                    String IndusName = ShortlistIndustryCombo.Text;

                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "select IDCode,FullName,Branch,Year,IndusName from EligibleTbl where Branch=@Br and Year=@Yr and IndusName=@IN order by Branch";
                    SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                    DA.SelectCommand.Parameters.AddWithValue("@Br", Branch);
                    DA.SelectCommand.Parameters.AddWithValue("@Yr", Year);
                    DA.SelectCommand.Parameters.AddWithValue("@IN ", IndusName);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    Con.Close();
                    SetTableData(DS);
                }
                else
                {
                    MessageBox.Show("Please enter correct details to search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
        }

        private void StudBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShortlistDataGridView.Rows.Count != 0)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    DataSet DS = new DataSet();
                    int count = 0;
                    for (int i = 0; i < ShortlistDataGridView.Rows.Count; i++)
                    {
                       
                            String Sl = Convert.ToString(ShortlistDataGridView.Rows[i].Cells[6].Value);
                            if (Sl == "True")
                            {
                                String IDCode = ShortlistDataGridView.Rows[i].Cells[1].Value.ToString();
                                String FullName = ShortlistDataGridView.Rows[i].Cells[2].Value.ToString();
                                String Branch = ShortlistDataGridView.Rows[i].Cells[3].Value.ToString();
                                String Year = ShortlistDataGridView.Rows[i].Cells[4].Value.ToString();
                                String IndusName = ShortlistDataGridView.Rows[i].Cells[5].Value.ToString();

                                Query = "select * from ShortlistTbl where IDCode=@id and FullName=@fn and Branch=@br and Year=@yr and IndusName=@in ";
                                SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                                da.SelectCommand.Parameters.AddWithValue("@id", IDCode);
                                da.SelectCommand.Parameters.AddWithValue("@fn", FullName);
                                da.SelectCommand.Parameters.AddWithValue("@br", Branch);
                                da.SelectCommand.Parameters.AddWithValue("@yr", Year);
                                da.SelectCommand.Parameters.AddWithValue("@in", IndusName);
                                da.Fill(DS);

                                if (DS.Tables[0].Rows.Count == 0)
                                {
                                    Query = "insert into ShortlistTbl(IDCode,FullName,Branch,Year,IndusName) values(@IC,@FN,@Br,@Yr,@IN)";
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
                    }
                    Con.Close();
                    if (count > 0)
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
            catch { }
        }
    }
}
