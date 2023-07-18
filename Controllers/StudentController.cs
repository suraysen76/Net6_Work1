using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6_Work1.Data;
using Net6_Work1.Models;

namespace Net6_Work1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _db.Students.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentObj = _db.Students.Find(id);

            if (studentObj == null)
            {
                return NotFound();
            }
            return View(studentObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student empobj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(empobj);
                _db.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentObj = _db.Students.Find(id);

            if (studentObj == null)
            {
                return NotFound();
            }
            return View(studentObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? id)
        {
            var deleterecord = _db.Students.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _db.Students.Remove(deleterecord);
            _db.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }


    }
}
