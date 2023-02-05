/*

Copyright (c) 2023 Gary Des Roches

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation files
(the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

Any person wishing to distribute modifications to the Software is
asked to send the modifications to the original developer so that
they can be incorporated into the canonical version.  This is,
however, not a binding provision of this license.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

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
