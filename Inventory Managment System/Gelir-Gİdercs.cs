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
    public partial class Gelir_Gİdercs : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Gelir_Gİdercs()
        {
            InitializeComponent();
            LoadGelir();
            LoadGider();
        }
        public void LoadGelir()
        {
            
            int i = 0;

            dataGridViewGelir.Rows.Clear();
            cmd = new SqlCommand("SELECT urunKodu,Fiyat,Miktar,toplamGelir FROM tGelir WHERE CONCAT(urunKodu,Miktar) LIKE '%"+ txtGelirArama.Text+"%'", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;

                dataGridViewGelir.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),dr[3].ToString());
            }
            dr.Close();
            conn.Close();
        }
        public void LoadGider()
        {
            int i = 0;
            dataGridViewGider.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tGider", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;

                dataGridViewGider.Rows.Add(i,dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            conn.Close();
        }
        private void dataGridViewGider_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dataGridViewGider.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                GiderModule giderModule = new GiderModule();
                giderModule.txtGiderTuru.Text = dataGridViewGider.Rows[e.RowIndex].Cells[1].Value.ToString();
                giderModule.txtGiderTutar.Text = dataGridViewGider.Rows[e.RowIndex].Cells[2].Value.ToString();
                giderModule.button1.Enabled = false;
                giderModule.button2.Enabled = true;
                giderModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bu Gideri Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tGider WHERE Tutar LIKE '" + dataGridViewGider.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Gider Başarıyla Silindi!");
                }

            }
            LoadGider();
        }

        private void dataGridViewGelir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dataGridViewGelir.Columns[e.ColumnIndex].Name;
           
             if (colName == "DELETE_")
            {
                if (MessageBox.Show("Bu Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tGelir WHERE toplamGelir LIKE '" + dataGridViewGelir.Rows[e.RowIndex].Cells[4].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Gelir Başarıyla Silindi!");

                    cmd = new SqlCommand("UPDATE tUrun SET miktar=(miktar+@miktar) WHERE urunkodu LIKE'" + dataGridViewGelir.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.Parameters.AddWithValue("@miktar", Convert.ToInt16(dataGridViewGelir.Rows[e.RowIndex].Cells[3].Value.ToString()));


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            LoadGelir();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GelirModule gelirModule = new GelirModule();
            gelirModule.ShowDialog();
            LoadGelir();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadGelir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GiderModule giderModule = new GiderModule();
            giderModule.button1.Enabled = true;
            giderModule.button2.Enabled = false;
            giderModule.ShowDialog();
            LoadGider();
        }
    }
}
