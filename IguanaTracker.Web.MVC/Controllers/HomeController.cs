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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using IguanaTracker.BL.Services;
using IguanaTracker.Data.Data.ViewModels;

namespace IguanaTracker.Web.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWebHostEnvironment _hostEnvironment;

		private readonly ILogger<HomeController> _logger;
		private readonly IIguanaTrackerService _iguanaTrackerService;

		private readonly AzureBlobService _azureBlobService;

		public HomeController(IWebHostEnvironment hostEnvironment, 
								ILogger<HomeController> logger, 
								IIguanaTrackerService iguanaTrackerService, 
								BlobServiceClient blobServiceClient)
		{
			_hostEnvironment = hostEnvironment;
			_logger = logger;
			_iguanaTrackerService = iguanaTrackerService;
			_azureBlobService = new AzureBlobService(blobServiceClient, "iguana-image-container");
		}

		[ResponseCache(Duration = 10)]
		public async Task<IActionResult> Index()
		{
			List<IguanaLinkViewModel> iguanaLinkVmLst = new List<IguanaLinkViewModel>();

			foreach(var i in _iguanaTrackerService.GetAmount(4))
			{
				IguanaLinkViewModel temp = new IguanaLinkViewModel();
				temp.iguana = i;
				temp.link = _azureBlobService.GetFileLinkByName(i.Directory + i.ImageFileName);
				iguanaLinkVmLst.Add(temp);
			}

			return View(iguanaLinkVmLst);
		}

		[ResponseCache(Duration = 30)]
		public IActionResult About(){
			return View();
		}

		[ResponseCache(Duration = 30)]
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[ResponseCache(Duration = 10)]
		public async Task<IActionResult> Sightings()
		{
			List<IguanaLinkViewModel> iguanaLinkVmLst = new List<IguanaLinkViewModel>();

			foreach (var i in await _iguanaTrackerService.GetAll()){
				IguanaLinkViewModel temp = new IguanaLinkViewModel();
				temp.iguana = i;
				temp.link = _azureBlobService.GetFileLinkByName(i.Directory + i.ImageFileName);

				iguanaLinkVmLst.Add(temp);
			}

			return View(iguanaLinkVmLst);
		}

		[ResponseCache(Duration = 5)]
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

				string filePath = string.Format("{0}{1}", iguana.Directory, iguana.ImageFileName);

				_azureBlobService.UploadFileToStorage(iguana._ImageData, filePath);
			}

			return RedirectToAction("Index");
		}
	}
}
