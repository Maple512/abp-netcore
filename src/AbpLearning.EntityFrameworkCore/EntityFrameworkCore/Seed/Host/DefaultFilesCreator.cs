namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    using System.Collections.Generic;
    using System.Linq;
    using Abp.Extensions;
    using Abp.Json;
    using AbpLearning.Core.Files;
    using Microsoft.EntityFrameworkCore;

    public class DefaultFilesCreator
    {
        private readonly AbpLearningDbContext _context;

        public DefaultFilesCreator(AbpLearningDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            CreateFeatureIfNotExists("图片", new List<string> { "png", "jpg", "jpeg", "gif" });
            CreateFeatureIfNotExists("文本", new List<string> { "doc", "docx", "pdf", "txt", "html", "js", "css", "ts", "less", "xml", "sql" });
            CreateFeatureIfNotExists("视频", new List<string> { "mp4", "avi" });
            CreateFeatureIfNotExists("音乐", new List<string> { "mp3" });
            CreateFeatureIfNotExists("压缩包", new List<string> { "zip", "rar" });
        }

        private void CreateFeatureIfNotExists(string name, IEnumerable<string> extension)
        {
            if (_context.FileTypes.IgnoreQueryFilters().Any(m => m.Name == name))
            {
                return;
            }

            extension = extension.Where(m => !m.IsNullOrEmpty());

            _context.FileTypes.Add(new FileType
            {
                Name = name,
                ExtensionJSON = extension.ToJsonString(),
            });
            _context.SaveChanges();
        }
    }
}
