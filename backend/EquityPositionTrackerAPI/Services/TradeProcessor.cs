using EquityPositionTrackerAPI.Models;
using EquityPositionTrackerAPI.Repos;

namespace EquityPositionTrackerAPI.Services
{
    public class TradeProcessor : ITradeProcessor
    {
        private readonly ITradeRepository _tradeRepo;
        private readonly IPositionRepository _positionRepo;

        public TradeProcessor(ITradeRepository tradeRepo, IPositionRepository positionRepo)
        {
            _tradeRepo = tradeRepo;
            _positionRepo = positionRepo;
        }

        public void ProcessTransaction(Transaction dto)
        {
            var existingTrades = _tradeRepo.GetTradesByTradeID(dto.TradeID);
            var latestTrade = existingTrades.OrderByDescending(t => t.Version).FirstOrDefault();

            if (dto.ActionType == "INSERT")
            {
                ApplyTrade(dto);
                _tradeRepo.SaveTrade(dto);
            }
            else if (dto.ActionType == "UPDATE")
            {
                if (latestTrade != null)
                    ReverseTrade(latestTrade);

                ApplyTrade(dto);
                _tradeRepo.SaveTrade(dto);
            }
            else if (dto.ActionType == "CANCEL")
            {
                if (latestTrade != null)
                    ReverseTrade(latestTrade);

                _tradeRepo.SaveTrade(dto); // Save CANCEL for audit, but don’t apply
            }
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _positionRepo.GetAllPositions();
        }

        private void ApplyTrade(Transaction trade)
        {
            int signedQty = trade.BuySell == "BUY" ? trade.Quantity : -trade.Quantity;
            _positionRepo.UpdatePosition(trade.SecurityCode, signedQty);
        }

        private void ReverseTrade(Transaction trade)
        {
            int signedQty = trade.BuySell == "BUY" ? -trade.Quantity : trade.Quantity;
            _positionRepo.UpdatePosition(trade.SecurityCode, signedQty);
        }


    }


}
