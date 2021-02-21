using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulApiService.Services
{
	public interface IBaseService<T>
	{
		List<T> GetAll();
	}
}
