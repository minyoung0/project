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
    public partial class Form4 : Form
    {
        OracleConnection oracleConnection;
        public Form4()
        {
            InitializeComponent();
            oracleConnection = new OracleConnection("Data Source=XE;User ID=sqlDB;Password=1234;Unicode=True");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            grid();
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

            query = "Select * from CUSTOMER";
            da = new OracleDataAdapter(query, oracleConnection);
            da.Fill(ds, "CUSTOMER");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "CUSTOMER";
        }
    }
}
