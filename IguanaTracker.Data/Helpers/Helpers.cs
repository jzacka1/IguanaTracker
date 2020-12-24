﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;

namespace IguanaTracker.Data.Helpers
{
	public class Helpers
	{
		//Convert image file to byte array
		public static byte[] ImageToByteArrayAsync(IFormFile img){
			byte[] fileBytes = null;

			if (img.Length > 0 || img != null)
			{
				using (var ms = new MemoryStream())
				{
					try{
						img.CopyTo(ms);
						//await img.CopyToAsync(ms);
						//await ms.WriteAsync(fileBytes, 0, fileBytes.Length);
						fileBytes = ms.ToArray();
					}
					catch(Exception exception){

					}
				}
			}
			else{
				return null;
			}

			return fileBytes;
		}

		//Creates a string to include bytes to show image.
		public static string formatBytesToImage(byte[] imageBytes){
			return "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
		}

		//Close the connection for FileStream after calling the method
		public static FileStream LoadImageFromFolder(string path)
		{
			//string path = @"..\\..\\..\\..\\Read file from project\\Images\\21xp-iguana1-videoSixteenByNineJumbo1600.jpg";
			string filePath = Path.GetFullPath(path);

			try
			{
				FileStream fs = new FileStream(filePath, FileMode.Open);
				return fs;
			}
			catch (Exception exception)
			{

			}

			return null;

		}

		//Close the connection for MemoryStream after calling the method
		public static MemoryStream ConvertFileStreamToMemoryStream(FileStream fs)
		{
			MemoryStream ms = new MemoryStream();

			try
			{
				fs.CopyTo(ms);

				return ms;
			}
			catch (Exception exception)
			{

			}

			return null;
		}

		public static FormFile ConvertMemoryStreamToFormFile(MemoryStream ms, string name, string fileName)
		{
			try
			{
				return new FormFile(ms, 0, ms.Length, name, fileName);
			}
			catch (Exception exception)
			{

			}

			return null;
		}
	}
}
