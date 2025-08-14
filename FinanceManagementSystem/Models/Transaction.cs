using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace FinanceManagementSystem.Models
    {
    // Ensure the project is targeting .NET 5.0 or later to support 'record' types.
    public record Transaction(int Id, DateTime Date, decimal Amount, string Category);
    }
