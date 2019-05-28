using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dilogrenme
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-0F01KL2;Initial Catalog=sozlukdb;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
