using Microsoft.EntityFrameworkCore;
using Minimal_API.Models;

namespace Minimal_API.DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Produto> Produtos => Set<Produto>();
    }
}
