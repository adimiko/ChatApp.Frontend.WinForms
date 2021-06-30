using ChatApp.Client.WinForms.Connection;
using ChatApp.Client.WinForms.GUI.Forms;
using ChatApp.Client.WinForms.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //await SimpleInjectorContainer.GetContainer().GetInstance<ConnectionHub>().Connect();
                //Application.Run(SimpleInjectorContainer.GetContainer().GetInstance<MainForm>());
                Application.Run(new MainForm());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
