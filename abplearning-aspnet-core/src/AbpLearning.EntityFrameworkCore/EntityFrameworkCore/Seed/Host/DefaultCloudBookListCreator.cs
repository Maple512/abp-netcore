namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    using System.Linq;
    using Core.CloudBookLists.BookLists;
    using Core.CloudBookLists.Books;
    using Core.CloudBookLists.BookTags;
    using Microsoft.EntityFrameworkCore;

    public class DefaultCloudBookListCreator
    {
        private readonly AbpLearningDbContext _context;

        public DefaultCloudBookListCreator(AbpLearningDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            
        }
        
    }
}
