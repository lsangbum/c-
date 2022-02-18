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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string pw = userPw.Text;
            string pw2 = userPw2.Text;

            if (pw.Equals(pw2))
            {
                string id = userId.Text;
                string name = userName.Text;
                string birth = userBirth.Text;
                string gender = userGender.Text;
                string mail = eMail.Text;
                string phone = phoneNum.Text;

                String userData = id + "," + pw + "," + name + "," + birth + "," + gender + "," + mail + "," + phone;

                StreamWriter wr = new StreamWriter("repository.txt", true);
                wr.WriteLine(userData);
                wr.Close();

                MessageBox.Show("가입완료");
                this.Visible = false;

            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
        }//btnJoin_Click

        
    }//class
}//namespace








