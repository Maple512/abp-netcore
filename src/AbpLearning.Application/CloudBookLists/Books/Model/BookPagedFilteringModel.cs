namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;
    using AbpLearning.Core.CloudBookLists.Books;

    /// <summary>
    /// <see cref="Book"/> 分页过滤模型
    /// </summary>
    public class BookPagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书名
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
