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
    public partial class tedarikci : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public tedarikci()
        {
            InitializeComponent();
            LoadTedarik();
            LoadSiparis();
        }
        public void LoadTedarik()
        {

            dataGridViewTed.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tTedarik", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridViewTed.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void dataGridViewTed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewTed.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                tedarkciModule tedarkciModule = new tedarkciModule();
                tedarkciModule.txtSirketI.Text = dataGridViewTed.Rows[e.RowIndex].Cells[0].Value.ToString();
                tedarkciModule.txtSirketAdr.Text = dataGridViewTed.Rows[e.RowIndex].Cells[1].Value.ToString();
                tedarkciModule.txtSirketTel.Text = dataGridViewTed.Rows[e.RowIndex].Cells[2].Value.ToString();
                tedarkciModule.btnKay.Enabled = false;
                tedarkciModule.btnDuz.Enabled = true;
                tedarkciModule.txtSirketI.Enabled = false;
                tedarkciModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bu Tedarikçiyi Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tTedarik WHERE tsirketI LIKE '" + dataGridViewTed.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Tedarikçi Başarıyla Silindi!");
                }

            }
            LoadTedarik();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tedarkciModule tedarikciModule = new tedarkciModule();
            tedarikciModule.btnKay.Enabled = true;
            tedarikciModule.btnDuz.Enabled = false;
            tedarikciModule.ShowDialog();
            LoadTedarik();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LoadSiparis()
        {

            dataGridViewSiparis.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tSiparis_", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridViewSiparis.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            conn.Close();
        }
        private void dataGridViewSiparis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewSiparis.Columns[e.ColumnIndex].Name;
            if (colName == "EDİT_")
            {
                SiparisModule siparisModule = new SiparisModule();
                siparisModule.txtUrunİsmi.Text = dataGridViewSiparis.Rows[e.RowIndex].Cells[0].Value.ToString();
                siparisModule.txtUrunMiktari.Text = dataGridViewSiparis.Rows[e.RowIndex].Cells[1].Value.ToString();
                siparisModule.txtSirketİsmi.Text = dataGridViewSiparis.Rows[e.RowIndex].Cells[2].Value.ToString();
                siparisModule.btnKay.Enabled = false;
                siparisModule.btnDuz.Enabled = true;
                siparisModule.txtUrunİsmi.Enabled = false;
                siparisModule.ShowDialog();

            }
            else if (colName == "DELETE_")
            {
                if (MessageBox.Show("Bu Tedarikçiyi Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tSiparis_ WHERE surunismi_ LIKE '" + dataGridViewSiparis.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sipariş Başarıyla Silindi!");
                }

            }
            LoadSiparis();

        }
       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            SiparisModule siparisModule = new SiparisModule();
            siparisModule.btnKay.Enabled = true;
            siparisModule.btnDuz.Enabled = false;
            siparisModule.ShowDialog();
            LoadSiparis();
        }
    }
}
