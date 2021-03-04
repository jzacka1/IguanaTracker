using IguanaTracker.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.BL
{
	public class BusinessServiceDbAccess : IDisposable
	{
		public readonly FloridaIguanaTrackerDBContext Db;

		public BusinessServiceDbAccess(FloridaIguanaTrackerDBContext db) 
		{
			this.Db = db;
		}

		public void Dispose()
		{
			this.Db.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
