namespace AbpLearning.Application.Organizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Users.Dto;
    using Base;
    using Dto;

    public interface IOrganizationAppService : ICrudAsyncAppService<long, OrganizationGetViewOutput, OrganizationGetPagedOutput, OrganizationGetPagedInput,
        OrganizationGetUpdateOutput, OrganizationCreateInput, OrganizationUpdateInput>
    {
        Task Move(OrganizationMoveInput input);

        Task<PagedResultDto<UserGetPagedOutput>> GetPagedForOrganizationUsers(OrganizationGetUserPagedInput input);

        /// <summary>
        /// add users from organization
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddUsersFromOrganization(OrganizationAndUserInput input);

        /// <summary>
        /// remove users from organization
        /// TODO:to do
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task RemoveUsersFromOrganization(OrganizationAndUserInput input);
    }
}
