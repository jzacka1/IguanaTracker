using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IguanaTracker.Data.Data;
using IguanaTracker.Data.Helpers;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IguanaTracker.Test.Data
{
	public class DataTesting
	{
		protected FloridaIguanaTrackerDBContext _dbTest;

		public DataTesting(){

			Initialize();
		}

		private async void Initialize(){
			_dbTest = await GetDatabaseContext();
		}

		private static List<string> IguanaImagePaths()
		{
			const string root = @"..\..\..\..\IguanaTracker.Test\Images\";
			var iguanaImg = new List<string>
			{
				string.Format("{0}{1}", root, "21xp-iguana1-videoSixteenByNineJumbo1600.jpg"),
				string.Format("{0}{1}", root, "iguana-ap-er-190702_hpMain_1x1_992.jpg"),
				string.Format("{0}{1}", root, "IguanaUFIFAS.jpg")
			};


			return iguanaImg;
		}

		private static IEnumerable<FormFile> IguanaFormFiles(IReadOnlyList<string> iguanaImg)
		{
			var frmFileLst = new List<FormFile>();

			for (var i = 0; i < iguanaImg.Count; i++)
			{
				var fs = Helpers.LoadImageFromFolder(iguanaImg[i]);
				var ms = Helpers.ConvertFileStreamToMemoryStream(fs);

				frmFileLst.Add(
					Helpers.ConvertMemoryStreamToFormFile(
						ms, 
						"imageSample_" + i + 1, 
						"Iguana_" + i + 1)
					);

				//When you're done, always close the connection.
				fs.Close();
				ms.Close();
			}

			return frmFileLst;
		}

		private static async Task<FloridaIguanaTrackerDBContext> GetDatabaseContext(){
			var options = new DbContextOptionsBuilder<FloridaIguanaTrackerDBContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			var databaseContext = new FloridaIguanaTrackerDBContext(options);
			await databaseContext.Database.EnsureCreatedAsync();
			if (await databaseContext.Iguanas.CountAsync() > 0) return databaseContext;
			IguanaFormFiles(IguanaImagePaths());

			/*-- 1 --*/
			await databaseContext.Iguanas.AddAsync(new Iguana()
			{
				Id = 1,
				DatePosted = DateTime.Now,
				City = "Boca Raton",
				State = "Florida",
				//Image = Helpers.ImageToByteArrayAsync(frmfileLst[0]),
				Latitude = 26.400000000F,
				Longitude = -80.200000000F,
				Description = "This one was found by the canal in the neighborhood scaring pets away."
			});

			/*-- 2 --*/
			await databaseContext.Iguanas.AddAsync(new Iguana()
			{
				Id = 2,
				DatePosted = DateTime.Now,
				City = "Boca Raton",
				State = "Florida",
				//Image = Helpers.ImageToByteArrayAsync(frmfileLst[0]),
				Latitude = 26.400829900F,
				Longitude = -80.198654000F,
				Description = "This iguana was lying on the sidewalk.  It's not moving, so I assume it's dead."
			});

			/*-- 3 --*/
			_ = await databaseContext.Iguanas.AddAsync(new Iguana()
			{
				Id = 3,
				DatePosted = DateTime.Now,
				City = "Boca Raton",
				State = "Florida",
				//Image = Helpers.ImageToByteArrayAsync(frmfileLst[0]),
				Latitude = 26.400829900F,
				Longitude = -80.198654000F,
				Description = "This iguana was basking in the sun by the street."
			});

			await databaseContext.SaveChangesAsync();
			return databaseContext;
		}


		//TESTS

		[Fact]
		public void FirstItemNotNull()
		{
			var ig = _dbTest.Iguanas.Find(1);
			Assert.NotNull(ig);
		}

		[Fact]
		public async void IguanasTableNotEmptyOrNull()
		{
			Assert.True(await _dbTest.Iguanas.CountAsync() > 0);
			Assert.NotNull(_dbTest.Iguanas);
		}

		[Fact]
		public void DeleteRecordTest(){
			try{
				var ig = _dbTest.Iguanas.Find(3);
				_dbTest.Iguanas.Remove(ig);
				_dbTest.SaveChanges();
				Assert.Null(_dbTest.Iguanas.Find(3));
			}
			catch (Exception)
			{
				// ignored
			}
		}
	}
}
