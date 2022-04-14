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

		/// <summary>
		/// Add a new record to the iguana table in the database
		/// </summary>
		/// <param name="item">New iguana record</param>
		public void Add(Iguana item)
		{
			Db.Add(item);
			Db.SaveChanges();
		}

		/// <summary>
		/// Delete a record from the iguana database by id
		/// </summary>
		/// <param name="id">id of iguana record</param>
		public void DeleteById(int id)
		{
			Iguana iguana = GetById(id);
			Db.Iguanas.Remove(iguana);
			Db.SaveChanges();
		}

		/// <summary>
		/// Fetch all records of Iguanas
		/// </summary>
		/// <returns>All records of Iguanas</returns>
		public List<Iguana> GetAll()
		{
			return Db.Iguanas.ToList<Iguana>();
		}

		/// <summary>
		/// Asynchronously fetch all records of Iguanas
		/// </summary>
		/// <returns>All records of Iguanas</returns>
		public async Task<List<Iguana>> GetAllAsync()
		{
			return await Db.Iguanas.ToListAsync<Iguana>();
		}

		/// <summary>
		/// Fetch all iguana records in reverse order
		/// </summary>
		/// <see cref="List{Iguana}"/>
		/// <returns>All iguana records</returns>
		public List<Iguana> GetReverse()
		{
			List<Iguana> list = GetAll();
			list.Reverse();
			return list;
		}
		/// <summary>
		/// Asynchronously fetch all records of Iguanas in reverse order
		/// </summary>
		/// <returns>All records of Iguanas in reverse order</returns>
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

		/// <summary>
		/// Fetch a specific number records
		/// </summary>
		/// <param name="count">Number of records to be return</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>Specified number of records</returns>
		public List<Iguana> GetAmount(int count){
			return Db.Iguanas
							.Take(count)
							.ToList<Iguana>();
		}

		/// <summary>
		/// Asynchronously fetch a specific number records in Async
		/// </summary>
		/// <param name="count">Number of records to be return</param>
		/// <see cref="Task{List{Iguana}}"/>
		/// <returns>Specified number of records</returns>
		public async Task<List<Iguana>> GetAmountAsync(int count)
		{
			return await Db.Iguanas
								.Take(count)
								.ToListAsync();
		}

		/// <summary>
		/// Fetch all Iguana records in reverse order
		/// </summary>
		/// <param name="count">Number of records to be return</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>Specified number of records</returns>
		public List<Iguana> GetAmountReverse(int count)
		{
			var list = Db.Iguanas
							.Take(count)
							.ToList<Iguana>();

			list.Reverse();

			return list;
		}

		/// <summary>
		/// Asynchronously fetch a specific number records in reverse order
		/// </summary>
		/// <param name="count">Number of records to be return</param>
		/// <see cref="Task{List{Iguana}}"/>
		/// <returns>Specified number of records</returns>
		public async Task<List<Iguana>> GetAmountReverseAsync(int count)
		{
			return await Task.Run(() => {
					List<Iguana> list = GetAmount(count);

					list.Reverse();

					return list;
				}
			);
		}

		/// <summary>
		/// Fetch all Iguana records by city location
		/// </summary>
		/// <param name="city">City where an iguana is located</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records in a specific city</returns>
		public List<Iguana> GetByCity(string city)
		{
			return Db.Iguanas.Where(i => i.City.ToLower() == city.ToLower()).ToList<Iguana>();
		}

		/// <summary>
		/// Fetch all Iguana records by date
		/// </summary>
		/// <param name="date">Date when iguana records are added</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records taken by date</returns>
		public List<Iguana> GetByDate(DateTime date)
		{
			return Db.Iguanas.Where(i => i.DatePosted.Date == date.Date).ToList<Iguana>();
		}

		/// <summary>
		/// Fetch all Iguana records by date and time
		/// </summary>
		/// <param name="date">Date and time when iguana records are added</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records taken by date and time</returns>
		public List<Iguana> GetByDateTime(DateTime datetime)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Fetch all Iguana records by date and time
		/// </summary>
		/// <param name="date">Date and time when iguana records are added</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records taken by date and time</returns>
		public Iguana GetById(int id)
		{
			return Db.Iguanas.Find(id);
		}

		/// <summary>
		/// Fetch all Iguana records by date in reverse order
		/// </summary>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records taken by date in reverse order</returns>
		public List<Iguana> GetReverseSortByDate()
		{
			return GetAll().OrderByDescending(d => d.DatePosted).ToList<Iguana>();
		}

		/// <summary>
		/// Fetch all Iguana records by date in reverse order in async
		/// </summary>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records sorted by date in reverse order</returns>
		async Task<List<Iguana>> IDataService<Iguana>.GetReverseSortByDateAsync()
		{
			return await Task.Run(() =>
			{
				return GetReverseSortByDate();
			});
		}

		/// <summary>
		/// Fetch a specified number of Iguana records by date in reverse
		/// </summary>
		/// <param name="count">Specified number of records</param>
		/// <see cref="List{Iguana}"/>
		/// <returns>List of iguana records sorted by date in reverse order</returns>
		public List<Iguana> GetAmountReverseSortByDate(int count)
		{
			return GetReverseSortByDate().Take(count).ToList();
		}

		/// <summary>
		/// Asynchronously fetch a specific number records in reverse order
		/// </summary>
		/// <param name="count">Number of records to be return</param>
		/// <see cref="Task{List{Iguana}}"/>
		/// <returns>Specified number of records</returns>
		public async Task<List<Iguana>> GetAmountReverseSortByDateAsync(int count)
		{
			return await Task.Run(() =>
			{
				return GetAmountReverseSortByDate(count);
			});
		}
	}
}
