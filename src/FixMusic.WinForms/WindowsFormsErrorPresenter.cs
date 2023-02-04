using System.Windows.Forms;

namespace FixMusic.WinForms
{
    class WindowsFormsErrorPresenter : IErrorPresenter
    {
        public void DisplayError(string message)
        {
            MessageBox.Show($"Error: {message}", Application.ProductName, MessageBoxButtons.OK);
        }
    }
}
