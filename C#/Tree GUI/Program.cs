using System;
using System.Windows.Forms;

namespace Tree_GUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new View();
            var presenter = new Presenter(view);
            Application.Run(view);
        }
    }
}
