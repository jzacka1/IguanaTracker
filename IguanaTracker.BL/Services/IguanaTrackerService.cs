using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IguanaTracker.BL.Services
{
	public class IguanaTrackerService : BusinessServiceDbAccess, IIguanaTrackerService
	{
		public IguanaTrackerService(FloridaIguanaTrackerDBContext db) : base(db){

		}

		public async void Add(Iguana item)
		{
			db.Add(item);
			await db.SaveChangesAsync();
		}

		public void DeleteById(int id)
		{
			Iguana iguana = GetById(id);
			db.Iguanas.Remove(iguana);
			db.SaveChanges();
		}

		public async Task<List<Iguana>> GetAll()
		{
			return await db.Iguanas.ToListAsync<Iguana>();
		}

		public async Task<List<Iguana>> GetAmount(int count){
			return await db.Iguanas.Take(count).ToListAsync<Iguana>();
		}

		public List<Iguana> GetByCity(string city)
		{
			return db.Iguanas.Where(i => i.City.ToLower() == city.ToLower()).ToList<Iguana>();
		}

		public List<Iguana> GetByDate(DateTime date)
		{
			return db.Iguanas.Where(i => i.DatePosted.Date == date.Date).ToList<Iguana>();
		}

		public List<Iguana> GetByDateTime(DateTime datetime)
		{
			throw new NotImplementedException();
		}

		public Iguana GetById(int id)
		{
			return db.Iguanas.Find(id);
		}
	}
}
