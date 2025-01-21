using ExpenseTracker.Models;
using System.Text.Json;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly BlobStorageService _blobStorageService;

        public ExpenseService(BlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            var container = await _blobStorageService.GetExpensesContainerClient();
            var expenses = new List<Expense>();

            await foreach (var blob in container.GetBlobsAsync())
            {
                var blobClient = container.GetBlobClient(blob.Name);
                var content = await blobClient.DownloadContentAsync();
                var expense = JsonSerializer.Deserialize<Expense>(content.Value.Content);
                if (expense != null)
                    expenses.Add(expense);
            }

            return expenses;
        }

        public async Task SaveExpenseAsync(Expense expense)
        {
            var container = await _blobStorageService.GetExpensesContainerClient();
            var blobClient = container.GetBlobClient($"{expense.Id}.json");
            var json = JsonSerializer.Serialize(expense);
            var content = new BinaryData(json);
            await blobClient.UploadAsync(content, overwrite: true);
        }

        public async Task DeleteExpenseAsync(string id)
        {
            var container = await _blobStorageService.GetExpensesContainerClient();
            var blobClient = container.GetBlobClient($"{id}.json");
            await blobClient.DeleteIfExistsAsync();
        }
    }
} 