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
    public partial class musteri : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ex\Documents\musteri.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public musteri()
        {
            InitializeComponent();
            LoadMusteri();
        }
        public void LoadMusteri()
        {
            
            dataGridView1.Rows.Clear();
            cmd=new SqlCommand("SELECT * FROM tMusteri",conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                musteriModule musteriModule = new musteriModule();
                musteriModule.textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                musteriModule.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                musteriModule.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                musteriModule.button1.Enabled = false;
                musteriModule.button2.Enabled = true;
                musteriModule.textBox1.Enabled = false;
                musteriModule.ShowDialog();
                 
            }
            else if(colName=="Delete")
            {
                if (MessageBox.Show("Bu Müşteriyi Silmek İstediğine Emin Misin?", "Siliniyor!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tMusteri WHERE adsoyad LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Müşteri Başarıyla Silindi!");
                }

            }
            LoadMusteri();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            musteriModule musteriModule=new musteriModule();
            musteriModule.button1.Enabled = true;
            musteriModule.button2.Enabled = false;
            musteriModule.ShowDialog();
            LoadMusteri();

        }
    }

}
