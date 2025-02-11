using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppWithReact
{
    public class WinFormInterop
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "React Call WinForms", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
