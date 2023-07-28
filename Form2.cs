using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardwareInfo;
using MySql.Data.MySqlClient;
namespace YillikAlbum
{





    public partial class Form2 : Form
    {

  

        private void Init_Data()
        {
            if (Properties.Settings.Default.lisanskey != string.Empty)
            {
                if (Properties.Settings.Default.remember == true)
                {
                    textBox1.Text = Properties.Settings.Default.lisanskey;
                    
                }
              
            }
        }

        private void Save_Data()
        {

          
            
                Properties.Settings.Default.lisanskey = textBox1.Text;
                Properties.Settings.Default.remember = true;
                Properties.Settings.Default.Save();
              

            
            

        }

        string hwid = HardwareDetection.getHddSerial().ToString();
        public Form2()
        {
            

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            hwid= HardwareDetection.getHddSerial();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Clipboard.SetText(HardwareDetection.getHddSerial());
            MessageBox.Show("HWİD KOPYALANDI.", "KOPYALANDI");
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            string connstring = "github icin silinmistir";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;

            conn.Open();
            string sql = "SELECT lisans,anahtar,hwid,durum from lisanslar WHERE  lisans='"+ textBox1.Text +"' AND hwid='"+hwid+ "' AND anahtar='yillikalbum' AND durum='0'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                string sorgusonucu = cmd.ExecuteScalar().ToString();
               
                if (sorgusonucu == textBox1.Text)
                {
                    Save_Data();
                    Form1 form1 = new Form1();
                    form1.Show(); 
                    this.Hide();
                }
               
            }
            catch
            {
                MessageBox.Show("GİRİŞ BAŞARISIZ! Lütfen bizimle iletişime geçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);





            }
             
            
            
            
            

            
            conn.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Init_Data();


         timer1.Stop();
            timer1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("0530 591 18 86 Arayınız.");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("0530 591 18 86 Arayınız.");
        }
    }
}
