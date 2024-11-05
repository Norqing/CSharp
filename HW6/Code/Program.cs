using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "Data Source=StudentManagement.db";
            DatabaseInitializer.InitializeDatabase(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
