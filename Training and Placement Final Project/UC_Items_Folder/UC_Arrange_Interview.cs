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
    public partial class UC_Arrange_Interview : UserControl
    {
        public UC_Arrange_Interview()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query="";

        private void UC_Arrange_Interview_Load(object sender, EventArgs e)
        {
            try
            {
                WrongMessage.Visible = false;
                ArrangeDateTest.Value = DateTime.Now;
                ArrangeDateInterview.Value = DateTime.Now;
                SetComboData();
                SetDataGridView();
                SetIDValue();
            }
            catch { }
        }

        public void ClearAll()
        {
            try
            {
                ArrangeComboName.SelectedIndex = -1;
                ArrangeDateTest.Value = DateTime.Now.Date;
                ArrangeDateInterview.Value = DateTime.Now.Date;
            }
            catch { }
        }

        public void SetDataGridView()
        {
            try
            {
                ArrangeDataGridView.Rows.Clear();
                Query = "select * from ArrangeIntTbl";
                DataSet ds = Fn.GetData(Query);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int j = ArrangeDataGridView.Rows.Add();
                    ArrangeDataGridView.Rows[j].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    ArrangeDataGridView.Rows[j].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    ArrangeDataGridView.Rows[j].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    ArrangeDataGridView.Rows[j].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                  
                }
            }
            catch { }

        }

        String idofarrange = "";
        private void ArrangeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idofarrange = ArrangeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                ArrangeComboName.Text = ArrangeDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                ArrangeDateTest.Value = DateTime.Parse(ArrangeDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                ArrangeDateInterview.Value = DateTime.Parse(ArrangeDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

            }
            catch { }
        }


        public void SetIDValue()
        {
            try
            {
                Query = "select * from ArrangeIntTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'ArrangeIntTbl\',reseed,0)";
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

        public void SetComboData()
        {
            ArrangeComboName.Items.Clear();
            try
            {
                Query = "select Name from IndusTbl";
                DataSet Ds = Fn.GetData(Query);
                if (Ds.Tables[0].Rows.Count != 0)
                {   for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    {   if (Ds.Tables[0].Rows[i][0].ToString() != "")
                        {
                            ArrangeComboName.Items.Add(Ds.Tables[0].Rows[i][0].ToString());
                        }
                    }
                }
                
            }
            catch { }
        }

        private void ArrangeBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (ArrangeComboName.SelectedIndex != -1 && ArrangeDateTest.Value >= DateTime.Now.Date && ArrangeDateInterview.Value >= DateTime.Now.Date)
                {
                    WrongMessage.Visible = false;
                    String IndusName = ArrangeComboName.Text;
                    String TestDate = ArrangeDateTest.Value.ToLongDateString();
                    String InterviewDate = ArrangeDateInterview.Value.ToLongDateString();
                    //MessageBox.Show(IndusName+"\n"+TestDate+"\n"+InterviewDate);

                    
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "insert into ArrangeIntTbl(Name,Test,Interview) values(@Nme,@Tst,@Itv)";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Nme", IndusName);
                    Cmd.Parameters.AddWithValue("@Tst", TestDate);
                    Cmd.Parameters.AddWithValue("@Itv", InterviewDate);
                   
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
            catch 
            {
                
            }
        }

        private void ArrangeBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (/*ArrangeComboName.SelectedIndex != -1  &&*/  ArrangeDateTest.Value >= DateTime.Now.Date && ArrangeDateInterview.Value >= DateTime.Now.Date)
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from ArrangeIntTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofarrange);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("Please enter valid details..");
                }
            }
            catch { }
        }

        private void ArrangeBtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

       
    }
}
