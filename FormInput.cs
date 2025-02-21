using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TUGAS_UAS2
{
    public partial class FormInput : Form
    {
        private IMongoCollection<BsonDocument> myhealth2Collection;
        private string selectedId = ""; // Menyimpan ID data yang dipilih

        public FormInput()
        {
            InitializeComponent();
            InitializeMongoDB();
            InitializeComboBox();
            LoadData();
            data_tanaman.CellClick += DataTanaman_CellClick;
        }

        private void InitializeMongoDB()
        {
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("myhealth");
                myhealth2Collection = database.GetCollection<BsonDocument>("myhealth2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in database connection: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.Add("Buruk");
            comboBox1.Items.Add("Baik");
            comboBox1.Items.Add("Sangat Baik");
            comboBox1.SelectedIndex = 0;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(selectedId))
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedId));
                    var update = Builders<BsonDocument>.Update
                        .Set("TinggiTanaman", textBox1.Text)
                        .Set("KondisiDaun", comboBox1.SelectedItem.ToString())
                        .Set("KebutuhanAir", textBox2.Text);

                    await myhealth2Collection.UpdateOneAsync(filter, update);
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var plantDocument = new BsonDocument
                    {
                        { "TinggiTanaman", textBox1.Text },
                        { "KondisiDaun", comboBox1.SelectedItem.ToString() },
                        { "KebutuhanAir", textBox2.Text }
                    };
                    await myhealth2Collection.InsertOneAsync(plantDocument);
                    MessageBox.Show("Data tanaman berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                await Task.Delay(200);
                LoadData(); // Memuat ulang data setelah input
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadData()
        {
            try
            {
                data_tanaman.ReadOnly = true;
                data_tanaman.Rows.Clear();
                data_tanaman.Columns.Clear();

                data_tanaman.Columns.Add("ID", "ID");
                data_tanaman.Columns.Add("TinggiTanaman", "Tinggi Tanaman");
                data_tanaman.Columns.Add("KondisiDaun", "Kondisi Daun");
                data_tanaman.Columns.Add("KebutuhanAir", "Kebutuhan Air");

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn()
                {
                    Name = "Update",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                data_tanaman.Columns.Add(editButton);

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                data_tanaman.Columns.Add(deleteButton);

                var documents = await Task.Run(() => myhealth2Collection.Find(new BsonDocument()).ToList());

                foreach (var doc in documents)
                {
                    data_tanaman.Rows.Add(
                        doc.GetValue("_id", "").ToString(),
                        doc.GetValue("TinggiTanaman", "").ToString(),
                        doc.GetValue("KondisiDaun", "").ToString(),
                        doc.GetValue("KebutuhanAir", "").ToString()
                    );
                }

                // Memastikan DataGridView diperbarui di UI Thread
                if (data_tanaman.InvokeRequired)
                {
                    data_tanaman.Invoke((MethodInvoker)delegate
                    {
                        data_tanaman.Refresh();
                    });
                }
                else
                {
                    data_tanaman.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataTanaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = data_tanaman.Rows[e.RowIndex];
                selectedId = row.Cells["ID"].Value.ToString();

                if (data_tanaman.Columns[e.ColumnIndex].Name == "Update")
                {
                    textBox1.Text = row.Cells["TinggiTanaman"].Value.ToString();
                    comboBox1.SelectedItem = row.Cells["KondisiDaun"].Value.ToString();
                    textBox2.Text = row.Cells["KebutuhanAir"].Value.ToString();
                }
                else if (data_tanaman.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedId));
                        myhealth2Collection.DeleteOne(filter);
                        LoadData(); // Segera muat ulang data setelah delete
                    }
                }
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            textBox2.Clear();
            selectedId = "";
        }
    }
}
