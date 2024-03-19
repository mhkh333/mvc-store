using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcStore.Models;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly MvcStoreContext _context;

    public HomeController(MvcStoreContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }




    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public async Task<IActionResult> Index(string searchString, decimal? minPrice, decimal? maxPrice)
    {
        if (_context.Product == null){
            return Problem("Entity set 'MvcStoreContext.Product' is null");
        }

        var products = from m in _context.Product select m;

        if(!String.IsNullOrEmpty(searchString)){
            products = products.Where(s => s.Name!.Contains(searchString));
        }

        if(minPrice != null){
            products = products.Where(p => p.Price >= minPrice);
        }

        if(maxPrice != null){
            products = products.Where(p => p.Price <= maxPrice);
        }

        // return View(await _context.Product.ToListAsync());
        return View(await products.ToListAsync());

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
