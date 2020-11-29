using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rocky.Models.ViewModels
{
public class HomeVM{


public IEnumerable<Product> Products {get;set;}
public IEnumerable<Category> Categories {get;set;}

    }
}