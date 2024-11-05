using System.Data.SQLite;

namespace StudentManagementSystem

{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createSchoolTable = @"
                CREATE TABLE IF NOT EXISTS School (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    ClassCount INTEGER DEFAULT 0,
                    StudentCount INTEGER DEFAULT 0,
                    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                );";

                string createClassTable = @"
                CREATE TABLE IF NOT EXISTS Class (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClassName TEXT NOT NULL,
                    StudentCount INTEGER DEFAULT 0,
                    SchoolID INTEGER,
                    FOREIGN KEY (SchoolID) REFERENCES School(ID) ON DELETE CASCADE
                );";

                string createStudentTable = @"
                CREATE TABLE IF NOT EXISTS Student (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    StudentNumber TEXT UNIQUE,
                    Birthdate DATETIME,
                    Gender TEXT,
                    Hometown TEXT,
                    Address TEXT,
                    ClassID INTEGER,
                    FOREIGN KEY (ClassID) REFERENCES Class(ID) ON DELETE CASCADE
                );";

                string createLogTable = @"
                CREATE TABLE IF NOT EXISTS Log (
                    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Action TEXT NOT NULL,
                    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                );";

                using (var command = new SQLiteCommand(createSchoolTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createClassTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createStudentTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createLogTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
