using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{ [Authorize(Roles=WC.AdminRole)]

    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

                   public IActionResult Edit(int? id)
        {   if (id==null||id==0){ return NotFound();}
            var obj=_db.ApplicationType.Find(id);
            if(obj==null){
                return NotFound();
            }
            return View(obj);
        }   


      [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {   if (ModelState.IsValid){
            _db.ApplicationType.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");}
             return View(obj);  
        }


           public IActionResult Delete(int? id)
        {   if (id==null||id==0){ return NotFound();}
            var obj=_db.ApplicationType.Find(id);
            if(obj==null){
                return NotFound();
            }
            return View(obj);
        }   


      [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {  
            var obj=_db.ApplicationType.Find(id);
           
            _db.ApplicationType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");}

    }
}
