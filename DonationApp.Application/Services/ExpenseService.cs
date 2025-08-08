using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Services
    {
    public class ExpenseService(IUnitOfWork unitOfWork) : IExpenseService
        {


        #region Add

        public async Task<bool> AddExpenseAsync(ExpenseDto expenseEntity)
            {
            //var expenseEntity = new ExpenseDto
            //    {
            //    Id = expense.Id,
            //    Amount = expense.Amount,
            //    Description = expense.Description,
            //    Date = expense.Date
            //    };

            if ( expenseEntity.Amount <= 0 || string.IsNullOrEmpty(expenseEntity.Description) )
                {
                throw new ArgumentException("Expense amount must be greater than zero and description must be provided.");
                }
            var mappedExpense = new Expense
                (
                amount: expenseEntity.Amount,
                description: expenseEntity.Description,
                date: expenseEntity.Date,
                expenseType: expenseEntity.ExpenseType
                );

            await unitOfWork.GetRepository<Expense, Guid>().AddAsync(mappedExpense);
            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 ) return false;

            return true;

            }

        #endregion

        #region Get All

        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync()
            {

            var expenses = await unitOfWork.GetRepository<Expense, Guid>().GetAllAsync(null, false);
            if ( expenses is null || !expenses.Any() )
                {
                throw new KeyNotFoundException("No expenses found.");
                }
            var mappedExpenses = expenses.Select(e => new ExpenseDto
                {
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                ExpenseType = e.ExpenseType
                }).ToList();
            if ( mappedExpenses is null || !mappedExpenses.Any() )
                {
                throw new KeyNotFoundException("No expenses found.");
                }
            return mappedExpenses;

            }


        #endregion

        #region Get By Id

        public async Task<ExpenseDto> GetExpenseByIdAsync(Guid id)
            {
            var expense = await unitOfWork.GetRepository<Expense, Guid>().GetByIdAsync(id);
            if ( expense is null )
                {
                throw new KeyNotFoundException($"Expense with ID {id} not found.");
                }
            var mappedExpense = new ExpenseDto
                {
                Amount = expense.Amount,
                Description = expense.Description,
                Date = expense.Date,
                ExpenseType = expense.ExpenseType
                };
            return mappedExpense;
            }

        #endregion

        #region Update

        public async Task<bool> UpdateExpenseAsync(ExpenseDto expense)
            {
            if ( expense.Amount <= 0 || string.IsNullOrWhiteSpace(expense.Description) )
                throw new ArgumentException("Expense amount must be greater than zero and description must be provided.");

            var existingExpense = await unitOfWork.GetRepository<Expense, Guid>().GetByIdAsync(expense.Id);
            if ( existingExpense is null )
                throw new KeyNotFoundException($"Expense with ID {expense.Id} not found.");

            existingExpense.Amount = expense.Amount;
            existingExpense.Description = expense.Description;
            existingExpense.Date = expense.Date;
            existingExpense.ExpenseType = expense.ExpenseType;

            unitOfWork.GetRepository<Expense, Guid>().Update(existingExpense);

            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 )
                throw new Exception("Failed to update expense.");

            return true;
            }

        #endregion

        #region Delete

        public async Task<bool> DeleteExpenseAsync(Guid id)
            {

            var existingExpense = await unitOfWork.GetRepository<Expense, Guid>().GetByIdAsync(id);
            if ( existingExpense is null )
                {
                throw new KeyNotFoundException($"Expense with ID {id} not found.");
                }
            unitOfWork.GetRepository<Expense, Guid>().Delete(existingExpense);
            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 )
                {
                throw new Exception("Failed to delete expense.");
                }
            return true;

            }

        #endregion


        }
    }
