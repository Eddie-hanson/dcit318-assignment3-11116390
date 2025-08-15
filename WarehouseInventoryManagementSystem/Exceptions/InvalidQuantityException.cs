using System;

namespace WarehouseInventoryManagementSystem
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
}
