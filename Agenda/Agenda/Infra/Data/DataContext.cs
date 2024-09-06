using Agenda.Infra.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Contato> Contatos { get; set; }
    }
}
