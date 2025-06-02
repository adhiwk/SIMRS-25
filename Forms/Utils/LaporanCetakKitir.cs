using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using SIMRS25.Class;
using SIMRS25.Dtos;

namespace SIMRS25.Forms.Utils
{
    public partial class LaporanCetakKitir : Form
    {
        public LaporanCetakKitir()
        {
            InitializeComponent();
        }

        private void LaporanCetakKitir_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = Application.OpenForms.OfType<MenuUtama>().FirstOrDefault();
            this.Show();
        }

        //public void LoadReportDataSet(KitirDto data)
        //{
        //    try
        //    {
        //        var dataSet = new DatasetCetakKitir().CreateDatasetCetakKitir(
        //            (data.tgl_registrasi, data.no_rkm_medis, data.nm_pasien, data.nm_dokter, data.no_rawat));

        //        var reportDocument = new ReportDocument();
        //        reportDocument.Load(Path.Combine(Application.StartupPath, "Template", "daftar_rj_adm.rpt"));
        //        reportDocument.SetDataSource(dataSet);

        //        CrViewer.ReportSource = reportDocument;
        //        CrViewer.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public void LoadReportListDataset<T>(List<T> dtoList, string dsName, string dtName, string reportFileName)
        {
            try
            {
                var dataSet = CreateObjectDataset.CreateDatasetListDto(dtoList, dsName, dtName);
                var reportDocument = new ReportDocument();
                string reportPath = Path.Combine(Application.StartupPath, "Template", reportFileName);

                if (!File.Exists(reportPath))
                {
                    throw new FileNotFoundException($"File report '{reportFileName}' tidak ditemukan di folder Template.");
                }

                reportDocument.Load(reportPath);
                reportDocument.SetDataSource(dataSet);
                CrViewer.ReportSource = reportDocument;
                CrViewer.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
