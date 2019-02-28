namespace AbpLearning.Application.Files.Model
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    public class FileTypePagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 类型名
        /// </summary>
        public string Name { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "CreationTime Desc";
            }
        }
    }
}
