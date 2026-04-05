
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentServiceI studentServiceI;

    public StudentController(StudentServiceI studentServiceI)
    {
        this.studentServiceI = studentServiceI;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewStudent([FromBody] StudentRequestDTO studentRequestDTO)
    {
        var student = await studentServiceI.AddNewStudent(studentRequestDTO);

        return StatusCode(201, $"Student is created with id - {student.Id}");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await studentServiceI.GetAllStudents();
        return Ok(students);
    }
}