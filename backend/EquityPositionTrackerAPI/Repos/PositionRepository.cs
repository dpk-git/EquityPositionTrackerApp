using EquityPositionTrackerAPI.Data;
using EquityPositionTrackerAPI.Models;

namespace EquityPositionTrackerAPI.Repos
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void UpdatePosition(string securityCode, int delta)
        {
            var position = _context.Positions
                .FirstOrDefault(p => p.SecurityCode == securityCode);

            if (position == null)
            {
                position = new Position
                {
                    SecurityCode = securityCode,
                    NetQuantity = delta
                };
                _context.Positions.Add(position);
            }
            else
            {
                position.NetQuantity += delta;
                _context.Positions.Update(position);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _context.Positions
                .Select(p => new Position
                {
                    SecurityCode = p.SecurityCode,
                    NetQuantity = p.NetQuantity
                })
                .ToList();
        }

    }
}
