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

namespace Personel_Kayit
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IPR9NU0\\SQLEXPRESS;Initial Catalog=Personel_DB;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Sehirler  Chart
            baglanti.Open();
            komut = new SqlCommand("SELECT perSehir,Count(*) FROM Tbl_Personel GROUP BY perSehir",baglanti);
            dr= komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            //Maas-Meslek Chart
            baglanti.Open();
            komut = new SqlCommand("SELECT perMeslek,AVG(perMaas) FROM Tbl_Personel GROUP BY perMeslek", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

        }
    }
}
