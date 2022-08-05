using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_and_Placement_Final_Project.UC_Items_Folder
{
    public partial class StudentForm : UserControl
    {
        public StudentForm()
        {
            InitializeComponent();
        }
        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        private void StudBtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File";
            fdlg.FileName = StudTxtFilePath.Text;
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if(fdlg.ShowDialog()==DialogResult.OK)
            {
                StudTxtFilePath.Text = fdlg.FileName;
            }
        }

        private void StudBtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Connection = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + StudTxtFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";");
                Connection.Open();
                OleDbDataAdapter DA = new OleDbDataAdapter("Select * from[Sheet1$]", Connection);

                DataTable dt = new DataTable();
                DA.Fill(dt);
                this.StudentDataGridView.DataSource = dt.DefaultView;
            }
            catch
            {

            }
        }

        public void ClearAll()
        {
            StudentDataGridView.DataSource="";
            StudTxtFilePath.Text = "";
            count = 0;
        }
        Int64 count = 0;
        private void StudBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudentDataGridView.Rows.Count != 0 && StudTxtFilePath.Text != "")
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    DataSet DS = new DataSet();
                    int count = 0;
                    for (int i = 0; i < StudentDataGridView.Rows.Count; i++)
                    {
                        String IDCode = StudentDataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();
                        String FullName = StudentDataGridView.Rows[i].Cells[1].Value.ToString();
                        String Above60 = StudentDataGridView.Rows[i].Cells[2].Value.ToString();
                        String Backlog = StudentDataGridView.Rows[i].Cells[3].Value.ToString();
                        String Branch = StudentDataGridView.Rows[i].Cells[4].Value.ToString().ToUpper();
                        String PassYear = StudentDataGridView.Rows[i].Cells[5].Value.ToString();


                        Query = "select * from StudTbl where IDCode=@id and FullName=@fn and Percentage=@pr and Backlog=@back and Branch=@br and Year=@yr ";
                        SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                        da.SelectCommand.Parameters.AddWithValue("@id", IDCode);
                        da.SelectCommand.Parameters.AddWithValue("@fn", FullName);
                        da.SelectCommand.Parameters.AddWithValue("@pr", Above60);
                        da.SelectCommand.Parameters.AddWithValue("@back", Backlog);
                        da.SelectCommand.Parameters.AddWithValue("@br", Branch);
                        da.SelectCommand.Parameters.AddWithValue("@yr", PassYear);
                        da.Fill(DS);

                        if (DS.Tables[0].Rows.Count == 0)
                        {
                            Query = "insert into StudTbl(IDCode,FullName,Percentage,Backlog,Branch,Year) values(@IC,@FN,@pr,@back,@Br,@Yr)";
                            SqlCommand Cmd = new SqlCommand(Query, Con);
                            Cmd.Parameters.AddWithValue("@IC", IDCode);
                            Cmd.Parameters.AddWithValue("@FN", FullName);
                            Cmd.Parameters.AddWithValue("@pr", Above60);
                            Cmd.Parameters.AddWithValue("@back", Backlog);
                            Cmd.Parameters.AddWithValue("@Br", Branch);
                            Cmd.Parameters.AddWithValue("@Yr", PassYear);
                            Cmd.ExecuteNonQuery();
                            count++;
                            //MessageBox.Show(IDCode+FullName+Above60+Backlog+Branch+PassYear);
                        }
                    }
                    Con.Close();
                    if (count > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Seems like Data alerady exist in Student \n -- Data not inserted --", "Insertion problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void StudentForm_Load(object sender, EventArgs e)
        {
            StudTxtFilePath.Enabled = false;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
