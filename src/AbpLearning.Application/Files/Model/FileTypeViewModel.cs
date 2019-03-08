namespace AbpLearning.Application.Files.Model
{
    using Abp.Application.Services.Dto;

    public class FileTypeViewModel : NullableIdDto<int>
    {
        /// <summary>
        /// 文件类型名
        /// </summary>
        public string Name { get; set; }
    }
}
