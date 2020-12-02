using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocky.Data;

namespace Rocky
{
    public static class WC
    {   public const string ImagePath=@"\images\product\";
    public const string SessionCart="ShoppingCartSession";
    public const string AdminRole="Admin";
    public const string CustomerRole="Customer";
public const string EmailAdmin="jakis@wp.pl";

    }
}