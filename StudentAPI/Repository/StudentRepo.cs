using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public class StudentRepo : IStudentRepo
    {
        StudentDbContext _db;
        public StudentRepo(StudentDbContext db)
        {
            _db = db;
        }
        public void AddStudent(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();

        }

        public void DeleteStudent(int id)
        {
            Student st = _db.Students.Find(id);
            if(st != null)
            {
                // if we find a student with such id: remove
                _db.Students.Remove(st);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("No such student exists");
            }
        }

        public List<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _db.Students.Find(id);
        }

        public void UpdateStudent(Student obj)
        {
            _db.Students.Update(obj);
            _db.SaveChanges();
        }
    }
}
