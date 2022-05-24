using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Resources;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;
using OrderManagement.Data;

namespace OrderManagement.API.Pages.Suppliers
{
    public class DeleteModel : PageModel
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;

        public DeleteModel(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        [BindProperty]
        public SupplierResource Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var supplier = await supplierService.GetSupplierByIDAsync(id.Value);

            if (supplier == null)
                return NotFound();
            else
                Supplier = mapper.Map<Supplier, SupplierResource>(supplier);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            await supplierService.SoftDeleteSupplierAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
