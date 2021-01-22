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

		public void Add(Iguana item)
		{
			db.Add(item);
			db.SaveChanges();
		}

		public void DeleteById(int id)
		{
			Iguana iguana = GetById(id);
			db.Iguanas.Remove(iguana);
			db.SaveChanges();
		}

		public List<Iguana> GetAll()
		{
			return db.Iguanas.ToList<Iguana>();
		}

		public async Task<List<Iguana>> GetAllAsync()
		{
			return await db.Iguanas.ToListAsync<Iguana>();
		}

		public List<Iguana> GetReverse()
		{
			List<Iguana> list = GetAll();
			list.Reverse();
			return list;
		}

		public async Task<List<Iguana>> GetReverseAsync()
		{
			//return list;
			return await Task.Run(() =>
			{
				List<Iguana> list = GetAll();

				list.Reverse();

				return list;

			});
		}

		public List<Iguana> GetAmount(int count){
			return db.Iguanas
							.Take(count)
							.ToList<Iguana>();
		}

		public async Task<List<Iguana>> GetAmountAsync(int count)
		{
			return await db.Iguanas
								.Take(count)
								.ToListAsync();
		}

		public List<Iguana> GetAmountReverse(int count)
		{
			var list = db.Iguanas
							.Take(count)
							.ToList<Iguana>();

			list.Reverse();

			return list;
		}

		public async Task<List<Iguana>> GetAmountReverseAsync(int count)
		{
			return await Task.Run(() => {
					List<Iguana> list = GetAmount(count);

					list.Reverse();

					return list;
				}
			);
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

		public List<Iguana> GetReverseSortByDate()
		{
			return GetAll().OrderByDescending(d => d.DatePosted).ToList<Iguana>();
		}

		Task<List<Iguana>> IDataService<Iguana>.GetReverseSortByDateAsync()
		{
			return Task.Run(() =>
			{
				return GetReverseSortByDate();
			});
		}

		public List<Iguana> GetAmountReverseSortByDate(int count)
		{
			return GetReverseSortByDate().Take(count).ToList();
		}

		public Task<List<Iguana>> GetAmountReverseSortByDateAsync(int count)
		{
			return Task.Run(() =>
			{
				return GetAmountReverseSortByDate(count);
			});
		}
	}
}
