using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IguanaTracker.Data.Helpers
{
	public class Helpers
	{
		//Convert image file to byte array
		public static async Task<byte[]> ImageToByteArrayAsync(IFormFile img){
			byte[] fileBytes = null;

			if (img.Length > 0 || img != null)
			{
				using (var ms = new MemoryStream())
				{
					try{
						img.CopyTo(ms);
						//await img.CopyToAsync(ms);
						await ms.WriteAsync(fileBytes, 0, fileBytes.Length);
						//fileBytes = ms.ToArray();
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
	}
}
