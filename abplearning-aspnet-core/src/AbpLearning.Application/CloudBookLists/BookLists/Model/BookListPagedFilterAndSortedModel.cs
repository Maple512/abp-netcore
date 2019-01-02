namespace AbpLearning.Application.CloudBookLists.BookLists.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Runtime.Validation;

    public class BookListPagedFilterAndSortedModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string FilterText { get; set; }

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
