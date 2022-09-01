// using FinancialTrackerMVC.Data;
// using FinancialTrackerMVC.Data.Entities;
// using FinancialTrackerMVC.Models.CreditCards;
// using Microsoft.EntityFrameworkCore;

// namespace FinancialTrackerMVC.Services.CreditCardsService
// {
//     public class CreditCards : ICreditCards
//     {
//         private readonly FinancialTrackerDbContext _dbContext;
//         public CreditCards(FinancialTrackerDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public async Task<bool> CreateCreditCardsAsync(CreditCardsCreate model)
//         {
//             var cred = new CreditCardsEntity
//             {
//                 CCDebtorType = model.DebtorType,
//                 amountDue = model.amountDue,
//                 dueDate = model.dueDate
//             };
//             _dbContext.CreditCards.Add(cred);
//             var numberOfChanges = await _dbContext.SaveChangesAsync();
//             return numberOfChanges == 1;
//         }

//         public async Task<IEnumerable<CreditCardsDetail>> GetAllCreditCardsAsync()
//         {
//             var cred = await _dbContext.CreditCards
//             .Select(
//                 s => new CreditCardsDetail
//                 {
//                     id = s.id,
//                     DebtorType = s.CCDebtorType,
//                     amountDue = s.amountDue,
//                     dueDate = s.dueDate
//                 }
//             )
//             .ToListAsync();
//             return cred;
//         }

//         public async Task<CreditCardsDetail> GetCreditCardsByIdAsync(int id)
//         {
//             var cred = await _dbContext.CreditCards
//             .Select(
//                 s => new CreditCardsDetail
//                 {
//                     id = s.id,
//                     DebtorType = s.CCDebtorType,
//                     amountDue = s.amountDue,
//                     dueDate = s.dueDate
//                 }
//             )
//             .Where(
//                 s => s.id == id
//             )
//             .FirstOrDefaultAsync();
//             return cred;
//         }

//         public async Task<bool> UpdateCreditCardsAsync(int id, CreditCardsUpdate request)
//         {
//             var cred = await _dbContext.CreditCards.FindAsync(id);
//             if (cred is null)
//             {
//                 return false;
//             }
//             cred.CCDebtorType = request.DebtorType;
//             cred.amountDue = request.amountDue;
//             cred.dueDate = request.dueDate;
//             var numberOfChanges = await _dbContext.SaveChangesAsync();
//             return numberOfChanges == 1;
//         }

//         public async Task<bool> DeleteCreditCardsAsync(int id)
//         {
//             var cred = await _dbContext.CreditCards.FindAsync(id);
//             if (cred is null)
//             {
//                 return false;
//             }
//             _dbContext.CreditCards.Remove(cred);
//             return await _dbContext.SaveChangesAsync() == 1;
//         }
        
//     }
// }