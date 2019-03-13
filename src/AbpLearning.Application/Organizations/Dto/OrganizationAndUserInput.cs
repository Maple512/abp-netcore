namespace AbpLearning.Application.Organizations.Dto
{
    using System.Collections.Generic;

    public class OrganizationAndUserInput
    {
        public List<long> UserIds { get; set; }

        public long OrganizationId { get; set; }
    }
}
