using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rocky.Models.ViewModels
{
public class ProductVM{

public Product  Product { get; set; }
public IEnumerable<SelectListItem> CategorySelectList {get;set;}
public IEnumerable<SelectListItem> ApplicationTypeSelectList {get;set;}

    }
}