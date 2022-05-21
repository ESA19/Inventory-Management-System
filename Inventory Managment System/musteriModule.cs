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
    public partial class musteriModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public musteriModule()
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
                    cmd = new SqlCommand("INSERT INTO tMusteri(adsoyad,adres,telefon)VALUES(@adsoyad,@adres,@telefon)", conn);
                    cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@adres", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Müşteri Başarıyla Eklendi!");
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Düzenlensin  mi?", "Düzenleniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tMusteri SET adres=@adres,telefon=@telefon WHERE adsoyad LIKE'" + textBox1.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@adres", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Müşteri Başarıyla Düzenlendi!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
