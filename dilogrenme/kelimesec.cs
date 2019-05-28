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
    public partial class kelimesec : MetroFramework.Forms.MetroForm
    {
        public kelimesec()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public void KelimeSec()
        {
            string ogrenilecek = comboBox1.SelectedItem.ToString();
            SqlCommand command = new SqlCommand("UPDATE kelimeler SET  islemTarihi=@guncelletarih,kelimeDurum=1,cevapSeviye=0  WHERE kelimeAdi=@kelime", bgl.baglanti());
            command.Parameters.AddWithValue("@kelime", ogrenilecek);
            command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(1));
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenilecek Kelime Seçildi..");
            comboBox1.Text = "Seçiniz...";
        }
        public void KelimeGetir()
        {
            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("select kelimeAdi from kelimeler where kelimeDurum=0", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["kelimeAdi"]);
            }
            bgl.baglanti().Close();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            KelimeSec();
            KelimeGetir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
      
        private void kelimesec_Load(object sender, EventArgs e)
        {
            KelimeGetir();
        }
    }
}
