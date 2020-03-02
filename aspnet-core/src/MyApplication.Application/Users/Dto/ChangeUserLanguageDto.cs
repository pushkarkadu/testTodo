using System.ComponentModel.DataAnnotations;

namespace MyApplication.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}