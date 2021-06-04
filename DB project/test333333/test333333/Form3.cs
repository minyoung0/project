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


namespace test333333
{
    public partial class Form3 : Form
    {
        OracleConnection oracleConnection;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;
        String connect_info = "DATA SOURCE = xe; User Id = sqlDB; password = 1234;";
        String temp;
        public Form3()
        {
            InitializeComponent();
            oracleConnection = new OracleConnection("Data Source=XE;User ID=sqlDB;Password=1234;Unicode=True");
        }

        private void open_conn() {
            if (oracleConnection.State == ConnectionState.Closed)
                oracleConnection.Open();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            grid();
        }

        private void grid() {
            OracleDataAdapter da;
            DataSet ds;
            ds = new DataSet();
            string query;

            query = "Select * from BOOK";
            da = new OracleDataAdapter(query, oracleConnection);
            da.Fill(ds, "BOOK");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "BOOK";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bid = string.Format(textBox1.Text); // 아이디
            string bname = string.Format(textBox2.Text); // 이름
            string bauthor = string.Format(textBox2.Text); // 저자
            string bcompany = string.Format(textBox2.Text); // 출판사
            string byear = string.Format(textBox2.Text); // 발행년도

            string sql = "INSERT INTO BOOK (BID,BNAME,BAUTHOR,BCOMPANY,BYEAR) VALUES ('" + bid + "','" + bname + "','" + bauthor + "','" + bcompany + "','" + byear + "')";
            string sql2 = "SELECT * FROM BOOK";
            conn = new OracleConnection(connect_info);
            conn.Open();
            comm = new OracleCommand(sql, conn);
            comm.ExecuteNonQuery();
            comm = new OracleCommand(sql2, conn);
            comm.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bid = string.Format(textBox1.Text);
            string sql = "DELETE FROM BOOK WHERE BID='" + bid + "'";
            string sql2 = "SELECT * FROM BOOK";
            conn = new OracleConnection(connect_info);
            conn.Open();
            comm = new OracleCommand(sql, conn);
            comm.ExecuteNonQuery();
            comm = new OracleCommand(sql2, conn);
            comm.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bid = string.Format(textBox1.Text); // 아이디
            string bname = string.Format(textBox2.Text); // 이름
            string bauthor = string.Format(textBox2.Text); // 저자
            string bcompany = string.Format(textBox2.Text); // 출판사
            string byear = string.Format(textBox2.Text); // 발행년도

            string sql = "UPDATE BOOK SET BID='" + bid + "', BNAME='" + bname + "', BAUTHOR ='" + bauthor + "', BCOMPANY='" + bcompany + "', BYEAR='" + byear + "' WHERE BID='" + temp + "'";
            string sql2 = "SELECT * FROM BOOK";
            conn = new OracleConnection(connect_info);
            conn.Open();
            comm = new OracleCommand(sql, conn);
            comm.ExecuteNonQuery();
            comm = new OracleCommand(sql2, conn);
            comm.ExecuteNonQuery();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            temp = textBox1.Text;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
