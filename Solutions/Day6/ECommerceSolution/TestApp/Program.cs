﻿using System;
using CatalogLib;


Console.WriteLine("Hello, World!");

Product latestOnDemandingProduct=new Product();
latestOnDemandingProduct.Name= "Macbook Pro";
latestOnDemandingProduct.Price = 1200.00m;



//Property Initialization Syntax
var product = new Product
{
    Id = 1,
    Name = "Sample Product",
    Price = 569.99m,
    Description = "This is a sample product."
};

Console.WriteLine(product);