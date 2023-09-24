using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {

        private int _studentId;

        private Student _student;

        public List<Classes> _classes;

        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);

        public AddEditStudent(int id =0)//kontsruktor
        {
            InitializeComponent();
            _studentId = id;

            _classes = HelperClasses.GetClasses("Brak");

            InitGroupsComboBox();

            GetStudentData();

            tbFirstName.Select();

        }

       private void InitGroupsComboBox()
        {
            cmbClassStudent.DataSource = _classes;//inicjalizacja ComboBox
            cmbClassStudent.DisplayMember = "ClassName";
            cmbClassStudent.ValueMember = "Id";
        }

        private void GetStudentData()
        {

            if (_studentId != 0)
            {//edycja danych
                Text = "Edytowanie ucznia";
                var students = _fileHelper.DeserializeFromFile();
                
                _student = students.FirstOrDefault(x => x.Id == _studentId);



                if (_student == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {

            tbId.Text = _student.Id.ToString();
            tbFirstName.Text = _student.FirstName;
            tbLastName.Text = _student.LastName;
            tbMath.Text = _student.Math;
            tbPhysic.Text = _student.Physics;
            tbTechnology.Text = _student.Technology;
            tbPolishLang.Text = _student.PolishLang;
            tbForeignLang.Text = _student.ForeignLang;
            rtbComents.Text = _student.Comments;
            cbAddActive.Checked= _student.AddActive;
          
            cmbClassStudent.SelectedItem = _classes.FirstOrDefault(x => x.Id == _student.ClassStudent);

        }

        private async  void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();


            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {
                AssignIdNewStudent(students);
            }

            AddNewUserToList(students);

            _fileHelper.SerializeToFile(students);

            Close();
        }

        private void AddNewUserToList(List<Student> students)
        {

            var student = new Student
            {

                Id = _studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Math = tbMath.Text,
                Technology = tbTechnology.Text,
                Physics = tbPhysic.Text,
                PolishLang = tbPolishLang.Text,
                ForeignLang = tbForeignLang.Text,
                Comments = rtbComents.Text,
                AddActive = cbAddActive.Checked,
                ClassStudent = (cmbClassStudent.SelectedItem as Classes).Id

            };

            students.Add(student);
        }

        private void AssignIdNewStudent(List<Student> students)
        {
            var studentWithHighestID = students.OrderByDescending(x => x.Id).FirstOrDefault();
            _studentId = studentWithHighestID == null ? 1 : studentWithHighestID.Id + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();//metoda dziedziczona po klasie Form
        }

 
    }
}
