using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CGIDigitalWeekWebChat.Models
{
    public static class CrowdModels
    {
        private static string StorageAccountConnectionString = "DefaultEndpointsProtocol=https;AccountName=nestorhubstorage;AccountKey=s9QL3M9moilOSR4xZ8qJVR1ngLaOO7n0pg/Vzu8zbEKODTWpGkYmXsZf1ZC0fERhuP2JDetI17w59hWjgIj+CQ==;EndpointSuffix=core.windows.net";
        public static int? GetPersons(string standId)
        {
            var storageAccount = CloudStorageAccount.Parse(StorageAccountConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();

            CloudTable iotTable = tableClient.GetTableReference("deviceData");
            TableQuery query = new TableQuery();
            //query.Select(new List<string>() {"message"});
            query.SelectColumns = new List<string>() { "deviceId", "persons" };
            query.Where(TableQuery.GenerateFilterCondition("deviceId", QueryComparisons.Equal, standId));
            var results = iotTable.ExecuteQuery(query);
            var result =  from elements in results
                           where elements.Timestamp == results.Max(c => c.Timestamp)
                           select new int?( elements.Properties["persons"].Int32Value.Value );
            return result.FirstOrDefault();
        }

    }
}