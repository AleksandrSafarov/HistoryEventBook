using HistoryEventBook.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HistoryEventBook.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HistoryEvent> HistoryEvents { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
