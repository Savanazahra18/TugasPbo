using MongoDB.Bson;
using MongoDB.Driver;
using BCrypt.Net;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using System.Windows.Controls;
using TUGAS_UAS2;

namespace TUGAS_UAS2
{
    public partial class Form1 : Form
    {
        // Definisikan variabel MongoDB Collection dengan tipe BsonDocument
        private IMongoCollection<BsonDocument> myhealthCollection;

        public Form1()
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
            NavigateToForm2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleLoginAndSaveData();
            NavigateToForm2();
        }

        private void HandleLoginAndSaveData()
        {
            try
            {
                // Ambil nilai dari input pengguna untuk login
                string username = textBox3.Text.Trim();
                string password = textBox4.Text.Trim();
                string name = textBox1.Text.Trim(); // Tambahkan input untuk nama
                string age = textBox2.Text.Trim();  // Tambahkan input untuk usia

                // Validasi input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(age))
                {
                    MessageBox.Show("Semua kolom harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
                    }
                    else
                    {
                        MessageBox.Show("Password salah. Silakan coba lagi.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Simpan data pengguna baru ke MongoDB jika username belum ada
                    var newUser = new BsonDocument
                    {
                        { "Name", name },
                        { "Age", age },
                        { "Username", username },
                        { "PasswordHash", BCrypt.Net.BCrypt.HashPassword(password) }
                    };

                    myhealthCollection.InsertOne(newUser);
                    MessageBox.Show("Registrasi berhasil! Data telah disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Tampilkan pesan jika terjadi kesalahan
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToForm2()
        {
            // Pindah ke Form2 (Halaman Registrasi atau lainnya)
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }


    }
}
