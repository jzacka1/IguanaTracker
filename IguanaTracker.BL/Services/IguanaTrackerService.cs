﻿using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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