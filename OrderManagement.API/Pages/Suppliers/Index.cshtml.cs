using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Resources;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;

namespace OrderManagement.API.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;

        public IndexModel(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierResource> Supplier { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var allSupplier = await supplierService.GetAllSuppliersAsync();
            Supplier = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(allSupplier);
        }
    }
}
