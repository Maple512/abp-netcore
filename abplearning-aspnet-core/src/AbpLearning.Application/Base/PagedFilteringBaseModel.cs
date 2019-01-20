namespace AbpLearning.Application.Base
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    /// <summary>
    /// 分页模型基类
    /// </summary>
    /// <inheritdoc cref="PagedAndSortedResultRequestDto" />
    public abstract class PagedFilteringBaseModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 过滤字段
        /// </summary>
        public virtual string FilterText { get; set; }

        /// <summary>
        /// 正常化（不需调用）
        /// <code>
        /// Sorting（排序）：默认“Name"
        /// </code>
        /// </summary>
        /// <inheritdoc />
        public virtual void Normalize()
        {
            // 默认排序字段
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "Name";
            }
        }
    }
}
