using System;
using System.Data.SQLite;

namespace StudentManagementSystem.Repositories
{
    public class LogRepository
    {
        private Database database;

        public LogRepository(Database db)
        {
            database = db;
        }

        // 添加日志记录
        public void AddLog(string action)
        {
            string query = "INSERT INTO Log (Action, Timestamp) VALUES (@Action, @Timestamp)";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();
        }
    }
}
