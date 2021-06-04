using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
public partial class Form1 : Form
{
        string connect_info = "DATA SOURCE = xe; User Id = sqlDB; password = 1234;";
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;
        String search_name;

        public Form1()
    {
        InitializeComponent();
        Text = "도서관 관리";

        DataSet data = new DataSet();
            string sql = "SELECT * FROM BOOK";
        conn = new OracleConnection(connect_info);
        conn.Open();
        adt = new OracleDataAdapter(sql, conn);
        adt.Fill(data);
        dataGridView1.DataSource = data.Tables[0];

            label5.Text = Convert.ToString(data.Tables[0].Rows.Count);
        
            // 라벨 설정
            /*   label5.Text = DataManager.Books.Count.ToString();
           label6.Text = DataManager.Users.Count.ToString();
           label7.Text = DataManager.Books.Where((x) => x.isBorrowed).Count().ToString();
           label8.Text = DataManager.Books.Where((x) => {
               return x.isBorrowed && x.BorrowedAt.AddDays(7) > DateTime.Now;
           }).Count().ToString();*/

            // 데이터 그리드 설정
            /*dataGridView1.DataSource = DataManager.Books;
            dataGridView2.DataSource = DataManager.Users;*/
            /*dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            dataGridView2.CurrentCellChanged += DataGridView2_CurrentCellChanged;*/

            // 버튼 이벤트 설정
    }

        

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new Form2().ShowDialog();
    }

    private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new Form3().ShowDialog();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DataSet data = new DataSet();
        search_name = textBox1.Text;
        string sql = "SELECT * FROM BOOK WHERE BNAME like '%" + search_name + "%'";
        conn = new OracleConnection(connect_info);
        conn.Open();
        adt = new OracleDataAdapter(sql, conn);
        adt.Fill(data);
        dataGridView1.DataSource = data.Tables[0];
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
    }

        private void Form1_Activated(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            string sql = "SELECT * FROM BOOK";
            conn = new OracleConnection(connect_info);
            conn.Open();
            adt = new OracleDataAdapter(sql, conn);
            adt.Fill(data);
            label5.Text = Convert.ToString(data.Tables[0].Rows.Count);
        }
    }
}
