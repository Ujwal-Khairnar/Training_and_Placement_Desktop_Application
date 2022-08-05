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
    public partial class UC_Student : UserControl
    {
        public UC_Student()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";
        private void UC_Student_Load(object sender, EventArgs e)
        {
            try
            {
                //this is uded to set year of datetimepicker
                //{
                DateYearLabel.Text = DateTime.Now.Date.Year.ToString();
                WrongMessage.Visible = false;
                SetDataGridView();
                SetIDValue();
                StudDateYear.MaxDate = DateTime.Now.Date;
                StudDateYear.Format = DateTimePickerFormat.Custom;
                StudDateYear.CustomFormat = "yyyy";
                StudDateYear.ShowUpDown = true;
                //}
            }
            catch
            {

            }
        }

        //this is used to check if keypress is letter in full name textbox
        private void StudTxtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        public void SetIDValue()
        {
            try
            {
                Query = "select * from StudTbl ";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if(Ds.Tables[0].Rows.Count==0)
                {
                    Query = "DBCC CHECKIDENT (\'StudTbl\',reseed,0)";
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
        public void SetDataGridView()
        {
            try
            {
                StudentDataGrid.Rows.Clear();
                Query = "select * from StudTbl where Year="+StudDateYear.Value.ToString()+" and Branch="+StudBranch.Text+" order by Branch asc";
                DataSet ds = Fn.GetData(Query);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int j = StudentDataGrid.Rows.Add();
                    StudentDataGrid.Rows[j].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    StudentDataGrid.Rows[j].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    StudentDataGrid.Rows[j].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    StudentDataGrid.Rows[j].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    StudentDataGrid.Rows[j].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    StudentDataGrid.Rows[j].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    StudentDataGrid.Rows[j].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                }
            }
            catch { }
          
        }

        String idofstudent = "";

        private void StudentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   idofstudent = StudentDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                StudTxtIdCode.Text = StudentDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                StudTxtFullName.Text = StudentDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                String SixtyYesNo = StudentDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (SixtyYesNo == "Yes")
                {
                    SixtyYes.Checked = true;
                }
                else
                {
                    SixtyNo.Checked = true;
                }
                String BacklogYesNo = StudentDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (BacklogYesNo == "Yes")
                {
                    BacklogYes.Checked = true;
                }
                else
                {
                    BacklogNo.Checked = true;
                }
                StudComboBranch.SelectedItem = StudentDataGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                DateYearLabel.Text= StudentDataGrid.Rows[e.RowIndex].Cells[6].Value.ToString(); ;

            }
            catch { }
            
        }

        public void ClearAll()
        {
            try
            {
                StudTxtIdCode.Text = "";
                StudTxtFullName.Text = "";
                SixtyYes.Checked = false;
                SixtyNo.Checked = false;
                BacklogYes.Checked = false;
                BacklogNo.Checked = false;
                StudComboBranch.SelectedIndex = -1;
                DateYearLabel.Text = DateTime.Now.Date.Year.ToString();
                idofstudent = "";
            }
            catch { }
        }

        private void StudBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (StudTxtIdCode.Text != "" && StudTxtFullName.Text != "" && (SixtyYes.Checked == true || SixtyNo.Checked == true) && (BacklogYes.Checked == true || BacklogNo.Checked == true) && StudComboBranch.SelectedIndex != -1)
                {
                    WrongMessage.Visible = false;
                    String IDCode = StudTxtIdCode.Text;
                    String FullName = StudTxtFullName.Text;
                    String SixtyYesNo="";
                    String BacklogYesNo="";
                    if (SixtyYes.Checked)
                    {
                        SixtyYesNo = "Yes";
                    }

                    if (SixtyNo.Checked)
                    {
                        SixtyYesNo = "No";
                    }

                    if (BacklogYes.Checked)
                    {
                        BacklogYesNo = "Yes";
                    }

                    if (BacklogNo.Checked)
                    {
                        BacklogYesNo = "No";
                    }

                    String Branch = StudComboBranch.Text;
                    String Date_Year = DateYearLabel.Text;

                    //MessageBox.Show(IDCode+"\n"+FullName + "\n" +SixtyYesNo + "\n" +BacklogYesNo + "\n" +Branch + "\n" +Date_Year);

                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "insert into StudTbl(IDCode,FullName,Percentage,Backlog,Branch,Year) values(@IC,@Fn,@SYN,@BYN,@Br,@DY)";
                    SqlCommand Cmd = new SqlCommand(Query,Con);
                    Cmd.Parameters.AddWithValue("@IC",IDCode);
                    Cmd.Parameters.AddWithValue("@Fn", FullName);
                    Cmd.Parameters.AddWithValue("@SYN", SixtyYesNo);
                    Cmd.Parameters.AddWithValue("@BYN", BacklogYesNo);
                    Cmd.Parameters.AddWithValue("@Br", Branch);
                    Cmd.Parameters.AddWithValue("@DY", Date_Year);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Inserted Successfully","Insertion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ClearAll();
                    SearchBtn.PerformClick();
                }
                else
                {
                    WrongMessage.Visible = true;
                }
            }
            catch { }
        }

        private void StudBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudTxtIdCode.Text != "" && StudTxtFullName.Text != "" && (SixtyYes.Checked == true || SixtyNo.Checked == true) && (BacklogYes.Checked == true || BacklogNo.Checked == true) && StudComboBranch.SelectedIndex != -1)
                {
                    WrongMessage.Visible = false;
                    String IDCode = StudTxtIdCode.Text;
                    String FullName = StudTxtFullName.Text;
                    String SixtyYesNo = "";
                    String BacklogYesNo = "";
                    if (SixtyYes.Checked)
                    {
                        SixtyYesNo = "Yes";
                    }

                    if (SixtyNo.Checked)
                    {
                        SixtyYesNo = "No";
                    }

                    if (BacklogYes.Checked)
                    {
                        BacklogYesNo = "Yes";
                    }

                    if (BacklogNo.Checked)
                    {
                        BacklogYesNo = "No";
                    }

                    String Branch = StudComboBranch.Text;
                    String Date_Year = DateYearLabel.Text;

                    //MessageBox.Show(IDCode + "\n" + FullName + "\n" + SixtyYesNo + "\n" + BacklogYesNo + "\n" + Branch + "\n" + Date_Year);

                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "update StudTbl set IDCode=@IC,FullName=@Fn,Percentage=@SYN,Backlog=@BYN,Branch=@Br,Year=@DY where Id=@id ";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@IC", IDCode);
                    Cmd.Parameters.AddWithValue("@Fn", FullName);
                    Cmd.Parameters.AddWithValue("@SYN", SixtyYesNo);
                    Cmd.Parameters.AddWithValue("@BYN", BacklogYesNo);
                    Cmd.Parameters.AddWithValue("@Br", Branch);
                    Cmd.Parameters.AddWithValue("@DY", Date_Year);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Updated Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    SearchBtn.PerformClick();

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

        private void StudBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudTxtIdCode.Text != "" && StudTxtFullName.Text != "" && (SixtyYes.Checked == true || SixtyNo.Checked == true) && (BacklogYes.Checked == true || BacklogNo.Checked == true) && StudComboBranch.SelectedIndex != -1)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from StudTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofstudent);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    SearchBtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please enter valid details..");
                }
            }
            catch { }
        }

        private void StudBtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
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
        


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {

                StudentDataGrid.Rows.Clear();
                String stuyear = StudDateYear.Value.Year.ToString();
                String bran = StudBranch.Text;
                Con = Fn.Get_Connection();
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

            }
            catch 
            {
              
            }
        }

        private void StudentDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
