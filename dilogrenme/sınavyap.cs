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
    public partial class sınavyap : MetroFramework.Forms.MetroForm
    {
        public sınavyap()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        string dogrucevap = "";
        string seviye = "";
        List<string> ingilizceKelimeler = new List<string>();
        string[] secilmisler = new string[5];

        public void SorulacakSoru()
        {
            SqlCommand komut = new SqlCommand("SELECT top (1) kelimeAdi,kelimeKarsiligi,cevapSeviye FROM kelimeler where kelimeDurum=1 and cevapSeviye<5 and CONVERT(varchar, islemTarihi, 104)=@buguntarihi order by NEWID()", bgl.baglanti());
            komut.Parameters.AddWithValue("@buguntarihi",DateTime.Now.ToShortDateString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                label3.Text = dr[0].ToString() + " kelimesinin ingilizce karşılığı hangisidir?";
                dogrucevap = dr[1].ToString();
                seviye = dr[2].ToString();
            }
            bgl.baglanti().Close();
            ingilizceKelimeler.Add(dogrucevap);
        }
        public void CevaplarGetir()
        { 
            SqlCommand mkt = new SqlCommand("SELECT top 4 kelimeKarsiligi FROM kelimeler order by NEWID()", bgl.baglanti());
            SqlDataReader dr1 = mkt.ExecuteReader();
            while (dr1.Read())
            {               
                ingilizceKelimeler.Add((dr1[0].ToString()));
             }
            bgl.baglanti().Close();

            List<string> siklar = new List<string>();
                       
            for (int i = 0; i < ingilizceKelimeler.Count; i++)
            {
                siklar.Add(ingilizceKelimeler[i]);
            }
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int secilen = random.Next(0, ingilizceKelimeler.Count - i - 1);
                secilmisler[i] = siklar[secilen];
                siklar.RemoveAt(secilen);
                }
            
        }
        public void Guncelle(bool cvp)
        {
            if (cvp==true)
            {
                SqlCommand command = new SqlCommand("UPDATE kelimeler SET  islemTarihi=@guncelletarih,cevapSeviye=@guncelseviye  WHERE kelimeKarsiligi=@kelime", bgl.baglanti());
                command.Parameters.AddWithValue("@kelime", dogrucevap);
                if (seviye=="5")
                {
                    MessageBox.Show("Tüm Aşamalar Tamamlandı. Kelime Öğrenildi...");
                }
                else if (seviye=="0")
                {
                    command.Parameters.AddWithValue("@guncelseviye", 1);
                    command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(7));
                }
                else if (seviye == "1")
                {
                    command.Parameters.AddWithValue("@guncelseviye", 2);
                    command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(30));
                }
                else if (seviye == "2")
                {
                    command.Parameters.AddWithValue("@guncelseviye", 3);
                    command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(180));

                }
                else if (seviye == "3")
                {
                    command.Parameters.AddWithValue("@guncelseviye", 4);
                    command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(365));
                }
                else if (seviye == "4")
                {
                    command.Parameters.AddWithValue("@guncelseviye", 5);
                    command.Parameters.AddWithValue("@guncelletarih", null);
                    MessageBox.Show("Tüm Aşamalar Tamamlandı. Kelime Öğrenildi...");
                }
                command.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Seviye ve Tarih Güncellendi");
            }
            else
            {
                SqlCommand command = new SqlCommand("UPDATE kelimeler SET  islemTarihi=@guncelletarih,cevapSeviye=0  WHERE kelimeKarsiligi=@kelime", bgl.baglanti());
                command.Parameters.AddWithValue("@kelime", dogrucevap);
                command.Parameters.AddWithValue("@guncelletarih", DateTime.Now.AddDays(1));
                command.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Seviye ve Tarih Güncellendi");
            }
        }
        int soruadet = 0;
        public int SoruKontrol()
        {
            SqlCommand komut = new SqlCommand("SELECT count(kelimeID) FROM kelimeler where kelimeDurum=1 and cevapSeviye<5 and CONVERT(varchar, islemTarihi, 104)=@buguntarihi order by NEWID()", bgl.baglanti());
            komut.Parameters.AddWithValue("@buguntarihi", DateTime.Now.ToShortDateString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                 soruadet = Convert.ToInt32(dr[0]);
             
            }
            bgl.baglanti().Close();
            return soruadet;
        }

    private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string cevap;
            if (rba.Checked) { cevap = rba.Text.ToLower(); }
            else if (rbb.Checked) { cevap = rbb.Text.ToLower(); }
            else if (rbc.Checked) { cevap = rbc.Text.ToLower(); }
            else if(rbd.Checked){cevap = rbd.Text.ToLower(); }
            else { cevap = rbe.Text.ToLower(); }

            
                if (dogrucevap == cevap)
                {
                    MessageBox.Show("Bildiniz..");
                    Guncelle(true);
                }
                else
                {
                    MessageBox.Show("yanlıs cevap..");
                    Guncelle(false);
                }
            if (SoruKontrol() == 0)
            {
                MessageBox.Show("Bugün sorulacak kelimeniz bulunmamaktadır.");
                this.Close();
            }
            else
            {
                SorulacakSoru();
                CevaplarGetir();
                radiobutondoldur();
                radiobutonsecili();

                
            }
        }
        public void radiobutondoldur()
        {
            rba.Text = secilmisler[0].ToString();
            rbb.Text = secilmisler[1].ToString();
            rbc.Text = secilmisler[2].ToString();
            rbd.Text = secilmisler[3].ToString();
            rbe.Text = secilmisler[4].ToString();

        }
        public void radiobutonsecili()
        {
            rba.Checked = false;
            rbb.Checked = false;
            rbc.Checked = false;
            rbd.Checked = false;
            rbe.Checked = false;
        }
        public void radiobutontemizle()
        {
            rba.Text = "";
            rbb.Text = "";
            rbc.Text = "";
            rbd.Text = "";
            rbe.Text = "";
        }
        private void sınavyap_Load(object sender, EventArgs e)
        {
           
            if (SoruKontrol()==0)
            {
                MessageBox.Show("Bugün sorulacak kelimeniz bulunmamaktadır.");
                this.Close();
            }
            else
            {
                SorulacakSoru();
                CevaplarGetir();
                radiobutondoldur();
                radiobutonsecili();
            }


        }
    }
}
