using System;
using InventoryRecordSystem.Models;
using InventoryRecordSystem.Services;

namespace InventoryRecordSystem.App
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Mouse", 50, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Keyboard", 30, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Monitor", 15, DateTime.Now));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            foreach (var item in _logger.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
