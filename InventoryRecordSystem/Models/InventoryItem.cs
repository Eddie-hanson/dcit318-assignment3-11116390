using System;
using InventoryRecordSystem.Interfaces;

namespace InventoryRecordSystem.Models
{
    // Immutable record for inventory item
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
