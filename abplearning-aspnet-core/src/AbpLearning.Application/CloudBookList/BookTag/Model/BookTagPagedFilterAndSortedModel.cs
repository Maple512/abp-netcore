namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Runtime.Validation;

    public class BookTagPagedFilterAndSortedModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 书签名
        /// </summary>
        public string Name { get; set; }

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
