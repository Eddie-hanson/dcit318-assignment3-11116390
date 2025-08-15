using System;
using InventoryRecordSystem.App;

namespace InventoryRecordSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "inventory.txt";

            // Initialize app
            InventoryApp app = new InventoryApp(filePath);

            // Seed and save data
            app.SeedSampleData();
            app.SaveData();

            // Clear memory (simulate new session)
            app = new InventoryApp(filePath);

            // Load and display data
            app.LoadData();
            app.PrintAllItems();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
