using EquityPositionTrackerAPI.Models;

namespace EquityPositionTrackerAPI.Services
{
    public interface ITradeProcessor
    {
        void ProcessTransaction(Transaction transaction);
        IEnumerable<Position> GetAllPositions();
    }

}
