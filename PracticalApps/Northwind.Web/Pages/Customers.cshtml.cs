using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using West.Shared;

namespace Northwind.Web.Pages
{
    public class CustomersPageModel : PageModel
    {
        private NorthwindContext db;
        public CustomersPageModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<IGrouping<string?, Customer>> Customers { get; set; } = null!;
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Customers";
            Customers = db.Customers.AsEnumerable()
                .GroupBy(c => c.Country)
                .OrderBy(c => c.Key);
        }
    }
}
