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
    public partial class FrmGiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IPR9NU0\\SQLEXPRESS;Initial Catalog=Personel_DB;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader dr;
        
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut =new SqlCommand("SELECT * FROM Tbl_Hesap WHERE kullaniciAd=@p1 and kullaniciSifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Kullanici Girişi Başarılı");
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre yanlış!");
            }
            baglanti.Close();
        }
    }
}
