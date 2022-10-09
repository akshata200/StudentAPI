using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repository;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentRepo _repo;
        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Student> students =  _repo.GetAllStudents();
            if(students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound("No Student exists in the database");
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetStudent(int id)
        {
            Student st = _repo.GetStudentById(id);
            if(st != null) 
                return Ok(st);
            return NotFound($"No student {id} exists in database");
        }

        [HttpPost]
        //[Route("add")]
        public IActionResult AddStudent(Student obj)
        {
            _repo.AddStudent(obj);
            return Ok("Student Added");
        }

        [HttpPut]
        //[Route("update")]
        public IActionResult UpdateStudent(Student obj)
        {
            try
            {
                _repo.UpdateStudent(obj);
                return Ok("Student Updated");
            }
            catch (Exception e)
            {
                return NotFound("No such Student found");
            }
        }

        [HttpDelete]
        //[Route("/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _repo.DeleteStudent(id);
                return Ok($"Student {id} is deleted from database");
            }
            catch(Exception e)
            {
                return NotFound("No such Student found");
            }
            
        }


    }
}
