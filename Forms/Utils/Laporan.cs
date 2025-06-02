using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SIMRS25.Class;

namespace SIMRS25.Forms.Utils
{
    public partial class Laporan : Form
    {
        public Laporan()
        {
            InitializeComponent();
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = Application.OpenForms.OfType<MenuUtama>().FirstOrDefault();
            this.Show();
        }
      
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

        public void LoadReportDataset(object dto,
            string dsName,
            string dtName,
            string reportFileName) 
        {
            try
            {
                var dataSet = CreateObjectDataset.CreateDatasetDto(dto,dsName,dtName);
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
