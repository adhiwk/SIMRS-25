using DevExpress.XtraPrinting.Native;
using MySql.Data.MySqlClient;
using SIMRS25.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Bpjs
{
    public class BpjsHeaders
    {
        private static readonly string _connectionString;
        private static string Decrypt(string key)
        {
            var dec = AesEncryptionService.CreateService();
            return dec.Decrypt(Convert.FromBase64String(EnvConfig.Get(key)));
        }
        static BpjsHeaders()
        {
            //var dec = AesEncryptionService.CreateService();
            //string Decrypt(string key) => dec.Decrypt(Convert.FromBase64String(EnvConfig.Get(key)));

            _connectionString = $"Server={Decrypt("DB_SERVER_HOST")};" +
                                $"Database={Decrypt("DB_SERVER_DB")};" +
                                $"User Id={Decrypt("DB_SERVER_USER")};" +
                                $"Password={Decrypt("DB_SERVER_PASS")};" +
                                $"Port={EnvConfig.Get("DB_SERVER_PORT")};" +
                                $"Connect Timeout=5;SslMode=none;";
        }

        private static async Task<MySqlConnection?> _OpenConnectionAsync()
        {
            var conn = new MySqlConnection(_connectionString);

            try
            {
                await conn.OpenAsync();

                if (conn.Ping())
                {
                    return conn; // sukses
                }
                else
                {
                    Console.WriteLine("koneksi ke database gagal dibuka");
                    conn.Dispose();
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conn.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Dispose();
                return null;
            }
        }

        private async static Task<DateTime> GetTimeUtc()
        {
            DateTime dtTglJam = DateTime.UtcNow; // Default ke UTC Now

            try
            {
                using (var mySqlConnection = await _OpenConnectionAsync())
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
        /**** end of mysql **/

        public static string TimeToUnix(DateTime dteDate)
        {
            return new DateTimeOffset(dteDate).ToUnixTimeSeconds().ToString();
        }

        public static async Task<string> TimeStamp()
        {
            string environment = EnvConfig.Get("UTC_SERVER_ENVIRONMENT");

            DateTime utcTime = await (environment == "production"
                ? GetTimeUtc()
                : Helpers.GetDateTimeUtc());

            string xTimeStamp = TimeToUnix(utcTime);
            return xTimeStamp;
        }

        public static string TimeStampTest(DateTime Utctime)
        {
            //DateTime dateNow = Helper.GetDateTime();
            string xTimeStamp = TimeToUnix(Utctime);
            return xTimeStamp;
        }

        public static string CreateSignature(string cData, string userKey)
        {


            using (var hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(userKey)))
            {
                var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(cData.Trim()));
                string xSignature = Convert.ToBase64String(signature);
                return xSignature.Trim();
            }
        }
    }
}
