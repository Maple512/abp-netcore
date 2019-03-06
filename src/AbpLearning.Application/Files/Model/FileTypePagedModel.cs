namespace AbpLearning.Application.Files.Model
{
    using System.Collections.Generic;
    using Abp.AutoMapper;
    using AbpLearning.Core.Files;

    [AutoMapFrom(typeof(FileType))]
    public class FileTypePagedModel
    {
        /// <summary>
        /// 文件类型名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 后缀名(IEnumerable)
        /// </summary>
        public IEnumerable<string> Extensions { get; }
    }
}
