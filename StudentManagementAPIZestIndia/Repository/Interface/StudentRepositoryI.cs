
public interface StudentRepositoryI
{
    public Task<Student> AddNewStudent(Student student);
    public Task<List<Student>> GetAllStudents();
    public Task<Student?> UpdateStudent(Guid id, StudentUpdateDTO dto);
    public Task<bool> DeleteStudent(Guid id);
}