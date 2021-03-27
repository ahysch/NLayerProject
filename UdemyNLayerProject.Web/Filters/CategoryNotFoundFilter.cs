using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Core.Services;


namespace UdemyNLayerProject.API.Filters
{
    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public CategoryNotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id =(int) context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryService.GetByIdAsync(id);

            if (category != null)
            {
                await next();
            }

            else
            {
                // bize otomatik hata sayfası geliyor onu kullanacağız.homecontroller içerisinde var bu sayfa sharedda. Mvc ilk başta ilgili (Home'a)  bakar bulamazsa shareda bakar
                ErrorDto errorDto = new ErrorDto();
               // errorDto.Status = 404; statüse gerek yok
                errorDto.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı.");
                // context.Result = new NotFoundObjectResult(errorDto);
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
