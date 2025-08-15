using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseInventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new WareHouseManager();
            manager.SeedData();

            Console.WriteLine("\n--- Grocery Items ---");
            manager.PrintAllItems(manager.GetGroceriesRepo());

            Console.WriteLine("\n--- Electronic Items ---");
            manager.PrintAllItems(manager.GetElectronicsRepo());

            Console.WriteLine("\n--- Testing Exceptions ---");

            try
            {
                
                manager.GetGroceriesRepo().AddItem(new GroceryItem(1, "Milk", 10, DateTime.Now.AddDays(5)));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                // Remove non-existent
                manager.GetElectronicsRepo().RemoveItem(99);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                // Update with invalid quantity
                manager.GetGroceriesRepo().UpdateQuantity(2, -10);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Final Grocery Items ---");
            manager.PrintAllItems(manager.GetGroceriesRepo());
        }
        }
}

