
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentServiceI studentServiceI;
    private readonly ILogger<StudentController> logger;

    public StudentController(StudentServiceI studentServiceI, ILogger<StudentController> logger)
    {
        this.studentServiceI = studentServiceI;
        this.logger = logger;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Add a new student", Description = "Creates a new student record in the system.")]
    public async Task<IActionResult> AddNewStudent([FromBody] StudentRequestDTO studentRequestDTO)
    {
        var student = await studentServiceI.AddNewStudent(studentRequestDTO);

        logger.LogInformation($"Student created with ID: {student.Id}");
        return StatusCode(201, $"Student is created with id - {student.Id}");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all students", Description = "Retrieves a list of all students in the system.")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await studentServiceI.GetAllStudents();
        logger.LogInformation($"Retrieved {students.Count} students.");
        return Ok(students);
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Update a student", Description = "Updates an existing student record in the system.")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentUpdateDTO studentUpdateDTO)
    {
        var student = await studentServiceI.UpdateStudent(id, studentUpdateDTO);
        logger.LogInformation($"Student updated with ID: {id}");
        return Ok(student);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a student", Description = "Deletes an existing student record from the system.")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var message = await studentServiceI.DeleteStudent(id);
        logger.LogInformation($"Student deleted with ID: {id}");
        return Ok(message);
    }
}