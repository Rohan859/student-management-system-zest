

using System.Linq;

public class StudentRepository : StudentRepositoryI
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Student> AddNewStudent(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public async Task<Student?> UpdateStudent(Guid id, StudentUpdateDTO dto)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return null;
        }

        // Update only provided fields
        if (!string.IsNullOrEmpty(dto.Email))
            {
               student.Email = dto.Email;
            }

        if (!string.IsNullOrEmpty(dto.Course))
           { 
              student.Course = dto.Course;
           }

        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<bool> DeleteStudent(Guid id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return false;
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return true;
    }
}