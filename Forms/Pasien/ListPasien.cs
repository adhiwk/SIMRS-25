using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using SIMRS25.Class;
using SIMRS25.Dtos;
using SIMRS25.Forms.Utils;

namespace SIMRS25.Forms.Pasien
{
    public partial class ListPasien : Form
    {
        #region "Setup"
        public ListPasien()
        {
            InitializeComponent();
            grdPasien.RowFormatting += Helpers.GridPasienRowFormatting;
            grdPasien.CellFormatting += Helpers.GridPasienCellFormatting;
        }

        private void DefaultSetting()
        {
            btnTambah.Enabled = true;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;
            btnBatal.Enabled = false;
            btnCetakKartu.Enabled = false;
            btnCetakGelang.Enabled = false;
            btnCetakLabel.Enabled = false;
            btnTutup.Enabled = true;
        }
       
        #endregion
        #region "Form Action"
        private void ListPasien_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DefaultSetting();
        }
   
        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            //EntryPasien frmEntryPasien = new EntryPasien
            //{
            //    MdiParent = Utility.MainMenuInstance
            //};

            //frmEntryPasien.Show();
            //frmEntryPasien.BringToFront();
            //string strData = EntryPasien.strData;
            //Console.WriteLine(strData);

            using (EntryPasien frmEntryPasien = new EntryPasien())
            {
                frmEntryPasien.isAdd = true;
                frmEntryPasien.ShowDialog();
                if (frmEntryPasien.strNoRM != null)
                {
                    grdPasien.Rows.Add(frmEntryPasien.pasienData.no_rkm_medis,
                        frmEntryPasien.pasienData.nm_pasien,
                        frmEntryPasien.pasienData.alamat,
                        frmEntryPasien.pasienData.no_ktp,
                        frmEntryPasien.pasienData.jk,
                        frmEntryPasien.pasienData.tgl_lahir,
                        frmEntryPasien.pasienData.no_tlp,
                        frmEntryPasien.pasienData.agama,
                        frmEntryPasien.pasienData.stts_nikah,
                        frmEntryPasien.pasienData.no_peserta,
                        frmEntryPasien.pasienData.kd_pj);
                }
                else
                {
                    DefaultSetting();
                }
            }
        }

        private void BtnUbah_Click(object sender, EventArgs e)
        {
            using (EntryPasien frmEntryPasien = new EntryPasien())
            {
                frmEntryPasien.isAdd = false;
                frmEntryPasien.strNoRM = grdPasien.CurrentRow.Cells[0].Value.ToString().Trim();
                frmEntryPasien.ShowDialog();
                if (frmEntryPasien.strNoRM != "null")
                {
                    /*
                     * update data grid pasien
                     */
                    grdPasien.CurrentRow.Cells[0].Value = frmEntryPasien.pasienData.no_rkm_medis;
                    grdPasien.CurrentRow.Cells[1].Value = frmEntryPasien.pasienData.nm_pasien;
                    grdPasien.CurrentRow.Cells[2].Value = frmEntryPasien.pasienData.alamat;
                    grdPasien.CurrentRow.Cells[3].Value = frmEntryPasien.pasienData.no_ktp;
                    grdPasien.CurrentRow.Cells[4].Value = frmEntryPasien.pasienData.jk;
                    grdPasien.CurrentRow.Cells[5].Value = frmEntryPasien.pasienData.tgl_lahir;
                    grdPasien.CurrentRow.Cells[6].Value = frmEntryPasien.pasienData.no_tlp;
                    grdPasien.CurrentRow.Cells[7].Value = frmEntryPasien.pasienData.agama;
                    grdPasien.CurrentRow.Cells[8].Value = frmEntryPasien.pasienData.stts_nikah;
                    grdPasien.CurrentRow.Cells[9].Value = frmEntryPasien.pasienData.no_peserta;
                    grdPasien.CurrentRow.Cells[10].Value = frmEntryPasien.pasienData.kd_pj;
                }
                else
                {
                    DefaultSetting();
                }
            }
        }

        private void ListPasien_Shown(object sender, EventArgs e)
        {
            LoadPasien();
        }

        private void GrdPasien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    grdPasien.EnableFiltering = true;
                    grdPasien.ShowFilteringRow = true;
                    grdPasien.Columns[2].AllowFiltering = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    grdPasien.EnableFiltering = false;
                    grdPasien.ShowFilteringRow = false;
                    grdPasien.Columns[2].AllowFiltering = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terdapat kesalahan " + ex.Message);
            }

        }
        private void BtnCariData_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    if (btnCariData.Text.Trim() == "")
                    {
                        LoadPasien("default", btnCariData.Text.Trim());
                        return;
                    }
                    LoadPasien("find", btnCariData.Text.Trim());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BtnCetakKartu_Click(object sender, EventArgs e)
        {
            try
            {
                KartuDto kartu = new()
                {
                   nomor_rekam_medik = grdPasien.CurrentRow.Cells[0].Value.ToString(),
                   nama_pasien = grdPasien.CurrentRow.Cells[1].Value.ToString(),
                   alamat = grdPasien.CurrentRow.Cells[2].Value.ToString()
                };

                Laporan laporanForm = new Laporan();
                laporanForm.LoadReportDataset(kartu,
                    "ReportDataSet",
                    "ReportTable",
                    "cetak_kartu.rpt");
                laporanForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pasien dalam keadaan kosong" + ex.Message, "Error");
            }
        }

        private void ListPasien_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void BtnCetakLabel_Click(object sender, EventArgs e)
        {
            try
            {
                PrintLabel printer = new PrintLabel();
                printer.CetakLabel(grdPasien.CurrentRow.Cells[0].Value.ToString(),
                        grdPasien.CurrentRow.Cells[1].Value.ToString(),
                        grdPasien.CurrentRow.Cells[2].Value.ToString(),
                        grdPasien.CurrentRow.Cells[4].Value.ToString(),
                        DateTime.Parse(grdPasien.CurrentRow.Cells[5].Value.ToString()),
                        Helper.HitungUmur(DateTime.Parse(grdPasien.CurrentRow.Cells[5].Value.ToString()))
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnCetakGelang_Click(object sender, EventArgs e)
        {
            try
            {
                PrintLabel printer = new PrintLabel();
                printer.CetakGelang(grdPasien.CurrentRow.Cells[0].Value.ToString(),
                        grdPasien.CurrentRow.Cells[1].Value.ToString(),
                        DateTime.Parse(grdPasien.CurrentRow.Cells[5].Value.ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region "Function"
        private async void LoadPasien(string strModel = "default", string strKeyWord = "none")
        {
            splashManager.ShowWaitForm();
            splashManager.SetWaitFormCaption("Please wait");
            splashManager.SetWaitFormDescription("Query data pasien");

            /*
              Barangkali telah kuseka namamu
              dengan tisu lusuh 
              yang tergelatak  begitu saja
              Seperti dalam perang yang lalu
              Kau seka namaku

              Barangkali kau telah menyeka bukan namaku
              Barangkali aku telah menyeka bukan namamu
              Barangkali kita malah tak pernah di sini
              Hanya hutan, jauh di selatan, hujan pagi
             */

            string strQuery;
            if (strModel == "default")
            {
                strQuery = "SELECT no_rkm_medis as `NO. RM`," +
                           "nm_pasien as `NAMA PASIEN`," +
                           "alamat as `ALAMAT PASIEN`," +
                           "no_ktp AS NIK," +
                           "jk as `KLM`," +
                           "DATE_FORMAT(tgl_lahir,'%Y-%m-%d') as `TGL LAHIR`," +
                           "no_tlp as `PHONE`," +
                           "agama as `AGAMA`," +
                           "stts_nikah as `STATUS NIKAH`," +
                           "no_peserta as `NO. PESERTA`," +
                           "kd_pj as `JENIS` " +
                           "FROM pasien ORDER BY no_rkm_medis DESC LIMIT 100";
            }
            else
            {
                strQuery = "SELECT no_rkm_medis as `NO. RM`," +
                           "nm_pasien as `NAMA PASIEN`," +
                           "alamat as `ALAMAT PASIEN`," +
                           "no_ktp AS NIK," +
                           "jk as `KLM`," +
                           "DATE_FORMAT(tgl_lahir,'%Y-%m-%d') as `TGL LAHIR`," +
                           "no_tlp as `PHONE`," +
                           "agama as `AGAMA`," +
                           "stts_nikah as `STATUS NIKAH`," +
                           "no_peserta as `NO. PESERTA`," +
                           "kd_pj as `JENIS` " +
                           "FROM pasien WHERE no_rkm_medis = '" + strKeyWord.Trim() + "' " +
                           "OR nm_pasien LIKE '%" + strKeyWord.Trim() + "%' " +
                           "OR alamat LIKE '%" + strKeyWord.Trim() + "%' " +
                           "OR no_ktp LIKE '%" + strKeyWord.Trim() + "%' " +
                           "OR no_peserta LIKE '%" + strKeyWord.Trim() + "%' " +
                           "OR no_tlp = '" + strKeyWord.Trim() + "' " +
                           "ORDER BY nm_pasien ASC";
            }

            DataTable dt = await DataLoader.ExecuteQueryAsync(strQuery.Trim());

            grdPasien.DataSource = dt;
            grdPasien.Columns[0].Width = 75;
            grdPasien.Columns[1].Width = 250;
            grdPasien.Columns[2].Width = 350;
            grdPasien.Columns[3].Width = 150;
            grdPasien.Columns[4].Width = 50;
            grdPasien.Columns[5].Width = 100;
            grdPasien.Columns[6].Width = 100;
            grdPasien.Columns[7].Width = 100;
            grdPasien.Columns[8].Width = 100;
            grdPasien.Columns[9].Width = 150;
            grdPasien.Columns[10].Width = 50;

            splashManager.CloseWaitForm();
        }
        #endregion

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            string? noRM = grdPasien.CurrentRow?.Cells["NO. RM"]?.Value?.ToString()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(noRM))
            {
                MessageBox.Show("No. RM harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var conn = await Databases.OpenConnectionAsync();
                using var cmd = new MySqlCommand("delete_pasien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Menambahkan parameter
                cmd.Parameters.Add(new MySqlParameter("@p_no_rkm_medis", MySqlDbType.VarChar, 15)).Value = noRM.Trim();
                var errorMessageParam = new MySqlParameter("@p_error_message", MySqlDbType.VarChar, 255);
                errorMessageParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(errorMessageParam);
                await cmd.ExecuteNonQueryAsync();

                string? errorMessage = errorMessageParam.Value.ToString();

                if (errorMessage == "SUCCESS")
                {
                    MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RadGridHelper.SafeRemoveCurrentRow(grdPasien);
                    // grdPasien.Rows.RemoveAt(grdPasien.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DefaultSetting();
        }

        private void grdPasien_Click(object sender, EventArgs e)
        {
            btnTambah.Enabled = false;
            btnUbah.Enabled = true;
            btnHapus.Enabled = true;
            btnBatal.Enabled = true;
            btnCetakLabel.Enabled = true;
            btnCetakKartu.Enabled = true;
            btnCetakGelang.Enabled = true;
        }

    }
}
