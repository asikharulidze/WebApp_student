using Microsoft.AspNetCore.Mvc;
using WebApp.Domain;
using WebApp.Models;

namespace WebApp.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentsDbContext _dbContext;

    public StudentController(ILogger<StudentController> logger, StudentsDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var students = GetStudents();

        return View(students);
    }

    // Add or edit a Students
    [HttpPost]
    public IActionResult SaveStudent(Student student)
    {
        if (!ModelState.IsValid) //validation
        {
            return View("Index", GetStudents());
        }

        Domain.Entities.Student entity = new Domain.Entities.Student()
        {
            Id = student.Id ?? Guid.NewGuid(),
            Email = student.Email,
            FullName = student.Name,
            PhoneNumber = student.PhoneNumber,
        };

        _dbContext.Students.Add(entity);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    //Edit Student
    public IActionResult Edit(Guid id)
    {
        var student = GetStudents().FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    public IActionResult EditStudent(Student updatedStudent)
    {
        var existingStudent = GetStudents().FirstOrDefault(s => s.Id == updatedStudent.Id);
        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Email = updatedStudent.Email;
        }

        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    // Delete a Students
    [HttpGet]
    public IActionResult DeleteStudent(Guid id)
    {
        var student = GetStudents().FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            GetStudents().Remove(student);
            _dbContext.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    private List<Student> GetStudents()
    {
        return _dbContext.Students.Select(x => new Student()
        {
            Id = x.Id,
            Email = x.Email,
            Name = x.FullName,
            PhoneNumber = x.PhoneNumber,
        }).ToList();
    }
}