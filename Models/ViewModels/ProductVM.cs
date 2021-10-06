using System.Collections;
using System.Collections.Generic;
using LaptopStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopStore.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
        public IEnumerable<SelectListItem>CategoryList { get; set; }
    }
}