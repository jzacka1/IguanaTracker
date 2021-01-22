using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IguanaTracker.BL.Services.Interfaces
{
	public interface IDataService<T>
	{
		//CRUD Methods
		void Add(T item);
		void DeleteById(int id);

		//Fetch all records from database
		List<T> GetAll();
		Task<List<T>> GetAllAsync();

		//Fetch number of records
		List<T> GetAmount(int count);
		Task<List<T>> GetAmountAsync(int count);

		//Fetch all records in reverse order
		List<T> GetReverse();
		Task<List<T>> GetReverseAsync();

		//Fetch number of records in reverse order
		List<T> GetAmountReverse(int count);
		Task<List<T>> GetAmountReverseAsync(int count);

		//Fetch records by field
		T GetById(int id);
		List<T> GetByCity(string city);
		List<T> GetByDate(DateTime date);
		List<T> GetByDateTime(DateTime datetime);

		//Fetch records sorted by date
		List<T> GetReverseSortByDate();
		List<T> GetAmountReverseSortByDate(int count);
		Task<List<T>> GetReverseSortByDateAsync();
		Task<List<T>> GetAmountReverseSortByDateAsync(int count);
	}
}
