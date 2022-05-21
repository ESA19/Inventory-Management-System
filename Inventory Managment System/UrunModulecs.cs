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
    public partial class UrunModulecs : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public UrunModulecs()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnKay_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Kaydedilsin mi?", "Kaydediliyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tUrun(urunkodu,urunismi,miktar,beden,fiyat)VALUES(@urunkodu,@urunismi,@miktar,@beden,@fiyat)", conn);
                    cmd.Parameters.AddWithValue("@urunkodu", txtUrunK.Text);
                    cmd.Parameters.AddWithValue("@urunismi", urunI.Text);
                    cmd.Parameters.AddWithValue("@miktar", Convert.ToInt16(UrunMiktar.Text));
                    cmd.Parameters.AddWithValue("@beden", UrunBeden.Text);
                    cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt16(UrunFiyat.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ürün Başarıyla Eklendi!");
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
            txtUrunK.Clear();
            urunI.Clear();
            UrunMiktar.Clear();
            UrunBeden.Clear();
            UrunFiyat.Clear();
        }

        private void btnDuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Düzenlensin  mi?", "Düzenleniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tUrun SET urunismi=@urunismi,miktar=@miktar,beden=@beden,fiyat=@fiyat WHERE urunkodu LIKE'" + txtUrunK.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@urunismi", urunI.Text);
                    cmd.Parameters.AddWithValue("@miktar", Convert.ToInt16(UrunMiktar.Text));
                    cmd.Parameters.AddWithValue("@beden", UrunBeden.Text);
                    cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt16(UrunFiyat.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ürün Başarıyla Düzenlendi!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void UrunModulecs_Load(object sender, EventArgs e)
        {

        }
    }
}
