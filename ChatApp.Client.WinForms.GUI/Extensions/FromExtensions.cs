using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms.GUI.Extensions
{
    public static class FromExtensions
    {
        public static void OpenNextForm(this Form currentForm, Form nextForm)
        {

            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Location = currentForm.Location;
            nextForm.Width = currentForm.Width;
            nextForm.Height = currentForm.Height;
            currentForm.Hide();
            nextForm.ShowDialog();
            currentForm.Close();
        }
    }
}
