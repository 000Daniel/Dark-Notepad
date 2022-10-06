using System;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Count() > 0)
            {
                Application.Run(new Notepad(args[0]));
            }
            else
            {
                Application.Run(new Notepad(String.Empty));
            }
        }
    }
}
