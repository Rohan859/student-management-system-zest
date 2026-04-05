public interface StudentServiceI
{
    public Task<Student> AddNewStudent(StudentRequestDTO studentRequestDTO);
}