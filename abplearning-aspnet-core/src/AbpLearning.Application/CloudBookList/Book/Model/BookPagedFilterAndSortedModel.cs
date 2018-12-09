namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Runtime.Validation;

    /// <summary>
    /// Book 分页过滤类
    /// </summary>
    public class BookPagedFilterAndSortedModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string FilterText { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        //public string Author { get; set; }

        public void Normalize()
        {
            // 默认排序字段
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Name";
            }
        }
    }
}
