using System;
using System.Collections.Generic;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Backtracking
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
