
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;
    private static List<Student> _Students = new List<Student>();

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_Students);
    }
    
    

    

    
    // Add or edit a Students
    [HttpPost]
    public IActionResult SaveStudent(Student student)
    {
        /*
        foreach (var state in ModelState)
        {
            foreach (var error in state.Value.Errors)
            {
                Console.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
            }
        }
        */
        if (!ModelState.IsValid) //validation
        {
            return View("Index", _Students); 
        }
        
        if (student.Id == 0) // New student
        {
            student.Id = _Students.Count > 0 ? _Students.Count() + 1 : 1;
            _Students.Add(student);
        }
        else // Update existing student
        {
            var existingStudent = _Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
                existingStudent.Email = student.Email;
            }
        }
        return RedirectToAction("Index");
    }
    
    //Edit Student
    public IActionResult Edit(int id)
    {
        var student = _Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound(); 
        }
    
        return View(student); 
    }
    [HttpPost]
    public IActionResult EditStudent(Student updatedStudent)
    {
        var existingStudent = _Students.FirstOrDefault(s => s.Id == updatedStudent.Id);
        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Grade = updatedStudent.Grade;
            existingStudent.Email = updatedStudent.Email;
        }

        return RedirectToAction("Index");
    }
    
    // Delete a Students
    [HttpGet]
    public IActionResult DeleteStudent(int id)
    {
        var student = _Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _Students.Remove(student);
        }
        return RedirectToAction("Index");
    }



}