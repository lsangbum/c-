using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnJoin_Click(object sender, EventArgs e)
        {
            Form2 joinForm = new Form2();
            joinForm.ShowDialog();          //이전 창 유지
        }//btnJoin_Click

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = userId.Text;
            string pw = userPw.Text;

            string userRepository = @"C:\Users\cesco\Documents\Visual Studio 2010\Projects\WindowsFormsApplication2\WindowsFormsApplication2\bin\Debug\repository.txt";
            string userInfoAll = File.ReadAllText(userRepository, Encoding.Default);
            Boolean findId = userInfoAll.Contains(id);
            Boolean findPw = userInfoAll.Contains(pw);

            if (findId == true && findPw == true)
            {
                this.Visible = false;
                Form3 mainForm = new Form3();
                mainForm.ShowDialog();
            }
            else if (findId == true && findPw == false)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
            else
            {
                MessageBox.Show("존재하지 않는 회원입니다.");
            }
        }//btnLogin_Click



        
    }//class
}//namespace
