using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using anob_blob_storage.Models;
using anob_blob_storage.Services;

namespace anob_blob_storage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlobService _blobService;

    public HomeController(ILogger<HomeController> logger, IBlobService blobService)
    {
        _logger = logger;
        _blobService = blobService;
    }

    public async Task<IActionResult> Index()
    {
        var blobs = await _blobService.ReturnAllFilesAsync();
        return View(blobs);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

