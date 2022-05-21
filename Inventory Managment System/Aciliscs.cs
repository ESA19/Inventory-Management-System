using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Managment_System
{
    public partial class Aciliscs : Form
    {
        public Aciliscs()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar1.Value=startPoint;
            if(progressBar1.Value==100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Form1 form=new Form1();
                this.Hide();
                form.ShowDialog();
                this.Dispose();
            }
        }
    }
}
