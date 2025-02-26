using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Model;
using System.Security.Cryptography.X509Certificates;
using FileWorking = System.IO;
using System.Diagnostics;
using System.Globalization;

namespace RazorPage.Pages
{
    public class ViewProductsModel : PageModel
    {
        public string FileErrorMessage;

        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            string filePath = @"ModelData\products.txt";
            if (FileWorking.File.Exists(filePath))
            {
                string[]? lines = FileWorking.File.ReadAllLines(filePath);
                foreach(string line in lines)
                {
                    string[]? parts = line.Split('|');
                    if (parts.Length == 4)
                    {
						Product product = new Product();
                        product.Id = int.Parse(parts[0]);
                        product.Name = parts[1];
                        product.Amount = int.Parse(parts[2]);
                        product.Price = decimal.Parse(parts[3], CultureInfo.InvariantCulture);
                        Products.Add(product);
					}
                    else
                    {
                        FileErrorMessage = "Error de càrrega dels atributs d'un producte";
                    }
                }
            }
            else
            {
                FileErrorMessage = "Error de càrrega de dades";
            }
        }
    }
}
