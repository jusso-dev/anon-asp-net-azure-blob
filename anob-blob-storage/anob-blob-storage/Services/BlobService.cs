using anob_blob_storage.Models;
using Azure.Storage.Blobs;

namespace anob_blob_storage.Services
{
	/// <summary>
    /// Queries Azure Storage Accounts for all blobs in a particular container
    /// </summary>
	public class BlobService : IBlobService
	{
		string connectionString = string.Empty;
		string containerName = string.Empty;

		private readonly IConfiguration _config;

        BlobContainerClient blobContainerClient;

        public BlobService(IConfiguration configuration)
		{
			_config = configuration;
			connectionString = _config["AZURE_STORAGE_CONNECTION_STRING"];
			containerName = _config["BLOB_CONTAINER_NAME"];

			blobContainerClient = new BlobContainerClient(connectionString, containerName);
		}

		public async Task<List<BlobFile>> ReturnAllFilesAsync()
        {
			List<BlobFile> blobFiles = new List<BlobFile>();
			string storageAccountUrl = $"https://{blobContainerClient.AccountName}.blob.core.windows.net/{containerName}";

            await foreach (var blob in blobContainerClient.GetBlobsAsync())
            {
				blobFiles.Add(new BlobFile() { Title = blob.Name, URL = storageAccountUrl + "/" + blob.Name });
            }

			return blobFiles;
        }
	}
}

