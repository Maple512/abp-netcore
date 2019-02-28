namespace AbpLearning.Core.Files
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Abp.Json;

    /// <summary>
    /// 文件类型
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.File + nameof(FileType), Schema = AbpLearningConsts.TableSchemaName.File)]
    public class FileType : AuditedEntity<int>, ISoftDelete
    {
        /// <summary>
        /// 文件类型名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 后缀名(IEnumerable)
        /// </summary>
        public IEnumerable<string> Extensions => ExtensionJSON?.FromJsonString<IEnumerable<string>>();

        /// <summary>
        /// 后缀名（集合，JSON格式）
        /// <code>
        /// ["jpeg","gif","png"]...
        /// </code>
        /// </summary>
        public string ExtensionJSON { get; set; }

        public bool IsDeleted { get; set; }
    }
}
