using API.Entities;

namespace API.Data.Dtos
{
    public class BetForInit
    {
        public long CostBest {get;set;}
        public string Color{get;set;}
        public int NumBet { get; set; }
        public Roulette Roulette { get; set; }
    }
}