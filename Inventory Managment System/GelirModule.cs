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
    public partial class GelirModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        int miktar = 0;
        public GelirModule()
        {
            InitializeComponent();
            LoadUrun();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void dataGridViewUrun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            LoadUrun();
        }
        public void LoadUrun()
        {

            dataGridViewUrun.Rows.Clear();
            cmd = new SqlCommand("SELECT urunkodu,miktar,fiyat FROM tUrun WHERE CONCAT(urunkodu,miktar,fiyat) LIKE '%" + txtArama.Text + "%'", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridViewUrun.Rows.Add(dr[0].ToString(), dr[1].ToString(),dr[2].ToString());
            }
            dr.Close();
            conn.Close();
        }
        
        private void dataGridViewUrun_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunKodu.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFiyat.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[2].Value.ToString();
            miktar = Convert.ToInt32(dataGridViewUrun.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void txtMiktar_ValueChanged(object sender, EventArgs e)
        {
            MiktarAl();
            if (Convert.ToInt32(txtMiktar.Value) > miktar)
            {
                MessageBox.Show("Stokta Bu Kadar Ürün Bulunamamaktadır!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMiktar.Value = txtMiktar.Value - 1;
                return;
            }
            if(Convert.ToInt32(txtMiktar.Value) > 0)
            {
                int total = Convert.ToInt32(txtFiyat.Text) * Convert.ToInt32(txtMiktar.Value);
                txtToplam.Text = total.ToString();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtFiyat.Text=="")
            {
                MessageBox.Show("Lütfen Bir Ürün Seçiniz!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (MessageBox.Show("Kaydedilsin mi?", "Kaydediliyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tGelir(urunKodu,Fiyat,Miktar,toplamGelir)VALUES(@urunKodu,@Fiyat,@Miktar,@toplamGelir)", conn);
                    cmd.Parameters.AddWithValue("@urunKodu", txtUrunKodu.Text);
                    cmd.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(txtFiyat.Text));
                    cmd.Parameters.AddWithValue("@Miktar", Convert.ToInt32(Math.Round(txtMiktar.Value)));
                    cmd.Parameters.AddWithValue("@toplamGelir", Convert.ToInt32(txtToplam.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Gelir Başarıyla Eklendi!");
                  




                    cmd = new SqlCommand("UPDATE tUrun SET miktar=(miktar-@miktar) WHERE urunkodu LIKE'" + txtUrunKodu.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@miktar", Convert.ToInt32(txtMiktar.Text));
                    
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                      Clear();
                    LoadUrun();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtUrunKodu.Clear();
            txtFiyat.Clear();
            txtMiktar.Value = 1;
            txtToplam.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            
        }
        public void MiktarAl()
        {
            cmd = new SqlCommand("SELECT miktar FROM tUrun WHERE urunkodu LIKE '" + txtUrunKodu + "'", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                miktar = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
        }
    }
}
