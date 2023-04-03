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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IPR9NU0\\SQLEXPRESS;Initial Catalog=Personel_DB;Integrated Security=True");

        void temizle()
        {
            txtid.Text ="";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            cmbSehir.Text = "";
            mskMaas.Text = "";
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personel_DBDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Personel (perAd,perSoyad,perSehir,perMaas,perDurum,perMeslek)" +
                "values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", txtMeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
            temizle();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text="False";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilendeger = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilendeger].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilendeger].Cells[4].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilendeger].Cells[6].Value.ToString();
            label8.Text = dataGridView1.Rows[secilendeger].Cells[5].Value.ToString();
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE  FROM Tbl_Personel WHERE Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutUpdate = new SqlCommand("UPDATE Tbl_Personel SET perAd=@a1,perSoyad=@a2,perSehir=@a3,perMaas=@a4,perDurum=@a5,perMeslek=@a6 WHERE Perid=@a0",baglanti);
            komutUpdate.Parameters.AddWithValue("@a1",txtAd.Text);
            komutUpdate.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutUpdate.Parameters.AddWithValue("@a3", cmbSehir.Text);
            komutUpdate.Parameters.AddWithValue("@a4", mskMaas.Text);
            komutUpdate.Parameters.AddWithValue("@a5", label8.Text);
            komutUpdate.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutUpdate.Parameters.AddWithValue("@a0",txtid.Text);
            komutUpdate.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellenmiştir");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmGiris frm = new FrmGiris();
            frm.Show();
            
            
        }
    }
}
