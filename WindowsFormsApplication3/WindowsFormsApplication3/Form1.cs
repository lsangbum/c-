using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
            MakeDataTables();
        }//Form1


        private void MakeDataTables() 
        {
            MakeParentTable();
            MakeChildTable();
            MakeDataRelation();
            BindToDataGrid();
        }

        /**
         * MakeParentTable
         * 작성자 : 이상범
         * 작성일 : 22.02.18
         * 개요 : 부모테이블생성
         **/
        private void MakeParentTable()
        {
            DataTable table = new DataTable("ParentTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn("id", typeof(int));
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn("parentItem", typeof(string));

            column.AutoIncrement = false;           //Default false
            column.Caption = "ParentItem";          //Default 생성이름
            column.ReadOnly = false;                //Default false
            column.Unique = false;                  //Default false
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            dataSet = new DataSet();
            dataSet.Tables.Add(table);

            for (int i = 0; i <= 2; i++) 
            {
                row = table.NewRow();
                row["id"] = i;
                row["ParentItem"] = "ParentItem " + i;
                table.Rows.Add(row);
            }
        }//MakeParentTable

        /**
         * MakeChildTable
         * 작성자 : 이상범
         * 작성일 : 22.02.18
         * 개요 : 자식테이블생성
         **/
        private void MakeChildTable()
        {
            DataTable table = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn("ChildID", typeof(int));
            column.AutoIncrement = true;
            column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;

            table.Columns.Add(column);

            column = new DataColumn("ChildItem", typeof(string));
            column.AutoIncrement = false;
            column.Caption = "ChildItem";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn("ParentID", typeof(int));
            column.AutoIncrement = false;
            column.Caption = "ParentID";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            dataSet.Tables.Add(table);

            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["childID"] = i;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 0;
                table.Rows.Add(row);
            }

            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["childID"] = i + 5;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 1;
                table.Rows.Add(row);
            }

            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["childID"] = i + 10;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 2;
                table.Rows.Add(row);
            }
        }//MakeChildTable

        /**
         * MakeDataRelation
         * 작성자 : 이상범
         * 작성일 : 22.02.18
         * 개요 : 테이블 관계설정
         **/
        private void MakeDataRelation()
        {
            DataColumn parentColumn =
                dataSet.Tables["ParentTable"].Columns["id"];
            DataColumn childColumn =
                dataSet.Tables["ChildTable"].Columns["parentID"];
            DataRelation relation =
                new DataRelation("parent2Child", parentColumn, childColumn);
            dataSet.Tables["ChildTable"].ParentRelations.Add(relation);
        }

        /**
         * BindToDataGrid
         * 작성자 : 이상범
         * 작성일 : 22.02.18
         **/
        private void BindToDataGrid()
        {
            gridControl1.DataSource = dataSet.Tables["ParentTable"];
        }
        
        
        

    }//class
}//namaspace
