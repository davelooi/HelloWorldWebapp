using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

public class ListFilesSample
{
    public IEnumerable<Google.Apis.Storage.v1.Data.Object> ListFiles(
        string bucketName = "dave-proj-bucket")
    {
        var storage = StorageClient.Create();
        var storageObjects = storage.ListObjects(bucketName);
        Console.WriteLine($"Files in bucket {bucketName}:");
        foreach (var storageObject in storageObjects)
        {
            Console.WriteLine(storageObject.Name);
        }

        return storageObjects;
    }
}
