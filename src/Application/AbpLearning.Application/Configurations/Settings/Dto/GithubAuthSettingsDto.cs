using System.ComponentModel.DataAnnotations;

namespace AbpLearning.Application.Configurations.Settings.Dto
{
    public class GithubAuthSettingsDto
    {
        /// <summary>
        /// GitHub授权是否启用
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// GitHub授权Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// GitHub授权Client Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// GitHub授权地址
        /// </summary>
        [DataType(DataType.Url)]
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// GitHub授权获取Access Token
        /// </summary>
        [DataType(DataType.Url)]
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// GitHub授权获取用户信息地址
        /// </summary>
        [DataType(DataType.Url)]
        public string UserinfoUrl { get; set; }
    }
}
