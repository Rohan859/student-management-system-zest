public interface StudentServiceI
{
    public Task<Student> AddNewStudent(StudentRequestDTO studentRequestDTO);
    public Task<List<Student>> GetAllStudents();
    public Task<String> UpdateStudent(Guid id, StudentUpdateDTO studentUpdateDTO);
}