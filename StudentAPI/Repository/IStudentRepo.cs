using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public interface IStudentRepo
    {
        // Get all students
        public List<Student> GetAllStudents();

        // Get student by ID
        public Student GetStudentById(int id);

        // Add student
        public void AddStudent(Student obj);

        // update student details
        public void UpdateStudent(Student obj);

        // delete student
        public void DeleteStudent(int id);
    }
}
