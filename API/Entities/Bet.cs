namespace API.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public long CostBest {get;set;}
        public string Color{get;set;}
        public int NumBet { get; set; }
        public Roulette Roulette { get; set; }

    }
}