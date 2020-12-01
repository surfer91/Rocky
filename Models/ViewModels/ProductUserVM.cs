using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rocky.Models.ViewModels
{
public class ProductUserVM{
public ProductUserVM()
{
   ProductList=new List<Product>();
}

public ApplicationUser ApplicationUser { get; set; }
public IEnumerable<Product> ProductList { get; set; }

    }
}