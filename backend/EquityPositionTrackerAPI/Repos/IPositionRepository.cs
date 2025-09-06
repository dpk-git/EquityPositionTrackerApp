using EquityPositionTrackerAPI.Models;

namespace EquityPositionTrackerAPI.Repos
{
    public interface IPositionRepository
    {
        void UpdatePosition(string securityCode, int delta);
        IEnumerable<Position> GetAllPositions();
    }


}
