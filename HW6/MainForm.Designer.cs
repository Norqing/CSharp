namespace StudentManagementSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            schoolTabPage = new TabPage();
            dgvSchools = new DataGridView();
            txtSchoolName = new TextBox();
            btnAddSchool = new Button();
            btnUpdateSchool = new Button();
            btnDeleteSchool = new Button();
            classTabPage = new TabPage();
            dgvClasses = new DataGridView();
            txtClassName = new TextBox();
            cmbSchools = new ComboBox();
            btnAddClass = new Button();
            btnUpdateClass = new Button();
            btnDeleteClass = new Button();
            studentTabPage = new TabPage();
            dgvStudents = new DataGridView();
            txtStudentName = new TextBox();
            txtStudentNumber = new TextBox();
            dtpBirthdate = new DateTimePicker();
            cmbGender = new ComboBox();
            txtHometown = new TextBox();
            txtAddress = new TextBox();
            cmbClasses = new ComboBox();
            btnAddStudent = new Button();
            btnUpdateStudent = new Button();
            btnDeleteStudent = new Button();
            tabControl.SuspendLayout();
            schoolTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchools).BeginInit();
            classTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            studentTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(schoolTabPage);
            tabControl.Controls.Add(classTabPage);
            tabControl.Controls.Add(studentTabPage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 600);
            tabControl.TabIndex = 0;
            // 
            // schoolTabPage
            // 
            schoolTabPage.Controls.Add(dgvSchools);
            schoolTabPage.Controls.Add(txtSchoolName);
            schoolTabPage.Controls.Add(btnAddSchool);
            schoolTabPage.Controls.Add(btnUpdateSchool);
            schoolTabPage.Controls.Add(btnDeleteSchool);
            schoolTabPage.Location = new Point(4, 29);
            schoolTabPage.Name = "schoolTabPage";
            schoolTabPage.Size = new Size(792, 567);
            schoolTabPage.TabIndex = 0;
            schoolTabPage.Text = "学校管理";
            // 
            // dgvSchools
            // 
            dgvSchools.ColumnHeadersHeight = 29;
            dgvSchools.Location = new Point(10, 10);
            dgvSchools.Name = "dgvSchools";
            dgvSchools.RowHeadersWidth = 51;
            dgvSchools.Size = new Size(750, 200);
            dgvSchools.TabIndex = 0;
            // 
            // txtSchoolName
            // 
            txtSchoolName.Location = new Point(10, 220);
            txtSchoolName.Name = "txtSchoolName";
            txtSchoolName.PlaceholderText = "学校名称";
            txtSchoolName.Size = new Size(200, 27);
            txtSchoolName.TabIndex = 1;
            // 
            // btnAddSchool
            // 
            btnAddSchool.Location = new Point(220, 220);
            btnAddSchool.Name = "btnAddSchool";
            btnAddSchool.Size = new Size(94, 27);
            btnAddSchool.TabIndex = 2;
            btnAddSchool.Text = "添加学校";
            // 
            // btnUpdateSchool
            // 
            btnUpdateSchool.Location = new Point(320, 220);
            btnUpdateSchool.Name = "btnUpdateSchool";
            btnUpdateSchool.Size = new Size(94, 27);
            btnUpdateSchool.TabIndex = 3;
            btnUpdateSchool.Text = "更新学校";
            // 
            // btnDeleteSchool
            // 
            btnDeleteSchool.Location = new Point(420, 220);
            btnDeleteSchool.Name = "btnDeleteSchool";
            btnDeleteSchool.Size = new Size(83, 30);
            btnDeleteSchool.TabIndex = 4;
            btnDeleteSchool.Text = "删除学校";
            // 
            // classTabPage
            // 
            classTabPage.Controls.Add(dgvClasses);
            classTabPage.Controls.Add(txtClassName);
            classTabPage.Controls.Add(cmbSchools);
            classTabPage.Controls.Add(btnAddClass);
            classTabPage.Controls.Add(btnUpdateClass);
            classTabPage.Controls.Add(btnDeleteClass);
            classTabPage.Location = new Point(4, 29);
            classTabPage.Name = "classTabPage";
            classTabPage.Size = new Size(792, 567);
            classTabPage.TabIndex = 1;
            classTabPage.Text = "班级管理";
            // 
            // dgvClasses
            // 
            dgvClasses.ColumnHeadersHeight = 29;
            dgvClasses.Location = new Point(10, 10);
            dgvClasses.Name = "dgvClasses";
            dgvClasses.RowHeadersWidth = 51;
            dgvClasses.Size = new Size(750, 200);
            dgvClasses.TabIndex = 0;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(10, 220);
            txtClassName.Name = "txtClassName";
            txtClassName.PlaceholderText = "班级名称";
            txtClassName.Size = new Size(200, 27);
            txtClassName.TabIndex = 1;
            // 
            // cmbSchools
            // 
            cmbSchools.Location = new Point(220, 220);
            cmbSchools.Name = "cmbSchools";
            cmbSchools.Size = new Size(200, 28);
            cmbSchools.TabIndex = 2;
            // 
            // btnAddClass
            // 
            btnAddClass.Location = new Point(430, 220);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(75, 23);
            btnAddClass.TabIndex = 3;
            btnAddClass.Text = "添加班级";
            // 
            // btnUpdateClass
            // 
            btnUpdateClass.Location = new Point(530, 220);
            btnUpdateClass.Name = "btnUpdateClass";
            btnUpdateClass.Size = new Size(75, 23);
            btnUpdateClass.TabIndex = 4;
            btnUpdateClass.Text = "更新班级";
            // 
            // btnDeleteClass
            // 
            btnDeleteClass.Location = new Point(630, 220);
            btnDeleteClass.Name = "btnDeleteClass";
            btnDeleteClass.Size = new Size(75, 23);
            btnDeleteClass.TabIndex = 5;
            btnDeleteClass.Text = "删除班级";
            // 
            // studentTabPage
            // 
            studentTabPage.Controls.Add(dgvStudents);
            studentTabPage.Controls.Add(txtStudentName);
            studentTabPage.Controls.Add(txtStudentNumber);
            studentTabPage.Controls.Add(dtpBirthdate);
            studentTabPage.Controls.Add(cmbGender);
            studentTabPage.Controls.Add(txtHometown);
            studentTabPage.Controls.Add(txtAddress);
            studentTabPage.Controls.Add(cmbClasses);
            studentTabPage.Controls.Add(btnAddStudent);
            studentTabPage.Controls.Add(btnUpdateStudent);
            studentTabPage.Controls.Add(btnDeleteStudent);
            studentTabPage.Location = new Point(4, 29);
            studentTabPage.Name = "studentTabPage";
            studentTabPage.Size = new Size(792, 567);
            studentTabPage.TabIndex = 2;
            studentTabPage.Text = "学生管理";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeight = 29;
            dgvStudents.Location = new Point(10, 10);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(750, 200);
            dgvStudents.TabIndex = 0;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(10, 220);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.PlaceholderText = "学生姓名";
            txtStudentName.Size = new Size(150, 27);
            txtStudentName.TabIndex = 1;
            // 
            // txtStudentNumber
            // 
            txtStudentNumber.Location = new Point(170, 220);
            txtStudentNumber.Name = "txtStudentNumber";
            txtStudentNumber.PlaceholderText = "学号";
            txtStudentNumber.Size = new Size(150, 27);
            txtStudentNumber.TabIndex = 2;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Location = new Point(330, 220);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(150, 27);
            dtpBirthdate.TabIndex = 3;
            // 
            // cmbGender
            // 
            cmbGender.Items.AddRange(new object[] { "男", "女" });
            cmbGender.Location = new Point(490, 220);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(100, 28);
            cmbGender.TabIndex = 4;
            // 
            // txtHometown
            // 
            txtHometown.Location = new Point(10, 260);
            txtHometown.Name = "txtHometown";
            txtHometown.PlaceholderText = "家乡";
            txtHometown.Size = new Size(200, 27);
            txtHometown.TabIndex = 5;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(220, 260);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "地址";
            txtAddress.Size = new Size(300, 27);
            txtAddress.TabIndex = 6;
            // 
            // cmbClasses
            // 
            cmbClasses.Location = new Point(530, 260);
            cmbClasses.Name = "cmbClasses";
            cmbClasses.Size = new Size(100, 28);
            cmbClasses.TabIndex = 7;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(10, 300);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(75, 23);
            btnAddStudent.TabIndex = 8;
            btnAddStudent.Text = "添加学生";
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new Point(120, 300);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(75, 23);
            btnUpdateStudent.TabIndex = 9;
            btnUpdateStudent.Text = "更新学生";
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(230, 300);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(75, 23);
            btnDeleteStudent.TabIndex = 10;
            btnDeleteStudent.Text = "删除学生";
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "学生管理系统";
            tabControl.ResumeLayout(false);
            schoolTabPage.ResumeLayout(false);
            schoolTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchools).EndInit();
            classTabPage.ResumeLayout(false);
            classTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            studentTabPage.ResumeLayout(false);
            studentTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage schoolTabPage;
        private System.Windows.Forms.TabPage classTabPage;
        private System.Windows.Forms.TabPage studentTabPage;

        // School tab controls
        private System.Windows.Forms.DataGridView dgvSchools;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Button btnAddSchool;
        private System.Windows.Forms.Button btnUpdateSchool;
        private System.Windows.Forms.Button btnDeleteSchool;

        // Class tab controls
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.ComboBox cmbSchools;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.Button btnDeleteClass;

        // Student tab controls
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtHometown;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
    }
}

