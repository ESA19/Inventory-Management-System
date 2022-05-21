namespace Inventory_Managment_System
{
    partial class SiparisModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparisModule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTem = new System.Windows.Forms.Button();
            this.btnDuz = new System.Windows.Forms.Button();
            this.btnKay = new System.Windows.Forms.Button();
            this.txtSirketİsmi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrunMiktari = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrunİsmi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 69);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(650, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(175, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "SİPARİŞ İŞLEMLERİ";
            // 
            // btnTem
            // 
            this.btnTem.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTem.Location = new System.Drawing.Point(515, 336);
            this.btnTem.Name = "btnTem";
            this.btnTem.Size = new System.Drawing.Size(106, 35);
            this.btnTem.TabIndex = 29;
            this.btnTem.Text = "TEMİZLE";
            this.btnTem.UseVisualStyleBackColor = true;
            this.btnTem.Click += new System.EventHandler(this.btnTem_Click);
            // 
            // btnDuz
            // 
            this.btnDuz.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuz.Location = new System.Drawing.Point(369, 336);
            this.btnDuz.Name = "btnDuz";
            this.btnDuz.Size = new System.Drawing.Size(117, 35);
            this.btnDuz.TabIndex = 28;
            this.btnDuz.Text = "DÜZENLE";
            this.btnDuz.UseVisualStyleBackColor = true;
            this.btnDuz.Click += new System.EventHandler(this.btnDuz_Click);
            // 
            // btnKay
            // 
            this.btnKay.BackColor = System.Drawing.SystemColors.Control;
            this.btnKay.FlatAppearance.BorderSize = 0;
            this.btnKay.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKay.Location = new System.Drawing.Point(240, 336);
            this.btnKay.Name = "btnKay";
            this.btnKay.Size = new System.Drawing.Size(101, 35);
            this.btnKay.TabIndex = 27;
            this.btnKay.Text = "KAYDET";
            this.btnKay.UseVisualStyleBackColor = true;
            this.btnKay.Click += new System.EventHandler(this.btnKay_Click);
            // 
            // txtSirketİsmi
            // 
            this.txtSirketİsmi.Location = new System.Drawing.Point(201, 259);
            this.txtSirketİsmi.Multiline = true;
            this.txtSirketİsmi.Name = "txtSirketİsmi";
            this.txtSirketİsmi.Size = new System.Drawing.Size(418, 33);
            this.txtSirketİsmi.TabIndex = 26;
            this.txtSirketİsmi.TextChanged += new System.EventHandler(this.txtSirketTel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(32, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "ŞİRKET İSMİ :";
            // 
            // txtUrunMiktari
            // 
            this.txtUrunMiktari.Location = new System.Drawing.Point(201, 188);
            this.txtUrunMiktari.Multiline = true;
            this.txtUrunMiktari.Name = "txtUrunMiktari";
            this.txtUrunMiktari.Size = new System.Drawing.Size(418, 36);
            this.txtUrunMiktari.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(76, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "MİKTAR :";
            // 
            // txtUrunİsmi
            // 
            this.txtUrunİsmi.Location = new System.Drawing.Point(201, 116);
            this.txtUrunİsmi.Multiline = true;
            this.txtUrunİsmi.Name = "txtUrunİsmi";
            this.txtUrunİsmi.Size = new System.Drawing.Size(418, 39);
            this.txtUrunİsmi.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "ÜRÜN İSMİ :";
            // 
            // SiparisModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 396);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTem);
            this.Controls.Add(this.btnDuz);
            this.Controls.Add(this.btnKay);
            this.Controls.Add(this.txtSirketİsmi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUrunMiktari);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrunİsmi);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SiparisModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SiparisModule";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnTem;
        public System.Windows.Forms.Button btnDuz;
        public System.Windows.Forms.Button btnKay;
        public System.Windows.Forms.TextBox txtSirketİsmi;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtUrunMiktari;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtUrunİsmi;
        private System.Windows.Forms.Label label2;
    }
}