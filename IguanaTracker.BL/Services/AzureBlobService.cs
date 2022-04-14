using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ExifLib;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.BL.Services
{
	public class AzureBlobService
	{
		private readonly BlobServiceClient _blobServiceClient;
		private readonly BlobContainerClient _blobContainer;

		public AzureBlobService(BlobServiceClient blobServiceClient) : base(){
			_blobServiceClient = blobServiceClient;
		}

		/// <summary>
		/// Fetch blob container from Azure with the same name
		/// </summary>
		/// <param name="blobServiceClient">BlobClient Service parameter instantiated via dependency Injection</param>
		/// <param name="containerName">Name of container within Azure Blob storage</param>
		public AzureBlobService(BlobServiceClient blobServiceClient, string containerName)
		{
			_blobServiceClient = blobServiceClient;
			_blobContainer = GetBlobContainer(containerName);
			//_blobContainer.CreateIfNotExists(PublicAccessType.Blob);
		}

		/// <summary>
		/// Fetch blob container from Azure with the same name
		/// </summary>
		/// <param name="containerName">Name of container in the Blob storage</param>
		/// <returns>BlobContainerClient with the same name of container</returns>
		public BlobContainerClient GetBlobContainer(string containerName){
			return _blobServiceClient.GetBlobContainerClient(containerName);
		}

		/// <summary>
		/// Upload to file to blob container
		/// </summary>
		/// <param name="file">file from the form</param>
		/// <param name="fileName">Name of file to the new uploaded file</param>
		/// <param name="blobHttpHeader">Set Http properties</param>
		/// <returns>BlobClient where the file with the same name is located</returns>
		public void UploadFileToStorage(IFormFile file, string fileName, BlobHttpHeaders blobHttpHeader){
			GetBlobByFileName(fileName)
			.Upload(file.OpenReadStream(), blobHttpHeader);
		}

		/// <summary>
		/// Fetch a filename from the blob storage
		/// </summary>
		/// <param name="fileName">Name of file stored in the Blob storage</param>
		/// <returns>BlobClient where the file with the same name is located</returns>
		public BlobClient GetBlobByFileName(string fileName){
			return _blobContainer.GetBlobClient(fileName);
		}

		/// <summary>
		/// Fetch link to the file from the blob storage
		/// </summary>
		/// <param name="fileName">Name of file stored in the Blob storage</param>
		/// <returns>Link to file</returns>
		public Uri GetFileLinkByName(string fileName)
		{
			return GetBlobByFileName(fileName).Uri;
		}
	}
}
