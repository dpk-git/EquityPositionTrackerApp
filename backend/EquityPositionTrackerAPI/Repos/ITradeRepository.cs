using EquityPositionTrackerAPI.Models;

namespace EquityPositionTrackerAPI.Repos
{
    public interface ITradeRepository
    {
        IEnumerable<Transaction> GetTradesByTradeID(string tradeID);
        void SaveTrade(Transaction trade);
    }

}
