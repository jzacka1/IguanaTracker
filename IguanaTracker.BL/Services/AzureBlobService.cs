using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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

		public AzureBlobService(BlobServiceClient blobServiceClient, string containerName)
		{
			_blobServiceClient = blobServiceClient;
			_blobContainer = GetBlobContainer(containerName);
			//_blobContainer.CreateIfNotExists(PublicAccessType.Blob);
		}

		public BlobContainerClient GetBlobContainer(string containerName){
			return _blobServiceClient.GetBlobContainerClient(containerName);
		}

		public void UploadFileToStorage(IFormFile file, string fileName){
			GetBlobByFileName(fileName)
				.Upload(file.OpenReadStream());
		}

		public BlobClient GetBlobByFileName(string fileName){
			return _blobContainer.GetBlobClient(fileName);
		}

		public string GetFileLinkByName(string fileName)
		{
			return GetBlobByFileName(fileName).Uri.ToString();
		}
	}
}
