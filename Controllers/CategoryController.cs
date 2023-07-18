using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var  listModel = await _db.Categories.ToListAsync();
            return View(listModel);
        }
    }
}
