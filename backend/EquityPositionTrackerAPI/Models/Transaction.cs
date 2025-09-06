namespace EquityPositionTrackerAPI.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TradeID { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string ActionType { get; set; } // INSERT, UPDATE, CANCEL
        public string BuySell { get; set; }    // BUY, SELL
    }
}

