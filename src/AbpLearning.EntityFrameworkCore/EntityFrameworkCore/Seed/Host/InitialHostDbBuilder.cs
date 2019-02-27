namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly AbpLearningDbContext _context;

        public InitialHostDbBuilder(AbpLearningDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            // 云书单 初始数据
            new DefaultCloudBookListCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
