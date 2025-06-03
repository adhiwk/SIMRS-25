using System;
using System.Windows.Forms;
using Seagull.BarTender.Print;
using SIMRS25.Properties;

namespace SIMRS25.Class
{
    class PrintLabel
    {
        public void CetakGelang(string noRekamMedik,string namaPasien, DateTime dtLahir)
        {
            // Initialize and start a BarTender Engine 
            Engine btEngine = new Engine(true);
            // Open a label format 
            LabelFormatDocument btFormat = btEngine.Documents.Open(Application.StartupPath + "\\Template\\GelangPasien.btw");
            btFormat.SubStrings["nama_pasien"].Value = namaPasien;
            btFormat.SubStrings["no_rm"].Value = noRekamMedik;
            btFormat.SubStrings["tgl_lahir"].Value = dtLahir.ToString("dd-MM-yyyy");

            // Setup printer name
            btFormat.PrintSetup.PrinterName = EnvConfig.Get("PRINTER_GELANG_MALE");
            
            // Subscribe to the format event 
            btFormat.JobQueued += new EventHandler<PrintJobEventArgs>(MyLabelFormatOnJobQueued);
                
            // Print the label 
            btFormat.Print();
            // Stop the BarTender Engine 
            btEngine.Stop(SaveOptions.DoNotSaveChanges);
            btEngine.Dispose();
        }

        public void CetakLabel(string noRekamMedik,
            string namaPasien,
            string alamatPasien,
            string jenisKelamin,
            DateTime dtLahir, 
            string umurPasien) {

            string stringClipBoard = noRekamMedik + Environment.NewLine +
                    namaPasien + " (" + jenisKelamin + ")" + Environment.NewLine +
                    dtLahir.ToString("dd-MM-yyyy") + " (" + umurPasien + ")" + Environment.NewLine +
                    alamatPasien;

            // inisialisasi dan mulai bartender enggine 
            Engine btEngine = new Engine(true);

            // buka format label 
            LabelFormatDocument btFormat = btEngine.Documents.Open(Application.StartupPath + @"\Template\LabelPasien.btw");
            btFormat.SubStrings["label"].Value = stringClipBoard;

            // atur nama printer
            btFormat.PrintSetup.PrinterName = EnvConfig.Get("PRINTER_GELANG_MALE");
            btFormat.PrintSetup.IdenticalCopiesOfLabel = int.Parse(EnvConfig.Get("PRINTER_LABEL_COPY"));

            // masukkan ke format event 
            btFormat.JobQueued += new EventHandler<PrintJobEventArgs>(MyLabelFormatOnJobQueued);
            
            // cetak label 
            btFormat.Print();

            // tutup bartender engine 
            btEngine.Stop(SaveOptions.DoNotSaveChanges);
            btEngine.Dispose();
        }
        void MyLabelFormatOnJobQueued(object sender, PrintJobEventArgs printJobEventInfo)
        {
            if (printJobEventInfo == null)
                return;

            if (sender is LabelFormatDocument btFormat)
            {
                // Lakukan penanganan jika diperlukan
            }
        }
    }
}
