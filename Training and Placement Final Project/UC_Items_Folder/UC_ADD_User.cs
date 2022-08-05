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
    public partial class UC_ADD_User : UserControl
    {
        public UC_ADD_User()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";

        public void ClearAll()
        {
            try
            {
                AddUserTxtUsername.Text = "";
                AddUserTxtPassword.Text = "";
            }
            catch { }
        }

        public void SetDataGridView()
        {
            try
            {
                
                AddUserDataGrid.Rows.Clear();
                Query = "select LoginId,LoginUsername,LoginPassword from LoginTbl where LoginRole=\'User\'";
                DataSet ds = Fn.GetData(Query);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                    int j = AddUserDataGrid.Rows.Add();
                    AddUserDataGrid.Rows[j].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    AddUserDataGrid.Rows[j].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    AddUserDataGrid.Rows[j].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                   
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void AddUserBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //SetIDValue();
                if (AddUserTxtUsername.Text != "" && AddUserTxtPassword.Text != "" )
                {
                    WrongMessage.Visible = false;
                    String Username = AddUserTxtUsername.Text;
                    String Password = AddUserTxtPassword.Text;

                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "insert into LoginTbl(LoginRole,LoginUsername,LoginPassword) values(@IC,@Fn,@SYN)";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@IC", "User");
                    Cmd.Parameters.AddWithValue("@Fn", Username);
                    Cmd.Parameters.AddWithValue("@SYN", Password);
                   
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    SetDataGridView();
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

        private void UC_ADD_User_Load(object sender, EventArgs e)
        {
            WrongMessage.Visible = false;
            SetDataGridView();
        }

        String idofuser = "";
        private void AddUserDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idofuser = AddUserDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void AddUserBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Con = Fn.Get_Connection();
                Con.Open();
                Query = "delete from LoginTbl where LoginId=@Id";
                SqlCommand Cmd = new SqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("@Id", idofuser);
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Data Deleted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                SetDataGridView();
            }
            catch { }
        }
    }
}
