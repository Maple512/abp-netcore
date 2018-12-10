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
            AddBookIfNotExists("高等数学（第七版）（上册）", "同济大学数学系", "http://img3m4.ddimg.cn/77/5/25205774-1_w_3.jpg",
                @"本书是同济大学数学系编的《高等数学》第七版，从整体上说与第六版没有大的变化，内容深广度符合“工科类本科数学基础课程教学基本要求”，适合高等院校工科类各专业学生使用。
本次修订遵循“坚持改革、不断锤炼、打造精品”的要求，对第六版中个别概念的定义，少量定理、公式的证明及定理的假设条件作了一些重要修改；对全书的文字表达、记号的采用进行了仔细推敲；
个别内容的安排作了一些调整，习题配置予以进一步充实、丰富，对少量习题作了更换。所有这些修订都是为了使本书更加完善，更好地满足教学需要。
本书分上、下两册出版，上册包括函数与极限、导数与微分、微分中值定理与导数的应用、不定积分、定积分及其应用、微分方程等内容，
书末还附有二阶和三阶行列式简介、基本初等函数的图形、几种常用的曲线、积分表、习题答案与提示。",
                "http://product.dangdang.com/25205774.html");

            AddBookListIfNotExists("教育", "教育...");
            AddBookListAndBookIfNotExists(1, 1);

            AddBookTagIfNotExists("高等数学教科书", "#f50");
            AddBookTagIfNotExists("高数啊啊啊", "#2db7f5");
            AddBookTagIfNotExists("伟大的数学", "#87d068");
            AddBookAndBookTagIfNotExists(1, 1);
            AddBookAndBookTagIfNotExists(1, 2);
            AddBookAndBookTagIfNotExists(1, 3);


            AddBookIfNotExists("活着（2017年新版）", "余华", "http://img3m0.ddimg.cn/7/27/25137790-3_w_3.jpg",
                @"《活着》是一部充满血泪的小说。余华通过一位中国农民的苦难生活 讲述了人如何去承受巨大的苦难；
讲述了眼泪的丰富和宽广；讲述了*望 的不存在：讲述了人是为了活着本身而活着…… 《活着》这部小说荣获意大利格林扎纳·卡佛文学奖*高奖项(1998年 )，
台湾《中国时报》10本好书奖(1994年)，香港“博益”15本好书奖 (1990年)；并入选香港《亚洲周刊》评选的“20世纪中文小说百年百强” ；
入选中国百位批评家和文学编辑评选的“九十年代*有影响的10部作品 ”。", "http://product.dangdang.com/25137790.html");

            AddBookListIfNotExists("小说", "小说...");
            AddBookListAndBookIfNotExists(2, 2);

            AddBookTagIfNotExists("小小小小说", "#108ee9");
            AddBookTagIfNotExists("充满血泪的", "#2db7f5");
            AddBookTagIfNotExists("香港小说", "#f5222d");
            AddBookAndBookTagIfNotExists(2, 4);
            AddBookAndBookTagIfNotExists(2, 5);
            AddBookAndBookTagIfNotExists(2, 6);


            AddBookIfNotExists("诗经（韩寒推荐，全三册注音插图版）", "骆玉明(解注)", "http://img3m3.ddimg.cn/70/8/25216063-1_w_10.jpg",
                @"关于版本：
　　以《毛诗正义》为底本，辅以其它版本全新精校。收录全305篇。
　　文字部分：
生僻字、多音字、假借字即时注音，通畅诵读。
复旦大学中文系教授骆玉明解注，每诗题解。
注释求简求全，综合历代名家见解而取其优。保留重要异说，提供不同视角的解读。
插图部分：
录日本江户时代细井徇《诗经名物图》全图二百余幅。
插图对应相关诗篇，并结合现代生物学对插图物种作简介说明。", "http://product.dangdang.com/25216063.html");

            AddBookListIfNotExists("文艺", "文艺...");
            AddBookListAndBookIfNotExists(3, 3);

            AddBookTagIfNotExists("诗诗诗诗诗经", "#238ee9");
            AddBookTagIfNotExists("诗正义", "#2d95f5");
            AddBookTagIfNotExists("全图二百余幅", "#f5234d");
            AddBookAndBookTagIfNotExists(3, 7);
            AddBookAndBookTagIfNotExists(3, 8);
            AddBookAndBookTagIfNotExists(3, 9);


            AddBookIfNotExists("我愿做你的欢喜，套路你的余生", "雷垒", "http://img3m4.ddimg.cn/42/4/25578474-1_w_3.jpg",
                @"这是一本纯爱故事集，作者雷垒用幽默诙谐的语言讲了一个又一个现实却温暖、调皮也浪漫的爱情故事。
有乍见心欢，小别思恋，久处怦然，也有久别重逢，失而复得，虚惊一场……这些故事或许把你治愈，或许让你感动，或许对你震撼。
愿你读完这几十个爱情故事，能被温暖几十秒钟、几十分钟、几十小时、几十天、几十年……", "http://product.dangdang.com/25578474.html");

            AddBookListIfNotExists("青春文学", "青春文学...");
            AddBookListAndBookIfNotExists(4, 4);

            AddBookTagIfNotExists("雷垒垒垒垒垒", "#528ee9");
            AddBookTagIfNotExists("温暖", "#2d95f5");
            AddBookTagIfNotExists("幽默诙谐", "#f5234d");
            AddBookAndBookTagIfNotExists(4, 10);
            AddBookAndBookTagIfNotExists(4, 11);
            AddBookAndBookTagIfNotExists(4, 12);


            AddBookIfNotExists("孩子看的编程启蒙书（全4册）", "【日】松田孝", "http://img3m5.ddimg.cn/1/4/25352515-5_w_3.jpg",
                @"《孩子看的编程启蒙书1：算法原来是这样的》算法是解决问题、实现目标的方法。思考算法，指挥计算机去做，就是编程。
读完这本书，孩子们将会了解到：如何思考算法来实现特定的目标，以及如何判断哪种算法合适。也就是说，他们能够学到基本的编程思维。
《孩子看的编程启蒙书2：掌握常用的算法》把大量东西按一定规则排列（排序），从中找出所需要的部分（检索），是计算机的“拿手好戏”。
这本书从孩子们的日常学习与生活经验入手，在运动会赛前练习、查字典、图书馆找书等场景中，介绍了冒泡排序、选择排序、二分检索、线性检索等常用的算法。
《孩子看的编程启蒙书3：用流程图描绘生活》在编写程序前，流程图充当着类似设计图的角色。如果能把算法先用流程图表示出来，就能很容易地把它写成程序。
种蔬菜、打扫卫生……只要掌握了一定的规则和方法，熟悉算法的三种基本结构，生活中的许多事都可以画成流程图！", "http://product.dangdang.com/25352515.html");

            AddBookListIfNotExists("童书", "童书...");
            AddBookListAndBookIfNotExists(5, 5);

            AddBookTagIfNotExists("孩子看的", "#528ee9");
            AddBookTagIfNotExists("编程程程程程", "#2d95f5");
            AddBookTagIfNotExists("规则和方法", "#f5234d");
            AddBookAndBookTagIfNotExists(5, 13);
            AddBookAndBookTagIfNotExists(5, 14);
            AddBookAndBookTagIfNotExists(5, 15);


            AddBookIfNotExists("大明首相（全三册，当当独家限量签名本）", "郭宝平", "http://img3m1.ddimg.cn/37/6/25584211-1_w_3.jpg",
                @"16世纪中叶，世界历史进入转折点，大明王朝也进入大变局的前夜。本书在充分尊重历史真实的基础上，塑造了给积弊丛生的大明王朝带来清明刚健新风，
以忠诚、干净、担当著称，锐志匡时，肩大任而不挠的执政者的真实形象，揭开了帝制中国上层的神秘面纱。在错综复杂的矛盾纠葛中，
全方位再现了大明中后期那段犹暗乍明、朦胧躁动的历史。本书主人公高拱是一位意识超前，推崇实政，集忠诚、干净、担当于一身的政治家、改革家、思想家，
也是有望引领中华号航船驶向新航道的领导人。在他的执政下，大明王朝面临战争与和平、保守与改革的抉择。这一时期，体制内的争斗表现得异常激烈，
从而使这部书不仅情节曲折，而且有相当的思想深度。张居正、海瑞、戚继光、王世贞、俺答汗、三娘子、邵大侠等作为与主人公有交集的重要人物，展示出不同的个性，
又反映了明朝中后期政治、经济、文化、军事、社会各方面的风貌。
本书注重对制度、风俗的考证，语言表述尊重历史原貌，人物事件不虚构，不美化，不丑化，以朝廷为枢纽，以人性为底色，使人仿佛置身时空隧道，
一览大明王朝的历史风景。", "http://product.dangdang.com/25584211.html#ddclick_lishizhubiantuijian");

            AddBookListIfNotExists("人文社科", "人文社科...");
            AddBookListAndBookIfNotExists(6, 6);

            AddBookTagIfNotExists("16世纪中叶", "#528ee9");
            AddBookTagIfNotExists("世界历史转折点", "#2d95f5");
            AddBookTagIfNotExists("大明王朝", "#f5234d");
            AddBookAndBookTagIfNotExists(6, 16);
            AddBookAndBookTagIfNotExists(6, 17);
            AddBookAndBookTagIfNotExists(6, 18);


            AddBookIfNotExists("大势将至，未来已来", "王鹏", "http://img3m3.ddimg.cn/91/8/25546843-1_w_9.jpg",
                @"「摩登中产」：一个面向城市新兴中产家庭的内容服务平台，由专业媒体团队创立打造，深受新兴中产家庭喜爱。
用时代的视角，观察中国中产阶层的诞生与成长，也用细致的笔触，解析中产阶层的困惑与烦恼。
本书涵盖「摩登中产」的精华思辨，紧扣当下时代脉搏，足以颠覆你对目前生活、职业、投资、未来的一切观点。", "http://product.dangdang.com/25546843.html");

            AddBookListIfNotExists("经营", "经营...");
            AddBookListAndBookIfNotExists(7, 7);

            AddBookTagIfNotExists("摩登中产", "#528ee9");
            AddBookTagIfNotExists("内容服务平台", "#2d95f5");
            AddBookTagIfNotExists("专业媒体团队创立打造", "#f5234d");
            AddBookAndBookTagIfNotExists(7, 19);
            AddBookAndBookTagIfNotExists(7, 20);
            AddBookAndBookTagIfNotExists(7, 21);


            AddBookIfNotExists("别做那只迷途的候鸟", "刘同", "http://img3m2.ddimg.cn/2/31/25536062-1_w_15.jpg",
                @"别人都在做自己喜欢的工作，为什么你不可以？
那是因为也许你还没听过“职场3232”法则啊！
《我在未来等你》《谁的青春不迷茫》新版之后，暌违数年，刘同重新书写职场，不仅写给每一只在时代浪潮中奋力打拼的职场候鸟，也是写给在职场拼搏十八年，
依然在前行的自己。职场上有这样一种新族群，他们随着大潮读书，求职，进入大城市，在人生关键的十年里，不愿错过每次机遇，就像一群候鸟，努力跟上每次冷暖迁徙，
一刻不停往前飞。然而不知不觉中，
许多人已经迷了路，找不到方向，找不到方法，也找不到动力。慢慢地，不知道自己喜欢什么、能做什么、能做多好，不断奔波漂泊，到头来，成熟的只是外表，
内心依然焦躁。", "http://product.dangdang.com/25536062.html");

            AddBookListIfNotExists("成功/励志", "成功/励志...");
            AddBookListAndBookIfNotExists(8, 8);

            AddBookTagIfNotExists("别人", "#528ee9");
            AddBookTagIfNotExists("为什么你不可以", "#2d95f5");
            AddBookTagIfNotExists("职场法则", "#f5234d");
            AddBookAndBookTagIfNotExists(8, 22);
            AddBookAndBookTagIfNotExists(8, 23);
            AddBookAndBookTagIfNotExists(8, 24);


            AddBookIfNotExists("婚姻心理学", "乐子丫头", "http://img3m2.ddimg.cn/33/25/25583712-1_w_2.jpg",
                @"具备实战价值的婚姻生活指南俗话说，好的爱情靠缘分，好的婚姻靠经营。再甜美、浪漫的爱情，走入婚姻之后，依然会面临着诸多挑战，
审美疲劳、生活琐事、婆媳关系、孕产育儿、夫妻沟通……每一样都需要我们用技巧去解决，用智慧去经营。在婚姻生活中，仅仅有一颗爱他（她）的心是不够的。
事实上，当婚姻问题发生时，通常只有一方会积极寻求解决方法，因为只有感受到痛苦的人才会寻求改变。也许你觉得不公平——为什么明明是对方的错，
却需要我来做出改变？其实很公平——谁痛苦谁改变谁改变谁受益。本书将教会你如何跟伴侣沟通、
如何提升自我魅力、如何为夫妻感情打好基础、如何将婚姻危机扼杀在萌芽状态，这些能力*终都会转化为你的心理优势，
让你把婚姻的主动权掌握在自己手里。", "http://product.dangdang.com/25583712.html");

            AddBookListIfNotExists("生活", "生活...");
            AddBookListAndBookIfNotExists(9, 9);

            AddBookTagIfNotExists("婚姻生活指南", "#528ee9");
            AddBookTagIfNotExists("经营婚姻", "#2d95f5");
            AddBookTagIfNotExists("沟通", "#f5234d");
            AddBookAndBookTagIfNotExists(9, 25);
            AddBookAndBookTagIfNotExists(9, 26);
            AddBookAndBookTagIfNotExists(9, 27);


            AddBookIfNotExists("C++ Primer Plus", "[美]Stephen Prata", "http://img3m4.ddimg.cn/40/14/22783504-1_w_4.jpg",
                @"C++ 是在 C 语言基础上开发的一种集面向对象编程、泛型编程和过程化编程于一体的编程语言，是C语言的超集。
《C Primer Plus(第6版)中文版》是根据2003年的ISO/ANSI C 标准编写的，
通过大量短小精悍的程序详细而全面地阐述了 C 的基本概念和技术，并专辟一章介绍了C 11新增的功能。
　　全书分18章和10个附录。分别介绍了C 程序的运行方式、基本数据类型、复合数据类型、循环和关系表达式、分支语句和逻辑运算符、函数重载和函数模板、
内存模型和名称空间、类的设计和使用、多态、虚函数、动态内存分配、继承、代码重用、友元、异常处理技术、string类和标准模板库、输入/输出、C 11新增功能等内容。 　　
    《C Primer Plus(第6版)中文版》针对C 初学者，书中从C语言基础知识开始介绍，然后在此基础上详细阐述C 新增的特性，因此不要求读者有C语言方面的背景知识。
本书可作为高等院校教授C 课程的教材，也可供初学者自学C 时使用。", "http://product.dangdang.com/22783504.html");

            AddBookListIfNotExists("科技", "科技...");
            AddBookListAndBookIfNotExists(10, 10);

            AddBookTagIfNotExists("C++", "#528ee9");
            AddBookTagIfNotExists("面向对象编程", "#2d95f5");
            AddBookTagIfNotExists("初学者自学C", "#f5234d");
            AddBookAndBookTagIfNotExists(10, 28);
            AddBookAndBookTagIfNotExists(10, 29);
            AddBookAndBookTagIfNotExists(10, 30);


            AddBookIfNotExists("Dear Zoo", "Rod Campbell", "http://img3m5.ddimg.cn/97/29/1330191025-1_w_6.jpg", "", "http://product.dangdang.com/1330191025.html");

            AddBookListIfNotExists("英文原版", "英文原版...");
            AddBookListAndBookIfNotExists(11, 11);


            AddBookIfNotExists("博物杂志", "中国国家地理少年版青少儿期刊", "http://img3m5.ddimg.cn/57/33/1097251905-1_w_15.jpg", "", "http://product.dangdang.com/1097251905.html");

            AddBookListIfNotExists("期刊", "期刊...");
            AddBookListAndBookIfNotExists(12, 12);

            AddBookTagIfNotExists("博物", "#528ee9");
            AddBookTagIfNotExists("期刊", "#2d95f5");
            AddBookAndBookTagIfNotExists(12, 31);
            AddBookAndBookTagIfNotExists(12, 32);

            
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

        private void AddBookTagIfNotExists(string name, string color = null, int? tenantId = null)
        {
            if (_context.BookTag.IgnoreQueryFilters().Any(s => s.Name == name))
            {
                return;
            }

            _context.BookTag.Add(new BookTag(name, color, tenantId));
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
