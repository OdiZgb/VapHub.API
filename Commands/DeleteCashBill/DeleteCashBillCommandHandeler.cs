using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.deleteItem
{


    public class DeleteCashBillCommandHandler : IRequestHandler<DeleteCashBillCommand, bool>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCashBillCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteCashBillCommand request, CancellationToken cancellationToken)
        {
            var historyOfCashBills = await _dbContext.HistoryOfCashBill
                                                     .Where(x => x.billId == request._Id)
                                                     .ToListAsync(cancellationToken);

            if (!historyOfCashBills.Any())
            {
                return false; // No items found with the given billId
            }

            foreach (var historyOfCashBill in historyOfCashBills)
            {
                historyOfCashBill.SoftDeleted = 1;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
