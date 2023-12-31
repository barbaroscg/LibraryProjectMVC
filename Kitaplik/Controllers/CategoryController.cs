using Kitaplik.DataAccess.Data;
using Kitaplik.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Category> objCategoryList = _context.Categories.ToList();
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
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

            var category = _context.Categories.Find(id);
            // var categoryx = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete işleminin gerçekleştirilmesi

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            // var categoryx = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        //Eğer sadece list sayfasındaki buton üzerinden silme işlemi gerçekleştirilecekse alttaki yöntem kullanılabilir.
        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _context.Categories.Find(id);

        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Category obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            TempData["success"] = "Category deleted successfully";
            _context.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
