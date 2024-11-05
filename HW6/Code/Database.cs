using System.Data.SQLite;

namespace StudentManagementSystem
{
    public class Database
    {
        private SQLiteConnection conn;

        public Database(string connectionString)
        {
            conn = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public SQLiteConnection GetConnection()
        {
            return conn;
        }
    }
}