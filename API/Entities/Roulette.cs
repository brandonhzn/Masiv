using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
    public class Roulette
    {
        public int Id { get; set; }
        [Required]
        public string NameRoulette { get; set; }
        [Required]
        public bool State { get; set; }

    }
}