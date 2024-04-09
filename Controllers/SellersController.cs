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
    public async Task<IActionResult> Index()
    {
        var list = await _context.FindAllAsync();
        return View(list);
    }
    public async Task<IActionResult> Create()
    {
        var departments = await _departmentService.FindAllAsync();
        var viewModel = new SellerFormVIewModel { Departments = departments };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller)
    {
        if (!ModelState.IsValid)
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormVIewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        await _context.InsertAsync(seller);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = await _context.FindByIdAsync(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }
        return View(obj);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _context.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (IntegrityException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = await _context.FindByIdAsync(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }
        return View(obj);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = await _context.FindByIdAsync(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }
        List<Department> departments = await _departmentService.FindAllAsync();
        SellerFormVIewModel viewModel = new SellerFormVIewModel { Seller = obj, Departments = departments };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Seller seller)
    {
        if (id != seller.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
        }
        if (!ModelState.IsValid)
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormVIewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        try
        {
            if (ModelState.IsValid)
            {
                await _context.UpdateAsync(seller);
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
