namespace AbpLearning.Core.CloudBookLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Services;
    using Abp.Domain.Uow;
    using BookLiseCells.DomainService;
    using BookLists;
    using BookLists.DomainService;
    using Books.DomainService;
    using BookTags.DomainService;
    using Microsoft.EntityFrameworkCore;

    public class CloudBookListManager : DomainService, ICloudBookListManager
    {
        private readonly IBookTagDomainService _bookTag;
        private readonly IBookDomainService _book;
        private readonly IBookListCellDomainService _bookListCell;
        private readonly IBookListDomainService _bookList;

        public CloudBookListManager(
            IBookTagDomainService bookTag,
            IBookDomainService book,
            IBookListCellDomainService bookListCell,
            IBookListDomainService bookList)
        {
            _bookTag = bookTag;
            _book = book;
            _bookListCell = bookListCell;
            _bookList = bookList;
        }

        #region Book

        [UnitOfWork]
        public async Task DeleteForBookAsync(long bookId)
        {
            // tag
            await _bookTag.BatchDeleteForBookAsync(bookId);

            // book
            await _book.DeleteAsync(bookId);

            // cell
            await _bookListCell.BatchDeleteForBookAsync(bookId);
        }

        [UnitOfWork]
        public async Task BatchDeleteForBookAsync(List<long> bookIds)
        {
            // tag
            await _bookTag.BatchDeleteForBookAsync(bookIds);

            // book
            await _book.BatchDeleteAsync(bookIds);

            // cell
            await _bookListCell.BatchDeleteForBookAsync(bookIds);
        }

        public async Task<List<BookList>> GetBookListForBookAsync(long bookId)
        {
            // 书籍所在的格子
            var cells = await _bookListCell.GetForBookAsync(bookId);

            if (cells.Count > 0)
            {
                // 格子所在的书单
                var bookListIds = cells.Select(m => m.BookListId);

                return await _bookList.GetAll().Where(m => bookListIds.Contains(m.Id)).ToListAsync();
            }

            return null;
        }

        #endregion


    }
}
