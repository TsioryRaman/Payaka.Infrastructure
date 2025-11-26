using Microsoft.EntityFrameworkCore;

namespace Payaka.Infrastructure.Database
{
    public class CoreDbContext : DbContext
    {
        #region Ctor

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #endregion
    }
}
