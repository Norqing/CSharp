using System.Data;
using System.Data.SQLite;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.Repositories
{
    public class ClassRepository
    {
        private Database database;
        private LogRepository logRepo;

        public ClassRepository(Database db, LogRepository logRepo)
        {
            database = db;
            this.logRepo = logRepo;
        }

        // 添加班级
        public void AddClass(Class classEntity)
        {
            string query = "INSERT INTO Class (ClassName, StudentCount, SchoolID) VALUES (@ClassName, @StudentCount, @SchoolID)";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@ClassName", classEntity.ClassName);
            cmd.Parameters.AddWithValue("@StudentCount", classEntity.StudentCount);
            cmd.Parameters.AddWithValue("@SchoolID", classEntity.SchoolID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Added class: {classEntity.ClassName}");
        }

        // 更新班级
        public void UpdateClass(Class classEntity)
        {
            string query = "UPDATE Class SET ClassName = @ClassName, SchoolID = @SchoolID WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@ClassName", classEntity.ClassName);
            cmd.Parameters.AddWithValue("@SchoolID", classEntity.SchoolID);
            cmd.Parameters.AddWithValue("@ID", classEntity.ID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Updated class with ID: {classEntity.ID}");
        }

        // 删除班级
        public void DeleteClass(int classID)
        {
            string query = "DELETE FROM Class WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@ID", classID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Deleted class with ID: {classID}");
        }

        // 查询所有班级
        public DataTable GetClasses()
        {
            string query = "SELECT * FROM Class";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, database.GetConnection());
            DataTable classTable = new DataTable();

            database.OpenConnection();
            adapter.Fill(classTable);
            database.CloseConnection();

            return classTable;
        }
    }
}
