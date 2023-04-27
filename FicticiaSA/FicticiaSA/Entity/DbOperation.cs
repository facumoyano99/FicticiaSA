using Microsoft.EntityFrameworkCore.Storage;

namespace FicticiaSA.Entity
{
    public class DbOperation: IDbOperation
    {
        private readonly ApplicationDbContext dbContext;

        public DbOperation(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Save()
        {
            try
            {
                return await dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveSync()
        {
            try
            {
                return dbContext.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
