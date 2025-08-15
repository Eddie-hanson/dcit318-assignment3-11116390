using System;
using System.Collections.Generic;
using System.IO;
using InventoryRecordSystem.Interfaces;

namespace InventoryRecordSystem.Services
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new List<T>();
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, false))
                {
                    foreach (var item in _log)
                    {
                        if (item is InventoryRecordSystem.Models.InventoryItem invItem)
                        {
                            writer.WriteLine(invItem.ToCsvLine());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                _log.Clear();

                if (!File.Exists(_filePath))
                    return;

                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (typeof(T) == typeof(InventoryRecordSystem.Models.InventoryItem))
                        {
                            var item = InventoryRecordSystem.Models.InventoryItem.FromCsvLine(line);
                            _log.Add((T)(IInventoryEntity)item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                _log.Clear();
            }
        }
    }
}
