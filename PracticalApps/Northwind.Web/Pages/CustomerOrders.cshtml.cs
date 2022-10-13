using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using West.Shared;

namespace Northwind.Web.Pages
{
    public class CustomerOrdersPageModel : PageModel
    {
        private NorthwindContext db;
        public CustomerOrdersPageModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
        public Customer? Customer { get; set; }
        public void OnGet()
        {
            string id = HttpContext.Request.Query["id"];

            Customer = db.Customers
                .Include(c => c.Orders)
                .SingleOrDefault(c => c.CustomerId == id);
        }
    }
}
