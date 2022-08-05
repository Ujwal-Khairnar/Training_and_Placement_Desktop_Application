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

namespace Training_and_Placement_Final_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Function FN = new Function();
        String query;
        //this code is for close button

        private void Login_Load(object sender, EventArgs e)
        {
            WrongLabel.Visible = false;
            Show_Password_CheckBox.Enabled = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {   if (MessageBox.Show(this, "Do you really want to close Application...", "Asking", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        //this code is for minimize button
        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //this code is for Gpa logo 
        private void GPALogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gpamravati.ac.in/gpamravati_new/");
        }

        bool Mouse_Down;
        int MouseX, MouseY;

        //this code is for moving window{
        private void LoginTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse_Down = true;
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void LoginTopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse_Down)
            {
                this.SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
            }
        }

        private void LoginTopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse_Down = false;
        }

        //}

        //this code is for Login Button
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(LoginRole.SelectedIndex!=-1 && LoginUsername.Text!="" && LoginPassword.Text!="")
            {
                WrongLabel.Visible = false;
                try
                {
                    query = "select LoginRole,LoginUsername,LoginPassword from LoginTbl where LoginRole=@Role and LoginUsername=@username and LoginPassword=@password";
                    SqlConnection CON = FN.Get_Connection();
                    SqlCommand CMD = new SqlCommand(query,CON);
                    CON.Open();
                    CMD.Parameters.AddWithValue("@Role",LoginRole.Text);
                    CMD.Parameters.AddWithValue("@username", LoginUsername.Text);
                    CMD.Parameters.AddWithValue("@password", LoginPassword.Text);
                    SqlDataAdapter DA = new SqlDataAdapter(CMD);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    CON.Close();
                    
                    if(DS.Tables[0].Rows.Count!=0)
                    {   if (DS.Tables[0].Rows[0][0].ToString() == "User" )
                        {
                            
                            if (DS.Tables[0].Rows[0][1].ToString() == LoginUsername.Text.Trim())
                            {
                                //MessageBox.Show("Hello");
                                if (DS.Tables[0].Rows[0][2].ToString() == LoginPassword.Text)
                                {
                                    Dashboard DashB = new Dashboard();
                                    DashB.Show();
                                    this.Hide();
                                    WrongLabel.Visible = false;
                                }
                                else
                                {
                                    WrongLabel.Visible = true;
                                    WrongLabel.Text = "**Username Can't be found";
                                }
                            }
                            else
                            {
                                WrongLabel.Text = "**Username Can't be found";
                                WrongLabel.Visible = true;
                                
                            }
                        }

                        if (DS.Tables[0].Rows[0][0].ToString() == "Administrator")
                        {

                            if (DS.Tables[0].Rows[0][1].ToString() == LoginUsername.Text.Trim())
                            {
                                //MessageBox.Show("Hello");
                                if (DS.Tables[0].Rows[0][2].ToString() == LoginPassword.Text)
                                {
                                    Dashboard DashB = new Dashboard("Admin");
                                    DashB.Show();
                                    this.Hide();
                                    WrongLabel.Visible = false;
                                }
                                else
                                {
                                    WrongLabel.Visible = true;
                                    WrongLabel.Text = "**Username Can't be found";
                                }
                            }
                            else
                            {
                                WrongLabel.Text = "**Username Can't be found";
                                WrongLabel.Visible = true;

                            }
                        }
                    }
                    else
                    {
                        WrongLabel.Visible = true;
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this,"Please Enter all the Details...","Empty Details",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void LoginPassword_TextChanged(object sender, EventArgs e)
        {
            if(LoginPassword.Text!="")
            {
                Show_Password_CheckBox.Enabled = true;
            }
            else
            {
                Show_Password_CheckBox.Enabled = false;
                Show_Password_CheckBox.Checked = false;
                Show_Password_CheckBox.Text = "Show Password";
            }
        }

        private void Show_Password_CheckBox_CheckStateChanged(object sender, EventArgs e)
        {   if (LoginPassword.Text != "")
            {
                if (Show_Password_CheckBox.Checked == true)
                {
                    LoginPassword.PasswordChar = '\0';
                    Show_Password_CheckBox.Text = "Hide Password";
                }
                else
                {
                    LoginPassword.PasswordChar = '*';
                    Show_Password_CheckBox.Text = "Show Password";
                }
            }
        }

        private void TAP_Label_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gpamravati.ac.in/gpamravati_new/#");
        }

    }
}
