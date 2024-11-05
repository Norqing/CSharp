using System.Data;
using System.Data.SQLite;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class StudentRepository
    {
        private Database database;
        private LogRepository logRepo;

        public StudentRepository(Database db, LogRepository logRepo)
        {
            database = db;
            this.logRepo = logRepo;
        }

        // 添加学生
        public void AddStudent(Student student)
        {
            string query = "INSERT INTO Student (Name, StudentNumber, Birthdate, Gender, Hometown, Address, ClassID) " +
                           "VALUES (@Name, @StudentNumber, @Birthdate, @Gender, @Hometown, @Address, @ClassID)";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Hometown", student.Hometown);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@ClassID", student.ClassID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Added student: {student.Name}");
        }

        // 更新学生
        public void UpdateStudent(Student student)
        {
            string query = "UPDATE Student SET Name = @Name, StudentNumber = @StudentNumber, Birthdate = @Birthdate, " +
                           "Gender = @Gender, Hometown = @Hometown, Address = @Address, ClassID = @ClassID WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Hometown", student.Hometown);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@ClassID", student.ClassID);
            cmd.Parameters.AddWithValue("@ID", student.ID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Updated student with ID: {student.ID}");
        }

        // 删除学生
        public void DeleteStudent(int studentID)
        {
            string query = "DELETE FROM Student WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, database.GetConnection());
            cmd.Parameters.AddWithValue("@ID", studentID);

            database.OpenConnection();
            cmd.ExecuteNonQuery();
            database.CloseConnection();

            logRepo.AddLog($"Deleted student with ID: {studentID}");
        }

        // 查询所有学生
        public DataTable GetStudents()
        {
            string query = "SELECT * FROM Student";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, database.GetConnection());
            DataTable studentTable = new DataTable();

            database.OpenConnection();
            adapter.Fill(studentTable);
            database.CloseConnection();

            return studentTable;
        }
    }
}
