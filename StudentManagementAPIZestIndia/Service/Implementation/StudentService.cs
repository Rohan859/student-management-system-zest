

public class StudentService : StudentServiceI
{
    private readonly StudentRepositoryI studentRepositoryI;
    private readonly ILogger<StudentService> _logger;

    public StudentService(StudentRepositoryI studentRepositoryI, ILogger<StudentService> logger)
    {
        this.studentRepositoryI = studentRepositoryI;
        this._logger = logger;
    }

    public async Task<Student> AddNewStudent(StudentRequestDTO studentRequestDTO)
    {
        if(studentRequestDTO == null)
        {
            throw new ArgumentException("Invalid student data.");
        }

        Student student = new Student
        {
            Name = studentRequestDTO.Name,
            Age = studentRequestDTO.Age,
            Email = studentRequestDTO.Email,
            Course = studentRequestDTO.Course
        };

        var addedStudent = await studentRepositoryI.AddNewStudent(student);

        if (addedStudent == null)
        {
            _logger.LogError($"Failed to add new student with id {student.Id} and email {student.Email} to the database.");
            throw new DatabaseException("Failed to add new student.");
        }

        return addedStudent;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        List<Student> students = await studentRepositoryI.GetAllStudents();
        
        if(students == null)
        {
            _logger.LogError("Failed to retrieve students from the database.");
            throw new DatabaseException("Failed to retrieve students.");
        }

        return students;
    }

    public async Task<string> UpdateStudent(Guid id, StudentUpdateDTO studentUpdateDTO)
    {
        if (studentUpdateDTO == null)
        {
            throw new ArgumentException("Invalid student update data.");
        }

        var updatedStudent = await studentRepositoryI.UpdateStudent(id, studentUpdateDTO);

        if (updatedStudent == null)
        {
            throw new KeyNotFoundException($"Student with id {id} not found.");
        }

        return $"Student with id {id} updated successfully.";
    }

     public async Task<String> DeleteStudent(Guid id)
    {
        bool isDeleted = await studentRepositoryI.DeleteStudent(id);

        if(!isDeleted)
        {
            _logger.LogError($"Failed to delete student with id {id} from the database because it was not found.");
            throw new KeyNotFoundException($"Student with id {id} not found.");
        }

        return $"Student with id {id} deleted successfully.";
    }
    
}