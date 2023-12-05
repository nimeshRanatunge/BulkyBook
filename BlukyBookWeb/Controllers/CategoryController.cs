using BlukyBookWeb.Data;
using BlukyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlukyBookWeb.Controllers;
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        //this ApplicationDbContext will have implementations for db connection including connection strings
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //retrieve all records without sql statements
            //write a for loop for display this
            //var objCategoryList = _db.Categories.ToList();
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //create a model directly inside the view, no need to pass the model
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                //index, in the same controller
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
		var categoryFromDb = _db.Categories.Find(id);
		//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
		//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

		if (categoryFromDb == null)
		{
			return NotFound();
		}

		return View(categoryFromDb);
	}

	//POST
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(Category obj)
	{
		if (obj.Name == obj.DisplayOrder.ToString())
		{
			ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
		}
		if (ModelState.IsValid)
		{
			_db.Categories.Update(obj);
			_db.SaveChanges();
			TempData["success"] = "Category updated successfully";
			return RedirectToAction("Index");
		}
		return View(obj);
	}

	public IActionResult Delete(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var categoryFromDb = _db.Categories.Find(id);
		//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
		//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

		if (categoryFromDb == null)
		{
			return NotFound();
		}

		return View(categoryFromDb);
	}

	//POST
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeletePOST(int? id)
	{
		var obj = _db.Categories.Find(id);
		if (obj == null)
		{
			return NotFound();
		}

		_db.Categories.Remove(obj);
		_db.SaveChanges();
		TempData["success"] = "Category deleted successfully";
		return RedirectToAction("Index");

	}
}
