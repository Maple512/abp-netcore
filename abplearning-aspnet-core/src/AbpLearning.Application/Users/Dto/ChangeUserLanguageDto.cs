using System.ComponentModel.DataAnnotations;

namespace AbpLearning.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}