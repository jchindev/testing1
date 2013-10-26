using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using TT.BizLogic.Dto;

namespace TT.BizLogic
{
    public enum StrokeType
    {
        Forehand = 0,
        Backhand = 1,
        Slice = 2,
        Volley = 3,
        Serve = 4
    }

    public enum StrokeAngle
    {
        Front = 0,
        Back = 1,
        LeftSide = 2,
        RightSide = 3
    }

    public class Strokes
    {
        public StrokeDto GetStroke(int userId)
        {
            //todo:get from azure
            return new StrokeDto();
        }

        public StrokeDto GetStroke(int userId, StrokeType strokeType = StrokeType.Forehand, StrokeAngle strokeAngle = StrokeAngle.Front)
        {
            //todo:get from azure
            return new StrokeDto();
        }

        public void UploadStroke(StrokeDto strokeDto)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference("user-" + strokeDto.UserId.ToString());
            container.CreateIfNotExists();

            var blobName = GetVideoName(strokeDto);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            blockBlob.UploadFromStream(strokeDto.StrokeVideo);
        }

        private string GetVideoName(StrokeDto strokeDto)
        {
            var strokeType = Enum.GetName(typeof(StrokeType), (int)strokeDto.StrokeType);
            var strokeAngle = Enum.GetName(typeof(StrokeAngle), (int)strokeDto.StrokeAngle);
            return string.Format("{0}-{1}-{2}", strokeDto.UserId.ToString(), strokeType.ToLower(), strokeAngle.ToLower());
        }

    }
}
