namespace AbpLearning.Core.CloudBookLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Services;
    using Abp.Domain.Uow;
    using AbpLearning.Core.CloudBookLists.Books;
    using BookListCells.DomainService;
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

        /// <summary>
        /// 删除单个书籍
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task DeleteForBookAsync(long bookId)
        {
            // tag
            await _bookTag.BatchDeleteForBookAsync(bookId);

            // book
            await _book.DeleteAsync(bookId);
        }

        /// <summary>
        /// 删除多个书籍
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task BatchDeleteForBookAsync(List<long> bookIds)
        {
            // tag
            await _bookTag.BatchDeleteForBookAsync(bookIds);

            // book
            await _book.BatchDeleteAsync(bookIds);
        }

        /// <summary>
        /// 获取引用书籍的所有书单
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
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

        #region BookList

        /// <summary>
        /// 获取书单引用的所有书籍
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        public async Task<List<Book>> GetBookForBookListAsync(long bookListId)
        {
            // cell
            var cells = await _bookListCell.GetForBookListAsync(bookListId);

            if (cells.Count > 0)
            {
                // book
                var bookIds = cells.OrderBy(m => m.Sort).Select(m => m.BookId);
                var books = await _book.GetAll().Where(m => bookIds.Contains(m.Id))?.ToListAsync();
                return books;
            }

            return null;
        }

        /// <summary>
        /// 删除书单
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task DeleteForBookListAsync(long bookListId)
        {
            // cell
            await _bookListCell.BatchDeleteForBookListAsync(bookListId);

            // booklist
            await _bookList.DeleteAsync(bookListId);
        }

        /// <summary>
        /// 删除多个书单
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task BatchDeleteForBookListAsync(List<long> bookListIds)
        {
            // cell
            await _bookListCell.BatchDeleteForBookListAsync(bookListIds);

            // booklist
            await _bookList.BatchDeleteAsync(bookListIds);
        }

        #endregion
    }
}
