using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using IguanaTracker.API.Interfaces;
using IguanaTracker.BL.Services;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IguanaTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
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

		// GET: api/<HomeController>
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<List<Iguana>> Get()
		{
			return await _iguanaTrackerService.GetAllAsync();
			//return new string[] { "value1", "value2" };
		}

		// GET api/<HomeController>/5
		[HttpGet("{id}")]
		public Iguana Get(int id)
		{
			return _iguanaTrackerService.GetById(id);
		}

		// POST api/<HomeController>
		[HttpPost]
		public void Post([FromBody] Iguana item)
		{
			_iguanaTrackerService.Add(item);
		}

		// PUT api/<HomeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HomeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_iguanaTrackerService.DeleteById(id);
		}
	}
}
