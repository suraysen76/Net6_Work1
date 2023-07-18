using Microsoft.AspNetCore.Mvc;
using Net6_Work1.Data;

namespace Net6_Work1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Students;
            return View(model);
        }
    }
}
