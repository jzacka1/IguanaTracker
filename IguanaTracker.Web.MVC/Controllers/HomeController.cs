using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IguanaTracker.Web.MVC.Models;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace IguanaTracker.Web.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWebHostEnvironment _hostEnvironment;

		private readonly ILogger<HomeController> _logger;
		private readonly IIguanaTrackerService _iguanaTrackerService;

		public HomeController(IWebHostEnvironment hostEnvironment, ILogger<HomeController> logger, IIguanaTrackerService iguanaTrackerService)
		{
			_logger = logger;
			_iguanaTrackerService = iguanaTrackerService;
			_hostEnvironment = hostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _iguanaTrackerService.GetAmount(4));
		}

		public IActionResult About(){
			return View();
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

		public async Task<IActionResult> Sightings()
		{
			return View(await _iguanaTrackerService.GetAll());
		}

		public IActionResult AddSighting(){
			return View();
		}

		[HttpPost]
		public IActionResult AddSighting(Iguana iguana)
		{
			//https://www.codegrepper.com/code-examples/csharp/how+to+convert+iformfile+to+byte+array+c%23
			if (ModelState.IsValid)
			{
				_iguanaTrackerService.Add(iguana);
			}

			return RedirectToAction("Index");
		}
	}
}
