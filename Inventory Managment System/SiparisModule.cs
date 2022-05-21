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
    public partial class SiparisModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public SiparisModule()
        {
            InitializeComponent();
        }

        private void txtSirketTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKay_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Kaydedilsin mi?", "Kaydediliyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tSiparis_(surunismi_,smiktar_,ssirektismi_)VALUES(@surunismi_,@smiktar_,@ssirektismi_)", conn);
                    cmd.Parameters.AddWithValue("@surunismi_", (txtUrunİsmi.Text));
                    cmd.Parameters.AddWithValue("@smiktar_", Convert.ToInt32(txtUrunMiktari.Text));
                    cmd.Parameters.AddWithValue("@ssirektismi_", txtSirketİsmi.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sipariş Başarıyla Eklendi!");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtUrunİsmi.Clear();
            txtUrunMiktari.Clear();
            txtSirketİsmi.Clear();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Düzenlensin  mi?", "Düzenleniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tSiparis_ SET smiktar_=@smiktar_,ssirektismi_=@ssirektismi_ WHERE surunismi_ LIKE'" + txtUrunİsmi.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@smiktar_", Convert.ToInt32(txtUrunMiktari.Text));
                    cmd.Parameters.AddWithValue("@ssirektismi_", txtSirketİsmi.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sipariş Başarıyla Düzenlendi!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTem_Click(object sender, EventArgs e)
        {
            Clear();
            btnKay.Enabled = true;
            btnDuz.Enabled = false;
        }

       
    }
}
