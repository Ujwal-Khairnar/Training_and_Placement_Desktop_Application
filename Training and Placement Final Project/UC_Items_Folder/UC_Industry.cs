using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_and_Placement_Final_Project.UC_Items_Folder
{
    public partial class UC_Industry : UserControl
    {
        public UC_Industry()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con;
        String Query="";
        private void UC_Industry_Load(object sender, EventArgs e)
        {
            WrongMessage.Visible = false;
            ImageMessage.Visible = false;
            SetDataGridView();
            SetIDValue();
        }
        public void SetDataGridView()
        {
            try
            {
                IndustryDataGrid.Rows.Clear();
                Query = "select Id,Name,Type,Website from IndusTbl";
                DataSet ds = Fn.GetData(Query);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int j = IndustryDataGrid.Rows.Add();
                    IndustryDataGrid.Rows[j].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    IndustryDataGrid.Rows[j].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    IndustryDataGrid.Rows[j].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    IndustryDataGrid.Rows[j].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                }
            }
            catch { }

        }
        String idofindustry = "";
        private void IndustryDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idofindustry = IndustryDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                IndustryTxtName.Text = IndustryDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                IndustryComboType.Text = IndustryDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                Induswebsite.Text= IndustryDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
               
                if(idofindustry!="")
                {
                    
                    Query = "select Description,Address,Photograph from IndusTbl where Id=" + idofindustry;
                    DataSet DS = Fn.GetData(Query);
                    if(DS.Tables[0].Rows.Count>=0)
                    {
                        IndustryTxtDescription.Text = DS.Tables[0].Rows[0][0].ToString();
                        IndustryTxtAddress.Text = DS.Tables[0].Rows[0][1].ToString();
                        byte[] image = (byte[])DS.Tables[0].Rows[0][2];
                        if(image==null)
                        {
                            IndustryPicBox.Image = null;
                        }
                        else
                        {
                            MemoryStream MS = new MemoryStream(image);
                            IndustryPicBox.Image = Image.FromStream(MS);
                        }
                    }
                    else
                    {
                        ImageMessage.Visible = true;
                    }
                }
           }
            catch { }
        }
        public void SetIDValue()
        {
            try
            {
                Query = "select * from IndusTbl";
                DataSet Ds = Fn.GetData(Query);
                //MessageBox.Show(Ds.Tables[0].Rows.Count+"");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    Query = "DBCC CHECKIDENT (\'IndusTbl\',reseed,0)";
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
                IndustryTxtName.Text="";
                IndustryTxtDescription.Text="";
                IndustryComboType.SelectedIndex=-1;
                IndustryTxtAddress.Text="";
                IndustryPicBox.Image = null;
                idofindustry = "";
                Induswebsite.Text = "";
            }
            catch { }
        }
        String ImageLocationForBrowse = "";
        private void IndusBtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OD = new OpenFileDialog();
                OD.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Fiels (*.*)|*.*";
                OD.Title = "Select Company Picture";
                
                if(OD.ShowDialog()==DialogResult.OK)
                {
                    ImageLocationForBrowse = OD.FileName.ToString();
                    IndustryPicBox.ImageLocation = ImageLocationForBrowse;
                }
            }
            catch { }
        }
        
        private void IndusBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDValue();
                if (IndustryTxtName.Text!="" && IndustryTxtDescription.Text!="" && IndustryComboType.SelectedIndex!=-1 && IndustryTxtAddress.Text!="" && IndustryPicBox.Image!=null && Induswebsite.Text!="")
                {
                    WrongMessage.Visible = false;
                    String Name = IndustryTxtName.Text;
                    String Desc = IndustryTxtDescription.Text;
                    String Type = IndustryComboType.Text;
                    String Address = IndustryTxtAddress.Text;
                    String Website = Induswebsite.Text;
                    byte[] imagebrowse = null;
                    FileStream FS = new FileStream(ImageLocationForBrowse,FileMode.Open,FileAccess.Read);
                    BinaryReader BR = new BinaryReader(FS);
                    imagebrowse = BR.ReadBytes((int)FS.Length);

                    Con = Fn.Get_Connection();
                    Con.Open();
                    DataSet DS = new DataSet();
                   
                    Query = "select * from IndusTbl where Name=@Nme";
                    SqlDataAdapter da = new SqlDataAdapter(Query, Con);
                    da.SelectCommand.Parameters.AddWithValue("@Nme", Name);
                    da.Fill(DS);

                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        Query = "insert into IndusTbl(Name,Description,Type,Address,Website,Photograph) values(@Nme,@Des,@Typ,@Add,@Web,@Pho)";
                        SqlCommand Cmd = new SqlCommand(Query, Con);
                        Cmd.Parameters.AddWithValue("@Nme", Name);
                        Cmd.Parameters.AddWithValue("@Des", Desc);
                        Cmd.Parameters.AddWithValue("@Typ", Type);
                        Cmd.Parameters.AddWithValue("@Add", Address);
                        Cmd.Parameters.AddWithValue("Web", Website);
                        Cmd.Parameters.AddWithValue("@Pho", imagebrowse);
                        Cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Data Inserted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    Con.Close();
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

        private void IndusBtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void IndusBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {   
                if (IndustryTxtName.Text != "" && IndustryTxtDescription.Text != "" && IndustryComboType.SelectedIndex != -1 && IndustryTxtAddress.Text != "" )//&& IndustryPicBox.Image != null
                {
                    Con = Fn.Get_Connection();
                    Con.Open();
                    Query = "delete from IndusTbl where Id=@Id";
                    SqlCommand Cmd = new SqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("@Id", idofindustry);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("Please en", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch { }
        }

    }
}
