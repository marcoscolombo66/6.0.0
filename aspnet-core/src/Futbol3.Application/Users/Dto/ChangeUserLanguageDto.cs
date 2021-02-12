using System.ComponentModel.DataAnnotations;

namespace Futbol3.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}