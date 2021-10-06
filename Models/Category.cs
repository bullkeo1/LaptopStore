using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name="Category")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}