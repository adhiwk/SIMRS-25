using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace SIMRS25.Class
{
    public static class GlobalVar
    {
        public static string? Username;
    }
    public class Helpers
    {
        public static bool ValidateField(string fieldValue, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(fieldValue))
            {
                MessageBox.Show(errorMessage, "Error");
                return false;
            }
            return true;
        }

        public async static Task<DateTime> GetDateTime()
        {
            DateTime dtTglJam = DateTime.Now;
            try
            {
                using (var Conn = await Databases.OpenConnectionAsync())
                {
                    using (var mySqlCommand = new MySqlCommand("SELECT DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s') as TGL_JAM", Conn))
                    {
                        var result = await mySqlCommand.ExecuteScalarAsync();
                        if (result != null)
                        {
                            string? dateString = result.ToString();

                            // Parsing dengan format tetap (YYYY-MM-DD HH:MM:SS)
                            if (!DateTime.TryParseExact(dateString, "yyyy-MM-dd HH:mm:ss",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtTglJam))
                            {
                                Console.WriteLine("Gagal parsing tanggal, gunakan DateTime.Now sebagai fallback.");
                                dtTglJam = DateTime.Now;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Menggunakan DateTime.Now sebagai fallback.");
            }

            return dtTglJam;
        }

        public async static Task<DateTime> GetDateTimeUtc()
        {
            DateTime dtTglJam = DateTime.UtcNow; // Default ke UTC Now

            try
            {
                using (var mySqlConnection = await Databases.OpenConnectionAsync())
                {
                    // Gunakan DATE_FORMAT agar MySQL mengembalikan format yang pasti
                    using (var mySqlCommand = new MySqlCommand("SELECT UTC_TIMESTAMP()", mySqlConnection))
                    {
                        var result = await mySqlCommand.ExecuteScalarAsync();
                        if (result != null && result is DateTime mysqlTime)
                        {
                            dtTglJam = DateTime.SpecifyKind(mysqlTime, DateTimeKind.Utc); // Pastikan tetap UTC
                        }
                        else
                        {
                            Console.WriteLine("Gagal parsing waktu dari MySQL, fallback ke DateTime.UtcNow");
                            dtTglJam = DateTime.UtcNow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Menggunakan DateTime.UtcNow sebagai fallback.");
            }

            return dtTglJam;
        }

        public static long ConvertToTimestampMilliseconds(DateTime dateTime)
        {
            /* 
             * Pastikan waktu yang dikonversi adalah UTC
             * 
             * contoh penggunaaan
             * 
             *  DateTime inputUtc = new DateTime(2025, 2, 14, 10, 25, 0, DateTimeKind.Utc);
             *  long timestampUtc = TimeHelper.ConvertToTimestampMilliseconds(inputUtc);
             *  Console.WriteLine(timestampUtc);
             *  
             */

            DateTime utcDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            // Konversi ke timestamp milisecond
            return new DateTimeOffset(utcDateTime).ToUnixTimeMilliseconds();
        }

        public static async Task<TimeSpan> GetTime()
        {
            TimeSpan jam = TimeSpan.Zero;
            using var mySqlConnection = await Databases.OpenConnectionAsync();

            try
            {
                using var mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = "SELECT CURRENT_TIME()  as JAM";

                using var mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();
                if (await mySqlDataReader.ReadAsync())
                {
                    // Mengambil waktu sebagai TimeSpan
                    jam = TimeSpan.Parse(mySqlDataReader["JAM"]!.ToString()!);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jam;
        }

        public static (int umur, string status_umur) StatusUmur(DateTime tanggalLahir, DateTime tanggalSekarang)
        {
            // Hitung perbedaan antara tanggal lahir dan tanggal sekarang
            TimeSpan selisih = tanggalSekarang - tanggalLahir;

            if (selisih.Days >= 365)
            {
                int umurTahun = selisih.Days / 365;
                return (umurTahun, "Th");
            }
            else if (selisih.Days >= 30)
            {
                int umurBulan = selisih.Days / 30;
                return (umurBulan, "Bl");
            }
            else
            {
                return (selisih.Days, "Hr");
            }
        }

        public static string TrimTo50Characters(string input)
        {
            if (input.Length > 50)
            {
                return input.Substring(0, 50);
            }
            return input;
        }

        public static string DateToString(DevExpress.XtraEditors.DateEdit dtControl)
        {
            return dtControl.DateTime.ToString("yyyy-MM-dd");
        }

        //refactor hitung umur
        public static string HitungUmur(DateTime tglLahir)
        {
            DateTime today = DateTime.Today;
            int years = CalculateYears(today, tglLahir);
            int months = CalculateMonths(today, tglLahir);
            int days = CalculateDays(today, tglLahir);

            return $"{years} thn {months} bln {days} hari";
        }

        private static int CalculateYears(DateTime today, DateTime tglLahir)
        {
            int years = today.Year - tglLahir.Year;
            if (today < tglLahir.AddYears(years))
            {
                years--;
            }
            return years;
        }

        private static int CalculateMonths(DateTime today, DateTime tglLahir)
        {
            int months = today.Month - tglLahir.Month;
            if (today.Day < tglLahir.Day)
            {
                months--;
            }
            if (months < 0)
            {
                months += 12;
            }
            return months;
        }

        private static int CalculateDays(DateTime today, DateTime tglLahir)
        {
            int days;
            if (today.Day >= tglLahir.Day)
            {
                days = today.Day - tglLahir.Day;
            }
            else
            {
                var lastMonth = today.AddMonths(-1);
                days = (DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month) - tglLahir.Day) + today.Day;
            }
            return days;
        }

        public static void GridRowFormatting(object sender, RowFormattingEventArgs e)
        {
            // Reset semua nilai agar tidak ada pewarnaan yang bertumpuk
            e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);

            if (e.RowElement.RowInfo.Cells["STATUS"]?.Value is string status)
            {
                Color rowColor;

                switch (status)
                {
                    case "Belum": rowColor = ColorTranslator.FromHtml("#A8DF8E"); break;
                    case "Sudah": rowColor = Color.LightGray; break;
                    case "Batal": rowColor = ColorTranslator.FromHtml("#FFBFBF"); break;
                    case "Berkas Diterima": rowColor = ColorTranslator.FromHtml("#BEADFA"); break;
                    case "Dirujuk": rowColor = ColorTranslator.FromHtml("#96B6C5"); break;
                    case "Meninggal": rowColor = ColorTranslator.FromHtml("#EEE0C9"); break;
                    case "Dirawat": rowColor = ColorTranslator.FromHtml("#6E85B7"); break;
                    case "Pulang Paksa": rowColor = ColorTranslator.FromHtml("#FF87B2"); break;
                    default: return; // Jika status tidak dikenali, biarkan tetap default
                }

                // Set warna hanya jika status valid
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = rowColor;
            }
        }

        public static void GridCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement == null || e.CellElement.RowInfo == null) return;

            bool isCurrent = e.CellElement.RowInfo.IsCurrent;

            e.CellElement.DrawFill = true;
            e.CellElement.GradientStyle = GradientStyles.Solid;

            Color rowColor = e.CellElement.BackColor;
            if (e.CellElement.RowInfo.Cells["STATUS"]?.Value is string status)
            {
                switch (status)
                {
                    case "Belum": rowColor = ColorTranslator.FromHtml("#A8DF8E"); break;
                    case "Sudah": rowColor = ColorTranslator.FromHtml("#FFB4A2"); break;
                    case "Batal": rowColor = ColorTranslator.FromHtml("#FFBFBF"); break;
                    case "Berkas Diterima": rowColor = ColorTranslator.FromHtml("#BEADFA"); break;
                    case "Dirujuk": rowColor = ColorTranslator.FromHtml("#96B6C5"); break;
                    case "Meninggal": rowColor = ColorTranslator.FromHtml("#EEE0C9"); break;
                    case "Dirawat": rowColor = ColorTranslator.FromHtml("#6E85B7"); break;
                    case "Pulang Paksa": rowColor = ColorTranslator.FromHtml("#FF87B2"); break;
                    default: return; // Jika status tidak dikenali, biarkan tetap default
                }
            }

            // Gunakan warna dari current row color agar warna tetap sesuai
            e.CellElement.BackColor = isCurrent ? ColorTranslator.FromHtml("#3674B5") : rowColor;
            e.CellElement.ForeColor = isCurrent ? Color.White : Color.Black;
        }
      
        //Handler untuk Row Formatting grid pasien
        public static void GridPasienRowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["JENIS"]?.Value is string jenis)
            {
                e.RowElement.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;

                var colors = new Dictionary<string, string>
                {
                    { "UMU", "#BFECFF" },
                    { "ASR", "#CDC1FF" },
                    { "BPJ", "#FFF6E3" }
                };

                if (colors.TryGetValue(jenis, out var hexColor))
                {
                    e.RowElement.BackColor = ColorTranslator.FromHtml(hexColor);
                }
            }
        }

        // Handler untuk Cell Formatting
        public static void GridPasienCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement?.RowInfo == null) return;

            bool isCurrent = e.CellElement.RowInfo.IsCurrent;
            e.CellElement.DrawFill = true;
            e.CellElement.GradientStyle = GradientStyles.Solid;

            var colors = new Dictionary<string, string>
            {
                { "UMU", "#BFECFF" },
                { "ASR", "#CDC1FF" },
                { "BPJ", "#FFF6E3" }
            };

            string defaultColor = "#A1E3F9";
            string cellColor = e.CellElement.RowInfo.Cells["JENIS"]?.Value is string jenis 
                && colors.TryGetValue(jenis, out var hexColor) ? hexColor : defaultColor;

            e.CellElement.BackColor = isCurrent ? ColorTranslator.FromHtml("#3674B5") : ColorTranslator.FromHtml(cellColor);
            e.CellElement.ForeColor = isCurrent ? Color.White : Color.Black;
        }
    }
}
