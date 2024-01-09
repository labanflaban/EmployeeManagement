using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AdventureWorksLt2019Context _context;

        public IList<Customer> customers { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = new AdventureWorksLt2019Context();
        }

        public async Task OnGet()
        {
            customers = await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).ToListAsync();
        }
        


    }
}