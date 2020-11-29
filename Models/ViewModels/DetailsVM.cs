using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rocky.Models.ViewModels
{
public class DetailsVM{
public DetailsVM()
{
    Product=new Product();
}
public Product Product { get; set; }
public bool ExistsInCart  { get; set; }

    }
}