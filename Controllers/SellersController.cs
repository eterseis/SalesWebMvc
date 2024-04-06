using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
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
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _context.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
}
