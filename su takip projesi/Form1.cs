using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace su_takip_projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            try
            {             
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO SuKayit (miktar) VALUES (@p1)", baglanti);              
                komut.Parameters.AddWithValue("@p1", textBox1.Text);             
                komut.ExecuteNonQuery();             
                baglanti.Close();                
                listBox1.Items.Add(textBox1.Text + " ml");
                textBox1.Clear();                
            }
            catch (Exception hata)
            {                
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
                if (baglanti.State == System.Data.ConnectionState.Open)
                    baglanti.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT SUM(miktar) FROM SuKayit", baglanti);
            object sonuc = komut.ExecuteScalar();
            baglanti.Close();

            if (sonuc != DBNull.Value)
                MessageBox.Show("Bugün içilen toplam su: " + sonuc.ToString() + " ml");
        }

      
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string miktar;

            // Eğer TextBox boşsa varsayılan olarak 250 kabul et
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                miktar = "250";
            }
            else
            {
                miktar = textBox1.Text;
            }
            SqlConnection baglanti = new SqlConnection(
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SuKayit (miktar) VALUES (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", miktar);
            komut.ExecuteNonQuery();
            baglanti.Close();

            listBox1.Items.Add(miktar + " ml");
        }
        
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                // Not: Veritabanından da silmek istersen DELETE sorgusu eklenmeli.
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            listBox1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM SuKayit", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tüm kayıtlar sıfırlandı.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuTakipDB;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT SUM(miktar) FROM SuKayit", baglanti);
            int toplam = Convert.ToInt32(komut.ExecuteScalar() ?? 0);
            baglanti.Close();

            int hedef = 2000; // Örnek hedef 2 litre
            if (toplam >= hedef)
                MessageBox.Show("Tebrikler! Günlük su hedefinize ulaştınız.");
            else
                MessageBox.Show($"Hedefe ulaşmak için {hedef - toplam} ml daha içmelisiniz.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Tebrikler! Günlük hedefe ulaşıldı.";
            label1.ForeColor = Color.Green; // Yazıyı yeşil yapar
            label1.BackColor = Color.LightYellow; // Arka planı hafif sarı yapar
        }
        }
    }
    
 