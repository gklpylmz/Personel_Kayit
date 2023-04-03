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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IPR9NU0\\SQLEXPRESS;Initial Catalog=Personel_DB;Integrated Security=True");
        SqlCommand komut1;
        SqlDataReader dr1;
        private void Form2_Load(object sender, EventArgs e)
        {
            //Toplam personel sayısını gösterir.
            baglanti.Open();
            komut1 = new SqlCommand("SELECT count(*) FROM Tbl_Personel",baglanti);
            dr1 = komut1.ExecuteReader();
            while(dr1.Read()) //dr1 bütün değerleri okuyana kadar işlemi yap
            {
                LblToplamPersonel.Text = dr1[0].ToString(); //Sqlden dönen kolonlarından 0. indexi bu komutatada tüm istatistiklerden  1 sonuç çıkacağı için [0]
            }
            baglanti.Close();


            //Evli Personel Sayısı
            baglanti.Open();
            komut1 = new SqlCommand("SELECT count(*) FROM Tbl_Personel WHERE perDurum=1",baglanti);
            dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                LblEvliPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel sayisi
            baglanti.Open();
            komut1 = new SqlCommand("SELECT count(*) FROM Tbl_Personel WHERE perDurum=0", baglanti);
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblBekar.Text= dr1[0].ToString();
            }
            baglanti.Close();

            //Şehir Sayısı 
            baglanti.Open();
            komut1 = new SqlCommand("SELECT COUNT(distinct(perSehir)) FROM Tbl_Personel", baglanti);
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblSehir.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maaş 
            baglanti.Open();
            komut1 = new SqlCommand("SELECT AVG(perMaas) FROM Tbl_Personel", baglanti);
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAvgMaas.Text = dr1[0].ToString()+" TL";
            }
            baglanti.Close();

            //Toplam Maaş
            baglanti.Open();
            komut1 = new SqlCommand("SELECT SUM(perMaas) FROM Tbl_Personel", baglanti);
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblSumMaas.Text = dr1[0].ToString() + " TL";
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
