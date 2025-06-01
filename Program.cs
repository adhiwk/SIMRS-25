using SIMRS25.Class;

namespace SIMRS25
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            EnvConfig.Load(); // load dari .env

            string base64Key = EnvConfig.Get("ENCRYPTION_KEY");
            string base64IV = EnvConfig.Get("ENCRYPTION_IV");


            AesEncryptionService.Initialize(base64Key, base64IV);

            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.Utils.SecurityText());
        }
    }
}