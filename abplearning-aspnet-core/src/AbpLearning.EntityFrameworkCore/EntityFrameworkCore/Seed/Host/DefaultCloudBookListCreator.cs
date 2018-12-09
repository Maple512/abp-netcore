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
            AddBookIfNotExists("鬼谷子", "（战国）鬼谷子", "http://img3m0.ddimg.cn/5/26/23691200-1_w_8.jpg",
                @"《鬼谷子》一书是其后学者根据其言论整理而成的，这部两千多年前的谋略学巨著，是中国传统文化中的奇葩，历来被人们称为“智慧之禁果，旷世之奇书”。
其思想内容十分丰富，涵盖了哲学、政治学、军事学、心理学、社会学、文学、情报学等多种学科，是一部可以被广泛解读的著作。它一直为中国乃至世界军事家、政治家和外交家所研究，
现又成为当代商家的必备之书。它所揭示的智谋权术的各类表现形式，被广泛运用于内政，外交、战争、经贸及公关等领域，其思想深深影响今人，享誉海内外。",
                "http://product.dangdang.com/23691200.html");

            AddBookIfNotExists("菜根谭", "洪应明", "http://img3m3.ddimg.cn/8/29/23691203-1_w_7.jpg",
                @"《菜根谭》是一部论述修养、人生、处世、出世的语录世集，是囊括五千年中国处世智慧的奇书。
作为一部富有汉民族生活伦理思想的著作，采儒、道、佛三家之精髓，以儒道为核心，拥有修身、齐家、治国、平天下等大道；融处世哲学，生活艺术，审美情趣于一体；
它似语录，却拥有语录所没有的趣味；它似随笔，却拥有随笔所不及的整饬。它是一部文辞优美、含义深邃的读物，更是一部陶冶人之情操、磨炼人之意志、催人奋发向上的中国文学作品。
“咬得菜根者则百事可为”，《菜根谭》以众多富含哲理的名言警句教予世人出世入世之法则及", "http://product.dangdang.com/23691203.html");

            AddBookIfNotExists("论语别裁", "南怀瑾", "http://img3m7.ddimg.cn/87/13/25274787-3_w_6.jpg",
                @"我们要了解传统文化，首先必须了解儒家的学术思想。要讲儒家的思想，首先便要研究孔孟的学术。要讲孔子的思想学术，
必须先要了解《论语》。《论语》是一部记载孔子言语行事的重要儒家经典，相关章句注疏累代不绝。南怀瑾先生曾于1962年至1975年间三次讲述《论语》。
第三次讲记结集出版时，南先生定名为“别裁”，意谓其讲述是个人所见，别裁于正宗儒者经学之外。南先生认为历来对《论语》的讲解，错误之处，屡见不鲜，
主要问题在于所讲的义理不对，内容的讲法不合科学。他讲述《论语》，“别裁于正宗儒者经学之外”，重在“入乎其内、出乎其外地体验”。", "http://product.dangdang.com/25274787.html");

            AddBookIfNotExists("道德经", "(春秋) 老子", "http://img3m0.ddimg.cn/58/7/23475730-1_w_9.jpg",
                @"《道德经》亦称《五千言》，相传为春秋时老子所作，是道家的开山之作，更是中华文明的智慧源泉。全书分为上、下两篇。上篇称《道经》，下篇为《德经》。
《道经》讲述的是宇宙根本，道出了天地万物变化的奥妙。《德经》讲述的是处世方略。道出了人事的进退之术，包含了长生久世之道。", "http://product.dangdang.com/23475730.html");

            AddBookIfNotExists("易经杂说", "南怀瑾", "http://img3m2.ddimg.cn/31/12/23686672-1_w_1.jpg",
                @"本书介绍了六十四卦的来历、过去卜卦的几种方法、《易经》与五行、干支、《河图》《洛书》的配合运用等；阐释了《系传》所揭示的人生和历史哲学；详细讲解了乾卦、坤卦、屯卦、需卦的卦名、卦辞、爻辞，
以及解释它们的《彖辞》、《象辞》、《文言》，以之为例，示范六十四卦的研究方法；说明了《序卦》排列六十四卦的理由，等等。", "http://product.dangdang.com/23686672.html");

            AddBookIfNotExists("王阳明心学", "王觉仁", "http://img3m9.ddimg.cn/40/8/23730439-3_w_1.jpg",
                @"一介儒生王阳明，为什么能成为立德、立功、立言三不朽的圣人？为什么能成为曾国藩、梁启超、伊藤博文、稻盛和夫等中外名人共同的心灵导师？后世无数阳明心学的践行者，为什么也能走出精彩人生，成就辉煌事业？这是因为他们无一例外地掌握了解决一切问题的利器——阳明心学。
　　阳明心学集儒、释、道三家之大成，强调心即理、知行合一、致良知，是500年来中国人*精妙的神奇智慧。本书用通俗易懂的语言解读阳明心学的传世典籍《传习录》，深入浅出地阐释阳明心学的核心理念，旨在让今天的读者轻松领悟阳明心学知行合一的智慧精髓，修炼内心强大的自己，开启与生俱来的正能量，获得幸福完满的人生。
　　本次再版，由作者王觉仁精心修订全稿，并新增《阳明心学简明纲要》，以便读者对阳明心学有一个完整而清晰的认识，奠定进一步研究的基础。", "http://product.dangdang.com/23730439.html");

            AddBookTagIfNotExists("鬼谷子纵横家");
            AddBookTagIfNotExists("菜根谭修养");
            AddBookTagIfNotExists("王阳明是谁");
            AddBookTagIfNotExists("我是老子");
            AddBookTagIfNotExists("老子是我");
            AddBookTagIfNotExists("孔子");

            AddBookAndBookTagIfNotExists(1, 1);
            AddBookAndBookTagIfNotExists(2, 2);
            AddBookAndBookTagIfNotExists(3, 3);
            AddBookAndBookTagIfNotExists(4, 4);
            AddBookAndBookTagIfNotExists(5, 5);
            AddBookAndBookTagIfNotExists(6, 6);

            AddBookListIfNotExists("谋略学", "");
            AddBookListIfNotExists("儒家", "");
            AddBookListIfNotExists("道家", "");
            AddBookListIfNotExists("哲学", "");
            AddBookListIfNotExists("卜卦", ""); 
            AddBookListIfNotExists("心学", ""); 

            AddBookListAndBookIfNotExists(1, 1);
            AddBookListAndBookIfNotExists(2, 2);
            AddBookListAndBookIfNotExists(3, 3);
            AddBookListAndBookIfNotExists(4, 4);
            AddBookListAndBookIfNotExists(5, 5);
            AddBookListAndBookIfNotExists(6, 6);
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
