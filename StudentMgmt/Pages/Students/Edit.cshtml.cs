using Infomax.Models;
using Infomax.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        public Student Student { get; set; }

        public EditModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Student = _studentRepository.GetStudent(id.Value);
            }
            else
            {
                Student = new Student();
            }

            if (Student == null)
            {
                return RedirectToPage("/404");
            }
            return Page();
            
        }

        public IActionResult OnPost(Student Student)
        {
            if(ModelState.IsValid)
            {
                if (Student.Id > 0)
                {
                    Student = _studentRepository.Update(Student);
                } else
                {
                    Student = _studentRepository.Add(Student);
                }
                
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
