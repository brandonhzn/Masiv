using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "La contraseña especificada debe estar entre 4 y 8 caracteres.")]
        public string Password { get; set; }
        [Required]
        public string Names {get; set; }
        [Required]
        public string SecondNames { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string PlaceBirth { get; set; }
        [Required]
        public string PlaceLive {get;set;}
        [Required]
        public string Genere { get; set; }
        
        public string Hobbies { get; set; }
    }
}