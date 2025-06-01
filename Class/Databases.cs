using DevExpress.XtraRichEdit.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Class
{
    public class Databases
    {
        private static readonly string _connectionString;
                
        static Databases()
        {
            var dec = AesEncryptionService.CreateService();
            string Decrypt(string key) => dec.Decrypt(Convert.FromBase64String(EnvConfig.Get(key)));

            _connectionString = $"Server={Decrypt("DB_SERVER_HOST")};" +
                                $"Database={Decrypt("DB_SERVER_DB")};" +
                                $"User Id={Decrypt("DB_SERVER_USER")};" +
                                $"Password={Decrypt("DB_SERVER_PASS")};" +
                                $"Port={EnvConfig.Get("DB_SERVER_PORT")};" +
                                $"Connect Timeout=5;SslMode=none;";
        }
        public static async Task<MySqlConnection?> OpenConnectionAsync()
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
                    MessageBox.Show("Tidak dapat menjangkau server MySQL (Ping gagal).", "Koneksi Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Dispose();
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Koneksi ke database gagal:\n{ex.Message}", "Koneksi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan:\n{ex.Message}", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Dispose();
                return null;
            }
        }

        public static async Task<DataTable> ExecuteQueryAsync(string query)
        {
            var dataTable = new DataTable();

            try
            {
                using var connection = await OpenConnectionAsync();
                if (connection == null)
                {
                    MessageBox.Show("Gagal membuka koneksi database.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return dataTable;
                }

                using var cmd = new MySqlCommand(query, connection);
                using var reader = await cmd.ExecuteReaderAsync();

                dataTable.Load(reader);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"[MySQL Error] {ex.Message}", "Kesalahan Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[General Error] {ex.Message}", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        // Overload untuk parameterized query (optional)
        public static async Task<DataTable> ExecuteQueryAsync(string query, params MySqlParameter[] parameters)
        {
            var dataTable = new DataTable();

            try
            {
                using var connection = await OpenConnectionAsync();
                if (connection == null)
                {
                    MessageBox.Show("Gagal membuka koneksi database.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return dataTable;
                }

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddRange(parameters);
                using var reader = await cmd.ExecuteReaderAsync();

                dataTable.Load(reader);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"[MySQL Error] {ex.Message}", "Kesalahan Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[General Error] {ex.Message}", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static async Task<int> ExecuteNonQueryAsync(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using var connection = await OpenConnectionAsync();
                if (connection == null) return 0;

                using var cmd = new MySqlCommand(query, connection);
                if (parameters?.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ExecuteNonQuery Error] {ex.Message}", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<object?> ExecuteScalarAsync(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using var connection = await OpenConnectionAsync();
                if (connection == null) return null;

                using var cmd = new MySqlCommand(query, connection);
                if (parameters?.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteScalarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ExecuteScalar Error] {ex.Message}", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
