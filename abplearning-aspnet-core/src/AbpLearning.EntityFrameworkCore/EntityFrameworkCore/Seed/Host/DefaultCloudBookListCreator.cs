namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    using System.Linq;
    using Core.CloudBookList.BookLists;
    using Core.CloudBookList.Books;
    using Core.CloudBookList.BookTags;
    using Core.CloudBookList.Relationships;
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
            AddBookIfNotExists("无羁", "墨香铜臭", "http://img3m9.ddimg.cn/23/21/26263139-1_u_2.jpg",
                @"“夷陵老祖”魏无羡，前世受万人唾骂，声名狼藉。被情同手足的师弟带人端了老巢，
纵横一世，死无全尸。十三年后，被人以禁术强行召回世上，竟沦为一名受尽欺压折辱的疯人，卷入一桩诡异的五马分尸奇案！在曾与自己“水火不容”的仙门名士蓝忘机结伴同行的路上，
往事风云再起。鬼手魅影、吃人石冢、迷雾棺城……乱葬岗围剿、血洗不夜天、穷奇道截杀……
这一次，“夷陵老祖”魏无羡与“含光君”蓝忘机携手探秘，能否解开这几十年间的重重谜团？", "http://product.dangdang.com/26263139.html");

            AddBookTagIfNotExists("有点好看");
            AddBookTagIfNotExists("作者是谁");
            AddBookTagIfNotExists("不知道有没有女主");

            AddBookAndBookTagIfNotExists(1, 1);
            AddBookAndBookTagIfNotExists(1, 2);
            AddBookAndBookTagIfNotExists(1, 3);

            AddBookListIfNotExists("科幻", "");
            AddBookListIfNotExists("新武侠", "");
            AddBookListIfNotExists("魔幻", "");
            AddBookListIfNotExists("玄幻", "");

            AddBookListAndBookIfNotExists(1, 1);
            AddBookListAndBookIfNotExists(2, 1);
            AddBookListAndBookIfNotExists(3, 1);
            AddBookListAndBookIfNotExists(4, 1);
        }

        private void AddBookIfNotExists(string name, string author, string converImgUrl = null, string intro = null, string url = null)
        {
            if (_context.Book.IgnoreQueryFilters().Any(s => s.Name == name))
            {
                return;
            }

            _context.Book.Add(new Book(name, author, converImgUrl, intro, url));
            _context.SaveChanges();
        }

        private void AddBookTagIfNotExists(string name, int? tenantId = null)
        {
            if (_context.BookTag.IgnoreQueryFilters().Any(s => s.Name == name))
            {
                return;
            }

            _context.BookTag.Add(new BookTag(name, tenantId));
            _context.SaveChanges();
        }

        private void AddBookListIfNotExists(string name, string intro = null)
        {
            if (_context.BookList.IgnoreQueryFilters().Any(s => s.Name == name))
            {
                return;
            }

            _context.BookList.Add(new BookList(name, intro));
            _context.SaveChanges();
        }

        private void AddBookListAndBookIfNotExists(long bookListId, long bookId)
        {
            if (_context.BookListAndBookRelationship.IgnoreQueryFilters().Any(s => s.BookListId == bookListId && s.BookId == bookId))
            {
                return;
            }

            _context.BookListAndBookRelationship.Add(new BookListAndBookRelationship(bookListId, bookId));
            _context.SaveChanges();
        }

        private void AddBookAndBookTagIfNotExists(long bookId, long bookTagId)
        {
            if (_context.BookAndBookTagRelationship.IgnoreQueryFilters().Any(s => s.BookId == bookId && s.BookTagId == bookTagId))
            {
                return;
            }

            _context.BookAndBookTagRelationship.Add(new BookAndBookTagRelationship(bookId, bookTagId));
            _context.SaveChanges();
        }
    }
}
