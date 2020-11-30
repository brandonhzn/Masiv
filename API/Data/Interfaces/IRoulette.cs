using System.Threading.Tasks;
using API.Data.Dtos;
using API.Entities;

namespace API.Data.Interfaces
{    public interface IRoulette
    {
        Task<Roulette> RegisterRoulette (Roulette rouletteNew);   
        Task<bool> RouletteExists (string RouletteName); 
        Task<bool> ChangeStateRoulette(int Id);
        Task<bool> BetValidateRoulette(BetForInit Bet, int IdUser);
    }
}