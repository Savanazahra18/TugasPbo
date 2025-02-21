using MongoDB.Bson;
using MongoDB.Driver;
using BCrypt.Net;
using System;
using System.Windows.Forms;
using TUGAS_UAS2;

namespace TUGAS_UAS2
{
    public partial class Form2 : Form
    {
        // Definisikan variabel MongoDB Collection dengan tipe BsonDocument
        private IMongoCollection<BsonDocument> myhealthCollection;

        public Form2()
        {
            InitializeComponent();
            InitializeMongoDB();
        }

        private void InitializeMongoDB()
        {
            // Koneksi ke MongoDB
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("myhealth"); // Nama database
            myhealthCollection = database.GetCollection<BsonDocument>("myhealth"); // Nama koleksi untuk User
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HandleLoginAndNavigate())
            {
                NavigateToForm3();
            }
        }

        private bool HandleLoginAndNavigate()
        {
            try
            {
                // Ambil nilai dari input pengguna untuk login
                string username = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();

                // Validasi input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username dan password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Cari pengguna berdasarkan username
                var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
                var userDocument = myhealthCollection.Find(filter).FirstOrDefault();

                if (userDocument != null)
                {
                    // Ambil password hash dari database
                    string storedPasswordHash = userDocument["PasswordHash"].AsString;

                    // Verifikasi password
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);

                    if (isPasswordValid)
                    {
                        MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Password salah. Silakan coba lagi.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Username tidak ditemukan. Silakan periksa kembali.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Tampilkan pesan jika terjadi kesalahan
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void NavigateToForm3()
        {
            // Pindah ke Form3 (Halaman Utama setelah login)
            FormDashboard form3 = new FormDashboard();
            form3.Show();
            this.Hide();
        }
    }
}
