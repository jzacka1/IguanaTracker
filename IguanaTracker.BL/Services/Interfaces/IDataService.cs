using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IguanaTracker.BL.Services.Interfaces
{
	public interface IDataService<T>
	{
		void Add(T item);

		Task<List<T>> GetAll();
		Task<List<T>> GetAmount(int count);
		T GetById(int id);
		List<T> GetByCity(string city);
		List<T> GetByDate(DateTime date);
		List<T> GetByDateTime(DateTime datetime);

		void DeleteById(int id);
	}
}
