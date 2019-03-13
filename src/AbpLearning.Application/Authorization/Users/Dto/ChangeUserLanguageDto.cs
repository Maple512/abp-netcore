namespace AbpLearning.Application.Authorization.Users.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}