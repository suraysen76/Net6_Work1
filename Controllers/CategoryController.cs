using Microsoft.AspNetCore.Mvc;
using Net6_Work1.Data;
using Net6_Work1.Models;

namespace Net6_Work1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db= db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> listModel = _db.Categories;
            return View(listModel);
        }
    }
}
