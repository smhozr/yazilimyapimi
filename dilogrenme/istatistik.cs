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

namespace dilogrenme
{
    public partial class istatistik : MetroFramework.Forms.MetroForm
    {
        public istatistik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            label3.Visible = true;
            label2.Visible = true;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            label3.Visible = false;
            label2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void istatistik_Load(object sender, EventArgs e)
        {
            
            Grafik();
            Listele();
            label4.Text = listBox1.Items.Count + " kelime öğrenildi...";
            progressBar1.Value = listBox1.Items.Count;
            YilDoldur();

        }
        public void YilDoldur()
        {
            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT DISTINCT year(islemTarihi) FROM kelimeler where islemTarihi!=''	", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        public int KelimeSayisi()
        {
            SqlCommand komut = new SqlCommand("select count (kelimeID) from kelimeler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int kelimesayisi = 0;
            while (dr.Read())
            {
                kelimesayisi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
            return kelimesayisi;
        }
        public int ListeKelimeSayisi()
        {
            SqlCommand komut = new SqlCommand("select count (kelimeID) from kelimeler where kelimeDurum=1", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int kelimesayisi = 0;
            while (dr.Read())
            {
                kelimesayisi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
            return kelimesayisi;
        }
        public int OgrendigimKelimeSayisi()
        {
            SqlCommand komut = new SqlCommand("select count (kelimeID) from kelimeler where cevapSeviye=5", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int kelimesayisi = 0;
            while (dr.Read())
            {
                kelimesayisi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
            return kelimesayisi;
        }
        public void Grafik()
        {

            foreach (var series in chart1.Series)
            { series.Points.Clear(); }
            chart1.Series["Sözlükteki Kelimeler"].Points.Add(KelimeSayisi());
            chart1.Series["Listemdeki Kelimeler"].Points.Add(ListeKelimeSayisi());
            chart1.Series["Öğrendiğim Kelimeler"].Points.Add(OgrendigimKelimeSayisi());


        }
        public void Listele()
        {
            SqlCommand komut = new SqlCommand("SELECT kelimeAdi FROM kelimeler where cevapSeviye=5", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                listBox1.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                int secilenyil = int.Parse(comboBox1.SelectedItem.ToString());
                int secilenay = comboBox2.SelectedIndex + 1;
                listBox1.Items.Clear();
                SqlCommand komut = new SqlCommand("SELECT  kelimeAdi FROM kelimeler where year(islemTarihi)=@yil and month(islemTarihi)=@ay and cevapSeviye=5	", bgl.baglanti());
                komut.Parameters.Add("@yil", secilenyil);
                komut.Parameters.Add("@ay", secilenay);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0]);
                }
                bgl.baglanti().Close();

            }
            else if (radioButton2.Checked==true)
            {
               int secilenyil=int.Parse(comboBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                SqlCommand komut = new SqlCommand("SELECT  kelimeAdi FROM kelimeler where year(islemTarihi)=@yil and cevapSeviye=5	", bgl.baglanti());
                komut.Parameters.Add("@yil", secilenyil);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0]);
                }
                bgl.baglanti().Close();

            }
            label4.Text = listBox1.Items.Count + " kelime öğrenildi...";
            progressBar1.Value = listBox1.Items.Count;
        }
    }
}
