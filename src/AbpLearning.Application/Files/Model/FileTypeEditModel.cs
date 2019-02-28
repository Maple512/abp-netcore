namespace AbpLearning.Application.Files.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using AbpLearning.Core.Files;

    [AutoMapTo(typeof(FileType))]
    public class FileTypeEditModel
    {
        /// <summary>
        /// 文件类型名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 后缀名(IEnumerable)
        /// </summary>
        public IEnumerable<string> Extensions { set; get; }
    }
}
