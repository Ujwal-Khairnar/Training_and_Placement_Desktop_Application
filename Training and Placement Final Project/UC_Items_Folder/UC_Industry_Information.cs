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
    public partial class UC_Industry_Information : UserControl
    {
        public UC_Industry_Information()
        {
            InitializeComponent();
        }

        Function Fn = new Function();
        SqlConnection Con = new SqlConnection();
        String Query = "";
        private void Industry_Information_Load(object sender, EventArgs e)
        {
            GetIndusData();
        }
        
       void LinkClicked12(object sender, EventArgs e)
        {
            LinkLabel LL = (LinkLabel)sender;
            String LLText = LL.Text;
            //MessageBox.Show(LLText);
            Con = Fn.Get_Connection();
            Con.Open();
            Query = "select Name,Description,Type,Address,Website from IndusTbl where Name=@nm";
            SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
            DA.SelectCommand.Parameters.AddWithValue("nm ", LLText);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            //MessageBox.Show(DS.Tables[0].Rows.Count+"");
            Con.Close();
            MessageBox.Show("Industry Name:- "+DS.Tables[0].Rows[0][0].ToString()+"\n"+"Description:- "+ DS.Tables[0].Rows[0][1].ToString() + "\n" +"Type:- "+ DS.Tables[0].Rows[0][2].ToString() + "\n"+"Address:- " + DS.Tables[0].Rows[0][3].ToString() + "\n"+"Website:- " + DS.Tables[0].Rows[0][4].ToString(),"Industry Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void GetIndusData()
        {
            this.Controls.Clear();
            try
            {   
                Con = Fn.Get_Connection();
                Con.Open();
                Query = "select Name,Description,Type,Address,Photograph from IndusTbl";                          
                SqlDataAdapter DA = new SqlDataAdapter(Query, Con);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                //MessageBox.Show(DS.Tables[0].Rows.Count+"");
                Con.Close();

               
                int x = 70, y = 60;
                String Hpe = "go";
                for (int i=1;i<=DS.Tables[0].Rows.Count;i++)
                {
                    byte[] image = (byte[])DS.Tables[0].Rows[i-1][4];
                    MemoryStream MS = new MemoryStream(image);
                    if (Hpe=="go")
                    {   
                        PictureBox Pb = new PictureBox()
                        {
                            Location = new Point(x, y),
                            Size = new Size(175, 204),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.FixedSingle,
                            Image = Image.FromStream(MS),
                    };
                        this.Controls.Add(Pb);
                        
                        LinkLabel LL = new LinkLabel()
                        {
                            Text = DS.Tables[0].Rows[i-1][0].ToString(),
                            Location = new Point(x+50, y+210),
                            Font = new Font("Century Gothic", 10, FontStyle.Bold),

                        };
                        this.Controls.Add(LL);
                        LL.Click+= new EventHandler(this.LinkClicked12);

                        if (i == DS.Tables[0].Rows.Count)
                        {
                            Panel PN = new Panel()
                            {
                                Location = new Point(0, y + 250),
                                Size = new Size(900, 50),
                                BorderStyle = BorderStyle.None,
                            };
                            this.Controls.Add(PN);
                        }

                    }
                    else 
                    { 
                        PictureBox Pb = new PictureBox()
                        {
                            Location = new Point(x+=300, y),
                            Size = new Size(175, 204),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.FixedSingle,
                            Image = Image.FromStream(MS)
                        };
                        this.Controls.Add(Pb);

                        LinkLabel LL = new LinkLabel()
                        {
                            Text = DS.Tables[0].Rows[i - 1][0].ToString(),
                            Font = new Font("Century Gothic",10,FontStyle.Bold),
                            Location = new Point(x + 50, y + 210)
                        };
                        this.Controls.Add(LL);
                        LL.Click += new EventHandler(this.LinkClicked12);

                        if (i == DS.Tables[0].Rows.Count)
                        {
                            Panel PN = new Panel()
                            {
                                Location = new Point(0, y + 250),
                                Size = new Size(900, 50),
                                BorderStyle= BorderStyle.None,
                            };
                            this.Controls.Add(PN);
                        }
                    }

                    if(i%3==0)
                    {
                        x = 70;
                        y = y + 260;
                        Hpe = "go";
                    }
                    else
                    {
                        Hpe = "show";
                    }
                }

            }
            catch
            {
              
            }
        }
    }
}
