using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpLearning.Authorization.Roles;
using AbpLearning.Authorization.Users;
using AbpLearning.MultiTenancy;

namespace AbpLearning.EntityFrameworkCore
{
    public class AbpLearningDbContext : AbpZeroDbContext<Tenant, Role, User, AbpLearningDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpLearningDbContext(DbContextOptions<AbpLearningDbContext> options)
            : base(options)
        {
        }
    }
}
