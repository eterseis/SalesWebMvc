using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _context;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService context, DepartmentService departmentService)
    {
        _context = context;
        _departmentService = departmentService;
    }
    public IActionResult Index()
    {
        var list = _context.FindAll();
        return View(list);
    }
    public IActionResult Create()
    {
        var departments = _departmentService.FindAll();
        var viewModel = new SellerFormVIewModel { Departments = departments };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _context.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var obj = _context.FindById(id.Value);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _context.Remove(id);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var obj = _context.FindById(id.Value);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }
}
