using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDiary
{
    static class Program
    {
        public static string FilePath = Path.Combine(Environment.CurrentDirectory, "students.txt");
        //public static string FilePath2 = Path.Combine(Environment.CurrentDirectory, "classes.txt");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]


        public static string FilePath2 = Path.Combine(Environment.CurrentDirectory, "classes.txt");
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
