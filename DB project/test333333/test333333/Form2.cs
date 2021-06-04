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
    public partial class Form2 : Form
    {
        OracleConnection oracleConnection;
        public Form2()
        {
            InitializeComponent();
            oracleConnection = new OracleConnection("Data Source=XE;User ID=sqlDB;Password=1234;Unicode=True");
            OracleConnection conn;
            OracleCommand comm;
            OracleDataAdapter adt;
            OracleDataAdapter adt2;

        }

        private void open_conn()
        {
            if (oracleConnection.State == ConnectionState.Closed)
                oracleConnection.Open();
        }

        private void grid()
        {
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

        private void Form2_Load(object sender, EventArgs e)
        {
            grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                OracleConnection searchdata = new OracleConnection();

                searchdata.ConnectionString = "Data Source = XE; User ID = sqlDB; Password = 1234; Unicode = True";

                searchdata.Open();



                OracleCommand commandSearch = new OracleCommand();

                commandSearch.Connection = searchdata;



                string btn_Search = string.Format("SELECT * FROM BOOK WHERE BNAME='" + textBox2.Text + "'");

                commandSearch.CommandText = btn_Search;



                OracleDataAdapter daSearch = new OracleDataAdapter(commandSearch);

                DataSet dsSearch = new DataSet();

                //DataSEt에 Customers 테이블 만들고 그 테이블에 데이터를 저장

                daSearch.Fill(dsSearch, "dataGridView1");

                dataGridView1.DataSource = dsSearch;

                //DataSet 내부의 테이블 이름

                dataGridView1.DataMember = "dataGridView1";



                MessageBox.Show("검색이 완료됐습니다.", "Information");



                searchdata.Close();

            }

            catch (OracleException ex)

            {

                MessageBox.Show(ex.Message);

            }
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
