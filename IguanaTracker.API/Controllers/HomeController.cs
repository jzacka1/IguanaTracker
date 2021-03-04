using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IguanaTracker.API.Interfaces;
using IguanaTracker.BL.Services;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IguanaTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly ILoggerService _logger;
		private readonly IIguanaTrackerService _iguanaTracker;

		public HomeController(IIguanaTrackerService iguanaTracker,
								ILoggerService logger)
		{
			_logger = logger;
			_iguanaTracker = iguanaTracker;
		}

		// GET: api/<HomeController>
		[HttpGet]
		public async Task<List<Iguana>> Get()
		{
			return await _iguanaTracker.GetAllAsync();
			//return new string[] { "value1", "value2" };
		}

		// GET api/<HomeController>/5
		[HttpGet("{id}")]
		public Iguana Get(int id)
		{
			return _iguanaTracker.GetById(id);
		}

		// POST api/<HomeController>
		[HttpPost]
		public void Post([FromBody] Iguana item)
		{
			_iguanaTracker.Add(item);
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
			_iguanaTracker.DeleteById(id);
		}
	}
}
