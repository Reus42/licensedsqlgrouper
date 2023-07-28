using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
namespace YillikAlbum
{
    public partial class Form1 : Form
    {

 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                string connstring = "github icin gizlenmistir";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;

                conn.Open();
                string sql = "select okuladi from okullar";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                comboBox1.Items.Clear();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["okuladi"].ToString());

                }



            }
            catch (MySqlException ex)
            {


            }
        }   

        private void button1_Click(object sender, EventArgs e)
        {

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstring = "-github icin gizlenmistir";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Close();

            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                try
                {

               
                    string connstring = "-github icin gizlenmistir";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;

                    conn.Open();
                    string sql = "select DISTINCT sinifid from okulgunluk where okulid="+comboBox1.SelectedIndex+1+"";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    comboBox2.Items.Clear();

                        while (reader.Read()) { 
                        comboBox2.Items.Add(reader["sinifid"].ToString());

                        }

                       conn.Close();
                    


                }
                catch (MySqlException ex)
                {


                }


            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               
                {
                    string connstring = "-github icin gizlenmistir";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;

                    conn.Open();
                    string sql = "SELECT DISTINCT sinifid,yazilanadi from okulgunluk WHERE okulid="+comboBox1.SelectedIndex+1+" AND sinifid='"+comboBox2.SelectedItem.ToString()+"'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }


            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connstring = "-github icin gizlenmistir";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;

            conn.Open();
            string sql = "SELECT yazaradi,mesaj from okulgunluk WHERE yazilanadi='"+ dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();

            if (dataGridView1.CurrentRow.Cells[0].Selected) { Clipboard.SetText(dataGridView1.CurrentRow.Cells[0].Value.ToString()); }
            if (dataGridView1.CurrentRow.Cells[1].Selected) { Clipboard.SetText(dataGridView1.CurrentRow.Cells[1].Value.ToString()); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView2.CurrentRow.Cells[0].Selected) { Clipboard.SetText(dataGridView2.CurrentRow.Cells[0].Value.ToString()); }

            if (dataGridView2.CurrentRow.Cells[1].Selected) { Clipboard.SetText(dataGridView2.CurrentRow.Cells[1].Value.ToString()); }

        }
    }
}
