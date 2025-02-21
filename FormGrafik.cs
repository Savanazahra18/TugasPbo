using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TUGAS_UAS2
{
    public partial class FormGrafik : Form
    {
        private IMongoCollection<BsonDocument> myhealth2Collection;

        public FormGrafik()
        {
            InitializeComponent();
            InitializeMongoDB();
            InitializeChart();
            LoadChartData();
        }

        // 🔹 Inisialisasi koneksi ke MongoDB
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
                MessageBox.Show($"Error in database connection: {ex.Message}",
                                "Connection Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // 🔹 Inisialisasi Chart1 dengan dua seri data
        private void InitializeChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            // Tambahkan Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);

            // Konfigurasi Chart
            chart1.Titles.Add("Grafik Data Tanaman Berdasarkan Kondisi Daun");
            chart1.ChartAreas["MainArea"].AxisX.Title = "Kondisi Daun";
            chart1.ChartAreas["MainArea"].AxisY.Title = "Nilai";
            chart1.ChartAreas["MainArea"].AxisY.Minimum = 0;
            chart1.ChartAreas["MainArea"].RecalculateAxesScale();

            // **Seri 1: Rata-rata tinggi tanaman (Bar Chart)**
            Series series1 = new Series("RataRataTinggi")
            {
                ChartType = SeriesChartType.Column, // Grafik batang
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            // **Seri 2: Jumlah tanaman (Line Chart)**
            Series series2 = new Series("JumlahTanaman")
            {
                ChartType = SeriesChartType.Line, // Grafik garis
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32,
                BorderWidth = 3
            };

            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
        }

        // 🔹 Memuat data ke dalam Chart1
        private void LoadChartData()
        {
            try
            {
                if (chart1 == null)
                {
                    MessageBox.Show("Chart belum ditambahkan ke Form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                chart1.Series["RataRataTinggi"].Points.Clear();
                chart1.Series["JumlahTanaman"].Points.Clear();
                var documents = myhealth2Collection.Find(new BsonDocument()).ToList();

                Console.WriteLine($"Jumlah Data: {documents.Count}"); // Debugging

                if (documents.Count == 0)
                {
                    MessageBox.Show("Database tidak memiliki data!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔹 Hitung rata-rata tinggi tanaman berdasarkan KondisiDaun
                var groupedTinggi = documents
                    .Where(doc => doc.Contains("TinggiTanaman") && doc.Contains("KondisiDaun"))
                    .GroupBy(doc => doc["KondisiDaun"].ToString())
                    .Select(group => new
                    {
                        KondisiDaun = group.Key,
                        RataRataTinggi = group.Average(doc =>
                            double.TryParse(doc["TinggiTanaman"].ToString(), out double tinggi) ? tinggi : 0)
                    })
                    .ToList();

                // 🔹 Hitung jumlah tanaman berdasarkan KondisiDaun
                var groupedJumlah = documents
                    .Where(doc => doc.Contains("KondisiDaun"))
                    .GroupBy(doc => doc["KondisiDaun"].ToString())
                    .Select(group => new
                    {
                        KondisiDaun = group.Key,
                        JumlahTanaman = group.Count()
                    })
                    .ToList();

                // 🔹 Tambahkan data ke Chart 1 (Rata-rata Tinggi Tanaman - Bar Chart)
                foreach (var data in groupedTinggi)
                {
                    Console.WriteLine($"Menambahkan Data ke Chart 1: Kondisi={data.KondisiDaun}, Rata-rata Tinggi={data.RataRataTinggi}");
                    chart1.Series["RataRataTinggi"].Points.AddXY(data.KondisiDaun, data.RataRataTinggi);
                }

                // 🔹 Tambahkan data ke Chart 1 (Jumlah Tanaman - Line Chart)
                foreach (var data in groupedJumlah)
                {
                    Console.WriteLine($"Menambahkan Data ke Chart 1: Kondisi={data.KondisiDaun}, Jumlah Tanaman={data.JumlahTanaman}");
                    chart1.Series["JumlahTanaman"].Points.AddXY(data.KondisiDaun, data.JumlahTanaman);
                }

                // Perbarui tampilan chart setelah data dimuat
                chart1.ChartAreas["MainArea"].RecalculateAxesScale();
                chart1.Invalidate();
                chart1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
