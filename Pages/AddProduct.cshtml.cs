using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Model;

namespace RazorPage.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            string filePath = @"ModelData\products.txt";
            string? productString = $"{NewProduct.Id}|{NewProduct.Name}|{NewProduct.Amount}|{NewProduct.Price}";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.AppendAllText(filePath, productString);
            } // ToDo ErrorMessage

            return Page();
        }
    }
}
