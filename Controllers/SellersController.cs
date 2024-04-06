using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _context;

    public SellersController(SellerService context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var list = _context.FindAll();
        return View(list);
    }
}
