namespace AbpLearning.Application.CloudBookList.BookList.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Runtime.Validation;

    public class BookListPagedFilterAndSortedModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

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
