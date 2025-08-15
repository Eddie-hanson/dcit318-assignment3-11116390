using System;

namespace WarehouseInventoryManagementSystem
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
