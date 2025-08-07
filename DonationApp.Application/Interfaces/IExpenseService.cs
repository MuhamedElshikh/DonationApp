using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Shared.Dtos;

namespace DonationApp.Applications.Interfaces
{
    public interface IExpenseService
    {
        Task<bool> AddExpenseAsync(ExpenseDto expense);
        Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync();
        Task<ExpenseDto> GetExpenseByIdAsync(Guid id);
        Task<bool> UpdateExpenseAsync(ExpenseDto expense);
        Task<bool> DeleteExpenseAsync(Guid id);
    }
}
