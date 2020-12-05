using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.BL.Services.Interfaces
{
	public interface IDataService<T>
	{
		void Add(T item);

		List<T> GetAll();
		T GetById(int id);
		List<T> GetByCity(string city);
		List<T> GetByDate(DateTime date);
		List<T> GetByDateTime(DateTime datetime);

		void DeleteById(int id);
	}
}
