using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_and_Placement_Final_Project
{
    internal class Function
    {
        //Connection to GPADatabase
        public SqlConnection Get_Connection()
        {
            SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename= "+ System.IO.Path.GetFullPath("GPADatabase.mdf")+"; Integrated Security = True") ;
            // "+ System.IO.Path.GetFullPath("GPADatabase.mdf")+"
            //= D:\project for desktop\Training and Placement Final Project\GPADatabase.mdf;
            return Con;
        }

        //Used to send Table Filled with data
        public DataSet GetData(String query)
        {
                SqlConnection CON = Get_Connection();
                CON.Open();
                SqlDataAdapter DA = new SqlDataAdapter(query, CON);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                CON.Close();
                return DS;
        }

        //Used for inserting ,deleteing & updating GPADatabase
        public void SetData(String query,String Message_Box)
        {
            SqlConnection CON = Get_Connection();
            CON.Open();
            SqlCommand CMD = new SqlCommand(query,CON);
            CMD.ExecuteNonQuery();
            CON.Close();
            MessageBox.Show(Message_Box, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
