using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.Models.Local_DB;

namespace Project1.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDBContext _CTX;

        public ApplicationController(ApplicationDBContext CTX)
        {
            _CTX = CTX;
        }

        public IActionResult AddData() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddData(Student Stu)
        {
            if(ModelState.IsValid)
            {
                _CTX.Students.Add(Stu);
                _CTX.SaveChanges();
                return RedirectToAction("ReadData");
            }

            return View();
        }

        public IActionResult ReadData(string search)
        {
            var result = _CTX.Students.ToList();
            return View(result);
        }

        public IActionResult EditData(int id)
        {
            var ed =  _CTX.Students.Find(id);
            if(ed == null)
            {
                return NotFound();
            }
            return View(ed);
        }

        [HttpPost]

        public IActionResult EditData(Student st)
        {
            _CTX.Students.Update(st);
            _CTX.SaveChanges();
            return RedirectToAction("ReadData");

        }

        
        public IActionResult DeleteData(int id)
        {
            var del = _CTX.Students.Find(id);
            if(del == null)
            {
                return NotFound();
            }
            _CTX.Students.Remove(del);
            _CTX.SaveChanges();
            return RedirectToAction("ReadData");
        }



        public IActionResult Searchbar(string search)
        {

            var bar = _CTX.Students.Where(x => x.Name.Contains(search) || x.Department.Contains(search) || x.College.Contains(search) || x.Mobile.ToString().Contains(search));

            return View("ReadData", bar.ToList());
        }

    }
}
