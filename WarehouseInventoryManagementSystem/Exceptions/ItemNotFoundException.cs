using System;

namespace WarehouseInventoryManagementSystem
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}
