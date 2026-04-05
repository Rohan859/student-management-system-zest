

public class StudentService : StudentServiceI
{
    private readonly StudentRepositoryI studentRepositoryI;

    public StudentService(StudentRepositoryI studentRepositoryI)
    {
        this.studentRepositoryI = studentRepositoryI;
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
            throw new DatabaseException("Failed to add new student.");
        }

        return addedStudent;
    }
    
    public async Task<List<Student>> GetAllStudents()
    {
        List<Student> students = await studentRepositoryI.GetAllStudents();
        
        if(students == null)
        {
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
}