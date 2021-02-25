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
using ExifLib;
using System.Linq.Dynamic.Core;

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

			foreach(var i in await _iguanaTrackerService.GetAmountReverseSortByDateAsync(4))
			{
				IguanaLinkViewModel temp = new IguanaLinkViewModel
				{
					Iguana = i,
					Link = _azureBlobService.GetFileLinkByName(i.Directory + i.ImageFileName)
				};
				iguanaLinkVmLst.Add(temp);
			}

			return View(iguanaLinkVmLst);
		}

		[ResponseCache(Duration = 30)]
		public IActionResult About(){
			return View();
		}

		public IActionResult Instructions()
		{
			return View();
		}

		public IActionResult Companies()
		{
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

		//p is the current page
		[ResponseCache(Duration = 10)]
		public async Task<IActionResult> Sightings(int p = 1)
		{

			List<IguanaLinkViewModel> iguanaLinkVmLst = new List<IguanaLinkViewModel>();

			foreach (var i in await _iguanaTrackerService.GetReverseSortByDateAsync()){
				IguanaLinkViewModel temp = new IguanaLinkViewModel
				{
					Iguana = i,
					Link = _azureBlobService.GetFileLinkByName(i.Directory + i.ImageFileName)
				};

				iguanaLinkVmLst.Add(temp);
			}

			int pageSize = 6;

			int skipRecords = (pageSize * p) - pageSize;
			int pageCount = iguanaLinkVmLst.Count() / pageSize;

			PagedResult<IguanaLinkViewModel> list = new PagedResult<IguanaLinkViewModel>
			{
				Queryable = iguanaLinkVmLst.AsQueryable<IguanaLinkViewModel>()
								.Skip(skipRecords)
								.Take(pageSize),
				PageSize = pageSize,
				PageCount = pageCount,
				CurrentPage = p
			};

			return View(list);
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
				string filePath = string.Format("{0}{1}", iguana.Directory, iguana.ImageFileName);

				BlobHttpHeaders blobHttpHeader = new BlobHttpHeaders();
				blobHttpHeader.ContentType = "image/jpeg";

				_azureBlobService.UploadFileToStorage(iguana.ImageData, filePath, blobHttpHeader);

				_iguanaTrackerService.Add(iguana);
			}

			return RedirectToAction("Index");
		}
	}
}
