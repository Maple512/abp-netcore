namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    using System.Linq;
    using Core.CloudBookList.BookLists;
    using Core.CloudBookList.Books;
    using Core.CloudBookList.BookTags;
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
