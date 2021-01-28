using IguanaTracker.Data.Data;
using IguanaTracker.Data.Helpers;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IguanaTracker.Test
{
	public class DataTesting
	{
		public static FloridaIguanaTrackerDBContext dbTest;

		public DataTesting(){

			Initialize();
		}

		async void Initialize(){
			dbTest = await GetDatabaseContext();
		}

		private async Task<FloridaIguanaTrackerDBContext> GetDatabaseContext(){
			var options = new DbContextOptionsBuilder<FloridaIguanaTrackerDBContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			var databaseContext = new FloridaIguanaTrackerDBContext(options);
			databaseContext.Database.EnsureCreated();
			if (await databaseContext.Iguanas.CountAsync() <= 0)
			{
				//List<FormFile> frmfileLst = IguanaFormFiles(IguanaImagePaths());

				/*-- 1 --*/
				databaseContext.Iguanas.Add(new Iguana()
				{
					Id = 1,
					DatePosted = DateTime.Now,
					City = "Boca Raton",
					State = "Florida",
					ImageFileName = String.Format("IguanaSighting_{0}", TimeHelper.GetEpochSeconds()),
					Directory = "sighting/",
					Latitude = 26.400000000F,
					Longitude = -80.200000000F,
					Description = "This one was found by the canal in the neighborhood scaring pets away.",
					
					
				});

				/*-- 2 --*/
				databaseContext.Iguanas.Add(new Iguana()
				{
					Id = 2,
					DatePosted = DateTime.Now,
					City = "Boca Raton",
					State = "Florida",
					ImageFileName = String.Format("IguanaSighting_{0}", TimeHelper.GetEpochSeconds()),
					Directory = "sighting/",
					Latitude = 26.400829900F,
					Longitude = -80.198654000F,
					Description = "This iguana was lying on the sidewalk.  It's not moving, so I assume it's dead."
				});

				/*-- 3 --*/
				databaseContext.Iguanas.Add(new Iguana()
				{
					Id = 3,
					DatePosted = DateTime.Now,
					City = "Boca Raton",
					State = "Florida",
					ImageFileName = String.Format("IguanaSighting_{0}", TimeHelper.GetEpochSeconds()),
					Directory = "sighting/",
					Latitude = 26.400829900F,
					Longitude = -80.198654000F,
					Description = "This iguana was basking in the sun by the street."
				});

				await databaseContext.SaveChangesAsync();
			}
			return databaseContext;
		}


		//TESTS

		[Fact]
		public void FirstItemNotNull()
		{
			Iguana ig = dbTest.Iguanas.Find(1);
			Assert.NotNull(ig);
		}

		[Fact]
		public async void IguanasTableNotEmptyOrNull()
		{
			Assert.True(await dbTest.Iguanas.CountAsync() > 0);
			Assert.NotNull(dbTest.Iguanas);
		}

		[Fact]
		public void DeleteRecordTest(){
			try{
				Iguana ig = dbTest.Iguanas.Find(3);
				dbTest.Iguanas.Remove(ig);
				dbTest.SaveChanges();
				Assert.Null(dbTest.Iguanas.Find(3));
			}
			catch(Exception exception){

			}
		}
	}
}
