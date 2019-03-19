namespace AbpLearning.Application.Base
{
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    /// <summary>
    /// paged filtering base dto
    /// default sort：CreationTime DESC
    /// </summary>
    public class PagedFilteringDtoBase : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public PagedFilteringDtoBase()
        {
        }

        /// <summary>
        /// Filter Text
        /// </summary>
        public virtual string FilterText { get; set; }

        /// <summary>
        /// Normalize order
        /// default sort：CreationTime DESC
        /// </summary>
        public virtual void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "CreationTime DESC";
            }
        }
    }
}
