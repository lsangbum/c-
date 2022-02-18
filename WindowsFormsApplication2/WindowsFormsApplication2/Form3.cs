using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
/**
 * 전체조회 후 검색조회 하면 검색조회 후 전체조회 외 다른 조회 가능  
 **/
namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable userT = new DataTable();
            DataColumn pkUserId = userT.Columns.Add("아이디");
            pkUserId.ReadOnly = true;
            userT.Columns.Add("이름");
            userT.Columns.Add("생년월일");
            userT.Columns.Add("성별");
            userT.Columns.Add("이메일");
            userT.Columns.Add("연락처");

            userT.PrimaryKey = new DataColumn[] { pkUserId };

            StreamReader rd = new StreamReader(@"C:\Users\cesco\Documents\Visual Studio 2010\Projects\WindowsFormsApplication2\WindowsFormsApplication2\bin\Debug\repository.txt");
            while (!rd.EndOfStream)
            {
                string line = rd.ReadLine();
                string[] cols = line.Split(',');
                userT.Rows.Add(cols[0], cols[2], cols[3], cols[4], cols[5], cols[6]);
            }

            if (!findUser.Text.Equals(""))
            {
                string findOne = findUser.Text;
                DataRow[] dr = userT.Select("성별 = '" + findOne + "'");
                if (dr.Length != 0)
                {
                    userT = dr.CopyToDataTable();
                }
                else
                {
                    userT = new DataTable();
                }

            }
            rd.Close();
            gridControl1.DataSource = userT;
            
        }//simpleButton1_Click

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Form2 loginForm = new Form2();
            loginForm.ShowDialog();
        }//simpleButton1_Click_1

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
        }//simpleButton2_Click

    }
}
