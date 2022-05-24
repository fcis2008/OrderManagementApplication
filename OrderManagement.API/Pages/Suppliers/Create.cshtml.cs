using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.API.Resources;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;

namespace OrderManagement.API.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly ISupplierService supplierService;
        private readonly IStateService stateService;
        private readonly IMapper mapper;

        [BindProperty]
        public SupplierResource Supplier { get; set; } = default!;

        public CreateModel(ISupplierService supplierService, IMapper mapper, IStateService stateService)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
            this.stateService = stateService;
        }

        public async Task<IActionResult> OnGet()
        {
            await FillViewData();
            return Page();
        }

        private async Task FillViewData()
        {
            ViewData["FKStateID"] = new SelectList(await stateService.GetAllStatesAsync(), "ID", "Name");
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Supplier == null)
            {
                await FillViewData();
                return Page();
            }

            await supplierService.AddSupplierAsync(mapper.Map<SupplierResource, Supplier>(Supplier));

            return RedirectToPage("./Index");
        }
    }
}
