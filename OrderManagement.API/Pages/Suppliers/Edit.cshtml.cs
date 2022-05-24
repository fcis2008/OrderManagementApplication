using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.API.Resources;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;

namespace OrderManagement.API.Pages.Suppliers
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService supplierService;
        private readonly IStateService stateService;
        private readonly IMapper mapper;

        public EditModel(ISupplierService supplierService, IMapper mapper, IStateService stateService)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
            this.stateService = stateService;
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

            ViewData["FKStateID"] = new SelectList(await stateService.GetAllStatesAsync(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var supplierToBeUpdated = await supplierService.GetSupplierByIDAsync(Supplier.ID);

            if (supplierToBeUpdated == null)
                return NotFound();

            var tempSupplier = mapper.Map<SupplierResource, Supplier>(Supplier);

            await supplierService.UpdateSupplierAsync(supplierToBeUpdated, tempSupplier);

            return RedirectToPage("./Index");
        }
    }
}
