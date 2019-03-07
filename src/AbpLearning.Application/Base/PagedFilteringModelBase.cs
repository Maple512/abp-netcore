namespace AbpLearning.Application.Base
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    /// <summary>
    /// 分页过滤基类
    /// 默认排序方式：CreationTime DESC
    /// </summary>
    public abstract class PagedFilteringModelBase : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 分页过滤文本
        /// </summary>
        public string FilterText { get; set; }

        /// <summary>
        /// 初始化
        /// 默认排序方式：CreationTime DESC
        /// </summary>
        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "CreationTime DESC";
            }
        }
    }
}
