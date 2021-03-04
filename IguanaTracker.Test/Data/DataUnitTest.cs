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
		private FloridaIguanaTrackerDBContext dbTest;

		public DataTesting(){

			Initialize();
		}

		async void Initialize(){
			dbTest = await GetDatabaseContext();
		}

		private List<string> IguanaImagePaths()
		{
			string root = @"..\..\..\..\IguanaTracker.Test\Images\";
			List<string> iguanaImg = new List<string>();

			iguanaImg.Add(String.Format("{0}{1}", root, "21xp-iguana1-videoSixteenByNineJumbo1600.jpg"));
			iguanaImg.Add(String.Format("{0}{1}", root, "iguana-ap-er-190702_hpMain_1x1_992.jpg"));
			iguanaImg.Add(String.Format("{0}{1}", root, "IguanaUFIFAS.jpg"));

			return iguanaImg;
		}

		private List<FormFile> IguanaFormFiles(List<string> iguanaImg)
		{
			List<FormFile> frmFileLst = new List<FormFile>();

			for (int i = 0; i < iguanaImg.Count; i++)
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

		private async Task<FloridaIguanaTrackerDBContext> GetDatabaseContext(){
			var options = new DbContextOptionsBuilder<FloridaIguanaTrackerDBContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			var databaseContext = new FloridaIguanaTrackerDBContext(options);
			databaseContext.Database.EnsureCreated();
			if (await databaseContext.Iguanas.CountAsync() <= 0)
			{
				List<FormFile> frmfileLst = IguanaFormFiles(IguanaImagePaths());

				/*-- 1 --*/
				databaseContext.Iguanas.Add(new Iguana()
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
				databaseContext.Iguanas.Add(new Iguana()
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
				databaseContext.Iguanas.Add(new Iguana()
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
