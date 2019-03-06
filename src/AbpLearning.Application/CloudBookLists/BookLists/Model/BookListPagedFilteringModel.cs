namespace AbpLearning.Application.CloudBookLists.BookLists.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;
    using AbpLearning.Core.CloudBookLists.BookLists;

    /// <summary>
    /// <see cref="BookList"/> 分页排序过滤模型
    /// </summary>
    public class BookListPagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书单名
        /// </summary>
        public string Name { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "Name";
            }
        }
    }
}
