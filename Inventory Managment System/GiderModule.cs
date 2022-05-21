using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Managment_System
{
    public partial class GiderModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public GiderModule()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Kaydedilsin mi?", "Kaydediliyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tGider(giderTürü,Tutar)VALUES(@giderTürü,@Tutar)", conn);
                    cmd.Parameters.AddWithValue("@giderTürü", txtGiderTuru.Text);
                    cmd.Parameters.AddWithValue("@Tutar", Convert.ToInt32(txtGiderTutar.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Gider Başarıyla Eklendi!");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtGiderTuru.Clear();
            txtGiderTutar.Clear();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Düzenlensin  mi?", "Düzenleniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tGider SET giderTürü=@giderTürü,Tutar=@Tutar", conn);
                    cmd.Parameters.AddWithValue("@Tutar", Convert.ToInt32(txtGiderTutar.Text));
                    cmd.Parameters.AddWithValue("@giderTürü", txtGiderTuru.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Gider Başarıyla Düzenlendi!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
