using EquityPositionTrackerAPI.Data;
using EquityPositionTrackerAPI.Models;

namespace EquityPositionTrackerAPI.Repos
{
    public class TradeRepository : ITradeRepository
    {
        private readonly AppDbContext _context;

        public TradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetTradesByTradeID(string tradeID)
        {
            return _context.Transactions
                .Where(t => t.TradeID == tradeID)
                .Select(t => new Transaction
                {
                    TradeID = t.TradeID,
                    Version = t.Version,
                    SecurityCode = t.SecurityCode,
                    Quantity = t.Quantity,
                    ActionType = t.ActionType,
                    BuySell = t.BuySell
                })
                .ToList();
        }

        public void SaveTrade(Transaction dto)
        {
            var entity = new Transaction
            {
                TradeID = dto.TradeID,
                Version = dto.Version,
                SecurityCode = dto.SecurityCode,
                Quantity = dto.Quantity,
                ActionType = dto.ActionType,
                BuySell = dto.BuySell
            };

            _context.Transactions.Add(entity);
            _context.SaveChanges();
        }

    }
}
