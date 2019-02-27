using System.ComponentModel.DataAnnotations;

namespace AbpLearning.Application.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}