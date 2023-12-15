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

namespace WindowsFormsApp1

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-TC9JDP4\\SQLEXPRESS; Initial Catalog=personel;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelDataSet.bilgiler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bilgilerTableAdapter.Fill(this.personelDataSet.bilgiler);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    string kayıtekle = "insert into bilgiler(adi,soyadi) values (@kişi_adi , @kişi_soyadi)";
                    SqlCommand komut = new SqlCommand(kayıtekle, connect);

                    komut.Parameters.AddWithValue("@kişi_adi", textBox1.Text);
                    komut.Parameters.AddWithValue("@kişi_soyadi", textBox2.Text);

                    komut.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("işlem yapıldı");

                }
            }
            catch(Exception uyarı)
            {
                MessageBox.Show("uyarınız var" + uyarı);
                throw;

            }

        }
    }
}
