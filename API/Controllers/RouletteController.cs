using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data.Dtos;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly IRoulette _repo;
        private readonly DataContext _context;
        public RouletteController(DataContext context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetRoulettes(){
            var roulettes =  await _context.Roulettes.ToListAsync();
            return Ok(roulettes);
        } 

        [HttpPost("newroulette")]
        public async Task<IActionResult> NewRoulette(Roulette rouletteNew){

            rouletteNew.NameRoulette = rouletteNew.NameRoulette.ToLower();
            if (await _repo.RouletteExists(rouletteNew.NameRoulette))
            {
                return BadRequest("La ruleta ya existe");
            }
            var RouletteToCreate = new Roulette
            {
                NameRoulette = rouletteNew.NameRoulette,
                State = rouletteNew.State
            };
            var createdRoulette = await _repo.RegisterRoulette(RouletteToCreate);
            return Ok(createdRoulette.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ChangeStateRoulette(int id){
            var status = await _repo.ChangeStateRoulette(id);
            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> BetValidate(BetForInit bet, int IdUser ){
            var validate = await _repo.BetValidateRoulette(bet,IdUser);
            return Ok(validate);
        }
    }
}