using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace dilogrenme
{
    public partial class Form1 :MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            kelimeekle frmekle = new kelimeekle();
            frmekle.ShowDialog();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            kelimesec frmkelimesec = new kelimesec();
            frmkelimesec.ShowDialog();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            sınavyap frmsinavyap = new sınavyap();
            frmsinavyap.ShowDialog();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            istatistik frmistatistik = new istatistik();
            frmistatistik.ShowDialog();
        }
    }
}
