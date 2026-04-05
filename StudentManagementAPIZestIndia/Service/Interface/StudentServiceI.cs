public interface StudentServiceI
{
    public Task<Student> AddNewStudent(StudentRequestDTO studentRequestDTO);
    public Task<List<Student>> GetAllStudents();
}