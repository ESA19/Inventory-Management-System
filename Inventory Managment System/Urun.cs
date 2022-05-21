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
    public partial class Urun : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Urun()
        {
            InitializeComponent();
            LoadUrun();
        }
        public void LoadUrun()
        {

            dataGridViewUrun.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tUrun WHERE CONCAT(urunkodu,urunismi) LIKE '%"+txtArama.Text+"%'", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridViewUrun.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            UrunModulecs urunmodule = new UrunModulecs();
            urunmodule.btnKay.Enabled = true;
            urunmodule.btnDuz.Enabled = false;
            urunmodule.ShowDialog();
            LoadUrun();
        }

        private void dataGridViewUrun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewUrun.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UrunModulecs urunModulecs = new UrunModulecs();
                urunModulecs.txtUrunK.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[0].Value.ToString();
                urunModulecs.urunI.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[1].Value.ToString();
                urunModulecs.UrunMiktar.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[2].Value.ToString();
                urunModulecs.UrunBeden.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[3].Value.ToString();
                urunModulecs.UrunFiyat.Text = dataGridViewUrun.Rows[e.RowIndex].Cells[4].Value.ToString();
                urunModulecs.btnKay.Enabled = false;
                urunModulecs.btnDuz.Enabled = true;
                urunModulecs.txtUrunK.Enabled = false;
                urunModulecs.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bu Ürünü Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tUrun WHERE urunkodu LIKE '" + dataGridViewUrun.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ürün Başarıyla Silindi!");
                }

            }
            LoadUrun();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            LoadUrun();
        }
    }
}
