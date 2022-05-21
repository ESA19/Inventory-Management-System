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
    public partial class tedarkciModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public tedarkciModule()
        {
            InitializeComponent();
        }

        private void btnKay_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Kaydedilsin mi?", "Kaydediliyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tTedarik(tsirketi,tadres,ttel)VALUES(@tsirketi,@tadres,@ttel)", conn);
                    cmd.Parameters.AddWithValue("@tsirketi", txtSirketI.Text);
                    cmd.Parameters.AddWithValue("@tadres", txtSirketAdr.Text);
                    cmd.Parameters.AddWithValue("@ttel", txtSirketTel.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Tedarikçi Başarıyla Eklendi!");
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
            txtSirketI.Clear();
            txtSirketAdr.Clear();
            txtSirketTel.Clear();
           
        }

        private void btnTem_Click(object sender, EventArgs e)
        {
            Clear();
            btnKay.Enabled = true;
            btnDuz.Enabled = false;
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
                    cmd = new SqlCommand("UPDATE tTedarik SET tadres=@tadres,ttel=@ttel WHERE tsirketI LIKE'" + txtSirketI.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@tadres", txtSirketAdr.Text);
                    cmd.Parameters.AddWithValue("@ttel", txtSirketTel.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Tedarikçi Başarıyla Düzenlendi!");
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
