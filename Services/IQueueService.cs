// using System.Text;
// using Azure.Storage.Blobs;
// using Azure.Storage.Queues;
// using Azure.Storage.Sas;
//
// namespace WebApp.Services;
//
// public interface IQueueService
// {
//     Task SendMessageAsync(string queue, string message);
// }
//
// public class StorageQueueService : IQueueService
// {
//     private readonly string? _storageConn;
//     
//     public StorageQueueService(string storageConn)
//     {
//         _storageConn = storageConn;
//     }
//     
//     public async Task SendMessageAsync(string queue, string message)
//     {
//         var queueClient = new QueueClient(_storageConn, queue);
//         await queueClient.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(message)));
//     }
// }