// using Azure.Storage.Blobs;
// using Azure.Storage.Sas;
//
// namespace WebApp.Services;
//
// public interface IStorageService
// {
//     Task<string?> UploadFileAsync(string absoluteFilePath, Stream stream);
// }
//
// public class StorageBlobService : IStorageService
// {
//     private readonly BlobContainerClient _containerClient = null!;
//     private const string ContainerImages = "images";
//     
//     public StorageBlobService(string connStr)
//     {
//         // var blobServiceClient = new BlobServiceClient(connStr);
//         // _containerClient = blobServiceClient.GetBlobContainerClient(ContainerImages);
//         // _containerClient.CreateIfNotExists();
//     }
//     
//     public async Task<string?> UploadFileAsync(string absoluteFilePath, Stream stream)
//     {
//         return null;
//         
//         // BlobClient? blobClient = _containerClient.GetBlobClient(absoluteFilePath);
//         // _ = await blobClient.UploadAsync(stream, true);
//         //
//         // return blobClient.Uri.AbsoluteUri;
//     }
// }