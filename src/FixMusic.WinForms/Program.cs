using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace FixMusic.WinForms
{
    class Program : IDisposable
    {
        private Program(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configurarion = builder.Build();
            AppSettings appSettings = configurarion.GetSection("AppSettings").Get<AppSettings>();

            _mainForm = new MainForm(appSettings);
        }

        private void Run()
        {
            Application.Run(_mainForm);
        }

        private readonly MainForm _mainForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using var app = new Program(args);
            app.Run();
        }

        #region Dispose Pattern

        protected virtual void Dispose(bool isExplicit)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isExplicit)
            {
                _mainForm.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose() => Dispose(isExplicit: true);

        private bool _isDisposed;

        #endregion
    }
}
