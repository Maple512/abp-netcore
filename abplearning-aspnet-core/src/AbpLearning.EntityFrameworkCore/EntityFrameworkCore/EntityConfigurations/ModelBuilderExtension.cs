namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.EntityConfigurations
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtension
    {
        public static void ExecuteConfigurations(this ModelBuilder modelBuilder, string assemblyName)
        {
            var configurationTypes = Assembly.Load(new AssemblyName(assemblyName)).GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                .Where(type => type.GetTypeInfo().IsClass)
                .Where(type => type.GetTypeInfo().BaseType != null)
                .Where(type => typeof(IEntityTypeConfiguration).IsAssignableFrom(type))
                .ToList();

            foreach (var type in configurationTypes)
            {
                Activator.CreateInstance(type, modelBuilder);
            }
        }
    }
}
