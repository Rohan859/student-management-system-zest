
public interface StudentRepositoryI
{
    public Task<Student> AddNewStudent(Student student);
    public Task<List<Student>> GetAllStudents();
}