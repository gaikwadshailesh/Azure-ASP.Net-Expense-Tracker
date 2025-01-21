using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text.Json;

namespace ExpenseTracker.Services
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _expensesContainer = "expenses";
        private readonly string _receiptsContainer = "receipts";
        private readonly string _reportsContainer = "reports";

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            InitializeContainers();
        }

        private async void InitializeContainers()
        {
            await _blobServiceClient.CreateBlobContainerAsync(_expensesContainer, PublicAccessType.None);
            await _blobServiceClient.CreateBlobContainerAsync(_receiptsContainer, PublicAccessType.None);
            await _blobServiceClient.CreateBlobContainerAsync(_reportsContainer, PublicAccessType.None);
        }

        public async Task<BlobContainerClient> GetExpensesContainerClient()
        {
            return _blobServiceClient.GetBlobContainerClient(_expensesContainer);
        }

        public async Task<BlobContainerClient> GetReceiptsContainerClient()
        {
            return _blobServiceClient.GetBlobContainerClient(_receiptsContainer);
        }

        public async Task<BlobContainerClient> GetReportsContainerClient()
        {
            return _blobServiceClient.GetBlobContainerClient(_reportsContainer);
        }
    }
} 