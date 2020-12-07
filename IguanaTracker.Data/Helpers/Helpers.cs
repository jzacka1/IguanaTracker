using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;

namespace IguanaTracker.Data.Helpers
{
	public class Helpers
	{
		//Convert image file to byte array
		public static byte[] ImageToByteArray(IFormFile img){
			byte[] fileBytes = null;

			if (img.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					img.CopyTo(ms);
					fileBytes = ms.ToArray();
				}
			}

			return fileBytes;
		}

		//Creates a string to include bytes to show image.
		public static string formatBytesToImage(byte[] imageBytes){
			return "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
		}
	}
}
