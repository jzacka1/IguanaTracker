using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IguanaTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MapController : ControllerBase
	{
		private string primaryKey = "BHcHezJyCywXkvo_mlpcCYsGdYepKIIVqKXSCvtu4vE";
		private string secondaryKey = "4AqTHeYCEVNq2MHvZF7MJuO0O2Bvbo9ioIwI8xUAN5E";

		private string url = "https://atlas.microsoft.com/search/address/reverse/json?api-version=1.0&language=en-US&entityType=Municipality";

		private readonly string link;

		public MapController(){
			link = String.Format("{0}&subscription-key={1}", link, primaryKey);
		}

		// GET: api/<MapController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<MapController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			
			return "value";
		}
	}
}
