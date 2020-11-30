using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos;
using API.Data.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RouletteRepository : IRoulette
    {
        private string[] Colors = {"black","red"};
        public long Top = 10_0000;
        private readonly DataContext _context;
        public RouletteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Roulette> RegisterRoulette(Roulette rouletteNew)
        {
            await _context.Roulettes.AddAsync(rouletteNew);
            await _context.SaveChangesAsync();
            return rouletteNew;
        }
        public async Task<bool> RouletteExists(string username)
        {
            if(await _context.Roulettes.AnyAsync(x => x.NameRoulette == username)){
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStateRoulette(int Id)
        {
            var RouletteSearch = await _context.Roulettes.FirstAsync(x => x.Id == Id);
            if(RouletteSearch != null){
            await _context.Roulettes.AddAsync(RouletteSearch);
            await _context.SaveChangesAsync();
            return true;
            }
            return false;
        }

        public async Task<bool> BetValidateRoulette(BetForInit Bet, int IdUser)
        {
            var Person = await _context.Users.FindAsync(IdUser); 
            if(Bet.CostBest <= Top && Person.CurrentBalance <= Bet.CostBest){
                if(Bet.NumBet >= 0 && Bet.NumBet <= 36){
                    if(Colors.Contains(Bet.Color)){
                    return true;
                    }
                }
            }
            return false;
        }
    }
}