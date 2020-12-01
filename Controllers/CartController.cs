using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rocky.Data;
using Rocky.Models;
using Rocky.Models.ViewModels;
using Rocky.Utility;

namespace Rocky.Controllers
{ [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ProductUserVM ProductUserVM { get; set; }

        public CartController(ILogger<HomeController> logger,ApplicationDbContext db)
        {   _db=db;
            _logger = logger;
        }

        public IActionResult Index()
        { List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
            if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null &&
        HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0){
                shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

        }

        List<int> prodInCart=shoppingCartList.Select(i=>i.ProductId).ToList();
        IEnumerable<Product> prodList=_db.Product.Where(u=>prodInCart.Contains(u.Id));
         return View(prodList);
        }


[HttpPost]    
[ActionName("Index")]        
                  public IActionResult IndexPost()
        { 
         return RedirectToAction(nameof(Summary));
        }
        


      
                  public IActionResult Summary()
        {  var claimsIdentity=(ClaimsIdentity)User.Identity;
        var claim=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //var userId=User.FindFirstValue(ClaimTypes.Name);

         List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
            if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null &&
        HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0){
                shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

        }

        List<int> prodInCart=shoppingCartList.Select(i=>i.ProductId).ToList();
        IEnumerable<Product> prodList=_db.Product.Where(u=>prodInCart.Contains(u.Id));

        ProductUserVM=new ProductUserVM(){
            ApplicationUser=_db.ApplicationUser.FirstOrDefault(u=>u.Id==claim.Value),
            ProductList=prodList
        };

         return RedirectToAction(nameof(InquiryConfirmation));
        }
[HttpPost]
[ActionName("Summary")]
                  public IActionResult SummaryPost(ProductUserVM productUserVM)
        {  

         return View(ProductUserVM);
        }
        
        [HttpPost]
[ActionName("Summary")]
                  public IActionResult InquiryConfirmation()
        {  
            HttpContext.Session.Clear();
         return View();
        }
        


        public IActionResult Remove(int id)
        { List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
            if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null &&
        HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0){
                shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

        }

        shoppingCartList.Remove(shoppingCartList.FirstOrDefault(u=>u.ProductId==id));
          HttpContext.Session.Set(WC.SessionCart,shoppingCartList);
          return RedirectToAction(nameof(Index));

        }





 


    //       public IActionResult Details(int id)
    //     {

    //          List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
    //         if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null
    //         && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0)
    //         {
    //             shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
    //         }

    //         DetailsVM DetailsVM=new DetailsVM(){
    //         Product=_db.Product.Include(u=>u.Category).Include(u=>u.ApplicationType).Where(u=>u.Id==id).FirstOrDefault(),
    //         ExistsInCart=false};

    //         foreach (var item in shoppingCartList)
    //         {
    //             if (item.ProductId==id){
    //                 DetailsVM.ExistsInCart=true;
    //             }
    //         }
    // return View(DetailsVM);
    //     }

    //     [HttpPost,ActionName("Details")]
    //       public IActionResult DetailsPost(int id)
    //     { List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
    //         if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null
    //         && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0)
    //         {
    //             shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
    //         }
    //         shoppingCartList.Add(new ShoppingCart{ProductId=id});
    //         HttpContext.Session.Set(WC.SessionCart,shoppingCartList);
    //         return RedirectToAction(nameof(Index));
    
    //     }

        
    //       public IActionResult RemovefromCart(int id)
    //     { List<ShoppingCart> shoppingCartList=new List<ShoppingCart>();
    //         if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null
    //         && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0)
    //         {
    //             shoppingCartList=HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
    //         }

    //         var itemToRemove=shoppingCartList.SingleOrDefault(r=>r.ProductId==id);
    //         if (itemToRemove!=null){
    //             shoppingCartList.Remove(itemToRemove);
    //         }

            
    //         HttpContext.Session.Set(WC.SessionCart,shoppingCartList);
    //         return RedirectToAction(nameof(Index));
    
    //     }

 
    }
}
