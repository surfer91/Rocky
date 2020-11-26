using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {   if (ModelState.IsValid){
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");}
             return View(obj);  
        }

           public IActionResult Edit(int? id)
        {   if (id==null||id==0){ return NotFound();}
            var obj=_db.Category.Find(id);
            if(obj==null){
                return NotFound();
            }
            return View(obj);
        }   

           public IActionResult Delete()
        {
            return View();
        }

    }
}
