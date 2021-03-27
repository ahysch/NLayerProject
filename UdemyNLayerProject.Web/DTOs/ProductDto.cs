using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public int CategoryId { get; set; }
    
    }
}
