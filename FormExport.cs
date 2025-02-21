using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using System.Threading.Tasks;

namespace TUGAS_UAS2
{
    public partial class FormExport : Form
    {
        private IMongoCollection<BsonDocument> _collection;

        public FormExport()
        {
            InitializeComponent();
            InitializeMongoDB();
            this.Shown += FormExport_Shown; // Memuat data setelah form selesai dimuat
        }

        private void FormExport_Shown(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        /// <summary>
        /// Koneksi ke MongoDB
        /// </summary>
        private void InitializeMongoDB()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("myhealth"); // Pastikan nama database sesuai
                _collection = database.GetCollection<BsonDocument>("myhealth2"); // Pastikan nama koleksi sesuai

                if (_collection == null)
                {
                    MessageBox.Show("Gagal menghubungkan ke MongoDB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan koneksi MongoDB: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fungsi untuk mengambil data dari MongoDB dan memasukkan ke DataGridView
        /// </summary>
        private async void LoadDataToGridView()
        {
            try
            {
                var documents = await Task.Run(() => _collection.Find(new BsonDocument()).ToList());

                // Debugging: Cek jumlah data yang ditemukan
                MessageBox.Show("Jumlah data ditemukan: " + documents.Count, "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (documents.Count == 0)
                {
                    MessageBox.Show("Tidak ada data di MongoDB!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    return;
                }

                // Membuat objek DataTable
                DataTable dataTable = new DataTable();

                // Menentukan kolom berdasarkan dokumen pertama
                foreach (var element in documents[0].Elements)
                {
                    if (!dataTable.Columns.Contains(element.Name))
                    {
                        dataTable.Columns.Add(element.Name);
                    }
                }

                // Menambahkan data ke DataTable
                foreach (var doc in documents)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (var element in doc.Elements)
                    {
                        row[element.Name] = element.Value.ToString();
                    }
                    dataTable.Rows.Add(row);
                }

                // Memasukkan data ke DataGridView
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke((MethodInvoker)delegate
                    {
                        dataGridView1.DataSource = dataTable;
                    });
                }
                else
                {
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan saat memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fungsi untuk mengekspor data ke PDF
        /// </summary>
        private void ExportToPDF()
        {
            try
            {
                var documents = _collection.Find(new BsonDocument()).ToList();

                if (documents.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diekspor!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Simpan Laporan PDF"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (PdfWriter writer = new PdfWriter(saveFileDialog.FileName))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        document.Add(new Paragraph("Laporan Data Tanaman").SetFontSize(14));

                        foreach (var doc in documents)
                        {
                            document.Add(new Paragraph(
                                "ID: " + (doc.Contains("_id") ? doc["_id"].ToString() : "N/A") + "\n" +
                                "Tinggi Tanaman: " + doc.GetValue("TinggiTanaman", "Tidak tersedia").ToString() + "\n" +
                                "Kondisi Daun: " + doc.GetValue("KondisiDaun", "Tidak tersedia").ToString() + "\n" +
                                "Kebutuhan Air: " + doc.GetValue("KebutuhanAir", "Tidak tersedia").ToString() + "\n"
                            ));
                            document.Add(new Paragraph("-----------------------------"));
                        }
                    }

                    MessageBox.Show("Data berhasil diekspor ke PDF!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengekspor ke PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Load Data
        /// </summary>
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        /// <summary>
        /// Event handler untuk tombol Export ke PDF
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ExportToPDF();
        }
    }
}
