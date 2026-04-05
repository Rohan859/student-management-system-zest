using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Course { get; set; }
    public DateTime CreatedDate { get; set;} = DateTime.UtcNow;
}