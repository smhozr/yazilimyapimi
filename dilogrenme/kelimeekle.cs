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
    public partial class kelimeekle : MetroFramework.Forms.MetroForm
    {
        public kelimeekle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public bool BosKontrol()
        {
            bool drm = true;

            if ((textBox1.Text == "") || (textBox2.Text == ""))
                drm = false;
            else
                drm = true;
            return drm;
        }
        public int kelimekotnrol(string secilen)
        {
          
            SqlCommand komut = new SqlCommand("select count (kelimeID) from kelimeler where kelimeAdi=@secilenkelime", bgl.baglanti());
            komut.Parameters.AddWithValue("@secilenkelime", secilen);
            SqlDataReader dr = komut.ExecuteReader();
            int topEleman = 0;
            while (dr.Read())
            {
                topEleman = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
            return topEleman;
            }

        public void KelimeEkle()
        {
            if (BosKontrol())
            {
                if (kelimekotnrol(textBox1.Text) > 0)
                {
                    MessageBox.Show("Kelime daha önce eklemiştir...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand komut = new SqlCommand("insert into kelimeler (kelimeAdi,kelimeKarsiligi,kelimeDurum) values (@p1,@p2,0)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kelime basariyla eklendi. :)", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                                           }
            else
                MessageBox.Show("Lütfen tüm alanları doldurun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
             KelimeEkle();
                       
        }

        private void kelimeekle_Load(object sender, EventArgs e)
        {

        }
    }
}
