using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IguanaTracker.BL.Services.Interfaces
{
	public interface IDataService<T>
	{
		void Add(T item);

		List<T> GetAll();
		Task<List<T>> GetAllAsync();
		List<T> GetAmount(int count);
		Task<List<T>> GetAmountAsync(int count);
		List<T> GetAmountReverse(int count);
		Task<List<T>> GetAmountReverseAsync(int count);
		List<T> GetReverse();
		Task<List<T>> GetReverseAsync();
		T GetById(int id);
		List<T> GetByCity(string city);
		List<T> GetByDate(DateTime date);
		List<T> GetByDateTime(DateTime datetime);

		void DeleteById(int id);
	}
}
