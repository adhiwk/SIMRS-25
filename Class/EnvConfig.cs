using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Class
{
    public static class EnvConfig
    {
        private static bool _loaded = false;

        // Panggil saat aplikasi mulai
        public static void Load(string? envPath = null)
        {
            if (!_loaded)
            {
                if (!string.IsNullOrEmpty(envPath))
                    Env.Load(envPath); // load dari path khusus
                else
                    Env.Load(); // load .env dari default lokasi

                _loaded = true;
            }
        }

        // Ambil string value
        public static string Get(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException($"Environment variable '{key}' tidak ditemukan.");

            return value;
        }

        // Ambil int
        public static int GetInt(string key)
        {
            var value = Get(key);
            return int.TryParse(value, out var result)
                ? result
                : throw new FormatException($"Environment variable '{key}' tidak valid sebagai integer.");
        }

        // Ambil bool
        public static bool GetBool(string key)
        {
            var value = Get(key);
            return bool.TryParse(value, out var result)
                ? result
                : throw new FormatException($"Environment variable '{key}' tidak valid sebagai boolean.");
        }

        // Ambil TimeSpan (misal offset waktu)
        public static TimeSpan GetTimeSpan(string key)
        {
            var value = Get(key);
            return TimeSpan.TryParse(value, out var result)
                ? result
                : throw new FormatException($"Environment variable '{key}' tidak valid sebagai TimeSpan.");
        }
    }
}
