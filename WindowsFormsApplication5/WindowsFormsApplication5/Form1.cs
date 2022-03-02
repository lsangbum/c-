using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Cesco.FW.Global.DBAdapter;



namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetGubnCombo();
        }

        /**
         * textEdit1_Properties_KeyDown
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void textEdit1_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                find_Item(); 
            }
        }//textEdit1_Properties_KeyDown

        /**
         * textEdit2_Properties_KeyDown
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void textEdit2_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                find_Item();
            }
        }//textEdit2_Properties_KeyDown

        /**
         * simpleButton1_Click
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            find_Item();

            //gridControl1.DataSource = dt;
        }//simpleButton1_Click

        /**
         * gridControl1_DoubleClick
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            simpleButton2_Click(sender, e);

        }//gridControl1_DoubleClick
                
        /**
         * 품목조회버튼 클릭 시 조건
         * + 해당조건에 부합하는 데이터 추출하여 뿌리기
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void find_Item()
        {
            if (txtItemName.Text.Equals("") && textEdit2.Text.Equals(""))
            {
                MessageBox.Show("품목명 또는 품목코드를 입력하세요.");
                this.ActiveControl = txtItemName;

            }
            else
            {
                string itemName = txtItemName.Text;
                string itemCode = textEdit2.Text;
                string useYN = comboBoxEdit1.SelectedItem.ToString();  
  
                switch (useYN)
                {
                    case "사용여부":
                        useYN = "";
                        break;
                    case "전체":
                        useYN = "";
                        break;
                    case "사용":
                        useYN = "1";
                        break;
                    case "미사용":
                        useYN = "0";
                        break;
                }

                DBAdapters dba = new DBAdapters("21930", MethodBase.GetCurrentMethod());
                dba.BindingConfig.ConnectDBName = ConfigurationDetail.DBName.DEVELOPDB;

                //QueryInfo qi = new QueryInfo();
                //qi.QueryString = new StringBuilder(
                //        "EXEC CESCOEIS.dbo.E_SEL_ITEMSEARCH '','',''"
                //    );
                //dba.Query = qi;

                dba.Procedure.ProcedureName = "CESCOEIS.dbo.E_SEL_ITEMSEARCH";

                dba.Procedure.ParamAdd("@ITEMNAME", itemName);
                dba.Procedure.ParamAdd("@ITEMCODE", itemCode);
                dba.Procedure.ParamAdd("@useYN", useYN);

                DataSet ds = dba.ProcedureToDataSet();

                //DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "NO", "품목구분", "품목코드", "품목명", "사양", "설명", "과세구분", "단위" });
                DataTable dt = ds.Tables[0];

                gridControl1.DataSource = dt;

                //lookUpEdit1.Properties.DisplayMember = "";
                //lookUpEdit1.Properties.ValueMember = "";

                
                
            }
        }//find_Item

        /**
         * 엑셀버튼 클릭시
         * + 파일저장 팝업 활성화
         * + 엑셀파일로 저장
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            sfd.FileName = "file_save" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                gridControl1.ExportToXlsx(path);
            }
        }//simpleButton3_Click

        /**
         * 상세보기버튼 클릭시
         * + 해당 row 상세데이터 추출
         * + 뿌리기
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string itemName = row["품목명"].ToString();
            string itemCode = row["품목코드"].ToString();
            

            DBAdapters dba = new DBAdapters("21930", MethodBase.GetCurrentMethod());
            dba.BindingConfig.ConnectDBName = ConfigurationDetail.DBName.DEVELOPDB;

            dba.Procedure.ProcedureName = "CESCOEIS.dbo.E_SEL_ITEMSEARCH";

            dba.Procedure.ParamAdd("@ITEMNAME", itemName);
            dba.Procedure.ParamAdd("@ITEMCODE", itemCode);
            dba.Procedure.ParamAdd("@useYN", "");

            DataSet ds = dba.ProcedureToDataSet();

            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];
            comboBoxEdit2.SelectedItem = dr["품목구분"].ToString();
            comboBoxEdit3.SelectedItem = dr["과세구분"].ToString();
            textEdit3.Text = dr["품목코드"].ToString();
            textEdit4.Text = dr["품목명"].ToString();
            textEdit5.Text = dr["사양"].ToString();
            textEdit6.Text = dr["설명"].ToString();
            textEdit7.Text = dr["단위"].ToString();
            textEdit8.Text = dr["멤버스가"].ToString();
            textEdit9.Text = dr["정상가"].ToString();
            textEdit10.Text = dr["온라인회원가"].ToString();
            textEdit11.Text = dr["임직원가"].ToString();
            //textEdit11.Text = dr["매입단가"].ToString(); 
            

            //상세보기버튼 클릭시 해당탭 기본값으로 지정
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            
        }//simpleButton2_Click

        /**
         * 품목구분 Combobox 기본값 삽입
         * 작성자 : 이상범
         * 작성일 : 22.02.24
         */
        private void GetGubnCombo()
        {
            DBAdapters dba = new DBAdapters("21930", MethodBase.GetCurrentMethod());
            dba.BindingConfig.ConnectDBName = ConfigurationDetail.DBName.DEVELOPDB;

            QueryInfo qi = new QueryInfo();
            qi.QueryString = new StringBuilder(
                "SELECT Gerldesp FROM CESCOEIS.DBO.MKTCGERL AS A WHERE gerlgubn = '판매품목구분' ORDER BY Gerldesp ASC" 
                + " SELECT Gerldesp FROM CESCOEIS.dbo.MKTCGERL WHERE gerlgubn = '과세구분'");

            dba.Query = qi;

            var ds = dba.QueryToDataSet();

            var dt = ds.Tables[0].DefaultView.ToTable(false, "Gerldesp");
            var dt2 = ds.Tables[1].DefaultView.ToTable(false, "Gerldesp");

            DataRow dr;
            DataRow dr2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                comboBoxEdit2.Properties.Items.Add(dr["Gerldesp"].ToString());
            }

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dr2 = dt2.Rows[i];
                comboBoxEdit3.Properties.Items.Add(dr2["Gerldesp"].ToString());
            }

        }//GetGerldespCombo

    }//class
}//namespace
