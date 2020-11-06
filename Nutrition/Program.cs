using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutrition
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

            //Start the launcher this way so we can use .close() when we don't need the launcher anymore
            //Doing it this way preserves the application instead of closing the main thread
            var launch = new Nutrition();
            launch.Show();
            Application.Run();
        }
    }
}
