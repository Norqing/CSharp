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
            // ��ʼ�����ݿ����־��¼
            var database = new Database("Data Source=StudentManagement.db");
            var logRepo = new LogRepository(database);

            // ��ʼ��ÿ��ʵ��� Repository
            schoolRepo = new SchoolRepository(database, logRepo);
            classRepo = new ClassRepository(database, logRepo);
            studentRepo = new StudentRepository(database, logRepo);

            InitializeComponent();
            LoadSchools();
            LoadClasses();
            LoadStudents();
        }

        // ����ѧУ����
        private void LoadSchools()
        {
            dgvSchools.DataSource = schoolRepo.GetSchools();
        }

        // ���ذ༶����
        private void LoadClasses()
        {
            dgvClasses.DataSource = classRepo.GetClasses();
            cmbSchools.DataSource = schoolRepo.GetSchools();
            cmbSchools.DisplayMember = "Name";
            cmbSchools.ValueMember = "ID";
        }

        // ����ѧ������
        private void LoadStudents()
        {
            dgvStudents.DataSource = studentRepo.GetStudents();
            cmbClasses.DataSource = classRepo.GetClasses();
            cmbClasses.DisplayMember = "ClassName";
            cmbClasses.ValueMember = "ID";
        }

        // ѧУ����¼�
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

        // ѧУ�����¼�
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
                MessageBox.Show("����ѡ��Ҫ���µ�ѧУ��");
            }
        }

        // ѧУɾ���¼�
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
                MessageBox.Show("����ѡ��Ҫɾ����ѧУ��");
            }
        }

        // �༶����¼�
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
                MessageBox.Show("����ѡ������ѧУ��");
            }
        }

        // �༶�����¼�
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
                MessageBox.Show("����ѡ��Ҫ���µİ༶������ѧУ��");
            }
        }

        // �༶ɾ���¼�
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
                MessageBox.Show("����ѡ��Ҫɾ���İ༶��");
            }
        }

        // ѧ������¼�
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
                MessageBox.Show("����ѡ�������༶��");
            }
        }

        // ѧ�������¼�
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
                MessageBox.Show("����ѡ��Ҫ���µ�ѧ���������༶��");
            }
        }

        // ѧ��ɾ���¼�
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
                MessageBox.Show("����ѡ��Ҫɾ����ѧ����");
            }
        }
    }
}
