namespace AbpLearning.Application.CloudBookList.BookList.Model
{
    using System.Collections.Generic;

    public class BookListAndBookEditModel
    {
        public long BookListId { get; set; }

        public List<long> BookIds { get; set; }
    }
}
