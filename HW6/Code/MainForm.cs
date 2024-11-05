using System;
using System.Windows.Forms;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Models;

namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        private SchoolRepository schoolRepo;
        private ClassRepository classRepo;
        private StudentRepository studentRepo;

        public MainForm()
        {
            // 初始化数据库和日志记录
            var database = new Database("Data Source=StudentManagement.db");
            var logRepo = new LogRepository(database);

            // 初始化每个实体的 Repository
            schoolRepo = new SchoolRepository(database, logRepo);
            classRepo = new ClassRepository(database, logRepo);
            studentRepo = new StudentRepository(database, logRepo);

            InitializeComponent();
            LoadSchools();
            LoadClasses();
            LoadStudents();
        }

        // 加载学校数据
        private void LoadSchools()
        {
            dgvSchools.DataSource = schoolRepo.GetSchools();
        }

        // 加载班级数据
        private void LoadClasses()
        {
            dgvClasses.DataSource = classRepo.GetClasses();
            cmbSchools.DataSource = schoolRepo.GetSchools();
            cmbSchools.DisplayMember = "Name";
            cmbSchools.ValueMember = "ID";
        }

        // 加载学生数据
        private void LoadStudents()
        {
            dgvStudents.DataSource = studentRepo.GetStudents();
            cmbClasses.DataSource = classRepo.GetClasses();
            cmbClasses.DisplayMember = "ClassName";
            cmbClasses.ValueMember = "ID";
        }

        // 学校添加事件
        private void BtnAddSchool_Click(object sender, EventArgs e)
        {
            var school = new School
            {
                Name = txtSchoolName.Text,
                CreatedAt = DateTime.Now
            };
            schoolRepo.AddSchool(school);
            LoadSchools();
        }

        // 学校更新事件
        private void BtnUpdateSchool_Click(object sender, EventArgs e)
        {
            if (dgvSchools.SelectedRows.Count > 0)
            {
                var row = dgvSchools.SelectedRows[0];
                var school = new School
                {
                    ID = Convert.ToInt32(row.Cells["ID"].Value),
                    Name = txtSchoolName.Text
                };
                schoolRepo.UpdateSchool(school);
                LoadSchools();
            }
            else
            {
                MessageBox.Show("请先选择要更新的学校！");
            }
        }

        // 学校删除事件
        private void BtnDeleteSchool_Click(object sender, EventArgs e)
        {
            if (dgvSchools.SelectedRows.Count > 0)
            {
                var schoolID = Convert.ToInt32(dgvSchools.SelectedRows[0].Cells["ID"].Value);
                schoolRepo.DeleteSchool(schoolID);
                LoadSchools();
            }
            else
            {
                MessageBox.Show("请先选择要删除的学校！");
            }
        }

        // 班级添加事件
        private void BtnAddClass_Click(object sender, EventArgs e)
        {
            if (cmbSchools.SelectedValue != null)
            {
                var classEntity = new Class
                {
                    ClassName = txtClassName.Text,
                    SchoolID = Convert.ToInt32(cmbSchools.SelectedValue)
                };
                classRepo.AddClass(classEntity);
                LoadClasses();
            }
            else
            {
                MessageBox.Show("请先选择所属学校！");
            }
        }

        // 班级更新事件
        private void BtnUpdateClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0 && cmbSchools.SelectedValue != null)
            {
                var row = dgvClasses.SelectedRows[0];
                var classEntity = new Class
                {
                    ID = Convert.ToInt32(row.Cells["ID"].Value),
                    ClassName = txtClassName.Text,
                    SchoolID = Convert.ToInt32(cmbSchools.SelectedValue)
                };
                classRepo.UpdateClass(classEntity);
                LoadClasses();
            }
            else
            {
                MessageBox.Show("请先选择要更新的班级和所属学校！");
            }
        }

        // 班级删除事件
        private void BtnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                var classID = Convert.ToInt32(dgvClasses.SelectedRows[0].Cells["ID"].Value);
                classRepo.DeleteClass(classID);
                LoadClasses();
            }
            else
            {
                MessageBox.Show("请先选择要删除的班级！");
            }
        }

        // 学生添加事件
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            if (cmbClasses.SelectedValue != null)
            {
                var student = new Student
                {
                    Name = txtStudentName.Text,
                    StudentNumber = txtStudentNumber.Text,
                    Birthdate = dtpBirthdate.Value,
                    Gender = cmbGender.SelectedItem?.ToString(),
                    Hometown = txtHometown.Text,
                    Address = txtAddress.Text,
                    ClassID = Convert.ToInt32(cmbClasses.SelectedValue)
                };
                studentRepo.AddStudent(student);
                LoadStudents();
            }
            else
            {
                MessageBox.Show("请先选择所属班级！");
            }
        }

        // 学生更新事件
        private void BtnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0 && cmbClasses.SelectedValue != null)
            {
                var row = dgvStudents.SelectedRows[0];
                var student = new Student
                {
                    ID = Convert.ToInt32(row.Cells["ID"].Value),
                    Name = txtStudentName.Text,
                    StudentNumber = txtStudentNumber.Text,
                    Birthdate = dtpBirthdate.Value,
                    Gender = cmbGender.SelectedItem?.ToString(),
                    Hometown = txtHometown.Text,
                    Address = txtAddress.Text,
                    ClassID = Convert.ToInt32(cmbClasses.SelectedValue)
                };
                studentRepo.UpdateStudent(student);
                LoadStudents();
            }
            else
            {
                MessageBox.Show("请先选择要更新的学生和所属班级！");
            }
        }

        // 学生删除事件
        private void BtnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["ID"].Value);
                studentRepo.DeleteStudent(studentID);
                LoadStudents();
            }
            else
            {
                MessageBox.Show("请先选择要删除的学生！");
            }
        }
    }
}
