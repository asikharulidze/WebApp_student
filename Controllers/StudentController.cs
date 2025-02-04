
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;
    private static List<Student> Students = new List<Student>();

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int? id)
    {
        if (id.HasValue) 
        {
            var student = Students.FirstOrDefault(s => s.Id == id.Value);
            ViewBag.Student = student;
        }
        return View(Students);
    }
    

    
    // Add or edit a Students
    [HttpPost]
    public IActionResult SaveStudent(Student student)
    {
        if (student.Id == 0) // New student
        {
            student.Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;
            Students.Add(student);
        }
        else // Update existing student
        {
            var existingStudent = Students.FirstOrDefault(s => s.Id == student.Id);
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
    
    // Delete a Students
    [HttpGet]
    public IActionResult DeleteStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            Students.Remove(student);
        }
        return RedirectToAction("Index");
    }



}