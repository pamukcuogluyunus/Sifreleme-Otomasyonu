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

namespace Sifreli_veriler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BITUB47;Initial Catalog=DbSifreleme;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLVERILER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void sifrenincozumu()
        {
            string adcozum = TxtAd.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi = ASCIIEncoding.ASCII.GetString(adcozumdizi);
            TxtAd.Text = adverisi;

            string soyadcozum = TxtSoyad.Text;
            byte[] soyadcozumdizi = Convert.FromBase64String(soyadcozum);
            string soyadverisi = ASCIIEncoding.ASCII.GetString(soyadcozumdizi);
            TxtSoyad.Text = soyadverisi;

            string mailcozum = TxtMail.Text;
            byte[] mailcozumdizi = Convert.FromBase64String(mailcozum);
            string mailverisi = ASCIIEncoding.ASCII.GetString(mailcozumdizi);
            TxtMail.Text = mailverisi;

            string sifrecozum = TxtSifre.Text;
            byte[] sifrecozumdizi = Convert.FromBase64String(sifrecozum);
            string sifreverisi = ASCIIEncoding.ASCII.GetString(sifrecozumdizi);
            TxtSifre.Text = sifreverisi;

            string hesapnocozum = textBox5.Text;
            byte[] hesapnocozumdizi = Convert.FromBase64String(hesapnocozum);
            string hesapnoverisi = ASCIIEncoding.ASCII.GetString(hesapnocozumdizi);
            textBox5.Text = hesapnoverisi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = TxtAd.Text;
            byte[] addizi=ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(addizi);
            

            string soyad = TxtSoyad.Text;
            byte [] soyaddizi = ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String (soyaddizi);

            string mail = TxtMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = TxtSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = textBox5.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLVERILER (AD,SOYAD,MAIL,SIFRE,HESAPNO) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", adsifre);
            komut.Parameters.AddWithValue("@p2", soyadsifre);
            komut.Parameters.AddWithValue("@p3", mailsifre);
            komut.Parameters.AddWithValue("@p4", sifresifre);
            komut.Parameters.AddWithValue("@p5", hesapnosifre);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler Eklendi");



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifrenincozumu();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
