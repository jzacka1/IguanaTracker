using IguanaTracker.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.BL
{
	public class BusinessServiceDbAccess : IDisposable
	{
		public readonly FloridaIguanaTrackerDBContext db;

		public BusinessServiceDbAccess(FloridaIguanaTrackerDBContext db) 
		{
			this.db = db;
		}

		public void Dispose()
		{
			this.db.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
