namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.Collections.Generic;

    public class BookAndBookTagEditModel
    {
        public long BookId { get; set; }

        public IEnumerable<long> BookTagIds { get; set; }
    }
}
