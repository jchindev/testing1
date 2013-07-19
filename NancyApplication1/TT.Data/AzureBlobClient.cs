using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;
using System.IO;

namespace TT.Data
{
    public class AzureBlobClient
    {
        protected CloudBlobClient _blobClient;

        public AzureBlobClient()
        {
            var storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public CloudBlobContainer CreateOrRetrieveContainer(string containerName)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();

            return container;
        }

        public void UploadBlob(FileStream fileStream, string blobName, string containerName)
        {
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = CreateOrRetrieveContainer(containerName);

            // Retrieve reference to a blob named blobName
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Create or overwrite the blobName blob with contents from file stream (upload dialog)
            blockBlob.UploadFromStream(fileStream);

            fileStream.Dispose();
        }

        public void DeleteBlob(string blobName, string containerName)
        {
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = CreateOrRetrieveContainer(containerName);

            // Retrieve reference to a blob named blobName
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Delete the blob.
            blockBlob.Delete();
        }
    }
}
