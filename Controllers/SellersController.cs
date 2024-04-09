using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
        if (!ModelState.IsValid)
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormVIewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        _context.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = _context.FindById(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
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
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = _context.FindById(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }
        return View(obj);
    }
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = _context.FindById(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }
        List<Department> departments = _departmentService.FindAll();
        SellerFormVIewModel viewModel = new SellerFormVIewModel { Seller = obj, Departments = departments };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Seller seller)
    {
        if (id != seller.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
        }
        if (!ModelState.IsValid)
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormVIewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        try
        {
            if (ModelState.IsValid)
            {
                _context.Update(seller);
            }
        }
        catch (ApplicationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e });
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(viewModel);
    }
}
