using System.Data;
using System.Data.SQLite;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.Repositories
{
    public class SchoolRepository
    {
        private Database database;
        private LogRepository logRepo;

        public SchoolRepository(Database db, LogRepository logRepo)
        {
            database = db;
            this.logRepo = logRepo;
        }

        // 添加学校
        public void AddSchool(School school)
        {
            string query = "INSERT INTO School (Name, ClassCount, StudentCount, CreatedAt) VALUES (@Name, @ClassCount, @StudentCount, @CreatedAt)";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@Name", school.Name);
            cmd.Parameters.AddWithValue("@ClassCount", school.ClassCount);
            cmd.Parameters.AddWithValue("@StudentCount", school.StudentCount);
            cmd.Parameters.AddWithValue("@CreatedAt", school.CreatedAt);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Added school: {school.Name}");
        }

        // 更新学校
        public void UpdateSchool(School school)
        {
            string query = "UPDATE School SET Name = @Name WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@Name", school.Name);
            cmd.Parameters.AddWithValue("@ID", school.ID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Updated school with ID: {school.ID}");
        }

        // 删除学校
        public void DeleteSchool(int schoolID)
        {
            string query = "DELETE FROM School WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@ID", schoolID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Deleted school with ID: {schoolID}");
        }

        // 查询所有学校
        public DataTable GetSchools()
        {
            string query = "SELECT * FROM School";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, database.GetConnection());
            DataTable schoolTable = new DataTable();

            database.OpenConnection();
            adapter.Fill(schoolTable);
            database.CloseConnection();

            return schoolTable;
        }
    }
}
