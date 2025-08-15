using System;
using InventoryRecordSystem.Interfaces;

namespace InventoryRecordSystem.Models
{
    // Immutable class for inventory item implementing IInventoryEntity
    public class InventoryItem : IInventoryEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateAdded { get; private set; }

        public InventoryItem(int id, string name, int quantity, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            DateAdded = dateAdded;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Quantity: {Quantity}, DateAdded: {DateAdded}";
        }

        // Serialize to CSV line
        public string ToCsvLine()
        {
            return $"{Id},{Name},{Quantity},{DateAdded:o}";
        }

        // Deserialize from CSV line
        public static InventoryItem FromCsvLine(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 4)
                throw new FormatException("Invalid line format.");

            int id = int.Parse(parts[0]);
            string name = parts[1];
            int quantity = int.Parse(parts[2]);
            DateTime dateAdded = DateTime.Parse(parts[3], null, System.Globalization.DateTimeStyles.RoundtripKind);

            return new InventoryItem(id, name, quantity, dateAdded);
        }
    }
}
